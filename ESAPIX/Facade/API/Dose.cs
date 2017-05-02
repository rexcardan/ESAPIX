#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
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
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public DoseValue DoseMax3D
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseMax3D") ? _client.DoseMax3D : default(DoseValue);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DoseValue>(sc => { return local._client.DoseMax3D; });
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
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DoseMax3DLocation")
                        ? _client.DoseMax3DLocation
                        : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.DoseMax3DLocation; });
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
                {
                    if ((_client as ExpandoObject).HasProperty("Isodoses"))
                        foreach (var item in _client.Isodoses) yield return item;
                    else yield break;
                }
                else
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
            set
            {
                if (_client is ExpandoObject) _client.Isodoses = value;
            }
        }

        public VVector Origin
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Origin") ? _client.Origin : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.Origin; });
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

        public VVector XDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("XDirection") ? _client.XDirection : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.XDirection; });
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

        public VVector YDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("YDirection") ? _client.YDirection : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.YDirection; });
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

        public VVector ZDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ZDirection") ? _client.ZDirection : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.ZDirection; });
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

        public DoseProfile GetDoseProfile(VVector start, VVector stop, double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetDoseProfile(start, stop, preallocatedBuffer);
            });
            return retVal;
        }

        public DoseValue GetDoseToPoint(VVector at)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetDoseToPoint(at); });
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
            var retVal =
                X.Instance.CurrentContext.GetValue(sc => { return local._client.VoxelToDoseValue(voxelValue); });
            return retVal;
        }
    }
}