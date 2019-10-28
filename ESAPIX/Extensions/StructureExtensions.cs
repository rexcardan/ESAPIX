#region

using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using ESAPIX.Constraints;
using System.Collections.Generic;
using ESAPIX.Constraints.DVH.Query;
using ESAPIX.Helpers;
using static ESAPIX.Helpers.Strings.MagicStrings;

#endregion

namespace ESAPIX.Extensions
{
    public static class StructureExtensions
    {
        /// <summary>
        ///     Returns the voxel HU from a given slice within a structure. Voxels outside the structure are NaN
        /// </summary>
        /// <param name="str">the structure</param>
        /// <param name="image">the image containing voxels</param>
        /// <param name="sliceZ">the slice of the image</param>
        /// <returns>display units of the image</returns>
        public static double[,] VoxelsOnSlice(this Structure str, Image image, int sliceZ)
        {
            var buffer = new int[image.XSize, image.YSize];
            var hu = new double[image.XSize, image.YSize];

            var contour = str.GetContoursOnImagePlane(sliceZ);
            if (contour.Count() > 0)
            {
                image.GetVoxels(sliceZ, buffer);
                for (var x = 0; x < image.XSize; x++)
                for (var y = 0; y < image.YSize; y++)
                {
                        var dx = (x * image.XRes * image.XDirection + image.Origin).x;
                        var dy = (y * image.YRes * image.YDirection + image.Origin).y;
                        var dz = (sliceZ * image.ZRes * image.ZDirection + image.Origin).z;
                        var insideSegment = str.IsPointInsideSegment(new VVector(dx, dy, dz));
                        hu[x, y] = insideSegment ? image.VoxelToDisplayValue(buffer[x, y]) : double.NaN;
                    }
            }
            return hu;
        }

        public static Dictionary<TargetStat, double> GetTargetStats(this Structure s, PlanningItem pi, DoseValue referenceDose, params TargetStat[] desiredStats)
        {
            Dictionary<TargetStat, double> stats = new Dictionary<TargetStat, double>();
            foreach(var ds in desiredStats)
            {
                switch (ds)
                {
                    case TargetStat.CONFORMITY_INDEX_RTOG: stats.Add(TargetStat.CONFORMITY_INDEX_RTOG, TargetStats.GetCI_RTOG(s, pi, referenceDose)); break;
                    case TargetStat.CONFORMITY_INDEX_PADDICK: stats.Add(TargetStat.CONFORMITY_INDEX_RTOG, TargetStats.GetCI_Paddick(s, pi, referenceDose)); break;
                }
            }
            return stats;
        }

        /// <summary>
        /// Writes the structure geometry to an .OBJ file for 3D applications
        /// </summary>
        /// <param name="s">the structure</param>
        /// <param name="objPath">the path to create the .OBJ file</param>
        public static void ToObjFile(this Structure s, string objPath)
        {
            ObjFileWriter.Write(s.MeshGeometry, objPath);
        }

        /// <summary>
        /// Copies a structure onto another structure within the z bounds of the input
        /// </summary>
        /// <param name="copy">the structure data will be copied into</param>
        /// <param name="toCopy">the structure from which we are copying</param>
        /// <param name="im">the image containing the contours</param>
        /// <param name="zBounds">the lower and upper bounds along the z axis where copying will occur</param>
        public static void CopyStructureInBounds(this Structure copy, Structure toCopy, Image im, (double LowerZBound, double UpperZBound) zBounds)
        {
            for (int z = 0; z < im.ZSize; z++)
            {
                var zPos = im.Origin.z + z * im.ZRes;
                if (zPos >= zBounds.LowerZBound && zPos <= zBounds.UpperZBound)
                {
                    copy.ClearAllContoursOnImagePlane(z);
                    var zContour = toCopy.GetContoursOnImagePlane(z);
                    zContour.ToList().ForEach(c => copy.AddContourOnImagePlane(c, z));
                }

            }
        }

        /// <summary>
        /// Returns the geometric midpoint of a structure (not the "Center" that ESAPI returns). Center
        /// is a weighted average of voxel position but midpoint doesn't use distribution of voxels to set
        /// </summary>
        /// <param name="str">the structure of which to find the midpoint</param>
        /// <returns>Returns the geometric midpoint of a structure</returns>
        public static VVector GetMidpoint(this Structure str)
        {
            if (str?.MeshGeometry == null) { return new VVector(double.NaN, double.NaN, double.NaN); }
            return new VVector(str.MeshGeometry.Bounds.X + str.MeshGeometry.Bounds.SizeX / 2,
                                                       str.MeshGeometry.Bounds.Y + str.MeshGeometry.Bounds.SizeY / 2,
                                                       str.MeshGeometry.Bounds.Z + str.MeshGeometry.Bounds.SizeZ / 2);
        }

        public static void ClearAllContours(this Structure str, Image im)
        {
            for (int z = 0; z < im.ZSize; z++)
            {
                str.ClearAllContoursOnImagePlane(z);
            }
        }

        /// <summary>
        /// Performs margin on structure ONLY in the bounds of the input, keeps original contour in
        /// all other Z coordinates
        /// </summary>
        /// <param name="baseStructure">base structure</param>
        /// <param name="margins">asymmetric margins to perform</param>
        /// <param name="ss">the structure set containing the structure</param>
        /// <param name="zBounds">the lower and upper bounds along the z axis where margin will occur</param>
        public static void AsymmetricMarginInBounds(this Structure baseStructure, AxisAlignedMargins margins, StructureSet ss, (double LowerZBound, double UpperZBound) zBounds)
        {
            var marginStr = ss.CreateStructureIfNotExists("tempAsMrg", DICOMType.CONTROL);
            marginStr.SegmentVolume = baseStructure.AsymmetricMargin(margins);

            for (int z = 0; z < ss.Image.ZSize; z++)
            {
                var zPos = ss.Image.Origin.z + z * ss.Image.ZRes;
                if (zPos >= zBounds.LowerZBound && zPos <= zBounds.UpperZBound)
                {
                    baseStructure.ClearAllContoursOnImagePlane(z);
                    var zContour = marginStr.GetContoursOnImagePlane(z);
                    zContour.ToList().ForEach(c => baseStructure.AddContourOnImagePlane(c, z));
                }
            }

            ss.RemoveStructure(marginStr);
        }

        /// <summary>
        /// Crops a structure and removes contours outside of the input z bounds
        /// </summary>
        /// <param name="baseStructure">base structure</param>
        /// <param name="im">the image containing the contours</param>
        /// <param name="zBounds">the lower and upper bounds along the z axis where copying will occur</param>
        public static void CropInBounds(this Structure baseStructure, Image im, (double LowerZBound, double UpperZBound) zBounds)
        {
            for (int z = 0; z < im.ZSize; z++)
            {
                var zPos = im.Origin.z + z * im.ZRes;
                if (zPos < zBounds.LowerZBound || zPos > zBounds.UpperZBound)
                {
                    baseStructure.ClearAllContoursOnImagePlane(z);
                }
            }
        }
    }
}