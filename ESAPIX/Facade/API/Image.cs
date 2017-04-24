using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Image : ESAPIX.Facade.API.ApiDataObject
    {
        public Image() { _client = new ExpandoObject(); }
        public Image(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String ContrastBolusAgentIngredientName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ContrastBolusAgentIngredientName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ContrastBolusAgentIngredientName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ContrastBolusAgentIngredientName = value; }
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public System.String DisplayUnit
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DisplayUnit; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DisplayUnit; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DisplayUnit = value; }
            }
        }
        public System.String FOR
        {
            get
            {
                if (_client is ExpandoObject) { return _client.FOR; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FOR; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.FOR = value; }
            }
        }
        public System.Boolean HasUserOrigin
        {
            get
            {
                if (_client is ExpandoObject) { return _client.HasUserOrigin; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasUserOrigin; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.HasUserOrigin = value; }
            }
        }
        public ESAPIX.Facade.Types.PatientOrientation ImagingOrientation
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ImagingOrientation; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.PatientOrientation>((sc) => { return (ESAPIX.Facade.Types.PatientOrientation)local._client.ImagingOrientation; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ImagingOrientation = value; }
            }
        }
        public System.Boolean IsProcessed
        {
            get
            {
                if (_client is ExpandoObject) { return _client.IsProcessed; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsProcessed; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.IsProcessed = value; }
            }
        }
        public System.Int32 Level
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Level; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Level; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Level = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector Origin
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Origin; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.Origin); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Origin = value; }
            }
        }
        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Series; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Series>((sc) => { return new ESAPIX.Facade.API.Series(local._client.Series); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Series = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector UserOrigin
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UserOrigin; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.UserOrigin); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UserOrigin = value; }
            }
        }
        public System.String UserOriginComments
        {
            get
            {
                if (_client is ExpandoObject) { return _client.UserOriginComments; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UserOriginComments; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.UserOriginComments = value; }
            }
        }
        public System.Int32 Window
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Window; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Window; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Window = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector XDirection
        {
            get
            {
                if (_client is ExpandoObject) { return _client.XDirection; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.XDirection); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.XDirection = value; }
            }
        }
        public System.Double XRes
        {
            get
            {
                if (_client is ExpandoObject) { return _client.XRes; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.XRes; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.XRes = value; }
            }
        }
        public System.Int32 XSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.XSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.XSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.XSize = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector YDirection
        {
            get
            {
                if (_client is ExpandoObject) { return _client.YDirection; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.YDirection); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.YDirection = value; }
            }
        }
        public System.Double YRes
        {
            get
            {
                if (_client is ExpandoObject) { return _client.YRes; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.YRes; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.YRes = value; }
            }
        }
        public System.Int32 YSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.YSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.YSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.YSize = value; }
            }
        }
        public ESAPIX.Facade.Types.VVector ZDirection
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ZDirection; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.VVector>((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.ZDirection); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ZDirection = value; }
            }
        }
        public System.Double ZRes
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ZRes; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ZRes; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ZRes = value; }
            }
        }
        public System.Int32 ZSize
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ZSize; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ZSize; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ZSize = value; }
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
        public ESAPIX.Facade.Types.VVector DicomToUser(ESAPIX.Facade.Types.VVector dicom, ESAPIX.Facade.API.PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.DicomToUser(dicom._client, planSetup._client)); });
            return retVal;

        }
        public ESAPIX.Facade.Types.ImageProfile GetImageProfile(ESAPIX.Facade.Types.VVector start, ESAPIX.Facade.Types.VVector stop, System.Double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.ImageProfile(local._client.GetImageProfile(start._client, stop._client, preallocatedBuffer)); });
            return retVal;

        }
        public void GetVoxels(System.Int32 planeIndex, System.Int32[,] preallocatedBuffer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.GetVoxels(planeIndex, preallocatedBuffer);
            });

        }
        public ESAPIX.Facade.Types.VVector UserToDicom(ESAPIX.Facade.Types.VVector user, ESAPIX.Facade.API.PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.Types.VVector(local._client.UserToDicom(user._client, planSetup._client)); });
            return retVal;

        }
        public System.Double VoxelToDisplayValue(System.Int32 voxelValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.VoxelToDisplayValue(voxelValue); });
            return retVal;

        }
    }
}