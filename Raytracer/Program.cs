using MyMath;
using System;
using System.Windows.Forms;

namespace Raytracer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyScreen());

            Matrix test = new Matrix(3, 3)
            {
                [0, 0] = 1,
                [0, 1] = 4,
                [0, 2] = 2,
                [1, 0] = 2,
                [1, 1] = 1,
                [1, 2] = 3,
                [2, 0] = 3,
                [2, 1] = 2,
                [2, 2] = 1,
            };
            Console.WriteLine(Matrix.Determinante(test));
            Console.WriteLine(Matrix.GetAdjugate(test));
        }
    }
}
