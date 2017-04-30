using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using ESAPIX.Facade.Types;
using X = ESAPIX.Facade.XContext;

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

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public VVector CenterPoint
        {
            get
            {
                if (_client is ExpandoObject) return _client.CenterPoint;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.CenterPoint)) return default(VVector);
                    return new VVector(local._client.CenterPoint);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.CenterPoint = value;
            }
        }

        public Color Color
        {
            get
            {
                if (_client is ExpandoObject) return _client.Color;
                var local = this;
                return X.Instance.CurrentContext.GetValue<Color>(sc => { return local._client.Color; });
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
                if (_client is ExpandoObject) return _client.DicomType;
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
                if (_client is ExpandoObject) return _client.HasSegment;
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
                if (_client is ExpandoObject) return _client.IsEmpty;
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
                if (_client is ExpandoObject) return _client.IsHighResolution;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsHighResolution; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsHighResolution = value;
            }
        }

        public MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject) return _client.MeshGeometry;
                var local = this;
                return X.Instance.CurrentContext.GetValue<MeshGeometry3D>(sc => { return local._client.MeshGeometry; });
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
                if (_client is ExpandoObject) return _client.ROINumber;
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
                if (_client is ExpandoObject) return _client.SegmentVolume;
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

        public IEnumerable<StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.StructureCodeInfos;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new StructureCodeInfo();
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

        public double Volume
        {
            get
            {
                if (_client is ExpandoObject) return _client.Volume;
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
                if (_client is ExpandoObject) return _client.Id;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public void AddContourOnImagePlane(VVector[] contour, int z)
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

        public SegmentVolume AsymmetricMargin(AxisAlignedMargins margins)
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

        public VVector[][] GetContoursOnImagePlane(int z)
        {
            var stubResult = _client.GetContoursOnImagePlane(z);
            int firstDim = stubResult.GetLength(0);
            var facade = new VVector[firstDim][];
            for (var i = 0; i < firstDim; i++)
                facade[i] = ((IEnumerable<dynamic>) stubResult[0]).Select(s => new VVector(s._client)).ToArray();
            return facade;
        }

        public int GetNumberOfSeparateParts()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetNumberOfSeparateParts(); });
            return retVal;
        }

        public SegmentProfile GetSegmentProfile(VVector start, VVector stop, BitArray preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new SegmentProfile(
                    local._client.GetSegmentProfile(start._client, stop._client, preallocatedBuffer));
            });
            return retVal;
        }

        public bool IsPointInsideSegment(VVector point)
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

        public void SubtractContourOnImagePlane(VVector[] contour, int z)
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