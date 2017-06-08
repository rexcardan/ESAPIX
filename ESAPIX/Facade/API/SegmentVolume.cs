#region

using System.Dynamic;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class SegmentVolume : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public SegmentVolume()
        {
            _client = new ExpandoObject();
        }

        public SegmentVolume(dynamic client)
        {
            _client = client;
        }

        public SegmentVolume And(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.And(other)); }
                );
                return vmsResult;
            }
            return _client.And(other);
        }

        public SegmentVolume AsymmetricMargin(AxisAlignedMargins margins)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new SegmentVolume(_client.AsymmetricMargin(margins));
                    }
                );
                return vmsResult;
            }
            return _client.AsymmetricMargin(margins);
        }

        public SegmentVolume Margin(double marginInMM)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Margin(marginInMM)); }
                );
                return vmsResult;
            }
            return _client.Margin(marginInMM);
        }

        public SegmentVolume Not()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return new SegmentVolume(_client.Not()); }
                );
                return vmsResult;
            }
            return _client.Not();
        }

        public SegmentVolume Or(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Or(other)); }
                );
                return vmsResult;
            }
            return _client.Or(other);
        }

        public SegmentVolume Sub(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Sub(other)); }
                );
                return vmsResult;
            }
            return _client.Sub(other);
        }

        public SegmentVolume Xor(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Xor(other)); }
                );
                return vmsResult;
            }
            return _client.Xor(other);
        }
    }
}