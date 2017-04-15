using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Structure : ESAPIX.Facade.API.ApiDataObject
    {
        public Structure() { _client = new ExpandoObject(); }
        public Structure(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.VVector CenterPoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CenterPoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.CenterPoint); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CenterPoint = value; }
            }
        }
        public System.Windows.Media.Color Color
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Color; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Color = value; }
            }
        }
        public System.String DicomType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DicomType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DicomType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DicomType = value; }
            }
        }
        public System.Boolean HasSegment
        {
            get
            {
                if (_client is ExpandoObject) { return _client.HasSegment; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasSegment; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.HasSegment = value; }
            }
        }
        public System.Boolean IsEmpty
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsEmpty; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsEmpty; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsEmpty = value; }
            }
        }
        public System.Boolean IsHighResolution
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsHighResolution; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsHighResolution; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsHighResolution = value; }
            }
        }
        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MeshGeometry; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>((sc) => { return local._client.MeshGeometry; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MeshGeometry = value; }
            }
        }
        public System.Int32 ROINumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ROINumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ROINumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ROINumber = value; }
            }
        }
        public ESAPIX.Facade.API.SegmentVolume SegmentVolume
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SegmentVolume; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.SegmentVolume>((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.SegmentVolume); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SegmentVolume = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.Types.StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.StructureCodeInfos;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.Types.StructureCodeInfo();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public System.Double Volume
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Volume; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Volume = value; }
            }
        }
        public System.String Id
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id = value; }
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
        public void AddContourOnImagePlane(ESAPIX.Facade.Types.VVector[] contour, System.Int32 z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.AddContourOnImagePlane(contour.Select(n => n._client).ToArray(), z);
            });

        }
        public ESAPIX.Facade.API.SegmentVolume And(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.And(other._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume AsymmetricMargin(ESAPIX.Facade.Types.AxisAlignedMargins margins)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.AsymmetricMargin(margins._client)); });
            return retVal;

        }
        public System.Boolean CanConvertToHighResolution()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanConvertToHighResolution(); });
            return retVal;

        }
        public System.Boolean CanSetAssignedHU(out System.String errorMessage)
        {
            var errorMessage_OUT = default(System.String);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanSetAssignedHU(out errorMessage_OUT); });
            errorMessage = errorMessage_OUT;
            return retVal;

        }
        public void ClearAllContoursOnImagePlane(System.Int32 z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ClearAllContoursOnImagePlane(z);
            });

        }
        public void ConvertToHighResolution()
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ConvertToHighResolution();
            });

        }
        public System.Boolean GetAssignedHU(out System.Double huValue)
        {
            var huValue_OUT = default(System.Double);
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetAssignedHU(out huValue_OUT); });
            huValue = huValue_OUT;
            return retVal;

        }
        public ESAPIX.Facade.Types.VVector[][] GetContoursOnImagePlane(System.Int32 z)
        {
            var stubResult = _client.GetContoursOnImagePlane(z);
            int firstDim = stubResult.GetLength(0);
            var facade = new ESAPIX.Facade.Types.VVector[firstDim][];
            for (int i = 0; i < firstDim; i++)
                facade[i] = ((IEnumerable<dynamic>)stubResult[0]).Select(s => new ESAPIX.Facade.Types.VVector(s._client)).ToArray();
            return facade;
        }
        public System.Int32 GetNumberOfSeparateParts()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetNumberOfSeparateParts(); });
            return retVal;

        }
        public ESAPIX.Facade.Types.SegmentProfile GetSegmentProfile(ESAPIX.Facade.Types.VVector start, ESAPIX.Facade.Types.VVector stop, System.Collections.BitArray preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.SegmentProfile(local._client.GetSegmentProfile(start._client, stop._client, preallocatedBuffer)); });
            return retVal;

        }
        public System.Boolean IsPointInsideSegment(ESAPIX.Facade.Types.VVector point)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.IsPointInsideSegment(point._client); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Margin(System.Double marginInMM)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Margin(marginInMM)); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Not()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Not()); });
            return retVal;

        }
        public ESAPIX.Facade.API.SegmentVolume Or(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Or(other._client)); });
            return retVal;

        }
        public System.Boolean ResetAssignedHU()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ResetAssignedHU(); });
            return retVal;

        }
        public void SetAssignedHU(System.Double huValue)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetAssignedHU(huValue);
            });

        }
        public ESAPIX.Facade.API.SegmentVolume Sub(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Sub(other._client)); });
            return retVal;

        }
        public void SubtractContourOnImagePlane(ESAPIX.Facade.Types.VVector[] contour, System.Int32 z)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SubtractContourOnImagePlane(contour.Select(n => n._client).ToArray(), z);
            });

        }
        public ESAPIX.Facade.API.SegmentVolume Xor(ESAPIX.Facade.API.SegmentVolume other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.SegmentVolume(local._client.Xor(other._client)); });
            return retVal;

        }
    }
}