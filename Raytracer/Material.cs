using MyMath;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Raytracer
{
    class Material
    {
        public Color Color;
        public float Ambient;
        public float Diffuse;
        public float Reflection;
        public float Shiny;
        public Scene Scene;

        public Material(Color color, float ambient, float diffuse, float reflection, float shiny, Scene scene)
        {
            Color = color;
            Ambient = ambient;
            Diffuse = diffuse;
            Reflection = reflection;
            Shiny = shiny;
            Scene = scene;
        }

        public Color GetColor(Shape obj, List<Light> lights, Vector3 hit, Ray ray)
        {
            //Color result = Color.FromArgb(0, 0, 0);
            Color result = Color.Multiply(Ambient);
            //Color result=new Color();
            foreach (Light light in lights)
            {
                float nearestDist = float.MaxValue;
                Vector3 vLight = (light.Position - hit).normalized;
                foreach (Shape shape in Scene.Objects)
                {
                    if (shape == obj) continue;
                    float temp = shape.IsHitByRay(new Ray(hit, vLight));
                    if (temp >= 0 && temp < nearestDist)
                    {
                        nearestDist = temp;
                    }
                }

                if (light.Distance(hit) <= nearestDist)
                {
                    Vector3 normal = obj.Normal(hit);
                    float cosAlpha = Vector3.Dot(normal, vLight);
                    Color diffuse = light.Color.Multiply(cosAlpha < 0 ? 0 : cosAlpha * Diffuse);
                    result = result.Add(diffuse).Multiply(light.Intensity);

                    Vector3 reflection = (normal * 2 * Vector3.Dot(normal, vLight) - vLight).normalized;
                    float specular = (float)Math.Pow(Reflection * Vector3.Dot(reflection, ray.Direction * (-1)), Shiny);
                    result = result.Add(light.Color.Multiply(specular).Multiply(light.Intensity));
                }

            }
            return result;
        }
    }
}
