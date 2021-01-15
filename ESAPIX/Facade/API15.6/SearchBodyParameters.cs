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
    public class SearchBodyParameters : ESAPIX.Facade.API.SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Boolean FillAllCavities
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FillAllCavities"))
                    {
                        return _client.FillAllCavities;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.FillAllCavities;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.FillAllCavities = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.FillAllCavities = (value));
                }
            }
        }

        public System.Boolean KeepLargestParts
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("KeepLargestParts"))
                    {
                        return _client.KeepLargestParts;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.KeepLargestParts;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.KeepLargestParts = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.KeepLargestParts = (value));
                }
            }
        }

        public System.Int32 LowerHUThreshold
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("LowerHUThreshold"))
                    {
                        return _client.LowerHUThreshold;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.LowerHUThreshold;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.LowerHUThreshold = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.LowerHUThreshold = (value));
                }
            }
        }

        public System.Int32 MREdgeThresholdHigh
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MREdgeThresholdHigh"))
                    {
                        return _client.MREdgeThresholdHigh;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.MREdgeThresholdHigh;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MREdgeThresholdHigh = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.MREdgeThresholdHigh = (value));
                }
            }
        }

        public System.Int32 MREdgeThresholdLow
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MREdgeThresholdLow"))
                    {
                        return _client.MREdgeThresholdLow;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.MREdgeThresholdLow;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MREdgeThresholdLow = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.MREdgeThresholdLow = (value));
                }
            }
        }

        public System.Int32 NumberOfLargestPartsToKeep
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("NumberOfLargestPartsToKeep"))
                    {
                        return _client.NumberOfLargestPartsToKeep;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.NumberOfLargestPartsToKeep;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.NumberOfLargestPartsToKeep = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.NumberOfLargestPartsToKeep = (value));
                }
            }
        }

        public System.Boolean PreCloseOpenings
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PreCloseOpenings"))
                    {
                        return _client.PreCloseOpenings;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PreCloseOpenings;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PreCloseOpenings = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.PreCloseOpenings = (value));
                }
            }
        }

        public System.Double PreCloseOpeningsRadius
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PreCloseOpeningsRadius"))
                    {
                        return _client.PreCloseOpeningsRadius;
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
                        return _client.PreCloseOpeningsRadius;
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
                    _client.PreCloseOpeningsRadius = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.PreCloseOpeningsRadius = (value));
                }
            }
        }

        public System.Boolean PreDisconnect
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PreDisconnect"))
                    {
                        return _client.PreDisconnect;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.PreDisconnect;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.PreDisconnect = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.PreDisconnect = (value));
                }
            }
        }

        public System.Double PreDisconnectRadius
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("PreDisconnectRadius"))
                    {
                        return _client.PreDisconnectRadius;
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
                        return _client.PreDisconnectRadius;
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
                    _client.PreDisconnectRadius = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.PreDisconnectRadius = (value));
                }
            }
        }

        public System.Boolean Smoothing
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Smoothing"))
                    {
                        return _client.Smoothing;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Smoothing;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Smoothing = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.Smoothing = (value));
                }
            }
        }

        public System.Int32 SmoothingLevel
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SmoothingLevel"))
                    {
                        return _client.SmoothingLevel;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.SmoothingLevel;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.SmoothingLevel = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.SmoothingLevel = (value));
                }
            }
        }

        public void LoadDefaults()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.LoadDefaults();
                }

                );
            }
            else
            {
                _client.LoadDefaults();
            }
        }

        public SearchBodyParameters()
        {
            _client = (new ExpandoObject());
        }

        public SearchBodyParameters(dynamic client)
        {
            _client = (client);
        }
    }
}