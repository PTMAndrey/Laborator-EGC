using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.IO;

namespace Lab3_Tema
{
    class Triunghi
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private Randomizer localRando;
        private PolygonMode polMode;

        public Triunghi(Randomizer _r)
        {
            localRando = _r;

            int contor = 0;

            char[] sep = { ' ' };
            using (System.IO.StreamReader f = new StreamReader("coordonate_varfuri_triunghi.txt"))
            {
                string linie;

                while ((linie = f.ReadLine()) != null && contor != 3)
                {
                    contor++;
                    // Console.WriteLine("######\n" + linie + "\n######\n");
                    string[] numere = linie.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    Vector3 vec = new Vector3(Convert.ToInt32(numere[0]), Convert.ToInt32(numere[1]), Convert.ToInt32(numere[2]));
                    if (contor == 1)
                        pointA = vec;
                    else
                        if (contor == 2)
                        pointB = vec;
                    else
                        if (contor == 3)
                        pointC = vec;
                }
            }

            Inits();
        }

        private void Inits()
        {
            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);
                GL.End();
            }
        }

        public void Coloratura()
        {
            color = localRando.GenerateColor();
        }

    }
}
