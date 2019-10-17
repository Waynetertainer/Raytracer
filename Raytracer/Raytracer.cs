using MyMath;
using System.Drawing;

namespace Raytracer
{
    class Raytracer
    {
        private Scene mScene;
        private Camera mCamera;

        public Raytracer(Camera camera, Scene scene)
        {
            mCamera = camera;
            mScene = scene;
        }

        public Color GetColor(int x, int y)
        {
            Vector3 direction = mCamera.GetViewDirection(x, y);
            Ray ray = new Ray(mCamera.ViewPoint, direction);
            float nearestDistance = float.MaxValue;
            Shape nearestShape = null;
            foreach (Shape sceneObject in mScene.Objects)
            {
                float temp = sceneObject.IsHitByRay(ray);
                if (temp >= 0 && temp < nearestDistance)
                {
                    nearestDistance = temp;
                    nearestShape = sceneObject;
                }
            }

            return nearestShape?.Material.GetColor(nearestShape, mScene.Lights, ray.Position + ray.Direction * nearestDistance, ray) ?? Color.Black;
        }
    }
}
