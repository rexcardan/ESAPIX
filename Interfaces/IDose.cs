using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
     public interface IDose : IApiDataObject
    {
         IEnumerable<IIsodose> Isodoses { get; }

         DoseValue DoseMax3D { get; }

         VVector DoseMax3DLocation { get; }

         int XSize { get; }

         int YSize { get; }

         int ZSize { get; }

         double XRes { get; }

         double YRes { get; }

         double ZRes { get; }

         VVector Origin { get; }

         VVector XDirection { get; }

         VVector YDirection { get; }

         VVector ZDirection { get; }
    }
}
