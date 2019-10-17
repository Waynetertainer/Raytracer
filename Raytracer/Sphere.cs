using MyMath;
using System;

namespace Raytracer
{
    class Sphere : Shape
    {
        public float Radius;

        public override Vector3 Normal(Vector3 pos)
        {
            return (pos - Position).normalized;
        }

        public Sphere(float radius, Vector3 position, Material material) : base(position, material)
        {
            Radius = radius;
            transformation = new Transformation()
            {
                [0, 0] = Radius,
                [1, 1] = Radius,
                [2, 2] = Radius,
                [3, 0] = position.x,
                [3, 1] = position.y,
                [3, 2] = position.z,
                [3, 3] = 1
            };
            Inverse = new Transformation(Matrix.Inverse(transformation));
        }

        public override float IsHitByRay(Ray ray)
        {
            ray.Position = Inverse * ray.Position;
            float b = 2 * (ray.Position.x * ray.Direction.x + ray.Position.y * ray.Direction.y + ray.Position.z * ray.Direction.z);
            float c = ray.Position.x * ray.Position.x + ray.Position.y * ray.Position.y + ray.Position.z * ray.Position.z - Radius * Radius;
            float d = b * b - 4 * c;
            if (d < 0) return -1;
            if (d < 0.0000001f) return -b * 0.5f;
            float t0 = (-b - (float)Math.Sqrt(d)) / 2;
            float t1 = (-b + (float)Math.Sqrt(d)) / 2;
            if (t0 < t1)
            {
                if (t0 >= 0) return t0;
                if (t1 >= 0) return t1;
                return -1;
            }

            if (t1 >= 0) return t1;
            if (t0 >= 0) return t0;
            return -1;
        }
    }
}
