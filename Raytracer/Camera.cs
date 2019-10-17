using MyMath;
using System;

namespace Raytracer
{
    public class Camera
    {
        private MyScreen mScreen;

        public Vector3 ViewPoint;
        private Vector3 mSide;
        private Vector3 mViewDirection;
        private Vector3 mCameraUp;
        private float mHeight;
        private float mWidth;
        private Vector3 mMiddle;

        public Camera(MyScreen screen, Vector3 viewPoint, Vector3 userUp, float angle, Vector3 center = null)
        {
            mScreen = screen;
            ViewPoint = viewPoint;
            mViewDirection = (center ?? new Vector3() - ViewPoint).normalized;
            //mViewDirection = (ViewPoint-(center ?? new Vector3())).normalized;
            mSide = Vector3.Cross(mViewDirection, userUp).normalized;
            mCameraUp = Vector3.Cross(mSide, mViewDirection).normalized;

            mHeight = 2 * (float)Math.Tan(angle * (Math.PI / 180) / 2);
            mWidth = mHeight * mScreen.Width / mScreen.Height;
            mMiddle = ViewPoint + mViewDirection;
        }

        public Vector3 GetViewDirection(int x, int y)
        {
            Vector2 pNorm = new Vector2(2 * (x + 0.5f) / mScreen.Width - 1, 2 * (y + 0.5f) / mScreen.Height - 1);
            return ((mCameraUp * mHeight * pNorm.y) + (mSide * mWidth * pNorm.x) + mViewDirection).normalized;
        }
    }
}
