#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using X = ESAPIX.Facade.XContext;

#endregion


namespace ESAPIX.Facade.API
{
    public class Image : ApiDataObject
    {
        public Image()
        {
            _client = new ExpandoObject();
        }

        public Image(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public string ContrastBolusAgentIngredientName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ContrastBolusAgentIngredientName")
                        ? _client.ContrastBolusAgentIngredientName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.ContrastBolusAgentIngredientName;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ContrastBolusAgentIngredientName = value;
            }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CreationDateTime")
                        ? _client.CreationDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public string DisplayUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("DisplayUnit")
                        ? _client.DisplayUnit
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.DisplayUnit; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DisplayUnit = value;
            }
        }

        public string FOR
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("FOR") ? _client.FOR : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.FOR; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FOR = value;
            }
        }

        public bool HasUserOrigin
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HasUserOrigin")
                        ? _client.HasUserOrigin
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.HasUserOrigin; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HasUserOrigin = value;
            }
        }

        public PatientOrientation ImagingOrientation
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("ImagingOrientation")
                        ? _client.ImagingOrientation
                        : default(PatientOrientation);
                var local = this;
                return X.Instance.CurrentContext.GetValue<PatientOrientation>(sc =>
                {
                    return local._client.ImagingOrientation;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ImagingOrientation = value;
            }
        }

        public bool IsProcessed
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("IsProcessed") ? _client.IsProcessed : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.IsProcessed; });
            }
            set
            {
                if (_client is ExpandoObject) _client.IsProcessed = value;
            }
        }

        public int Level
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Level") ? _client.Level : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Level; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Level = value;
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

        public VVector UserOrigin
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UserOrigin") ? _client.UserOrigin : default(VVector);
                var local = this;
                return X.Instance.CurrentContext.GetValue<VVector>(sc => { return local._client.UserOrigin; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UserOrigin = value;
            }
        }

        public string UserOriginComments
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("UserOriginComments")
                        ? _client.UserOriginComments
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UserOriginComments; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UserOriginComments = value;
            }
        }

        public int Window
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Window") ? _client.Window : default(int);
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Window; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Window = value;
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

        public VVector DicomToUser(VVector dicom, PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.DicomToUser(dicom, planSetup._client);
            });
            return retVal;
        }

        public ImageProfile GetImageProfile(VVector start, VVector stop, double[] preallocatedBuffer)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.GetImageProfile(start, stop, preallocatedBuffer);
            });
            return retVal;
        }

        public void GetVoxels(int planeIndex, int[,] preallocatedBuffer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.GetVoxels(planeIndex, preallocatedBuffer); });
        }

        public VVector UserToDicom(VVector user, PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.UserToDicom(user, planSetup._client);
            });
            return retVal;
        }

        public double VoxelToDisplayValue(int voxelValue)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.VoxelToDisplayValue(voxelValue);
            });
            return retVal;
        }
    }
}