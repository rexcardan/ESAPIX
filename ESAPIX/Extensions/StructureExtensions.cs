#region

using System.Linq;
using ESAPIX.Facade.API;

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
        /// <returns></returns>
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
                    //var dx = (x * image.XRes * image.XDirection + image.Origin).x;
                    //var dy = (y * image.YRes * image.YDirection + image.Origin).y;
                    ////var dz = (sliceZ * image.ZRes * image.ZDirection + image.Origin).z;
                    //var insideSegment = str.IsPointInsideSegment(new VVector(dx, dy, dz));
                    //hu[x, y] = insideSegment ? image.VoxelToDisplayValue(buffer[x, y]): double.NaN;
                }
            }
            return hu;
        }
    }
}