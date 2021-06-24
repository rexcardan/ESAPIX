using ESAPIX.Extensions;
using System.Numerics;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Helpers
{
    public static class MathHelper
    {
        public static double Interpolate(double x1, double x3, double y1, double y3, double x2)
        {
            return (x2 - x1) * (y3 - y1) / (x3 - x1) + y1;
        }

        public static Vector3 IntersectPoint(Vector3 rayVector, Vector3 rayPoint, Vector3 planeNormal, Vector3 planePoint)
        {
            var diff = rayPoint - planePoint;
            var prod1 = Vector3.Dot(diff, planeNormal);
            var prod2 = Vector3.Dot(rayVector, planeNormal);
            var prod3 = prod1 / prod2;
            return rayPoint - rayVector * prod3;
        }
    }
}