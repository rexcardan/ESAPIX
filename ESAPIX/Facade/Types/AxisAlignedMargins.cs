#region

using System;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

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
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructAxisAlignedMargins(geometry, x1, y1, z1, x2, y2, z2);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public StructureMarginGeometry Geometry
        {
            get { return (StructureMarginGeometry) _client.Geometry; }
        }

        public double X1
        {
            get { return _client.X1; }
        }

        public double Y1
        {
            get { return _client.Y1; }
        }

        public double Z1
        {
            get { return _client.Z1; }
        }

        public double X2
        {
            get { return _client.X2; }
        }

        public double Y2
        {
            get { return _client.Y2; }
        }

        public double Z2
        {
            get { return _client.Z2; }
        }

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }
    }
}