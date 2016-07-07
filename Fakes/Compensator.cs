using System;
using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class Compensator : ApiDataObject, ICompensator
    {
        public ITray Tray
        {
            get;
            set; 
        }

        public ISlot Slot
        {
            get;
            set; 
        }

        public IAddOnMaterial Material
        {
            get;
            set; 
        }
    }
}