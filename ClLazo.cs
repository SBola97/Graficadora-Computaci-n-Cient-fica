using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewPort_6617
{
    internal class ClLazo : ClCircunferencia
    {
        public ClLazo(double rd)
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
                v.x0 = x0 + rd * Math.Sin(2*t);
                v.y0 = y0 + rd * Math.Cos(3*t);
                /*
                int r = (int)ClUtil.interpolar2Puntos(t, 0.0, 0.0, 2 * Math.PI, 105);
                int g = (int)ClUtil.interpolar2Puntos(t, 0.0, 139, 2 * Math.PI, 105);
                int b = (int)ClUtil.interpolar2Puntos(t, 0.0, 139, 2 * Math.PI, 105);
                Color color = Color.FromArgb(r, g, b);
                v.color0 = color;*/

                v.Encender(canva);
                t = t + dt;
            }
            while (t <= 2 * Math.PI);
        }
    }
}
