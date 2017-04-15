using System;
using System.Collections.Generic;

namespace ESAPIX.Facade.Types
{
    public enum CalculationType
    {
        PhotonVolumeDose,
        PhotonSRSDose,
        PhotonIMRTOptimization,
        PhotonVMATOptimization,
        PhotonLeafMotions,
        ProtonVolumeDose,
        DVHEstimation
    }
}