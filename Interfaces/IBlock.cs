using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;

namespace ESAPIX.Interfaces
{
    public interface IBlock : IApiDataObject
    {
        IAddOnMaterial AddOnMaterial { get; }

        ITray Tray { get; }

        double TransmissionFactor { get; }

        double TrayTransmissionFactor { get; }

        BlockType Type { get; }

        bool IsDiverging { get; }
    }
}
