using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Media;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Catheter : ApiDataObject
    {
        public Catheter()
        {
            _client = new ExpandoObject();
        }

        public Catheter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public double ApplicatorLength
        {
            get
            {
                if (_client is ExpandoObject) return _client.ApplicatorLength;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.ApplicatorLength; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApplicatorLength = value;
            }
        }

        public int BrachySolidApplicatorPartID
        {
            get
            {
                if (_client is ExpandoObject) return _client.BrachySolidApplicatorPartID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc =>
                {
                    return local._client.BrachySolidApplicatorPartID;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.BrachySolidApplicatorPartID = value;
            }
        }

        public int ChannelNumber
        {
            get
            {
                if (_client is ExpandoObject) return _client.ChannelNumber;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ChannelNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ChannelNumber = value;
            }
        }

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject) return _client.Color;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Color>(sc => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public VVector[] Shape
        {
            get
            {
                if (_client is ExpandoObject) return _client.Shape;
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector[]>(sc =>
                {
                    return ArrayHelper.GenerateVVectorArray(local._client.Shape);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Shape = value;
            }
        }

        public IEnumerable<SourcePosition> SourcePositions
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.SourcePositions;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new SourcePosition();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public double StepSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.StepSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.StepSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StepSize = value;
            }
        }

        public BrachyTreatmentUnit TreatmentUnit
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentUnit;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.TreatmentUnit)) return default(BrachyTreatmentUnit);
                    return new BrachyTreatmentUnit(local._client.TreatmentUnit);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentUnit = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public double GetSourcePosCenterDistanceFromTip(SourcePosition sourcePosition)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetSourcePosCenterDistanceFromTip(sourcePosition._client);
            });
            return retVal;
        }

        public double GetTotalDwellTime()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetTotalDwellTime(); });
            return retVal;
        }
    }
}