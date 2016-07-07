using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Proxies;
using ESAPIX.Types;

namespace ESAPIX.Extensions
{
    public static class StructureExtensions
    {
        public static double[,] VoxelsOnSlice(this IStructure str, IImage image, int sliceZ){
            int[,] buffer = new int[image.XSize, image.YSize];
            double[,] hu = new double[image.XSize, image.YSize];

            var contour = str.GetContoursOnImagePlane(sliceZ);
            if (contour.Count() > 0)
            {
                image.GetVoxels(sliceZ, buffer);
                for (int x = 0; x < image.XSize; x++)
                {
                    for (int y = 0; y < image.YSize; y++)
                    {
                        var dx = (x * image.XRes * image.XDirection + image.Origin).x;
                        var dy = (y * image.YRes * image.YDirection + image.Origin).y;
                        var dz = (sliceZ * image.ZRes * image.ZDirection + image.Origin).z;
                        var insideSegment = str.IsPointInsideSegment(new VVector(dx, dy, dz));
                        hu[x, y] = insideSegment ? image.VoxelToDisplayValue(buffer[x, y]): double.NaN;
                    }
                }
            }
            return hu;
        }
    }
}
