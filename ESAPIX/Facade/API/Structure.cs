#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Structure : ApiDataObject
    {
        public Structure()
        {
            _client = new ExpandoObject();
        }

        public Structure(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Types.VVector CenterPoint
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CenterPoint")
                        ? _client.CenterPoint
                        : default(Types.VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.CenterPoint)) return default(Types.VVector);
                    return new Types.VVector(local._client.CenterPoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CenterPoint = value;
            }
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Color")
                        ? _client.Color
                        : default(System.Windows.Media.Color);
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>(sc =>
                {
                    return local._client.Color;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Color = value;
            }
        }

        public string DicomType
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DicomType") ? _client.DicomType : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.DicomType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DicomType = value;
            }
        }

        public bool HasSegment
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HasSegment") ? _client.HasSegment : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.HasSegment; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HasSegment = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsEmpty") ? _client.IsEmpty : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsEmpty; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsEmpty = value;
            }
        }

        public bool IsHighResolution
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsHighResolution")
                        ? _client.IsHighResolution
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsHighResolution; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsHighResolution = value;
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
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>(sc =>
                {
                    return local._client.MeshGeometry;
                });
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
                    return (_client as ExpandoObject).HasProperty("ROINumber") ? _client.ROINumber : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.ROINumber; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ROINumber = value;
            }
        }

        public SegmentVolume SegmentVolume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("SegmentVolume")
                        ? _client.SegmentVolume
                        : default(SegmentVolume);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.SegmentVolume)) return default(SegmentVolume);
                    return new SegmentVolume(local._client.SegmentVolume);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.SegmentVolume = value;
            }
        }

        public IEnumerable<Types.StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("StructureCodeInfos"))
                        foreach (var item in _client.StructureCodeInfos) yield return item;
                    else yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var asEnum = (IEnumerable) _client.StructureCodeInfos;
                        enumerator = asEnum.GetEnumerator();
                    });
                    while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Types.StructureCodeInfo();
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
                if (_client is ExpandoObject) _client.StructureCodeInfos = value;
            }
        }

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Volume") ? _client.Volume : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Volume = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Id") ? _client.Id : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void AddContourOnImagePlane(Types.VVector[] contour, int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.AddContourOnImagePlane(contour.Select(n => n._client).ToArray(), z);
            });
        }

        public SegmentVolume And(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.And(other._client));
            });
            return retVal;
        }

        public SegmentVolume AsymmetricMargin(Types.AxisAlignedMargins margins)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.AsymmetricMargin(margins._client));
            });
            return retVal;
        }

        public bool CanConvertToHighResolution()
        {
            var local = this;
            var retVal =
                X.Instance.CurrentContext.GetValue(sc => { return local._client.CanConvertToHighResolution(); });
            return retVal;
        }

        public bool CanSetAssignedHU(out string errorMessage)
        {
            var errorMessage_OUT = default(string);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanSetAssignedHU(out errorMessage_OUT);
            });
            errorMessage = errorMessage_OUT;
            return retVal;
        }

        public void ClearAllContoursOnImagePlane(int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ClearAllContoursOnImagePlane(z); });
        }

        public void ConvertToHighResolution()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ConvertToHighResolution(); });
        }

        public bool GetAssignedHU(out double huValue)
        {
            var huValue_OUT = default(double);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetAssignedHU(out huValue_OUT);
            });
            huValue = huValue_OUT;
            return retVal;
        }

        public Types.VVector[][] GetContoursOnImagePlane(int z)
        {
            var stubResult = _client.GetContoursOnImagePlane(z);
            int firstDim = stubResult.GetLength(0);
            var facade = new Types.VVector[firstDim][];
            for (var i = 0; i < firstDim; i++)
                facade[i] = ((IEnumerable<dynamic>) stubResult[0]).Select(s => new Types.VVector(s._client)).ToArray();
            return facade;
        }

        public int GetNumberOfSeparateParts()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetNumberOfSeparateParts(); });
            return retVal;
        }

        public Types.SegmentProfile GetSegmentProfile(Types.VVector start, Types.VVector stop,
            BitArray preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new Types.SegmentProfile(
                    local._client.GetSegmentProfile(start._client, stop._client, preallocatedBuffer));
            });
            return retVal;
        }

        public bool IsPointInsideSegment(Types.VVector point)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.IsPointInsideSegment(point._client);
            });
            return retVal;
        }

        public SegmentVolume Margin(double marginInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Margin(marginInMM));
            });
            return retVal;
        }

        public SegmentVolume Not()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return new SegmentVolume(local._client.Not()); });
            return retVal;
        }

        public SegmentVolume Or(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Or(other._client));
            });
            return retVal;
        }

        public bool ResetAssignedHU()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ResetAssignedHU(); });
            return retVal;
        }

        public void SetAssignedHU(double huValue)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.SetAssignedHU(huValue); });
        }

        public SegmentVolume Sub(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Sub(other._client));
            });
            return retVal;
        }

        public void SubtractContourOnImagePlane(Types.VVector[] contour, int z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SubtractContourOnImagePlane(contour.Select(n => n._client).ToArray(), z);
            });
        }

        public SegmentVolume Xor(SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentVolume(local._client.Xor(other._client));
            });
            return retVal;
        }
    }
}