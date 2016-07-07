using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ESAPIX.Interfaces
{
    public interface IVmsProxy
    {
        VmsComThread VmsThread { get; }
        dynamic VmsObject { get; }
    }
}
