using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IControlPoint
    {
        double MetersetWeight { get; }

        float[,] LeafPositions { get; }

        VRect<double> JawPositions { get; }

        double CollimatorAngle { get; }

        double GantryAngle { get; }

        double PatientSupportAngle { get; }
    }
}
