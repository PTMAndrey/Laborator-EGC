using System;
using System.Drawing;

namespace Tema
{
    class Randomizer
    {
        Random rnd;


        public Randomizer()
        { rnd= new Random(); }

        public Color FurnizareCuloareAleatorie()
        {
            int R = rnd.Next(0, 255);
            int G = rnd.Next(0, 255);
            int B = rnd.Next(0, 255);

            Color color = Color.FromArgb(R, G, B);
            
            return color;
        }

        public int FurnizareNumarAleator()
        {
            int nr = rnd.Next(0, 38);
            return nr;
        }
    }
}
