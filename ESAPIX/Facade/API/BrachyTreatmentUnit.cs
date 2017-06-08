#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BrachyTreatmentUnit : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public BrachyTreatmentUnit()
        {
            _client = new ExpandoObject();
        }

        public BrachyTreatmentUnit(dynamic client)
        {
            _client = client;
        }

        public string DoseRateMode
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseRateMode"))
                        return _client.DoseRateMode;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DoseRateMode; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseRateMode = value;
            }
        }

        public double DwellTimeResolution
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DwellTimeResolution"))
                        return _client.DwellTimeResolution;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DwellTimeResolution; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DwellTimeResolution = value;
            }
        }

        public string MachineInterface
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MachineInterface"))
                        return _client.MachineInterface;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MachineInterface; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MachineInterface = value;
            }
        }

        public string MachineModel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MachineModel"))
                        return _client.MachineModel;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MachineModel; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MachineModel = value;
            }
        }

        public double MaxDwellTimePerChannel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaxDwellTimePerChannel"))
                        return _client.MaxDwellTimePerChannel;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaxDwellTimePerChannel; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaxDwellTimePerChannel = value;
            }
        }

        public double MaxDwellTimePerPos
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaxDwellTimePerPos"))
                        return _client.MaxDwellTimePerPos;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaxDwellTimePerPos; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaxDwellTimePerPos = value;
            }
        }

        public double MaxDwellTimePerTreatment
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaxDwellTimePerTreatment"))
                        return _client.MaxDwellTimePerTreatment;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaxDwellTimePerTreatment; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaxDwellTimePerTreatment = value;
            }
        }

        public double MaximumChannelLength
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaximumChannelLength"))
                        return _client.MaximumChannelLength;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaximumChannelLength; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaximumChannelLength = value;
            }
        }

        public int MaximumDwellPositionsPerChannel
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaximumDwellPositionsPerChannel"))
                        return _client.MaximumDwellPositionsPerChannel;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaximumDwellPositionsPerChannel; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaximumDwellPositionsPerChannel = value;
            }
        }

        public double MaximumStepSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaximumStepSize"))
                        return _client.MaximumStepSize;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaximumStepSize; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaximumStepSize = value;
            }
        }

        public double MinimumChannelLength
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MinimumChannelLength"))
                        return _client.MinimumChannelLength;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MinimumChannelLength; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MinimumChannelLength = value;
            }
        }

        public double MinimumStepSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MinimumStepSize"))
                        return _client.MinimumStepSize;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MinimumStepSize; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MinimumStepSize = value;
            }
        }

        public int NumberOfChannels
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NumberOfChannels"))
                        return _client.NumberOfChannels;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NumberOfChannels; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NumberOfChannels = value;
            }
        }

        public double SourceCenterOffsetFromTip
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SourceCenterOffsetFromTip"))
                        return _client.SourceCenterOffsetFromTip;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SourceCenterOffsetFromTip; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SourceCenterOffsetFromTip = value;
            }
        }

        public string SourceMovementType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SourceMovementType"))
                        return _client.SourceMovementType;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SourceMovementType; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SourceMovementType = value;
            }
        }

        public double StepSizeResolution
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StepSizeResolution"))
                        return _client.StepSizeResolution;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StepSizeResolution; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StepSizeResolution = value;
            }
        }

        public RadioactiveSource GetActiveRadioactiveSource()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new RadioactiveSource(_client.GetActiveRadioactiveSource());
                    }
                );
                return vmsResult;
            }
            return _client.GetActiveRadioactiveSource();
        }
    }
}