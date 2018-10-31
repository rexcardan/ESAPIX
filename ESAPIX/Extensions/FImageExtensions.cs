#region

using ESAPIX.Facade.API;

#endregion

namespace ESAPIX.Extensions
{
    public static class FImageExtensions
    {
        /// <summary>
        ///     Gets an array of Hounsfield units for the given slice z
        /// </summary>
        /// <param name="image">the image to sample</param>
        /// <param name="sliceZ">the slice of the sample</param>
        /// <returns>a 2D (x,y) array of Hounsfield units</returns>
        private static double[,] GetSliceHU(this Image image, int sliceZ)
        {
            var buffer = new int[image.XSize, image.YSize];
            var hu = new double[image.XSize, image.YSize];
            image.GetVoxels(sliceZ, buffer);
            for (var i = 0; i < buffer.GetLength(0); i++)
            for (var j = 0; i < buffer.GetLength(1); j++)
                hu[i, j] = image.VoxelToDisplayValue(buffer[i, j]);
            return hu;
        }
    }
}