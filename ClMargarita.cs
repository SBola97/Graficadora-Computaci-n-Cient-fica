using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClMargarita : ClCircunferencia
    {
        public ClMargarita(double rd)
        {
            this.rd = rd;
        }

        public override void Encender(Bitmap canva)
        {
            float t = 0;
            float dt = 0.001f;
            ClVector v = new ClVector(0, 0, color0);
            do
            {
                v.x0 = x0 + rd * Math.Cos(4 * t) * Math.Cos(t);
                v.y0 = y0 + rd * Math.Cos(4 * t)*Math.Sin(t);
                v.Encender(canva);
                t = t + dt;
            }
            while (t <= 2 * Math.PI);
        }
    }
}
