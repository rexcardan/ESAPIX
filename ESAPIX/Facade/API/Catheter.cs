using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Catheter : ESAPIX.Facade.API.ApiDataObject
    {
        public Catheter() { _client = new ExpandoObject(); }
        public Catheter(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double ApplicatorLength
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ApplicatorLength; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ApplicatorLength; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApplicatorLength = value; }
            }
        }
        public System.Int32 BrachySolidApplicatorPartID
        {
            get
            {
                if (_client is ExpandoObject) { return _client.BrachySolidApplicatorPartID; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.BrachySolidApplicatorPartID; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.BrachySolidApplicatorPartID = value; }
            }
        }
        public System.Int32 ChannelNumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ChannelNumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ChannelNumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ChannelNumber = value; }
            }
        }
        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Color; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Color = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector[] Shape
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Shape; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector[]>((sc) => { return ArrayHelper.GenerateVVectorArray(local._client.Shape); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Shape = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SourcePosition> SourcePositions
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.SourcePositions;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.SourcePosition();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.Double StepSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StepSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StepSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StepSize = value; }
            }
        }
        public ESAPIX.Facade.API.BrachyTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentUnit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.BrachyTreatmentUnit>((sc) => { return new ESAPIX.Facade.API.BrachyTreatmentUnit(local._client.TreatmentUnit); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentUnit = value; }
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