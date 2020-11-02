using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class EvaluationDose : ESAPIX.Facade.API.Dose, System.Xml.Serialization.IXmlSerializable
    {
        public System.Int32 DoseValueToVoxel(VMS.TPS.Common.Model.Types.DoseValue doseValue)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.DoseValueToVoxel(doseValue));
                    if (fromClient.Equals(default (System.Int32)))
                    {
                        return default (System.Int32);
                    }

                    return (System.Int32)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Int32)(_client.DoseValueToVoxel(doseValue));
            }
        }

        public void SetVoxels(System.Int32 planeIndex, System.Int32[,] values)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetVoxels(planeIndex, values);
                }

                );
            }
            else
            {
                _client.SetVoxels(planeIndex, values);
            }
        }

        public EvaluationDose()
        {
            _client = (new ExpandoObject());
        }

        public EvaluationDose(dynamic client)
        {
            _client = (client);
        }
    }
}