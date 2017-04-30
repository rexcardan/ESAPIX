using System;
using System.Collections.Generic;
using System.Collections;

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