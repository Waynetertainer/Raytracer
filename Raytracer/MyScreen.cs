using MyMath;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Raytracer
{
    public partial class MyScreen : Form
    {
        private Bitmap mImage;
        private Camera mCamera;
        private Raytracer mRaytracer;
        private Scene mScene;

        public MyScreen()
        {
            InitializeComponent();
        }

        private void TargetWindow_Load(object sender, EventArgs e)
        {
            mImage = new Bitmap(this.Width, Height, PixelFormat.Format24bppRgb);
            mCamera = new Camera(this, new Vector3(0, 0, 17), new Vector3(0, 1, 0), 35);
            mScene = new Scene();                                                                                         //ambient diffuse reflection shiny
            mScene.Objects.Add(new Sphere(1,                      new Vector3( 0,  0,  1), new Material(Color.Aqua,         0.5f,   0.2f,   0.8f,      4, mScene)));
            mScene.Objects.Add(new Sphere(1,                      new Vector3( 1,  1,  0), new Material(Color.Red,          0.5f,   0.2f,   0.8f,      4, mScene)));
            //mScene.Objects.Add(new Sphere(1,                      new Vector3( 1, -1,  0), new Material(Color.Blue,         0.5f,   0.2f,   0.8f,      4, mScene)));
            mScene.Objects.Add(new Sphere(1,                      new Vector3(-1,  1,  2), new Material(Color.Green,        0.5f,   0.2f,   0.8f,      4, mScene)));
            mScene.Objects.Add(new Sphere(1,                      new Vector3(-1, -1,  2), new Material(Color.Black,        0.5f,   0.2f,   0.8f,      4, mScene)));
            mScene.Objects.Add(new Plane(new Vector3( 0,  0,  1), new Vector3( 0,  0, -3), new Material(Color.AntiqueWhite, 0.5f,   0.2f,   0.8f,      4, mScene)));//Back
            mScene.Objects.Add(new Plane(new Vector3( 0, -1,  0), new Vector3( 0,  3,  0), new Material(Color.SkyBlue,      0.5f,   0.2f,   0.8f,      4, mScene)));//Top
            mScene.Objects.Add(new Plane(new Vector3( 1,  0,  0), new Vector3(-3,  0,  0), new Material(Color.LightGreen,   0.5f,   0.2f,   0.8f,      4, mScene)));//Left
            mScene.Objects.Add(new Plane(new Vector3(-1,  0,  0), new Vector3( 3,  0,  0), new Material(Color.ForestGreen,  0.5f,   0.2f,   0.8f,      4, mScene)));//Right
            mScene.Objects.Add(new Plane(new Vector3( 0,  1,  0), new Vector3( 0, -3,  0), new Material(Color.SaddleBrown,  0.5f,   0.2f,   0.8f,      4, mScene)));//Bottom

            mScene.Lights.Add(new PointLight(new Vector3(1,2.5f,1),Color.White,1f ));
            mScene.Lights.Add(new PointLight(new Vector3(-1,2.5f,1),Color.White,1f ));
            mRaytracer = new Raytracer(mCamera, mScene);
        }

        private void TargetWindow_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            for (int i = 0; i < mImage.Width; i++)
            {
                for (int j = 0; j < mImage.Height; j++)
                {

                    //mImage.SetPixel(i, j, Color.FromArgb(i % 255, j % 255, 0));
                    mImage.SetPixel(i, mImage.Height-j-1, mRaytracer.GetColor(i, j));
                }
            }
            BackgroundImage = mImage;
        }
    }
}
