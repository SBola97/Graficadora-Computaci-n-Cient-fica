using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClVector
    {
        public double x0;
        public double y0;
        public Color color0;

        //Dimensión ViewPort Inicio y Fin
        public static int sx1 = 0;
        public static int sy1 = 0;
        public static int sx2 = 700;
        public static int sy2 = 500;

        //Factor de congruencia (700/500 = 1.4) para determinar los valores de y sin deformar ViewPort
        //1.15 (600/520) 

        //Plano cartesiano (Escala interna) (ventana real)

        private double x1 = -10.5, x2 = 10.5; // 14
        private double y1 = -7.5, y2 = 7.5; // 14/1.4 -> 10

        /*
        private double x1 = -10.5, x2 = 10.5;
        private double y1 = -7.5, y2 = 7.5; */

        /*
        private double x1 = -6, x2 = 5.2 ; // 8 * 1.15 = 9.2
        private double y1 = 5, y2 = -3; // 8
        */

        public ClVector()
        { }
        public ClVector(double x0, double y0, Color color0)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.color0 = color0;
        }
        virtual public void Encender(Bitmap canva)
        {
            int sX, sY;

            Pantalla(x0, y0, out sX, out sY);

            if (sX >= 0 && sX < 700 && sY >= 0 && sY < 500)
            {
                canva.SetPixel(sX, sY, color0);
            }
        }
        public void Pantalla(double x, double y, out int sx, out int sy)
        {
            sx = (int)(((x - x1) / (x1 - x2)) * (sx1 - sx2)) + sx1;
            sy = (int)(((y - y2) / (y2 - y1)) * (sy1 - sy2)) + sy1;
        }
        public void Transforma(int sx, int sy, out double x, out double y)
        {
            x = ((x1 - x2) * (sx - sx1) / (sx1 - sx2)) + x1;
            y = ((y2 - y1) * (sy - sy1) / (sy1 - sy2)) + y2;
        }

        public void Apagar(Bitmap canva)
        {
            color0 = Color.FromArgb(255, 255, 255, 255);
            Encender(canva);
        }

    }
}
