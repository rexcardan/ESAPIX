using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ESAPIX.Helpers
{
    public class ObjFileWriter
    {
        public static void Write(MeshGeometry3D model, string outputPath)
        {
            var sb = new StringBuilder();
            // Write the header lines
            sb.AppendLine("#");
            sb.AppendLine("# OBJ file created Abacus lib");
            sb.AppendLine("#");

            // Sequentially write the 3 vertices of the triangle, for each triangle
            for (int i = 0; i < model.Positions.Count; i++)
            {
                var vertex = model.Positions[i];
                string vertexString = "v " + vertex.X.ToString(CultureInfo.InvariantCulture) + " ";
                vertexString += vertex.Y.ToString(CultureInfo.InvariantCulture) + " " +
                                vertex.Z.ToString(CultureInfo.InvariantCulture);
                sb.AppendLine(vertexString);
            }

            // Sequentially write the 3 normals of the triangle, for each triangle
            for (int i = 0; i < model.Normals.Count; i++)
            {
                var normal = model.Normals[i];
                string normalString = "vn " + normal.X.ToString(CultureInfo.InvariantCulture) + " ";
                normalString += normal.Y.ToString(CultureInfo.InvariantCulture) + " " +
                                normal.Z.ToString(CultureInfo.InvariantCulture);
                sb.AppendLine(normalString);
            }

            for (int i = 0; i < model.TriangleIndices.Count / 3; i++)
            {
                string baseIndex0 = (model.TriangleIndices[i * 3] + 1).ToString(CultureInfo.InvariantCulture);
                string baseIndex1 = (model.TriangleIndices[i * 3 + 1] + 1).ToString(CultureInfo.InvariantCulture);
                string baseIndex2 = (model.TriangleIndices[i * 3 + 2] + 1).ToString(CultureInfo.InvariantCulture);

                string faceString = "f " + baseIndex0 + "//" + baseIndex0 + " " + baseIndex1 + "//" + baseIndex1 + " " +
                                    baseIndex2 + "//" + baseIndex2;
                sb.AppendLine(faceString);
            }
            File.WriteAllText(outputPath, sb.ToString());
        }
    }
}
