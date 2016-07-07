using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IApiDataObject
    {
        string Id { get; }

        string Name { get; }

        string Comment { get; }

        string HistoryUserName { get; }

        DateTime HistoryDateTime { get; }
    }
}
