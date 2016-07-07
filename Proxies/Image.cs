using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;
using ESAPIX.Types;


namespace ESAPIX.Proxies
{
    public class Image : ApiDataObject, IImage
    {
        public int XSize { get; set; }

        public int YSize { get; set; }

        public int ZSize { get; set; }

        public System.DateTime? CreationDateTime { get; set; }

        public double XRes { get; set; }

        public double YRes { get; set; }

        public double ZRes { get; set; }

        public VVector Origin { get; set; }

        public VVector XDirection { get; set; }

        public VVector YDirection { get; set; }

        public VVector ZDirection { get; set; }

        public string FOR { get; set; }

        public bool HasUserOrigin { get; set; }

        public VVector UserOrigin { get; set; }

        public string DisplayUnit { get; set; }

        public int Window { get; set; }

        public int Level { get; set; }

        public string ContrastBolusAgentIngredientName { get; set; }

        public PatientOrientation ImagingOrientation { get; set; }

        public bool IsProcessed { get; set; }

        public string UserOriginComments { get; set; }


        public void GetVoxels(int sliceZ, int[,] xyBuffer)
        {
            Invoke(MethodBase.GetCurrentMethod().Name, sliceZ, xyBuffer);
        }

        public double VoxelToDisplayValue(int voxel)
        {
            return InvokeAndWrap<double>(MethodBase.GetCurrentMethod().Name, voxel);
        }
    }
}