#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public double ApplicatorLength
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ApplicatorLength")
                        ? _client.ApplicatorLength
                        : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("BrachySolidApplicatorPartID")
                        ? _client.BrachySolidApplicatorPartID
                        : default(int);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ChannelNumber")
                        ? _client.ChannelNumber
                        : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ChannelNumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ChannelNumber = value;
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Color")
                        ? _client.Color
                        : default(System.Windows.Media.Color);
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>(sc =>
                {
                    return local._client.Color;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public Types.VVector[] Shape
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Shape") ? _client.Shape : default(Types.VVector[]);
                var local = this;
                return X.Instance.CurrentContext.GetValue<Types.VVector[]>(sc =>
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StepSize") ? _client.StepSize : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("TreatmentUnit")
                        ? _client.TreatmentUnit
                        : default(BrachyTreatmentUnit);
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

        public void WriteXml(System.Xml.XmlWriter writer)
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