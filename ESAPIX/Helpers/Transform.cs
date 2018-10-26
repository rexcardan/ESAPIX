using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Helpers
{
    public class Transform
    {
        /// <summary>
        /// Provides the transformation from patient DICOM coordinates to IEC coordinates, adjusted for the isocenter position.
        /// Useful for rendering structures.
        /// </summary>
        /// <param name="orient">patient orienation</param>
        /// /// <param name="iso">isocenter position</param>
        /// <returns>4x4 transformation matrix</returns>
        public static Matrix3D DICOM2IEC_IsoAdjusted(PatientOrientation orient, VVector iso)
        {
            var basic = DICOM2IEC(orient);
            var offset = Matrix3D.Identity;
            offset.OffsetX = -iso.x;
            offset.OffsetY = -iso.y;
            offset.OffsetZ = -iso.z;

            return Matrix3D.Multiply(offset, basic);
        }

        /// <summary>
        /// Provides the transformation from patient DICOM coordinates to IEC coordinates. Useful for rendering
        /// structures.
        /// </summary>
        /// <param name="orient"></param>
        /// <returns>4x4 transformation matrix</returns>
        public static Matrix3D DICOM2IEC(PatientOrientation orient)
        {
            switch (orient)
            {
                case PatientOrientation.HeadFirstSupine:
                    return new Matrix3D(
                        1, 0, 0, 0,
                        0, 0, -1, 0,
                        0, 1, 0, 0,
                        0, 0, 0, 1);
                case PatientOrientation.HeadFirstProne:
                    return new Matrix3D(
                       -1, 0, 0, 0,
                       0, 0, 1, 0,
                       0, 1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.FeetFirstSupine:
                    return new Matrix3D(
                       -1, 0, 0, 0,
                       0, 0, -1, 0,
                       0, -1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.FeetFirstProne:
                    return new Matrix3D(
                       1, 0, 0, 0,
                       0, 0, 1, 0,
                       0, -1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.HeadFirstDecubitusLeft:
                    return new Matrix3D(
                       0, 0, -1, 0,
                       -1, 0, 0, 0,
                       0, 1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.HeadFirstDecubitusRight:
                    return new Matrix3D(
                       0, 0, 1, 0,
                       1, 0, 0, 0,
                       0, 1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.FeetFirstDecubitusLeft:
                    return new Matrix3D(
                       0, 0, -1, 0,
                       1, 0, 0, 0,
                       0, -1, 0, 0,
                       0, 0, 0, 1);
                case PatientOrientation.FeetFirstDecubitusRight:
                    return new Matrix3D(
                       0, 0, 1, 0,
                       -1, 0, 0, 0,
                       0, -1, 0, 0,
                       0, 0, 0, 1);
                default: throw new Exception("Don't have transform for this orientation!");
            }
        }

        /// <summary>
        /// Provides the transformation from IEC coordinates to patient DICOM coordinates. Useful for rendering
        /// structures.
        /// </summary>
        /// <param name="orient"></param>
        /// <returns>4x4 transformation matrix</returns>
        public static Matrix3D IECToDICOM(PatientOrientation orient)
        {
            var tx = DICOM2IEC(orient);
            tx.Invert();
            return tx;
        }
    }
}
