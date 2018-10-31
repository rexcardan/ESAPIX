#region

using System.Linq;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;
using ESAPIX.Constraints;
using System.Collections.Generic;
using ESAPIX.Constraints.DVH.Query;
using ESAPIX.Helpers;

#endregion

namespace ESAPIX.Extensions
{
    public static class FStructureExtensions
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
    }
}