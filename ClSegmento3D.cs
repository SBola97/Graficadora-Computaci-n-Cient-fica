using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClSegmento3D : Vector3D
    {
        public double xf;
        public double yf;
        public double zf;

        public ClSegmento3D(double xf, double yf, double zf)
        {
            this.xf = xf;
            this.yf = yf;
            this.zf = zf;
        }

        public override void Encender(Bitmap canva)
        {
            double t = 0;
            double dt = 0.001;
            Vector3D v3d = new Vector3D(0, 0, 0, color0);
            do
            {
                v3d.x0 = x0 + (xf - x0) * t;
                v3d.y0 = y0 + (yf - y0) * t;
                v3d.z0 = z0 + (zf - z0) * t;
                v3d.Encender(canva);
                t = t + dt;
            }
            while (t <= 1);
        }
    }
}
