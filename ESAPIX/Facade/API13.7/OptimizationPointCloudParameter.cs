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
    public class OptimizationPointCloudParameter : ESAPIX.Facade.API.OptimizationParameter, System.Xml.Serialization.IXmlSerializable
    {
        public System.Double PointResolutionInMM
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PointResolutionInMM"))
                    {
                        return _client.PointResolutionInMM;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PointResolutionInMM;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PointResolutionInMM = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Structure"))
                    {
                        return _client.Structure;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Structure);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Structure) != (null))
                        {
                            return new ESAPIX.Facade.API.Structure(_client.Structure);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.Structure);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Structure = (value);
                }
                else
                {
                }
            }
        }

        public OptimizationPointCloudParameter()
        {
            _client = (new ExpandoObject());
        }

        public OptimizationPointCloudParameter(dynamic client)
        {
            _client = (client);
        }
    }
}