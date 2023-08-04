using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class Vector3D : ClVector
    {
        
        public double z0;
        public Vector3D() { }
        public Vector3D(double x0, double y0, double z0, Color color)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.z0 = z0;
            this.color0 = color;
        }

        public override void Encender(Bitmap canva)
        {
            double ax, ay; //plano axonometrico
            
            int sx, sy; //coordenadas monitor
            
            //Vector Real 3D a plano axonometrico real 2D
            Axonometria(x0, y0, z0, out ax, out ay);

            //Coordenadas axonometricas a coordenadas de monitor
            Pantalla(ax, ay, out sx, out sy);

            //Control para mantenerlo dentro del picture box y encender pixel
            if (sx >= 0 && sx < 700 && sy >= 0 && sy < 500)
            {
                canva.SetPixel(sx, sy, color0);
            }
        }
        //Pasar del plano 3D a Plano Real (Axonometrico 2D)
        public void Axonometria(double x, double y, double z, out double ax, out double ay)
        {
            const double alfa = 0.785; //45º o PI/4
            ax = y - ((x / 2) * Math.Cos(alfa));
            ay = z - ((x / 2) * Math.Sin(alfa));

        }

    }
}

