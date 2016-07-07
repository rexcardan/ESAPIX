using System;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class PlanningItem : ApiDataObject, IPlanningItem
    {
        public DateTime? CreationDateTime { get; set; }

        public IDose Dose
        {
            get;
            set; 
        }

        public DoseValuePresentation DoseValuePresentation { get; set; }

        public IDVHData GetDVHCumulativeData(IStructure structure, DoseValuePresentation dosePresentation,
            VolumePresentation volumePresentation, double binWidth)
        {
            throw new NotImplementedException();
        }
    }
}