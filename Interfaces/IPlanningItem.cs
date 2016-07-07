using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;

namespace ESAPIX.Interfaces
{
    public interface IPlanningItem : IApiDataObject
    {
        DateTime? CreationDateTime { get; }

        IDose Dose { get; }

        DoseValuePresentation DoseValuePresentation { get; }

        IDVHData GetDVHCumulativeData(IStructure structure, DoseValuePresentation dosePresentation, VolumePresentation volumePresentation, double binWidth);
    }
}
