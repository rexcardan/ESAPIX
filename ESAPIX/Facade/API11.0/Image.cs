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
    public class Image : ESAPIX.Facade.API.ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("CreationDateTime"))
                    {
                        return _client.CreationDateTime;
                    }
                    else
                    {
                        return default (System.Nullable<System.DateTime>);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.CreationDateTime;
                    }

                    );
                }
                else
                {
                    return default (System.Nullable<System.DateTime>);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.CreationDateTime = (value);
                }
                else
                {
                }
            }
        }

        public ESAPIX.Facade.API.Series Series
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Series"))
                    {
                        return _client.Series;
                    }
                    else
                    {
                        return default (ESAPIX.Facade.API.Series);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        if ((_client.Series) != (null))
                        {
                            return new ESAPIX.Facade.API.Series(_client.Series);
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
                    return default (ESAPIX.Facade.API.Series);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.Series = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 XSize
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("XSize"))
                    {
                        return _client.XSize;
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
                        return _client.XSize;
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
                    _client.XSize = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 YSize
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("YSize"))
                    {
                        return _client.YSize;
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
                        return _client.YSize;
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
                    _client.YSize = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 ZSize
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ZSize"))
                    {
                        return _client.ZSize;
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
                        return _client.ZSize;
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
                    _client.ZSize = (value);
                }
                else
                {
                }
            }
        }

        public System.Double XRes
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("XRes"))
                    {
                        return _client.XRes;
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
                        return _client.XRes;
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
                    _client.XRes = (value);
                }
                else
                {
                }
            }
        }

        public System.Double YRes
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("YRes"))
                    {
                        return _client.YRes;
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
                        return _client.YRes;
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
                    _client.YRes = (value);
                }
                else
                {
                }
            }
        }

        public System.Double ZRes
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ZRes"))
                    {
                        return _client.ZRes;
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
                        return _client.ZRes;
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
                    _client.ZRes = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector Origin
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Origin"))
                    {
                        return _client.Origin;
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
                        return _client.Origin;
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
                    _client.Origin = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector XDirection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("XDirection"))
                    {
                        return _client.XDirection;
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
                        return _client.XDirection;
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
                    _client.XDirection = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector YDirection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("YDirection"))
                    {
                        return _client.YDirection;
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
                        return _client.YDirection;
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
                    _client.YDirection = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector ZDirection
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ZDirection"))
                    {
                        return _client.ZDirection;
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
                        return _client.ZDirection;
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
                    _client.ZDirection = (value);
                }
                else
                {
                }
            }
        }

        public System.String FOR
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("FOR"))
                    {
                        return _client.FOR;
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
                        return _client.FOR;
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
                    _client.FOR = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean HasUserOrigin
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("HasUserOrigin"))
                    {
                        return _client.HasUserOrigin;
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
                        return _client.HasUserOrigin;
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
                    _client.HasUserOrigin = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.VVector UserOrigin
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UserOrigin"))
                    {
                        return _client.UserOrigin;
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
                        return _client.UserOrigin;
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
                    _client.UserOrigin = (value);
                }
                else
                {
                }
            }
        }

        public System.String DisplayUnit
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("DisplayUnit"))
                    {
                        return _client.DisplayUnit;
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
                        return _client.DisplayUnit;
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
                    _client.DisplayUnit = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 Window
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Window"))
                    {
                        return _client.Window;
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
                        return _client.Window;
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
                    _client.Window = (value);
                }
                else
                {
                }
            }
        }

        public System.Int32 Level
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("Level"))
                    {
                        return _client.Level;
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
                        return _client.Level;
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
                    _client.Level = (value);
                }
                else
                {
                }
            }
        }

        public System.String ContrastBolusAgentIngredientName
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ContrastBolusAgentIngredientName"))
                    {
                        return _client.ContrastBolusAgentIngredientName;
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
                        return _client.ContrastBolusAgentIngredientName;
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
                    _client.ContrastBolusAgentIngredientName = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.PatientOrientation ImagingOrientation
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("ImagingOrientation"))
                    {
                        return _client.ImagingOrientation;
                    }
                    else
                    {
                        return default (VMS.TPS.Common.Model.Types.PatientOrientation);
                    }
                }
                else if ((XC.Instance) != (null))
                {
                    return XC.Instance.GetValue(sc =>
                    {
                        return _client.ImagingOrientation;
                    }

                    );
                }
                else
                {
                    return default (VMS.TPS.Common.Model.Types.PatientOrientation);
                }
            }

            set
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    _client.ImagingOrientation = (value);
                }
                else
                {
                }
            }
        }

        public System.Boolean IsProcessed
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("IsProcessed"))
                    {
                        return _client.IsProcessed;
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
                        return _client.IsProcessed;
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
                    _client.IsProcessed = (value);
                }
                else
                {
                }
            }
        }

        public System.String UserOriginComments
        {
            get
            {
                if ((_client) is System.Dynamic.ExpandoObject)
                {
                    if (((ExpandoObject)(_client)).HasProperty("UserOriginComments"))
                    {
                        return _client.UserOriginComments;
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
                        return _client.UserOriginComments;
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
                    _client.UserOriginComments = (value);
                }
                else
                {
                }
            }
        }

        public VMS.TPS.Common.Model.Types.ImageProfile GetImageProfile(VMS.TPS.Common.Model.Types.VVector start, VMS.TPS.Common.Model.Types.VVector stop, System.Double[] preallocatedBuffer)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.GetImageProfile(start, stop, preallocatedBuffer));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.ImageProfile)))
                    {
                        return default (VMS.TPS.Common.Model.Types.ImageProfile);
                    }

                    return (VMS.TPS.Common.Model.Types.ImageProfile)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.ImageProfile)(_client.GetImageProfile(start, stop, preallocatedBuffer));
            }
        }

        public void GetVoxels(System.Int32 planeIndex, System.Int32[,] preallocatedBuffer)
        {
            if ((XC.Instance) != (null))
            {
                XC.Instance.Invoke(() =>
                {
                    _client.GetVoxels(planeIndex, preallocatedBuffer);
                }

                );
            }
            else
            {
                _client.GetVoxels(planeIndex, preallocatedBuffer);
            }
        }

        public System.Double VoxelToDisplayValue(System.Int32 voxelValue)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.VoxelToDisplayValue(voxelValue));
                    if (fromClient.Equals(default (System.Double)))
                    {
                        return default (System.Double);
                    }

                    return (System.Double)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (System.Double)(_client.VoxelToDisplayValue(voxelValue));
            }
        }

        public VMS.TPS.Common.Model.Types.VVector UserToDicom(VMS.TPS.Common.Model.Types.VVector user, ESAPIX.Facade.API.PlanSetup planSetup)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.UserToDicom(user, planSetup._client));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.VVector)))
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }

                    return (VMS.TPS.Common.Model.Types.VVector)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.VVector)(_client.UserToDicom(user, planSetup));
            }
        }

        public VMS.TPS.Common.Model.Types.VVector DicomToUser(VMS.TPS.Common.Model.Types.VVector dicom, ESAPIX.Facade.API.PlanSetup planSetup)
        {
            if ((XC.Instance) != (null))
            {
                var vmsResult = (XC.Instance.GetValue(sc =>
                {
                    var fromClient = (_client.DicomToUser(dicom, planSetup._client));
                    if (fromClient.Equals(default (VMS.TPS.Common.Model.Types.VVector)))
                    {
                        return default (VMS.TPS.Common.Model.Types.VVector);
                    }

                    return (VMS.TPS.Common.Model.Types.VVector)(fromClient);
                }

                ));
                return vmsResult;
            }
            else
            {
                return (VMS.TPS.Common.Model.Types.VVector)(_client.DicomToUser(dicom, planSetup));
            }
        }

        public Image()
        {
            _client = (new ExpandoObject());
        }

        public Image(dynamic client)
        {
            _client = (client);
        }
    }
}