#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class SegmentProfilePoint
    {
        internal dynamic _client;

        public SegmentProfilePoint()
        {
            _client = new ExpandoObject();
        }

        public SegmentProfilePoint(dynamic client)
        {
            _client = client;
        }

        public SegmentProfilePoint(VVector position, bool value)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructSegmentProfilePoint(position, value);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Position = position;
                _client.Value = value;
            }
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public VVector Position
        {
            get
            {
                if (_client is ExpandoObject) return _client.Position;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Position)) return default(VVector);
                    return new VVector(local._client.Position);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Position = value;
            }
        }

        public bool Value
        {
            get
            {
                if (_client is ExpandoObject) return _client.Value;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.Value; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Value = value;
            }
        }
    }
}