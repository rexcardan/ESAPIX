using System;
using System.Reflection;
using ESAPIX.Enums;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class Block : ApiDataObject, IBlock
    {
        public IAddOnMaterial AddOnMaterial
        {
            get;
            set; 
        }

        public ITray Tray { get; set; }

        public double TransmissionFactor { get; set; }

        public double TrayTransmissionFactor { get; set; }

        public BlockType Type { get; set; }

        public bool IsDiverging { get; set; }
    }
}