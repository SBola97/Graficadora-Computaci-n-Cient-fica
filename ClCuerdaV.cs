using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClCuerdaV : ClVector
    {
        public double t;

        public ClCuerdaV()
        {
        }

        public ClCuerdaV(double t)
        {
            this.t = t;
        }

        private double f(double x)
        {
            return ((-x) * (x - 3)) / 2;
        }

        private double g(double x)
        {
            return 1;
        }

        private void Fourier(double x, out double fou)
        {
            double pi = Math.PI;
            double ak, bk, l = 4;
            double c = 1; //constante

            int n = 0;
            double SumF = 0;

            do
            {
                n += 1;
                //ak = (2/3) * (0 + 4 * f(2) * Math.Sin(n * pi * 1 / 2) + f(4) * Math.Sin(n * pi));
                ak = (2 / 3) * (0 + 4 * f(2) * Math.Sin(n * pi / 2) + f(4) * Math.Sin(n * pi));
                ak *= 0.5;

                //bk = 0.667 * (0 + 4 * g(2) * Math.Sin(n * pi * 1 / 2) + g(4) * Math.Sin(n * pi));
                bk = 0.667 * (0 + 4 * g(2) * Math.Sin(n * pi / 2) + g(4) * Math.Sin(n * pi));
                bk *= 2 / (n * pi * c);

                SumF += (ak * Math.Cos((n * pi * c * t) / l) + bk * Math.Sin((n * pi * c * t) / l)) * Math.Sin((n * pi * x) / l);

            } while (n <= 20);
            fou = SumF;
        }

        public void Graficar(Bitmap screen)
        {
            ClVector vec = new ClVector();
            double h, dh;
            vec.color0 = color0;
            h = 0;
            dh = 0.002;
            do
            {
                vec.x0 = h;
                Fourier(h, out double fou);
                vec.y0 = fou;
                vec.Encender(screen);
                h += dh;
            } while (h <= 4);
        }
    }
}
