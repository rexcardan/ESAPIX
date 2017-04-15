using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Structure : ESAPIX.Facade.API.ApiDataObject
    {
        public Structure() { }
        public Structure(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.VVector CenterPoint
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.CenterPoint);
            }
        }
        public System.Windows.Media.Color Color
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Color>((sc) => { return local._client.Color; });
            }
        }
        public System.String DicomType
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DicomType; });
            }
        }
        public System.Boolean HasSegment
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasSegment; });
            }
        }
        public System.Boolean IsEmpty
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsEmpty; });
            }
        }
        public System.Boolean IsHighResolution
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsHighResolution; });
            }
        }
        public System.Windows.Media.Media3D.MeshGeometry3D MeshGeometry
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Windows.Media.Media3D.MeshGeometry3D>((sc) => { return local._client.MeshGeometry; });
            }
        }
        public System.Int32 ROINumber
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ROINumber; });
            }
        }
        public ESAPIX.Facade.API.SegmentVolume SegmentVolume
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.SegmentVolume(local._client.SegmentVolume);
            }
        }
        public IEnumerable<ESAPIX.Facade.Types.StructureCodeInfo> StructureCodeInfos
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.Types.StructureCodeInfo>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.StructureCodeInfos).Select(s => new ESAPIX.Facade.Types.StructureCodeInfo(s));
                });
            }
        }
        public System.Double Volume
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
        }
        public System.String Id
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
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