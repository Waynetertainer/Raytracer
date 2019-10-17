using System.Drawing;
using MyMath;

namespace Raytracer
{
    public class PointLight : Light
    {
        public PointLight(Vector3 position, Color color, float intensity) : base(position, color, intensity)
        {
        }
    }
}
