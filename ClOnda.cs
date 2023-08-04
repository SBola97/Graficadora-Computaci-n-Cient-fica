using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace ViewPort_6617
{
    internal class ClOnda : ClVector
    {
        public double t; //instante
        public double dt;
        public double w, v;
        public double w1, w2;
        public ClOnda()
        {
        }

        public ClOnda(double t)
        {
            this.t = t;
        }

        public void Graf(Bitmap canva)
        {
            int i, j, color0;
            double x, y, z;
            w = 7; //longitud de onda
            v = 9.3; // velocidad de propagación de onda
            Color c;
            Form1 form1 = new Form1();
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Transforma(i, j, out x, out y);

                    //sqrt((x-0)^2 +(y-0)^2) fórmula para la distancia de dos puntos (x,y) a (0,0) fuente

                    z = w *(Math.Sqrt(x * x + y * y) - t * v);
                    z = Math.Sin(z) + 1; //dominio [0,2]

                    color0 = (int)(z * 7.5);
                    c = form1.llenarPaleta(1)[color0];
                    
                    canva.SetPixel(i, j, c);
                }
            }
            
        }
        
        public void Interferencia2w3d(Bitmap canva, Color color1)
        {
            Vector3D vec = new Vector3D();
            double x, y, z, z2, d1, d2;
            w1 = 1.5;
            w2 = 3.7;
            v = 9.3;
            double m = 0.7;
            x = -9;
            do
            {
                y = -6.5;
                do
                {
                    d1 = Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));
                    z = w1 * (d1 - (t * v));
                    z = (m) * Math.Sin(z);

                    d2 = Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3));
                    z2 = w2 * (d2 - (t * v));
                    z2 = (m) * Math.Sin(z2);

                    vec.x0 = x;
                    vec.y0 = y;
                    vec.z0 = z + z2;
                    vec.color0 = color1;
                    vec.Encender(canva);
                    y += 0.1;
                } while (y <= 6.5);
                x += 0.1;
            } while (x <= 9);
        }

        public void Interferencia2w2d(Bitmap canva)
        {
            int i, j, color0;
            double x, y, z, z1, z2;
            w1 = 1.1; //longitud de onda
            w2 = 0.5;
            v = 9.3; // velocidad de propagación de onda
            Color c;
            Form1 form1 = new Form1();
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Transforma(i, j, out x, out y);

                    z1 = w1 * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3)) - v * t);
                    z2 = w2 * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3)) - v * t);

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;

                    z = z1 + z2;

                    color0 = (int)(z * 3.75);
                    c = form1.llenarPaleta(1)[color0];

                    canva.SetPixel(i, j, c);
                }
            }
        }

        public void Interferencia(Bitmap canva)
        {
            int i, j, color0;
            double x, y, z,z1,z2;
            w = 1.5; //longitud de onda
            v = 9.3; // velocidad de propagación de onda
            Color c;
            Form1 form1 = new Form1();
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Transforma(i, j, out x, out y);

                    z1 = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3)) - v * t);
                    z2 = w * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3)) - v * t);

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;

                    z = z1 + z2;

                    color0 = (int)(z * 3.75);
                    c = form1.llenarPaleta(1)[color0];

                    canva.SetPixel(i, j, c);
                }
            }
        }
        //3 Fuentes
        public void Interferencia3(Bitmap canva)
        {
            int i, j, color0;
            double x, y, z, z1, z2, z3;
            w = 1.5; 
            v = 9.3; 
            Color c;
            Form1 form1 = new Form1();
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Transforma(i, j, out x, out y);

                    z1 = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3)) - v * t);
                    z2 = w * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3)) - v * t);
                    z3 = w * (Math.Sqrt((x + 3) * (x + 3) + (y - 2) * (y - 2)) - v * t); //(-3,2)

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;

                    z = z1 + z2 + z3;

                    color0 = (int)(z * 2.5);
                    c = form1.llenarPaleta(1)[color0];

                    canva.SetPixel(i, j, c);
                }
            }
        }

        public void Onda3D(Bitmap viewport,Color color1)
        {
            Vector3D vec = new Vector3D();
            int r, g, b;
            double x, y, z,z2, d1,d2;
            w = 1.5;
            v = 9.3;
            double m = 0.7;
            x = -9;
            do
            {
                y = -6.5;
                do
                {
                    d1 = Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));
                    z = w * (d1 - (t * v));
                    z = (m) * Math.Sin(z);
                    vec.color0 = color1;
                    vec.x0 = x;
                    vec.y0 = y;
                    vec.z0 = z;
                    vec.Encender(viewport);
                    y += 0.1;
                } while (y <= 6.5);
                x += 0.1;
            } while (x <= 9);

        }

        public void Interferencia3d(Bitmap viewport,Color color1)
        {
            Vector3D vec = new Vector3D();
            int r, g, b;
            double x, y, z, z2, d1, d2;
            w = 1.5;
            v = 9.3;
            double m = 0.7;
            x = -9;
            do
            {
                y = -6.5;
                do
                {
                    d1 = Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));
                    z = w * (d1 - (t * v));
                    z = (m) * Math.Sin(z);

                    d2 = Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3));
                    z2 = w * (d2 - (t * v));
                    z2 = (m) * Math.Sin(z2);

                    vec.x0 = x;
                    vec.y0 = y;
                    vec.z0 = z + z2;
                    vec.color0 = color1;
                    vec.Encender(viewport);
                    y += 0.1;
                } while (y <= 6.5);
                x += 0.1;
            } while (x <= 9);
        }

        public void Interferencia3f(Bitmap viewport,Color color1)
        {
            Vector3D vec = new Vector3D();
            double x, y, z, z2, z3, d1, d2, d3;
            w = 1.5;
            v = 9.3;
            double m = 0.7;
            x = -9;
            do
            {
                y = -6.5;
                do
                {
                    d1 = Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0));
                    z = w * (d1 - (t * v));
                    z = (m) * Math.Sin(z);

                    d2 = Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3));
                    z2 = w * (d2 - (t * v));
                    z2 = (m) * Math.Sin(z2);

                    d3 = Math.Sqrt((x + 3) * (x + 3) + (y - 2) * (y - 2));
                    z3 = w * (d3 - (t * v));
                    z3 = (m) * Math.Sin(z3);

                    vec.x0 = x;
                    vec.y0 = y;
                    vec.z0 = z + z2 + z3;
                    vec.color0 = color1;
                    vec.Encender(viewport);
                    y += 0.1;
                } while (y <= 6.5);
                x += 0.1;
            } while (x <= 9);
        }

        public void Huyguens(Bitmap pantalla)
        {
            int color1;
            Form1 form1 = new Form1();
            Color c;
            double x, y, z, z1, z2, z3, z4, z5, z6, z7, z8, z9, z10, z11;
            Double m, w;
            w = 1.2;
            v = 9.3;
            m = 1;

            for (int i = 0; i < 700; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                


                    Transforma(i, j, out x, out y);
                    z1 = w * (Math.Sqrt((x + 5) * (x + 5) + (y + 5) * (y + 5)) - (v * t));
                    z2 = w * (Math.Sqrt((x + 4) * (x + 4) + (y + 4) * (y + 4)) - (v * t));
                    z3 = w * (Math.Sqrt((x + 3) * (x + 3) + (y + 3) * (y + 3)) - (v * t));
                    z4 = w * (Math.Sqrt((x + 2) * (x + 2) + (y + 2) * (y + 2)) - (v * t));
                    z5 = w * (Math.Sqrt((x + 1) * (x + 1) + (y + 1) * (y + 1)) - (v * t));
                    z6 = w * (Math.Sqrt((x + 0) * (x + 0) + (y + 0) * (y + 0)) - (v * t));
                    z7 = w * (Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) - (v * t));
                    z8 = w * (Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) - (v * t));
                    z9 = w * (Math.Sqrt((x - 3) * (x - 3) + (y - 3) * (y - 3)) - (v * t));
                    z10 = w * (Math.Sqrt((x - 4) * (x - 4) + (y - 4) * (y - 4)) - (v * t));
                    z11 = w * (Math.Sqrt((x - 5) * (x - 5) + (y - 5) * (y - 5)) - (v * t));

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;
                    z4 = Math.Sin(z4) + 1;
                    z5 = Math.Sin(z5) + 1;
                    z6 = Math.Sin(z6) + 1;
                    z7 = Math.Sin(z7) + 1;
                    z8 = Math.Sin(z8) + 1;
                    z9 = Math.Sin(z9) + 1;
                    z10 = Math.Sin(z10) + 1;
                    z11 = Math.Sin(z11) + 1;
                    z = z1 + z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 + z10 + z11;
                    color1 = (int)(z * 0.6818); // adjust to array color palette [0 : 15]
                    c = form1.llenarPaleta(1)[color1];
                    pantalla.SetPixel(i, j, c);
                }
            }

        }


    }
}
