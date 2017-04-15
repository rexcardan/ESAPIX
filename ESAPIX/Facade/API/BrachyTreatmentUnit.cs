using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachyTreatmentUnit : ESAPIX.Facade.API.ApiDataObject
    {
        public BrachyTreatmentUnit() { _client = new ExpandoObject(); }
        public BrachyTreatmentUnit(dynamic client) { _client = client; }
        public System.String DoseRateMode
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DoseRateMode; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DoseRateMode; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DoseRateMode = value; }
            }
        }
        public System.Double DwellTimeResolution
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DwellTimeResolution; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DwellTimeResolution; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DwellTimeResolution = value; }
            }
        }
        public System.String MachineInterface
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineInterface; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineInterface; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineInterface = value; }
            }
        }
        public System.String MachineModel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineModel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineModel = value; }
            }
        }
        public System.Double MaxDwellTimePerChannel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaxDwellTimePerChannel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerChannel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaxDwellTimePerChannel = value; }
            }
        }
        public System.Double MaxDwellTimePerPos
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaxDwellTimePerPos; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerPos; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaxDwellTimePerPos = value; }
            }
        }
        public System.Double MaxDwellTimePerTreatment
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaxDwellTimePerTreatment; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerTreatment; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaxDwellTimePerTreatment = value; }
            }
        }
        public System.Double MaximumChannelLength
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaximumChannelLength; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaximumChannelLength; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaximumChannelLength = value; }
            }
        }
        public System.Int32 MaximumDwellPositionsPerChannel
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaximumDwellPositionsPerChannel; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.MaximumDwellPositionsPerChannel; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaximumDwellPositionsPerChannel = value; }
            }
        }
        public System.Double MaximumStepSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaximumStepSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaximumStepSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaximumStepSize = value; }
            }
        }
        public System.Double MinimumChannelLength
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MinimumChannelLength; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MinimumChannelLength; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MinimumChannelLength = value; }
            }
        }
        public System.Double MinimumStepSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MinimumStepSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MinimumStepSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MinimumStepSize = value; }
            }
        }
        public System.Int32 NumberOfChannels
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfChannels; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfChannels; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfChannels = value; }
            }
        }
        public System.Double SourceCenterOffsetFromTip
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SourceCenterOffsetFromTip; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SourceCenterOffsetFromTip; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SourceCenterOffsetFromTip = value; }
            }
        }
        public System.String SourceMovementType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SourceMovementType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SourceMovementType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SourceMovementType = value; }
            }
        }
        public System.Double StepSizeResolution
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StepSizeResolution; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StepSizeResolution; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StepSizeResolution = value; }
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.RadioactiveSource GetActiveRadioactiveSource()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.RadioactiveSource(local._client.GetActiveRadioactiveSource()); });
            return retVal;

        }
    }
}