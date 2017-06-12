#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Image : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Image()
        {
            _client = new ExpandoObject();
        }

        public Image(dynamic client)
        {
            _client = client;
        }

        public string ContrastBolusAgentIngredientName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ContrastBolusAgentIngredientName"))
                        return _client.ContrastBolusAgentIngredientName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(
                        sc => { return _client.ContrastBolusAgentIngredientName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ContrastBolusAgentIngredientName = value;
            }
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public string DisplayUnit
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("DisplayUnit"))
                        return _client.DisplayUnit;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.DisplayUnit; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.DisplayUnit = value;
            }
        }

        public string FOR
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("FOR"))
                        return _client.FOR;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.FOR; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.FOR = value;
            }
        }

        public bool HasUserOrigin
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HasUserOrigin"))
                        return _client.HasUserOrigin;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HasUserOrigin; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.HasUserOrigin = value;
            }
        }

        public PatientOrientation ImagingOrientation
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ImagingOrientation"))
                        return _client.ImagingOrientation;
                    else
                        return default(PatientOrientation);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ImagingOrientation; }
                    );
                return default(PatientOrientation);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ImagingOrientation = value;
            }
        }

        public bool IsProcessed
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("IsProcessed"))
                        return _client.IsProcessed;
                    else
                        return default(bool);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.IsProcessed; }
                    );
                return default(bool);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.IsProcessed = value;
            }
        }

        public int Level
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Level"))
                        return _client.Level;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Level; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Level = value;
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
                    return XC.Instance.CurrentContext.GetValue(sc =>
                        {
                            if (_client.Series != null)
                                return new Series(_client.Series);
                            return null;
                        }
                    );
                return default(Series);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Series = value;
            }
        }

        public VVector UserOrigin
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UserOrigin"))
                        return _client.UserOrigin;
                    else
                        return default(VVector);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UserOrigin; }
                    );
                return default(VVector);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UserOrigin = value;
            }
        }

        public string UserOriginComments
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UserOriginComments"))
                        return _client.UserOriginComments;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UserOriginComments; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UserOriginComments = value;
            }
        }

        public int Window
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Window"))
                        return _client.Window;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Window; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Window = value;
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

        public VVector DicomToUser(VVector dicom, PlanSetup planSetup)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.DicomToUser(dicom, planSetup._client); }
                );
                return vmsResult;
            }
            return (VVector) _client.DicomToUser(dicom, planSetup);
        }

        public ImageProfile GetImageProfile(VVector start, VVector stop, double[] preallocatedBuffer)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return _client.GetImageProfile(start, stop, preallocatedBuffer);
                    }
                );
                return vmsResult;
            }
            return (ImageProfile) _client.GetImageProfile(start, stop, preallocatedBuffer);
        }

        public void GetVoxels(int planeIndex, int[,] preallocatedBuffer)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.GetVoxels(planeIndex, preallocatedBuffer); }
                );
            else
                _client.GetVoxels(planeIndex, preallocatedBuffer);
        }

        public VVector UserToDicom(VVector user, PlanSetup planSetup)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.UserToDicom(user, planSetup._client); }
                );
                return vmsResult;
            }
            return (VVector) _client.UserToDicom(user, planSetup);
        }

        public double VoxelToDisplayValue(int voxelValue)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.VoxelToDisplayValue(voxelValue); }
                );
                return vmsResult;
            }
            return (double) _client.VoxelToDisplayValue(voxelValue);
        }
    }
}