using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Image : ESAPIX.Facade.API.ApiDataObject
    {
        public Image() { }
        public Image(dynamic client) { _client = client; }
        public System.String ContrastBolusAgentIngredientName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ContrastBolusAgentIngredientName; });
            }
        }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public System.String DisplayUnit
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.DisplayUnit; });
            }
        }
        public System.String FOR
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.FOR; });
            }
        }
        public System.Boolean HasUserOrigin
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.HasUserOrigin; });
            }
        }
        public ESAPIX.Facade.Types.PatientOrientation ImagingOrientation
        {
            get
            {
                var local = this;
                return (ESAPIX.Facade.Types.PatientOrientation)local._client.ImagingOrientation;
            }
        }
        public System.Boolean IsProcessed
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.IsProcessed; });
            }
        }
        public System.Int32 Level
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Level; });
            }
        }
        public ESAPIX.Facade.Types.VVector Origin
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.Origin);
            }
        }
        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Series(local._client.Series);
            }
        }
        public ESAPIX.Facade.Types.VVector UserOrigin
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.UserOrigin);
            }
        }
        public System.String UserOriginComments
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.UserOriginComments; });
            }
        }
        public System.Int32 Window
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Window; });
            }
        }
        public ESAPIX.Facade.Types.VVector XDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.XDirection);
            }
        }
        public System.Double XRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.XRes; });
            }
        }
        public System.Int32 XSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.XSize; });
            }
        }
        public ESAPIX.Facade.Types.VVector YDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.YDirection);
            }
        }
        public System.Double YRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.YRes; });
            }
        }
        public System.Int32 YSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.YSize; });
            }
        }
        public ESAPIX.Facade.Types.VVector ZDirection
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.ZDirection);
            }
        }
        public System.Double ZRes
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ZRes; });
            }
        }
        public System.Int32 ZSize
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.ZSize; });
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