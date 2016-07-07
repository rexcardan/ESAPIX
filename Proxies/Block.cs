using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Block : ApiDataObject, IBlock
    {
        public IAddOnMaterial AddOnMaterial
        {
            get
            {
                return Wrap<AddOnMaterial>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public ITray Tray { get; set; }

        public double TransmissionFactor { get; set; }

        public double TrayTransmissionFactor { get; set; }

        public BlockType Type { get; set; }

        public bool IsDiverging { get; set; }
    }
}