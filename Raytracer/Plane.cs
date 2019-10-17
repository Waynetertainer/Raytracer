using System;
using MyMath;
using System.Drawing;

namespace Raytracer
{
    class Plane : Shape
    {
        public Vector3 Normale;
        public Plane(Vector3 normale, Vector3 position, Material material) : base(position*(-1), material)
        {
            Normale = normale;
            //Transformation = new Matrix(4, 4)
            //{
            //    [0, 0] = 1,
            //    [1, 1] = 1,
            //    [2, 2] = 1,
            //    [3, 0] = position.x,
            //    [3, 1] = position.y,
            //    [3, 2] = position.z,
            //    [3, 3] = 1
            //};
            //Console.WriteLine(Transformation);
            //Inverse = Matrix.GetInverse(Transformation);
            //Console.WriteLine(Inverse);
        }

        public override Vector3 Normal(Vector3 pos)
        {
            return Normale;
        }

        public override float IsHitByRay(Ray ray)
        {
            float a = Vector3.Dot(Normale, ray.Position) + Vector3.Dot(Normale, Position);
            float b = Vector3.Dot(Normale, ray.Direction);
            return Math.Abs(b) < 0.000001 ? -1 : -a / b;
        }
    }
}
