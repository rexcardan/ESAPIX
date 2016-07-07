using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Types
{
    public struct DVHPoint
    {
        public DoseValue DoseValue { get; private set; }

        public double Volume { get; private set; }

        public string VolumeUnit { get; private set; }

        public DVHPoint(DoseValue dose, double volume, string volumeUnit)
        {
            this = new DVHPoint();
            this.DoseValue = dose;
            this.Volume = volume;
            this.VolumeUnit = volumeUnit;
        }
    }
}
