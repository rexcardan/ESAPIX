using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Dose : ApiDataObject
    {
        public Dose()
        {
            _client = new ExpandoObject();
        }

        public Dose(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DoseValue DoseMax3D
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseMax3D;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseMax3D)) return default(DoseValue);
                    return new DoseValue(local._client.DoseMax3D);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseMax3D = value;
            }
        }

        public VVector DoseMax3DLocation
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseMax3DLocation;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseMax3DLocation)) return default(VVector);
                    return new VVector(local._client.DoseMax3DLocation);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseMax3DLocation = value;
            }
        }

        public IEnumerable<Isodose> Isodoses
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Isodoses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Isodose();
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

        public VVector Origin
        {
            get
            {
                if (_client is ExpandoObject) return _client.Origin;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Origin)) return default(VVector);
                    return new VVector(local._client.Origin);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Origin = value;
            }
        }

        public Series Series
        {
            get
            {
                if (_client is ExpandoObject) return _client.Series;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Series)) return default(Series);
                    return new Series(local._client.Series);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Series = value;
            }
        }

        public string SeriesUID
        {
            get
            {
                if (_client is ExpandoObject) return _client.SeriesUID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.SeriesUID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SeriesUID = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject) return _client.UID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UID = value;
            }
        }

        public VVector XDirection
        {
            get
            {
                if (_client is ExpandoObject) return _client.XDirection;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.XDirection)) return default(VVector);
                    return new VVector(local._client.XDirection);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.XDirection = value;
            }
        }

        public double XRes
        {
            get
            {
                if (_client is ExpandoObject) return _client.XRes;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.XRes; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XRes = value;
            }
        }

        public int XSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.XSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.XSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XSize = value;
            }
        }

        public VVector YDirection
        {
            get
            {
                if (_client is ExpandoObject) return _client.YDirection;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.YDirection)) return default(VVector);
                    return new VVector(local._client.YDirection);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.YDirection = value;
            }
        }

        public double YRes
        {
            get
            {
                if (_client is ExpandoObject) return _client.YRes;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.YRes; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YRes = value;
            }
        }

        public int YSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.YSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.YSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YSize = value;
            }
        }

        public VVector ZDirection
        {
            get
            {
                if (_client is ExpandoObject) return _client.ZDirection;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ZDirection)) return default(VVector);
                    return new VVector(local._client.ZDirection);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ZDirection = value;
            }
        }

        public double ZRes
        {
            get
            {
                if (_client is ExpandoObject) return _client.ZRes;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.ZRes; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ZRes = value;
            }
        }

        public int ZSize
        {
            get
            {
                if (_client is ExpandoObject) return _client.ZSize;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ZSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ZSize = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public DoseProfile GetDoseProfile(VVector start, VVector stop, double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new DoseProfile(
                    local._client.GetDoseProfile(start._client, stop._client, preallocatedBuffer));
            });
            return retVal;
        }

        public DoseValue GetDoseToPoint(VVector at)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new DoseValue(local._client.GetDoseToPoint(at._client));
            });
            return retVal;
        }

        public void GetVoxels(int planeIndex, int[,] preallocatedBuffer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.GetVoxels(planeIndex, preallocatedBuffer); });
        }

        public void SetVoxels(int planeIndex, int[,] values)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetVoxels(planeIndex, values); });
        }

        public DoseValue VoxelToDoseValue(int voxelValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new DoseValue(local._client.VoxelToDoseValue(voxelValue));
            });
            return retVal;
        }
    }
}