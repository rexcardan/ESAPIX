using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IImage : IApiDataObject
    {
        int XSize { get; set; }

        DateTime? CreationDateTime { get; set; }

        int YSize { get; set; }

        int ZSize { get; set; }
        double XRes { get; set; }

        double YRes { get; set; }

        double ZRes { get; set; }

        VVector Origin { get; set; }

        VVector XDirection { get; set; }

        VVector YDirection { get; set; }

        VVector ZDirection { get; set; }

        string FOR { get; set; }

        bool HasUserOrigin { get; set; }

        VVector UserOrigin { get; set; }

        string DisplayUnit { get; set; }

        int Window { get; set; }

        int Level { get; set; }

        string ContrastBolusAgentIngredientName { get; set; }

        PatientOrientation ImagingOrientation { get; set; }

        bool IsProcessed { get; set; }

        string UserOriginComments { get; set; }

        void GetVoxels(int sliceZ, int[,] xyBuffer);

        double VoxelToDisplayValue(int voxel);
    }
}
