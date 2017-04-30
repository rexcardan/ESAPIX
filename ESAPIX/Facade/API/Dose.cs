#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Types.DoseValue DoseMax3D
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseMax3D")
                        ? _client.DoseMax3D
                        : default(Types.DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseMax3D)) return default(Types.DoseValue);
                    return new Types.DoseValue(local._client.DoseMax3D);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseMax3D = value;
            }
        }

        public Types.VVector DoseMax3DLocation
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseMax3DLocation")
                        ? _client.DoseMax3DLocation
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.DoseMax3DLocation)) return default(Types.VVector);
                    return new Types.VVector(local._client.DoseMax3DLocation);
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
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("Isodoses")
                        ? _client.Isodoses
                        : default(IEnumerable<Isodose>);
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
            set
            {
                if (_client is ExpandoObject) _client.Isodoses = value;
            }
        }

        public Types.VVector Origin
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Origin") ? _client.Origin : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Origin)) return default(Types.VVector);
                    return new Types.VVector(local._client.Origin);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Series") ? _client.Series : default(Series);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SeriesUID") ? _client.SeriesUID : default(string);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UID") ? _client.UID : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UID = value;
            }
        }

        public Types.VVector XDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XDirection")
                        ? _client.XDirection
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.XDirection)) return default(Types.VVector);
                    return new Types.VVector(local._client.XDirection);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XRes") ? _client.XRes : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XSize") ? _client.XSize : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.XSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.XSize = value;
            }
        }

        public Types.VVector YDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YDirection")
                        ? _client.YDirection
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.YDirection)) return default(Types.VVector);
                    return new Types.VVector(local._client.YDirection);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YRes") ? _client.YRes : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YSize") ? _client.YSize : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.YSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.YSize = value;
            }
        }

        public Types.VVector ZDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ZDirection")
                        ? _client.ZDirection
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.ZDirection)) return default(Types.VVector);
                    return new Types.VVector(local._client.ZDirection);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ZRes") ? _client.ZRes : default(double);
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ZSize") ? _client.ZSize : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ZSize; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ZSize = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public Types.DoseProfile GetDoseProfile(Types.VVector start, Types.VVector stop, double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.DoseProfile(
                    local._client.GetDoseProfile(start._client, stop._client, preallocatedBuffer));
            });
            return retVal;
        }

        public Types.DoseValue GetDoseToPoint(Types.VVector at)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.DoseValue(local._client.GetDoseToPoint(at._client));
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

        public Types.DoseValue VoxelToDoseValue(int voxelValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.DoseValue(local._client.VoxelToDoseValue(voxelValue));
            });
            return retVal;
        }
    }
}