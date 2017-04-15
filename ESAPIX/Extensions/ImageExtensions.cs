using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Facade.API;

namespace ESAPIX.Extensions
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Gets an array of Hounsfield units for the given slice z
        /// </summary>
        /// <param name="image">the image to sample</param>
        /// <param name="sliceZ">the slice of the sample</param>
        /// <returns>a 2D (x,y) array of Hounsfield units</returns>
        private static double[,] GetSliceHU(this Image image, int sliceZ)
        {
            int[,] buffer = new int[image.XSize, image.YSize];
            double[,] hu = new double[image.XSize, image.YSize];
            image.GetVoxels(sliceZ, buffer);
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; i < buffer.GetLength(1); j++)
                {
                    hu[i, j] = image.VoxelToDisplayValue(buffer[i, j]);
                }
            }
            return hu;
        }
    }
}
