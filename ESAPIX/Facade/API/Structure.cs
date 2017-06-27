#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;
using System.Windows.Media.Media3D;

#endregion

namespace ESAPIX.Facade.API
{
    public class Structure : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Structure()
        {
            _client = new ExpandoObject();
        }

        public Structure(dynamic client)
        {
            _client = client;
        }

        public VVector CenterPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CenterPoint"))
                        return _client.CenterPoint;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CenterPoint; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CenterPoint = value;
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Color"))
                        return _client.Color;
                    else
                        return default(System.Windows.Media.Color);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Color; }
                    );
                return default(System.Windows.Media.Color);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Color = value;
            }
        }

        public string DicomType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DicomType"))
                        return _client.DicomType;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DicomType; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DicomType = value;
            }
        }

        public bool HasSegment
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HasSegment"))
                        return _client.HasSegment;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HasSegment; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.HasSegment = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsEmpty"))
                        return _client.IsEmpty;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsEmpty; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsEmpty = value;
            }
        }

        public bool IsHighResolution
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsHighResolution"))
                        return _client.IsHighResolution;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsHighResolution; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsHighResolution = value;
            }
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("MeshGeometry")
                        ? _client.MeshGeometry
                        : default(System.Windows.Media.Media3D.MeshGeometry3D);

                MeshGeometry3D mesh = new MeshGeometry3D();
                Point3D[] points = new Point3D[0];
                Vector3D[] normals = new Vector3D[0];
                int[] indices = new int[0];

                XC.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    points = new Point3D[_client.MeshGeometry.Positions.Count];
                    normals = new Vector3D[_client.MeshGeometry.Normals.Count];
                    indices = new int[_client.MeshGeometry.TriangleIndices.Count];
                    _client.MeshGeometry.Positions.CopyTo(points, 0);
                    _client.MeshGeometry.Normals.CopyTo(normals, 0);
                    _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                });
                mesh.Positions = new Point3DCollection(points);
                return mesh;
            }
            set
            {
                if (_client is ExpandoObject) _client.MeshGeometry = value;
            }
        }

        public int ROINumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ROINumber"))
                        return _client.ROINumber;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ROINumber; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ROINumber = value;
            }
        }

        public SegmentVolume SegmentVolume
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SegmentVolume"))
                        return _client.SegmentVolume;
                    else
                        return default(SegmentVolume);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.SegmentVolume != null)
                                return new SegmentVolume(_client.SegmentVolume);
                            return null;
                        }
                    );
                return default(SegmentVolume);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SegmentVolume = value;
            }
        }

        public IEnumerable<StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureCodeInfos"))
                        foreach (var item in _client.StructureCodeInfos)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.StructureCodeInfos;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = default(StructureCodeInfo);
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                facade = (StructureCodeInfo) vms;
                            }
                        );
                        yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StructureCodeInfos = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Volume"))
                        return _client.Volume;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Volume; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Volume = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id"))
                        return _client.Id;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id = value;
            }
        }

        public void AddContourOnImagePlane(VVector[] contour, int z)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.AddContourOnImagePlane(contour, z); }
                );
            else
                _client.AddContourOnImagePlane(contour, z);
        }

        public SegmentVolume And(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.And(other._client)); }
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

        public bool CanConvertToHighResolution()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanConvertToHighResolution(); }
                );
                return vmsResult;
            }
            return (bool) _client.CanConvertToHighResolution();
        }

        public bool CanSetAssignedHU(out string errorMessage)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var errorMessage_OUT = default(string);
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanSetAssignedHU(out errorMessage_OUT); }
                );
                errorMessage = errorMessage_OUT;
                return vmsResult;
            }
            return (bool) _client.CanSetAssignedHU(out errorMessage);
        }

        public void ClearAllContoursOnImagePlane(int z)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.ClearAllContoursOnImagePlane(z); }
                );
            else
                _client.ClearAllContoursOnImagePlane(z);
        }

        public void ConvertToHighResolution()
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.ConvertToHighResolution(); }
                );
            else
                _client.ConvertToHighResolution();
        }

        public bool GetAssignedHU(out double huValue)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var huValue_OUT = default(double);
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.GetAssignedHU(out huValue_OUT); }
                );
                huValue = huValue_OUT;
                return vmsResult;
            }
            return (bool) _client.GetAssignedHU(out huValue);
        }

        public VVector[][] GetContoursOnImagePlane(int z)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.GetContoursOnImagePlane(z); }
                );
                return vmsResult;
            }
            return (VVector[][]) _client.GetContoursOnImagePlane(z);
        }

        public int GetNumberOfSeparateParts()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.GetNumberOfSeparateParts(); }
                );
                return vmsResult;
            }
            return (int) _client.GetNumberOfSeparateParts();
        }

        public SegmentProfile GetSegmentProfile(VVector start, VVector stop, BitArray preallocatedBuffer)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetSegmentProfile(start, stop, preallocatedBuffer);
                    }
                );
                return vmsResult;
            }
            return (SegmentProfile) _client.GetSegmentProfile(start, stop, preallocatedBuffer);
        }

        public bool IsPointInsideSegment(VVector point)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.IsPointInsideSegment(point); }
                );
                return vmsResult;
            }
            return (bool) _client.IsPointInsideSegment(point);
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
                    sc => { return new SegmentVolume(_client.Or(other._client)); }
                );
                return vmsResult;
            }
            return _client.Or(other);
        }

        public bool ResetAssignedHU()
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc => { return _client.ResetAssignedHU(); }
                );
                return vmsResult;
            }
            return (bool) _client.ResetAssignedHU();
        }

        public void SetAssignedHU(double huValue)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SetAssignedHU(huValue); }
                );
            else
                _client.SetAssignedHU(huValue);
        }

        public SegmentVolume Sub(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Sub(other._client)); }
                );
                return vmsResult;
            }
            return _client.Sub(other);
        }

        public void SubtractContourOnImagePlane(VVector[] contour, int z)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.SubtractContourOnImagePlane(contour, z); }
                );
            else
                _client.SubtractContourOnImagePlane(contour, z);
        }

        public SegmentVolume Xor(SegmentVolume other)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new SegmentVolume(_client.Xor(other._client)); }
                );
                return vmsResult;
            }
            return _client.Xor(other);
        }
    }
}