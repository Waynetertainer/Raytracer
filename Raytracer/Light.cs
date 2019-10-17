using System;
using MyMath;
using System.Drawing;

namespace Raytracer
{
    public class Light
    {
        public Vector3 Position;
        public Color Color;
        public float Intensity;

        public Light(Vector3 position, Color color, float intensity)
        {
            Position = position;
            Color = color;
            Intensity = intensity;
        }

        public float Distance(Vector3 input)
        {
            Vector3 temp = Position - input;
            return (float) Math.Sqrt(temp.x.Sq() + temp.y.Sq() + temp.z.Sq());
        }
    }
}
