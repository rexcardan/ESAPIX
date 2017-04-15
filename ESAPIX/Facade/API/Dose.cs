using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Dose : ESAPIX.Facade.API.ApiDataObject
    {
        public Dose() { }
        public Dose(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.DoseValue DoseMax3D
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.DoseMax3D);
            }
        }
        public ESAPIX.Facade.Types.VVector DoseMax3DLocation
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.DoseMax3DLocation);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Isodose> Isodoses
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Isodose>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Isodoses).Select(s => new ESAPIX.Facade.API.Isodose(s));
                });
            }
        }
        public ESAPIX.Facade.Types.VVector Origin
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Origin);
            }
        }
        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Series(local._client.Series);
            }
        }
        public System.String SeriesUID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SeriesUID; });
            }
        }
        public System.String UID
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UID; });
            }
        }
        public ESAPIX.Facade.Types.VVector XDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.XDirection);
            }
        }
        public System.Double XRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.XRes; });
            }
        }
        public System.Int32 XSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.XSize; });
            }
        }
        public ESAPIX.Facade.Types.VVector YDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.YDirection);
            }
        }
        public System.Double YRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.YRes; });
            }
        }
        public System.Int32 YSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.YSize; });
            }
        }
        public ESAPIX.Facade.Types.VVector ZDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.ZDirection);
            }
        }
        public System.Double ZRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ZRes; });
            }
        }
        public System.Int32 ZSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ZSize; });
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
        public ESAPIX.Facade.Types.DoseProfile GetDoseProfile(ESAPIX.Facade.Types.VVector start, ESAPIX.Facade.Types.VVector stop, System.Double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.DoseProfile(local._client.GetDoseProfile(start._client, stop._client, preallocatedBuffer)); });
            return retVal;

        }
        public ESAPIX.Facade.Types.DoseValue GetDoseToPoint(ESAPIX.Facade.Types.VVector at)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.GetDoseToPoint(at._client)); });
            return retVal;

        }
        public void GetVoxels(System.Int32 planeIndex, System.Int32[,] preallocatedBuffer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.GetVoxels(planeIndex, preallocatedBuffer);
            });

        }
        public void SetVoxels(System.Int32 planeIndex, System.Int32[,] values)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetVoxels(planeIndex, values);
            });

        }
        public ESAPIX.Facade.Types.DoseValue VoxelToDoseValue(System.Int32 voxelValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.VoxelToDoseValue(voxelValue)); });
            return retVal;

        }
    }
}