using MyMath;
using System;
using System.Drawing;

namespace Raytracer
{
    class Shape
    {
        public Vector3 Position;
        public Material Material;
        public Transformation transformation;
        public Transformation Inverse;

        public virtual Vector3 Normal(Vector3 pos)
        {
            throw new NotImplementedException();

        }

        public Shape(Vector3 position, Material material)
        {
            Position = position;
            Material = material;
        }

        public virtual float IsHitByRay(Ray ray)
        {
            throw new NotImplementedException();
        }
    }
}
