using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClSuperficie3D : Vector3D
    {
        public int tipo; // Identifica el tipo de superficie
        public double Rd; // radio
        double dosPI = (2 * Math.PI);

        public ClSuperficie3D()
        {
        }

        public ClSuperficie3D(double Rd)
        {
            this.Rd = Rd;
        }
        public override void Encender(Bitmap viewPort)
        {
            double t, dt;

            if (tipo == 1)
            {
                t = 0;
                dt = 0.1f; 
                double tf = (2 * Math.PI); //límite de t
                
                Vector3D v = new Vector3D(0, 0, 0, color0);

                //Dos grados de libertad: t y h

                do
                {
                    float h = 0, dh = 0.15f;
                    do
                    {
                        //Nota: xo,y0,z0 sirven para posicionar en el espacio
                        v.x0 = x0 + (Rd * Math.Cos(t));
                        v.y0 = y0 + (Rd * Math.Sin(t));
                        v.z0 = z0 + h; 
                        v.Encender(viewPort);
                        h = h + dh;
                    }
                    while (h <= 4); // altura

                    t = t + dt;

                } while (t <= tf);
            }

            if (tipo == 2)
            {
                dosPI = (2 * Math.PI);
                double piMed = (Math.PI / 2);
                t = -piMed;
                dt = 0.1f;
                Vector3D v = new Vector3D(0, 0, 0, color0);
                do
                {
                    float h = 0, dh = 0.15f;
                    do
                    {
                        v.x0 = x0 + (Rd * Math.Cos(t) * Math.Cos(h));
                        v.y0 = y0 + (Rd * Math.Cos(t) * Math.Sin(h));
                        v.z0 = z0 + Rd * Math.Sin(t);
                        v.Encender(viewPort);
                        h = h + dh;
                    }
                    while (h <= dosPI); 

                    t = t + dt;

                } while (t <= piMed);
            }

            if (tipo == 3)
            {
                dosPI = (2 * Math.PI);
                t = 0;
                dt = 0.1f;
                Vector3D v = new Vector3D(0, 0, 0, color0);
                do
                {
                    float h = 0, dh = 0.15f;
                    do
                    {
                        v.x0 = x0 + (Rd * (3 + Math.Cos(t)) * Math.Cos(h));
                        v.y0 = y0 + (Rd * (3 + Math.Cos(t)) * Math.Sin(h));
                        v.z0 = z0 + Rd * Math.Sin(t);
                        v.Encender(viewPort);
                        h = h + dh;
                    }
                    while (h <= dosPI); 

                    t = t + dt;

                } while (t <= dosPI);
            }

            if (tipo == 4) //hiperboloide 1 hoja
            {
                Vector3D v = new Vector3D(0, 0, 0, color0);
                t = -2;
                dt = 0.1f;
                //double a, b, c;
                do
                {
                    double h = -dosPI, dh = 0.09f;

                    do
                    {
                        v.x0 = x0 * (Math.Cosh(t) * Math.Cos(h));
                        v.y0 = y0 * (Math.Cosh(t) * Math.Sin(h));
                        v.z0 = z0 * Math.Sinh(t);
                        v.Encender(viewPort);
                        h = h + dh;
                    }
                    while (h <= dosPI);

                    t = t + dt;

                } while (t <= 2);

            }
        }
    }
}
