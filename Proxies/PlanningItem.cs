using System;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class PlanningItem : ApiDataObject, IPlanningItem
    {
        public DateTime? CreationDateTime { get; set; }

        public IDose Dose
        {
            get
            {
                return Wrap<Dose>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public DoseValuePresentation DoseValuePresentation { get; set; }

        public IDVHData GetDVHCumulativeData(IStructure structure, DoseValuePresentation dosePresentation,
            VolumePresentation volumePresentation, double binWidth)
        {
            if(!(structure is VMSProxy)){throw new ArgumentException("The structure must be a VMSProxy object");}
            return InvokeAndWrap<DVHData>(MethodBase.GetCurrentMethod().Name, structure, dosePresentation, volumePresentation, binWidth);
        }
    }
}