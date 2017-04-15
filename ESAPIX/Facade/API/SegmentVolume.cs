using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SegmentVolume : ESAPIX.Facade.API.SerializableObject
    {
        public SegmentVolume() { }
        public SegmentVolume(dynamic client) { _client = client; }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.SegmentVolume And(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.And(other._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume AsymmetricMargin(ESAPIX.Facade.Types.AxisAlignedMargins margins)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.AsymmetricMargin(margins._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Margin(System.Double marginInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Margin(marginInMM)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Not()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Not()); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Or(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Or(other._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Sub(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Sub(other._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Xor(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Xor(other._client)); });
            return retVal;

        }
    }
}