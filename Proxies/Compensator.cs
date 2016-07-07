using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class Compensator : ApiDataObject, ICompensator
    {
        public ITray Tray
        {
            get
            {
                return Wrap<Tray>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public ISlot Slot
        {
            get
            {
                return Wrap<Slot>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IAddOnMaterial Material
        {
            get
            {
                return Wrap<AddOnMaterial>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}