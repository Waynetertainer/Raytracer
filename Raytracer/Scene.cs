using System.Collections.Generic;

namespace Raytracer
{
    class Scene
    {
        public List<Shape> Objects = new List<Shape>();
        public List<Light> Lights = new List<Light>();
    }
}
