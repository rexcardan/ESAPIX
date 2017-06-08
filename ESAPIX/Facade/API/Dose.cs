#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Dose : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Dose()
        {
            _client = new ExpandoObject();
        }

        public Dose(dynamic client)
        {
            _client = client;
        }

        public DoseValue DoseMax3D
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseMax3D"))
                        return _client.DoseMax3D;
                    else
                        return default(DoseValue);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DoseMax3D; }
                    );
                return default(DoseValue);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseMax3D = value;
            }
        }

        public VVector DoseMax3DLocation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DoseMax3DLocation"))
                        return _client.DoseMax3DLocation;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DoseMax3DLocation; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DoseMax3DLocation = value;
            }
        }

        public IEnumerable<Isodose> Isodoses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Isodoses"))
                        foreach (var item in _client.Isodoses)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Isodoses;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Isodose();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Isodoses = value;
            }
        }

        public VVector Origin
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Origin"))
                        return _client.Origin;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Origin; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Origin = value;
            }
        }

        public Series Series
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Series"))
                        return _client.Series;
                    else
                        return default(Series);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Series(_client.Series); }
                    );
                return default(Series);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Series = value;
            }
        }

        public string SeriesUID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SeriesUID"))
                        return _client.SeriesUID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SeriesUID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SeriesUID = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UID"))
                        return _client.UID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UID = value;
            }
        }

        public VVector XDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("XDirection"))
                        return _client.XDirection;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.XDirection; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.XDirection = value;
            }
        }

        public double XRes
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("XRes"))
                        return _client.XRes;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.XRes; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.XRes = value;
            }
        }

        public int XSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("XSize"))
                        return _client.XSize;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.XSize; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.XSize = value;
            }
        }

        public VVector YDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("YDirection"))
                        return _client.YDirection;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.YDirection; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.YDirection = value;
            }
        }

        public double YRes
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("YRes"))
                        return _client.YRes;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.YRes; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.YRes = value;
            }
        }

        public int YSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("YSize"))
                        return _client.YSize;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.YSize; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.YSize = value;
            }
        }

        public VVector ZDirection
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ZDirection"))
                        return _client.ZDirection;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ZDirection; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ZDirection = value;
            }
        }

        public double ZRes
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ZRes"))
                        return _client.ZRes;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ZRes; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ZRes = value;
            }
        }

        public int ZSize
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ZSize"))
                        return _client.ZSize;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ZSize; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ZSize = value;
            }
        }

        public DoseProfile GetDoseProfile(VVector start, VVector stop, double[] preallocatedBuffer)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetDoseProfile(start, stop, preallocatedBuffer);
                    }
                );
                return vmsResult;
            }
            return (DoseProfile) _client.GetDoseProfile(start, stop, preallocatedBuffer);
        }

        public DoseValue GetDoseToPoint(VVector at)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.GetDoseToPoint(at); }
                );
                return vmsResult;
            }
            return (DoseValue) _client.GetDoseToPoint(at);
        }

        public void GetVoxels(int planeIndex, int[,] preallocatedBuffer)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.GetVoxels(planeIndex, preallocatedBuffer); }
                );
            else
                _client.GetVoxels(planeIndex, preallocatedBuffer);
        }

        public void SetVoxels(int planeIndex, int[,] values)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetVoxels(planeIndex, values); }
                );
            else
                _client.SetVoxels(planeIndex, values);
        }

        public DoseValue VoxelToDoseValue(int voxelValue)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.VoxelToDoseValue(voxelValue); }
                );
                return vmsResult;
            }
            return (DoseValue) _client.VoxelToDoseValue(voxelValue);
        }
    }
}