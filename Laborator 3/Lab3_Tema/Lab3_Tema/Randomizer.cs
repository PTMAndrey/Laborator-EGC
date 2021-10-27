﻿using OpenTK;
using System;
using System.Drawing;

namespace Lab3_Tema
{
    class Randomizer
    {
        private Random r;
        private const int MIN_VAL = -25;
        private const int MAX_VAL = 25;

        public Randomizer()
        {
            r = new Random();
        }

        /// <summary>
        /// Genereaza culoare random!
        /// </summary>
        /// <returns>Culoarea randomizata....</returns>
        public Color GenerateColor()
        {
            int genR = r.Next(0, 256);
            int genG = r.Next(0, 256);
            int genB = r.Next(0, 256);

            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }

        public Vector3 Generate3DPoint()
        {
            int a = r.Next(MIN_VAL, MAX_VAL);
            int b = r.Next(MIN_VAL, MAX_VAL);
            int c = r.Next(MIN_VAL, MAX_VAL);

            Vector3 vec = new Vector3(a, b, c);

            return vec;
        }
    }
}
