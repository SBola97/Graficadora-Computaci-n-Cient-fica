using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClSegmento : ClVector
    {
        //Puntos finales
        public double xf;
        public double yf;

        public ClSegmento(double xf, double yf)
        {
            this.xf = xf;
            this.yf = yf;
        }

        public ClSegmento() { }

        public override void Encender(Bitmap canva)
        {
            double t = 0;
            double tf = 1;
            double dt = 0.001;
            ClVector v = new ClVector(0, 0, color0);
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.Encender(canva);
                t = t + dt;
            }
            while (t <= tf);

        }
    }
}
