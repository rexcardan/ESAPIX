#region

using System.Numerics;
using VMS.TPS.Common.Model.API;

#endregion

namespace ESAPIX.Extensions
{
    public static class ImageExtensions
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

        public static Vector3 MaxBounds(this Image im)
        {
            return new Vector3(
                (float)(im.Origin.x + ((im.XSize * im.XDirection)).x * im.XRes),
                (float)(im.Origin.y + ((im.YSize * im.YDirection)).y * im.YRes),
                (float)(im.Origin.z + ((im.ZSize * im.ZDirection)).z * im.ZRes));
        }

        /// <summary>
        /// Gets the plane representations for the boundries of the image volume. Useful for raytracing
        /// Coordinate system for planes is DICOM coordinate system
        /// </summary>
        /// <param name="im"></param>
        /// <returns>x1,x2,y1,y2,z1,z2</returns>
        public static Plane[] GetBoundingPlanes(this Image im)
        {
            var bounds = im.MaxBounds();
            var x1 = new Plane(im.XDirection.ToVector3(), (float)im.Origin.x);
            var x2 = new Plane(im.XDirection.ToVector3(), bounds.X);
            var y1 = new Plane(im.YDirection.ToVector3(), (float)im.Origin.y);
            var y2 = new Plane(im.YDirection.ToVector3(), bounds.Y);
            var z1 = new Plane(im.ZDirection.ToVector3(), (float)im.Origin.z);
            var z2 = new Plane(im.ZDirection.ToVector3(), bounds.Z);
            return new Plane[]
            {
                x1,x2,y1,y2,z1,z2
            };
        }
    }
}