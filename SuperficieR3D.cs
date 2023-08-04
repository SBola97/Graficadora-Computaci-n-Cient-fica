using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class SuperficieR3D : Vector3D
    {
        public int tipo; 
        public double fv; //factor de visualizacion

        public SuperficieR3D(double fv)
        {
            this.fv = fv;
        }

        public override void Encender(Bitmap canva)
        {
            Vector3D v = new Vector3D(0, 0, 0, color0);

            if (tipo == 1) //paraboloide (z = x^2 + y^2)
            {
                float x = -6, dx = 0.07f;
                do
                {
                    float y = -4, dy = 0.07f;
                    do
                    {
                        //implementación 
                        v.x0 = x;
                        v.y0 = y;
                        v.z0 = fv * (Math.Pow(x,2) + Math.Pow(y,2)) - 4.5;
                        v.Encender(canva);
                        y = y + dy;
                    }
                    while (y <= 4); // altura
                    x = x + dx;
                } while (x <= 6);
            }

            if (tipo == 2) //paraboloide hiperbolico ( z = x^2 - y^2)
            {
                float x = -6, dx = 0.07f;
                do
                {
                    float y = -4, dy = 0.07f;
                    do
                    {
                        v.x0 = x;
                        v.y0 = y;
                        v.z0 = fv * (Math.Pow(y, 2) - Math.Pow(x, 2)) ;
                        v.Encender(canva);
                        y = y + dy;
                    }
                    while (y <= 4); // altura
                    x = x + dx;
                } while (x <= 6);
            }

            if (tipo == 3) //epsilon 
            {
                float x = -6, dx = 0.07f;
                do
                {
                    float y = -4, dy = 0.07f;
                    do
                    {
                        v.x0 = x;
                        v.y0 = y;
                        v.z0 = fv * (Math.Pow(Math.E,-(Math.Pow(x,2) + Math.Pow(y,2))));
                        v.Encender(canva);
                        y = y + dy;
                    }
                    while (y <= 4); // altura
                    x = x + dx;
                } while (x <= 6);
            }
        }
    }
}
