using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Catheter : ESAPIX.Facade.API.ApiDataObject
    {
        public Catheter() { }
        public Catheter(dynamic client) { _client = client; }
        public System.Double ApplicatorLength
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ApplicatorLength; });
            }
        }
        public System.Int32 BrachySolidApplicatorPartID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.BrachySolidApplicatorPartID; });
            }
        }
        public System.Int32 ChannelNumber
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ChannelNumber; });
            }
        }
        public System.Windows.Media.Color Color
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
        }
        public ESAPIX.Facade.Types.VVector[] Shape
        {
            get
            {
                var local = this;
                return ArrayHelper.GenerateVVectorArray(local._client.Shape);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SourcePosition> SourcePositions
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.SourcePosition>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.SourcePositions).Select(s => new ESAPIX.Facade.API.SourcePosition(s));
                });
            }
        }
        public System.Double StepSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StepSize; });
            }
        }
        public ESAPIX.Facade.API.BrachyTreatmentUnit TreatmentUnit
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.BrachyTreatmentUnit(local._client.TreatmentUnit);
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
        public System.Double GetSourcePosCenterDistanceFromTip(ESAPIX.Facade.API.SourcePosition sourcePosition)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetSourcePosCenterDistanceFromTip(sourcePosition._client); });
            return retVal;

        }
        public System.Double GetTotalDwellTime()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetTotalDwellTime(); });
            return retVal;

        }
    }
}