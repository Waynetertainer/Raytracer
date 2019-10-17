using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MyMath;

namespace Raytracer
{
    public static class Extensions
    {
        public static Color Multiply(this Color a, float b)
        {
            return Color.FromArgb(((int) (a.R * b)), ((int) (a.B * b)), ((int) (a.G * b)));
        }

        public static Color Add(this Color a, Color b)
        {
            int R = (a.R + b.R).Clamp(255);
            int G = (a.G + b.G).Clamp(255);
            int B = (a.B + b.B).Clamp(255);
            return Color.FromArgb(R,G,B);
        }
    }
}
