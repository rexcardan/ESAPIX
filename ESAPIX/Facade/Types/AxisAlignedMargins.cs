using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class AxisAlignedMargins
    {
        internal dynamic _client;

        public AxisAlignedMargins()
        {
            _client = new ExpandoObject();
        }

        public AxisAlignedMargins(dynamic client)
        {
            _client = client;
        }

        public AxisAlignedMargins(StructureMarginGeometry geometry, double x1, double y1, double z1, double x2,
            double y2, double z2)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructAxisAlignedMargins(geometry, x1, y1, z1, x2, y2, z2);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.Geometry = geometry;
                _client.X1 = x1;
                _client.Y1 = y1;
                _client.Z1 = z1;
                _client.X2 = x2;
                _client.Y2 = y2;
                _client.Z2 = z2;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);
        public StructureMarginGeometry Geometry => (StructureMarginGeometry) _client.Geometry;
        public double X1 => _client.X1;
        public double Y1 => _client.Y1;
        public double Z1 => _client.Z1;
        public double X2 => _client.X2;
        public double Y2 => _client.Y2;
        public double Z2 => _client.Z2;

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }
    }
}