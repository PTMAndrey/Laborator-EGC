using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Tema
{
    class Cub
    {
        private const String FISIER = "coordonate.txt";

        private List<Vector3> listaCoordonate;
        char[] sep = { ' ' };
        private Color[] ColorV2 = new Color[39];

        public Cub()
        {
            listaCoordonate = CitireFisier(FISIER);
            SetareCuloare();
        }


        /* puteam sa dau valori random folosind metoda FurnizeazaCuloareAleatorie insa am zis sa am culori fixe pentru a testa daca merge randomizarea la apasarea tastei X */
        public void SetareCuloare() 
        {
            ColorV2[9] = ColorV2[1] = ColorV2[5] = Color.FromArgb(255, 30, 30);
            ColorV2[3] = ColorV2[34] = ColorV2[2] = Color.FromArgb(0, 0, 0);
            ColorV2[33] = ColorV2[7] = ColorV2[8] = Color.FromArgb(22, 82, 77);
            ColorV2[17] = ColorV2[37] = ColorV2[11] = Color.FromArgb(22, 82,77);
            ColorV2[15] = ColorV2[31] = ColorV2[14] = Color.FromArgb(82, 9, 66);
            ColorV2[13] = ColorV2[16] = ColorV2[38] = Color.FromArgb(255, 255, 1);
            ColorV2[18] = ColorV2[22] = ColorV2[30] = Color.FromArgb(50, 8, 5);
            ColorV2[0] = ColorV2[19] = ColorV2[23] = Color.FromArgb(255, 0, 255);
            ColorV2[24] = ColorV2[25] = ColorV2[20] = Color.FromArgb(11, 111, 23);
            ColorV2[6] = ColorV2[28] = ColorV2[29] = Color.FromArgb(55, 0, 34);
            ColorV2[32] = ColorV2[15] = ColorV2[26] = Color.FromArgb(94, 172, 13);
            ColorV2[27] = ColorV2[4] = ColorV2[35] = Color.FromArgb(88, 0, 88);
            ColorV2[21] = ColorV2[10] = ColorV2[36] = Color.FromArgb(2, 0, 85);
        }

        public void SchimbareCuloare(Randomizer r)
        {
            Color color1;
            int i = r.FurnizareNumarAleator();
            color1 = r.FurnizareCuloareAleatorie();
            ColorV2[i] = color1;
            Console.WriteLine(ColorV2[i] + "  ");
            
            Console.WriteLine("\n\n######################################################################\n\n");
        }

        public void Desenare()
        {
            int j = 0;
            GL.Begin(PrimitiveType.Triangles);
            foreach (var vert in listaCoordonate)
            {
                GL.Color3(ColorV2[j]);
                GL.Vertex3(vert);
                j++;
            }
            GL.End();

        }

        private List<Vector3> CitireFisier(string fis)
        {
            List<Vector3> vlc3 = new List<Vector3>();

            var lines = File.ReadLines(fis);
            foreach (var line in lines)
            {
                string[] numere = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                Vector3 vec = new Vector3(Convert.ToInt32(numere[0]), Convert.ToInt32(numere[1]), Convert.ToInt32(numere[2]));
                vlc3.Add(vec);
            }
            return vlc3;
        }
    }
}
