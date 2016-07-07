using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Types;

namespace ESAPIX.Extensions
{
    public static class ImageExtensions
    {
        private static double[,] GetSliceHU(this IImage image, int sliceZ)
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
