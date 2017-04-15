using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachyTreatmentUnit : ESAPIX.Facade.API.ApiDataObject
    {
        public BrachyTreatmentUnit() { }
        public BrachyTreatmentUnit(dynamic client) { _client = client; }
        public System.String DoseRateMode
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DoseRateMode; });
            }
        }
        public System.Double DwellTimeResolution
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DwellTimeResolution; });
            }
        }
        public System.String MachineInterface
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineInterface; });
            }
        }
        public System.String MachineModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineModel; });
            }
        }
        public System.Double MaxDwellTimePerChannel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerChannel; });
            }
        }
        public System.Double MaxDwellTimePerPos
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerPos; });
            }
        }
        public System.Double MaxDwellTimePerTreatment
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaxDwellTimePerTreatment; });
            }
        }
        public System.Double MaximumChannelLength
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaximumChannelLength; });
            }
        }
        public System.Int32 MaximumDwellPositionsPerChannel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.MaximumDwellPositionsPerChannel; });
            }
        }
        public System.Double MaximumStepSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaximumStepSize; });
            }
        }
        public System.Double MinimumChannelLength
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MinimumChannelLength; });
            }
        }
        public System.Double MinimumStepSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MinimumStepSize; });
            }
        }
        public System.Int32 NumberOfChannels
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.NumberOfChannels; });
            }
        }
        public System.Double SourceCenterOffsetFromTip
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SourceCenterOffsetFromTip; });
            }
        }
        public System.String SourceMovementType
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SourceMovementType; });
            }
        }
        public System.Double StepSizeResolution
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StepSizeResolution; });
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