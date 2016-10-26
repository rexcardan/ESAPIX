using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Query
{
    public class MayoConstraint
    {
        public MayoQuery Query { get; set; }
        public Discriminator Discriminator { get; set; }
        public double ConstraintValue { get; set; }
    }
}
