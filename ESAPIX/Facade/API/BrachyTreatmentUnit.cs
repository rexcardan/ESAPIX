#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BrachyTreatmentUnit : ApiDataObject
    {
        public BrachyTreatmentUnit()
        {
            _client = new ExpandoObject();
        }

        public BrachyTreatmentUnit(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string DoseRateMode
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseRateMode;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.DoseRateMode; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseRateMode = value;
            }
        }

        public double DwellTimeResolution
        {
            get
            {
                if (_client is ExpandoObject) return _client.DwellTimeResolution;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.DwellTimeResolution; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DwellTimeResolution = value;
            }
        }

        public string MachineInterface
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineInterface;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MachineInterface; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineInterface = value;
            }
        }

        public string MachineModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MachineModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineModel = value;
            }
        }

        public double MaxDwellTimePerChannel
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaxDwellTimePerChannel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(
                    sc => { return local._client.MaxDwellTimePerChannel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaxDwellTimePerChannel = value;
            }
        }

        public double MaxDwellTimePerPos
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaxDwellTimePerPos;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MaxDwellTimePerPos; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaxDwellTimePerPos = value;
            }
        }

        public double MaxDwellTimePerTreatment
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaxDwellTimePerTreatment;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.MaxDwellTimePerTreatment;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaxDwellTimePerTreatment = value;
            }
        }

        public double MaximumChannelLength
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaximumChannelLength;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MaximumChannelLength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaximumChannelLength = value;
            }
        }

        public int MaximumDwellPositionsPerChannel
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaximumDwellPositionsPerChannel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc =>
                {
                    return local._client.MaximumDwellPositionsPerChannel;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaximumDwellPositionsPerChannel = value;
            }
        }

        public double MaximumStepSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.MaximumStepSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MaximumStepSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MaximumStepSize = value;
            }
        }

        public double MinimumChannelLength
        {
            get
            {
                if (_client is ExpandoObject) return _client.MinimumChannelLength;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MinimumChannelLength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MinimumChannelLength = value;
            }
        }

        public double MinimumStepSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.MinimumStepSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.MinimumStepSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MinimumStepSize = value;
            }
        }

        public int NumberOfChannels
        {
            get
            {
                if (_client is ExpandoObject) return _client.NumberOfChannels;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.NumberOfChannels; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfChannels = value;
            }
        }

        public double SourceCenterOffsetFromTip
        {
            get
            {
                if (_client is ExpandoObject) return _client.SourceCenterOffsetFromTip;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc =>
                {
                    return local._client.SourceCenterOffsetFromTip;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceCenterOffsetFromTip = value;
            }
        }

        public string SourceMovementType
        {
            get
            {
                if (_client is ExpandoObject) return _client.SourceMovementType;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SourceMovementType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SourceMovementType = value;
            }
        }

        public double StepSizeResolution
        {
            get
            {
                if (_client is ExpandoObject) return _client.StepSizeResolution;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StepSizeResolution; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StepSizeResolution = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public RadioactiveSource GetActiveRadioactiveSource()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new RadioactiveSource(local._client.GetActiveRadioactiveSource());
            });
            return retVal;
        }
    }
}