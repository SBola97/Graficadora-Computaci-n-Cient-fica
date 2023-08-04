using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClCircunferencia : ClVector
    {
        public double rd;

        public ClCircunferencia(double rd)
        {
            this.rd = rd;
        }

        public ClCircunferencia()
        { }

        public override void Encender(Bitmap canva)
        {
            float t = 0;
            float dt = 0.001f;
            ClVector v = new ClVector(0, 0, color0);
            do
            {
                v.x0 = x0+rd*Math.Cos(t);
                v.y0 = y0+rd*Math.Sin(t);
                v.Encender(canva);
                t = t + dt;
            }
            while (t <= 2 * Math.PI);
        }
    }
}
