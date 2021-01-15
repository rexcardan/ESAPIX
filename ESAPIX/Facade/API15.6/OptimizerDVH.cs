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
    public class OptimizerDVH
    {
        internal dynamic _client;

        public VMS.TPS.Common.Model.Types.DVHPoint[] CurveData
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CurveData"))
                    {
                        return _client.CurveData;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.DVHPoint[]);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CurveData;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.DVHPoint[]);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CurveData = (value);
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

        public OptimizerDVH()
        {
            _client = (new ExpandoObject());
        }

        public OptimizerDVH(dynamic client)
        {
            _client = (client);
        }
    }
}