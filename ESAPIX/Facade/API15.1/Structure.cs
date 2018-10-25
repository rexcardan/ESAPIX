using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Common.AppComThread;
using V = VMS.TPS.Common.Model.API;
using Types = VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.API
{
    public class Structure : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.String Id
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Id"))
                    {
                        return _client.Id;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Id;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Id = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.Id = (value));
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector CenterPoint
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CenterPoint"))
                    {
                        return _client.CenterPoint;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CenterPoint;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.VVector);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CenterPoint = (value);
                }
                else
                {
                }
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Color"))
                    {
                        return _client.Color;
                    }
                    else
                    {
                        return default (System.Windows.Media.Color);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Color;
                    }

                    );
                }
                else
                {
                    return default (System.Windows.Media.Color);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Color = (value);
                }
                else
                {
                }
            }
        }

        public System.String DicomType
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DicomType"))
                    {
                        return _client.DicomType;
                    }
                    else
                    {
                        return default (System.String);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.DicomType;
                    }

                    );
                }
                else
                {
                    return default (System.String);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.DicomType = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean HasSegment
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("HasSegment"))
                    {
                        return _client.HasSegment;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.HasSegment;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.HasSegment = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsEmpty
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsEmpty"))
                    {
                        return _client.IsEmpty;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsEmpty;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsEmpty = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsHighResolution
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsHighResolution"))
                    {
                        return _client.IsHighResolution;
                    }
                    else
                    {
                        return default (System.Boolean);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.IsHighResolution;
                    }

                    );
                }
                else
                {
                    return default (System.Boolean);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.IsHighResolution = (value);
                }
                else
                {
                }
            }
        }

        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("MeshGeometry"))
                    {
                        return _client.MeshGeometry;
                    }
                    else
                    {
                        return default (System.Windows.Media.Media3D.MeshGeometry3D);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    MeshGeometry3D mesh = (new MeshGeometry3D());
                    var points = (new Point3D[]{});
                    var normals = (new Vector3D[]{});
                    var indices = (new Int32[]{});
                    XC.Instance.Invoke(() =>
                    {
                        if ((_client.MeshGeometry) != (null))
                        {
                            points = (new Point3D[_client.MeshGeometry.Positions.Count]);
                            normals = (new Vector3D[_client.MeshGeometry.Normals.Count]);
                            indices = (new Int32[_client.MeshGeometry.TriangleIndices.Count]);
                            _client.MeshGeometry.Positions.CopyTo(points, 0);
                            _client.MeshGeometry.Normals.CopyTo(normals, 0);
                            _client.MeshGeometry.TriangleIndices.CopyTo(indices, 0);
                        }
                    }

                    );
                    if ((points.Length) == (0))
                    {
                        return null;
                    }

                    mesh.Positions = (new Point3DCollection(points));
                    mesh.Normals = (new Vector3DCollection(normals));
                    mesh.TriangleIndices = (new Int32Collection(indices));
                    return mesh;
                }
                else
                {
                    return default (System.Windows.Media.Media3D.MeshGeometry3D);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.MeshGeometry = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 ROINumber
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ROINumber"))
                    {
                        return _client.ROINumber;
                    }
                    else
                    {
                        return default (System.Int32);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ROINumber;
                    }

                    );
                }
                else
                {
                    return default (System.Int32);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ROINumber = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.SegmentVolume SegmentVolume
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("SegmentVolume"))
                    {
                        return _client.SegmentVolume;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.SegmentVolume);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.SegmentVolume) != (null))
                        {
                            return new ESAPIX.Facade.API.SegmentVolume(_client.SegmentVolume);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    );
                }
                else
                {
                    return default (ESAPIX.Facade.API.SegmentVolume);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.SegmentVolume = (value);
                }
                else
                {
                }

                if ((XC.Instance) != (null))
                {
                    XC.Instance.Invoke(() => _client.SegmentVolume = (value));
                }
            }
        }

        public IEnumerable<VMS.TPS.Common.Model.Types.StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureCodeInfos"))
                    {
                        foreach (var item in _client.StructureCodeInfos)
                        {
                            yield return item;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.Invoke(() =>
                    {
                        var asEnum = (IEnumerable)_client.StructureCodeInfos;
                        if ((asEnum) != null)
                        {
                            enumerator = asEnum.GetEnumerator();
                        }
                    }

                    );
                    if (enumerator == null)
                    {
                        yield break;
                    }

                    while (XC.Instance.GetValue<bool>(sc => enumerator.MoveNext()))
                    {
                        var facade = default (VMS.TPS.Common.Model.Types.StructureCodeInfo);
                        XC.Instance.Invoke(() =>
                        {
                            var vms = enumerator.Current;
                            facade = (VMS.TPS.Common.Model.Types.StructureCodeInfo)vms;
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

        public System.Double Volume
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Volume"))
                    {
                        return _client.Volume;
                    }
                    else
                    {
                        return default (System.Double);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.Volume;
                    }

                    );
                }
                else
                {
                    return default (System.Double);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Volume = (value);
                }
                else
                {
                }
            }
        }

        public void AddContourOnImagePlane(VMS.TPS.Common.Model.Types.VVector[] contour, System.Int32 z)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.AddContourOnImagePlane(contour, z);
                }

                );
            }
            else
            {
                _client.AddContourOnImagePlane(contour, z);
            }
        }

        public ESAPIX.Facade.API.SegmentVolume And(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.And(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.And(other));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume AsymmetricMargin(VMS.TPS.Common.Model.Types.AxisAlignedMargins margins)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.AsymmetricMargin(margins));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.AsymmetricMargin(margins));
            }
        }

        public System.Boolean CanConvertToHighResolution()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanConvertToHighResolution());
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanConvertToHighResolution());
            }
        }

        public System.Boolean CanSetAssignedHU(out System.String errorMessage)
        {
            if ((XC.Instance) != (null))
            {
                var errorMessage_OUT = (default (System.String));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.CanSetAssignedHU(out errorMessage_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                errorMessage = (errorMessage_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.CanSetAssignedHU(out errorMessage));
            }
        }

        public void ClearAllContoursOnImagePlane(System.Int32 z)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ClearAllContoursOnImagePlane(z);
                }

                );
            }
            else
            {
                _client.ClearAllContoursOnImagePlane(z);
            }
        }

        public void ConvertDoseLevelToStructure(ESAPIX.Facade.API.Dose dose, VMS.TPS.Common.Model.Types.DoseValue doseLevel)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ConvertDoseLevelToStructure(dose._client, doseLevel);
                }

                );
            }
            else
            {
                _client.ConvertDoseLevelToStructure(dose, doseLevel);
            }
        }

        public void ConvertToHighResolution()
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.ConvertToHighResolution();
                }

                );
            }
            else
            {
                _client.ConvertToHighResolution();
            }
        }

        public System.Boolean GetAssignedHU(out System.Double huValue)
        {
            if ((XC.Instance) != (null))
            {
                var huValue_OUT = (default (System.Double));
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetAssignedHU(out huValue_OUT));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                huValue = (huValue_OUT);
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.GetAssignedHU(out huValue));
            }
        }

        public VMS.TPS.Common.Model.Types.VVector[][] GetContoursOnImagePlane(System.Int32 z)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetContoursOnImagePlane(z));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.VVector[][])))
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector[][]);
                    }

                    return (VMS.TPS.Common.Model.Types.VVector[][])(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.VVector[][])(_client.GetContoursOnImagePlane(z));
            }
        }

        public System.Int32 GetNumberOfSeparateParts()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetNumberOfSeparateParts());
                    if (fromClient.Equals(default (System.Int32)))
                    {
                        return default (System.Int32);
                    }

                    return (System.Int32)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Int32)(_client.GetNumberOfSeparateParts());
            }
        }

        public VMS.TPS.Common.Model.Types.SegmentProfile GetSegmentProfile(VMS.TPS.Common.Model.Types.VVector start, VMS.TPS.Common.Model.Types.VVector stop, System.Collections.BitArray preallocatedBuffer)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetSegmentProfile(start, stop, preallocatedBuffer));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.SegmentProfile)))
                    {
                        return default (VMS.TPS.Common.Model.Types.SegmentProfile);
                    }

                    return (VMS.TPS.Common.Model.Types.SegmentProfile)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.SegmentProfile)(_client.GetSegmentProfile(start, stop, preallocatedBuffer));
            }
        }

        public System.Boolean IsPointInsideSegment(VMS.TPS.Common.Model.Types.VVector point)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.IsPointInsideSegment(point));
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.IsPointInsideSegment(point));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Margin(System.Double marginInMM)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Margin(marginInMM));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Margin(marginInMM));
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Not()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Not());
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Not());
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Or(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Or(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Or(other));
            }
        }

        public System.Boolean ResetAssignedHU()
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.ResetAssignedHU());
                    if (fromClient.Equals(default (System.Boolean)))
                    {
                        return default (System.Boolean);
                    }

                    return (System.Boolean)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Boolean)(_client.ResetAssignedHU());
            }
        }

        public void SetAssignedHU(System.Double huValue)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SetAssignedHU(huValue);
                }

                );
            }
            else
            {
                _client.SetAssignedHU(huValue);
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Sub(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Sub(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Sub(other));
            }
        }

        public void SubtractContourOnImagePlane(VMS.TPS.Common.Model.Types.VVector[] contour, System.Int32 z)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.SubtractContourOnImagePlane(contour, z);
                }

                );
            }
            else
            {
                _client.SubtractContourOnImagePlane(contour, z);
            }
        }

        public ESAPIX.Facade.API.SegmentVolume Xor(ESAPIX.Facade.API.SegmentVolume other)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.Xor(other._client));
                    if ((fromClient) == (null))
                    {
                        return null;
                    }

                    return new ESAPIX.Facade.API.SegmentVolume(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (ESAPIX.Facade.API.SegmentVolume)(_client.Xor(other));
            }
        }

        public Structure()
        {
            _client = (new ExpandoObject());
        }

        public Structure(dynamic client)
        {
            _client = (client);
        }
    }
}