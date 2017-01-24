using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Query
{
    public enum QueryType
    {
        VOLUME_AT_DOSE,
        COMPLIMENT_VOLUME,
        DOSE_AT_VOLUME,
        DOSE_COMPLIMENT,
        MEAN_DOSE,
        MIN_DOSE,
        MAX_DOSE
    }
}
