using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewPort_6617
{
    public partial class Form1 : Form
    {
        Bitmap screen;
        int w = 700, h = 500; //Declaración de dimensiones de ancho y alto para el bitmap

        Color[] paleta1 = new Color[16];
        public Color[] llenarPaleta(int tpaleta)
        {
            if (tpaleta == 1)
            {
                paleta1[0] = Color.Black;
                paleta1[1] = Color.Navy;
                paleta1[2] = Color.Green;
                paleta1[3] = Color.Aqua;
                paleta1[4] = Color.Red;
                paleta1[5] = Color.Purple;
                paleta1[6] = Color.Maroon;
                paleta1[7] = Color.LightGray;
                paleta1[8] = Color.DarkCyan;
                paleta1[9] = Color.Blue;
                paleta1[10] = Color.Lime;
                paleta1[11] = Color.Silver;
                paleta1[12] = Color.Teal;
                paleta1[13] = Color.Fuchsia;
                paleta1[14] = Color.Yellow;
                paleta1[15] = Color.White;
               
            }
            
            if(tpaleta == 2) //Interpolacion de color (180,90,40) a (180,130,40)
            {
                for (int i = 0; i < 16; i++)
                {
                    paleta1[i] = Color.FromArgb(180, (int)(90 + 2.66 * i), 40);
                }

            }

            if (tpaleta == 3)
            {
                for (int i = 0; i < 16; i++)
                {
                    paleta1[i] = Color.FromArgb((int)(4.5 * i + 188), (int)(4.5 * i + 188), (int)(4.2 * i + 192));
                }
            }

            if(tpaleta == 4) //paleta para piedra -> Gris Piedra (139,140,122) a Pantone (112,112,97)
            {
                for(int i = 0; i < 16; i++)
                {
                    int r = (int)ClUtil.interpolar2Puntos(i, 0.0, 139, 15, 112);
                    int g = (int)ClUtil.interpolar2Puntos(i, 0.0, 140, 15, 112);
                    int b = (int)ClUtil.interpolar2Puntos(i, 0.0, 122, 15, 97);
                    paleta1[i] = Color.FromArgb(r, g, b);
                }
            }

            if (tpaleta == 5) //gris oscuro (75,75,75) a gris claro (156,156,156)
            {
                for (int i = 0; i < 16; i++)
                {
                    /*
                    int r = (int)ClUtil.interpolar2Puntos(i, 0.0, 75, 15, 156);
                    int g = (int)ClUtil.interpolar2Puntos(i, 0.0, 75, 15, 156);
                    int b = (int)ClUtil.interpolar2Puntos(i, 0.0, 75, 15, 156);
                    paleta1[i] = Color.FromArgb(r, g, b);*/

                    paleta1[i] = Color.FromArgb((int)((26 / 3) * i + 100), (int)((26 / 3) * i + 100), (int)((23 / 3) * i + 105));
                }
            }


            return paleta1;


        }

        public Form1()
        {
            screen = new Bitmap(w,h);
            InitializeComponent();
        }

        private void btnDegradado_Click(object sender, EventArgs e)
        {

            // DarkCyan to DimGray -----> (0,139,139) a (105,105,105)
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    /*
                        screen.SetPixel(x, y, 
                        Color.FromArgb(Convert.ToInt32(0.15 * x), 
                        Convert.ToInt32(-0.049 * x) + 139, 
                        Convert.ToInt32(-0.049 * x) + 139));
                    */
                    
                    int r = (int)ClUtil.interpolar2Puntos(x, 0.0, 0.0, 700, 105);
                    int g = (int)ClUtil.interpolar2Puntos(x, 0.0, 139, 700, 105);
                    int b = (int)ClUtil.interpolar2Puntos(x, 0.0, 139, 700, 105);
                    screen.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            PBViewPort.Image = screen; //Carga el bitmap en el picturebox
        }

        private void btnPintarDiv_Click(object sender, EventArgs e)
        {

            //Encender píxeles
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (x <= 350)
                        screen.SetPixel(x, y, Color.DarkCyan);
                    else
                        screen.SetPixel(x, y, Color.DimGray);
                }
            }
            PBViewPort.Image = screen; //Carga el bitmap en el picturebox
        }

        private void btnPintarV_Click(object sender, EventArgs e)
        {
            ClVector vector = new ClVector(-4, 0, Color.Red);
            double x = -2;

            do
            {
                vector.x0 = x;
                vector.y0 = x*x-5;
                vector.Encender(screen);
                x += 0.05;

            }
            while (x <= 3);

            PBViewPort.Image = screen;
        }

        private void btnSegmento_Click(object sender, EventArgs e)
        {
            ClSegmento segmento = new ClSegmento(3,-3);
            segmento.x0 = -5;
            segmento.y0 = 2;
            segmento.color0 = Color.Red;
            segmento.Encender(screen);

            PBViewPort.Image = screen;
        }

        private void btnCircunferencia_Click(object sender, EventArgs e)
        {
            ClCircunferencia circunferencia = new ClCircunferencia(2);
            circunferencia.x0 = 1;
            circunferencia.y0 = 1;
            circunferencia.color0 = Color.Purple;
            circunferencia.Encender(screen);

            PBViewPort.Image = screen;
        }

        private void btnCircySeg_Click(object sender, EventArgs e)
        {
            
            ClSegmento seg = new ClSegmento(1.8,-2.25);
            seg.x0 = -2;
            seg.y0 = 0.35;
            seg.color0 = Color.Red;
            seg.Encender(screen);

            ClSegmento seg2 = new ClSegmento(3,3);
            seg2.x0 = -1.25;
            seg2.y0 = -0.5;
            seg2.color0 = Color.Blue;
            seg2.Encender(screen);
            
            ClSegmento seg3 = new ClSegmento(-5.2, -5);
            seg3.x0 = -5;
            seg3.y0 = 1;
            seg3.color0 = Color.LimeGreen;
            seg3.Encender(screen);

            ClCircunferencia circulo = new ClCircunferencia(2);
            circulo.x0 = 3;
            circulo.y0 = 0;
            circulo.color0 = Color.Purple;
            circulo.Encender(screen);

            ClCircunferencia circulo2 = new ClCircunferencia(1.35);
            circulo2.x0 = -1.05;
            circulo2.y0 = 2.3;
            circulo2.color0 = Color.Cyan;
            circulo2.Encender(screen);

            ClCircunferencia circulo3 = new ClCircunferencia(1);
            circulo3.x0 = -3.85;
            circulo3.y0 = -0.4;
            circulo3.color0 = Color.Yellow;
            circulo3.Encender(screen);


            PBViewPort.Image = screen;

        }

        private void btnLazo_Click(object sender, EventArgs e)
        {
            ClLazo Lazo = new ClLazo(1.5);
            Lazo.x0 = -1;
            Lazo.y0 = -1;
            Lazo.color0 = Color.Purple;
            Lazo.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnMargarita_Click(object sender, EventArgs e)
        {
            ClMargarita margarita = new ClMargarita(2);
            margarita.x0 = -1;
            margarita.y0 = -1;
            margarita.color0 = Color.Purple;
            margarita.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnLazoyMargarita_Click(object sender, EventArgs e)
        {
            ClLazo lazo1 = new ClLazo(1.25);
            lazo1.x0 = 3;
            lazo1.y0 = -2.25;
            lazo1.color0 = Color.Green;
            lazo1.Encender(screen);

            ClLazo lazo2 = new ClLazo(1.55);
            lazo2.x0 = -4;
            lazo2.y0 = 2.25;
            lazo2.color0 = Color.Blue;
            lazo2.Encender(screen);

            ClMargarita mrg1 = new ClMargarita(1.75);
            mrg1.x0 = 2;
            mrg1.y0 = 2;
            mrg1.color0 = Color.Purple;
            mrg1.Encender(screen);

            ClMargarita mrg2 = new ClMargarita(2.2);
            mrg2.x0 = -3;
            mrg2.y0 = -2.25;
            mrg2.color0 = Color.Red;
            mrg2.Encender(screen);

            ClCircunferencia circ = new ClCircunferencia(1);
            circ.x0 = 0;
            circ.y0 = 0;
            circ.color0 = Color.Cyan;
            circ.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            ClVector v = new ClVector();
            //Para mover al vector
            float t = -5.5f; //cerca al borde -7
            float dt = 0.001f;
            
            do
            {
                v.x0 = t;
                v.y0 = Math.Pow(t, 2) - 3;
                v.color0 = Color.Cyan;
                v.Encender(screen);

                v.y0 = Math.Pow(2, t);
                v.color0 = Color.Blue;
                v.Encender(screen);

                v.y0 = Math.Sin(t);
                v.color0 = Color.Red;
                v.Encender(screen);


                v.y0 = Math.Sin(t) * Math.Pow(Math.Cos(t),2);
                v.color0 = Color.Green;
                v.Encender(screen);

                t = t + dt;

            } while (t <= 5.5);


            PBViewPort.Image = screen;

        }

        //Botones de borrado
        private void btnBorrarVector_Click(object sender, EventArgs e)
        {
            ClVector vector = new ClVector(-4, 0, Color.Red);
            double x = -2;

            do
            {
                vector.x0 = x;
                vector.y0 = x * x - 5;
                vector.Apagar(screen);
                x += 0.05;

            }
            while (x <= 3);

            PBViewPort.Image = screen;
        }

        private void btnBorrarSegmento_Click(object sender, EventArgs e)
        {
            ClSegmento segmento = new ClSegmento(3, -3);
            segmento.x0 = -5;
            segmento.y0 = 2;
            segmento.Apagar(screen);

            PBViewPort.Image = screen;
        }

        private void btnBorrarCircySeg_Click(object sender, EventArgs e)
        {

            ClSegmento seg = new ClSegmento(1.8, -2.25);
            seg.x0 = -2;
            seg.y0 = 0.35;
            seg.Apagar(screen);

            ClSegmento seg2 = new ClSegmento(3, 3);
            seg2.x0 = -1.25;
            seg2.y0 = -0.5;
            seg2.Apagar(screen);

            ClSegmento seg3 = new ClSegmento(-5.2, -5);
            seg3.x0 = -5;
            seg3.y0 = 1;
            seg3.Apagar(screen);

            ClCircunferencia circulo = new ClCircunferencia(2);
            circulo.x0 = 3;
            circulo.y0 = 0;
            circulo.Apagar(screen);

            ClCircunferencia circulo2 = new ClCircunferencia(1.35);
            circulo2.x0 = -1.05;
            circulo2.y0 = 2.3;
            circulo2.Apagar(screen);

            ClCircunferencia circulo3 = new ClCircunferencia(1);
            circulo3.x0 = -3.85;
            circulo3.y0 = -0.4;
            circulo3.Apagar(screen);


            PBViewPort.Image = screen;
        }

        private void btnBorrarLazo_Click(object sender, EventArgs e)
        {
            ClLazo Lazo = new ClLazo(1);
            Lazo.x0 = -1;
            Lazo.y0 = -1;
            Lazo.Apagar(screen);
            PBViewPort.Image = screen;
        }

        private void btnBorrarMargarita_Click(object sender, EventArgs e)
        {
            ClMargarita margarita = new ClMargarita(2);
            margarita.x0 = -1;
            margarita.y0 = -1;
            margarita.Apagar(screen);
            PBViewPort.Image = screen;
        }

        private void btnBorrarLazoyMarg_Click(object sender, EventArgs e)
        {
            ClLazo lazo1 = new ClLazo(1.25);
            lazo1.x0 = 3;
            lazo1.y0 = -2.25;
            lazo1.Apagar(screen);

            ClLazo lazo2 = new ClLazo(1.55);
            lazo2.x0 = -4;
            lazo2.y0 = 2.25;
            lazo2.Apagar(screen);

            ClMargarita mrg1 = new ClMargarita(1.75);
            mrg1.x0 = 2;
            mrg1.y0 = 2;
            mrg1.Apagar(screen);

            ClMargarita mrg2 = new ClMargarita(2.2);
            mrg2.x0 = -3;
            mrg2.y0 = -2.25;
            mrg2.Apagar(screen);

            ClCircunferencia circ = new ClCircunferencia(1);
            circ.x0 = 0;
            circ.y0 = 0;
            circ.Apagar(screen);
            PBViewPort.Image = screen;
        }

        private void btnBorrarFunciones_Click(object sender, EventArgs e)
        {
            ClVector v = new ClVector();
            float t = -5.5f;
            float dt = 0.001f;

            do
            {
                v.x0 = t;
                v.y0 = Math.Pow(t, 2) - 3;
                v.Apagar(screen);

                v.y0 = Math.Pow(2, t);
                v.Apagar(screen);

                v.y0 = Math.Sin(t);
                v.Apagar(screen);


                v.y0 = Math.Sin(t) * Math.Pow(Math.Cos(t), 2);
                v.Apagar(screen);

                t = t + dt;

            } while (t <= 5.5);


            PBViewPort.Image = screen;
        }

        private void btnLimpiarVP_Click(object sender, EventArgs e)
        {
            //Encender píxeles
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    screen.SetPixel(x, y, Color.White);
                }
            }
            PBViewPort.Image = screen; //Carga el bitmap en el picturebox
        }

        private void btnEjes_Click(object sender, EventArgs e)
        {
            //EJE X
            ClSegmento seg = new ClSegmento(7, 0);
            seg.x0 = -7;
            seg.y0 = 0;
            seg.color0 = Color.Black;
            seg.Encender(screen);
            
            //EJE Y
            ClSegmento seg2 = new ClSegmento(0, 5);
            seg2.x0 = 0;
            seg2.y0 = -5;
            seg2.color0 = Color.Black;
            seg2.Encender(screen);

            PBViewPort.Image = screen;
        }

        private async void btnLazo2_Click(object sender, EventArgs e)
        {
            float x = -5;
            ClLazo Lazo2 = new ClLazo(0.8);
            do
            {
                Lazo2.x0 = x;
                Lazo2.y0 = Math.Sin(x);
                Lazo2.color0 = Color.Purple;
                x += 0.2f;
                Lazo2.Encender(screen);
                await Task.Delay(100);
                Lazo2.Apagar(screen);
                PBViewPort.Image = screen;
            } while (x <= 5);

        }

        private void btnDegradarPrueba_Click(object sender, EventArgs e)
        {
            /* DarkCyan to Blanco -----> (0,139,139) a (255,255,255) hasta mitad
            for (int x = 0; x < 350; x++)
            {

                int r = (int)ClUtil.interpolar2Puntos(x, 0.0, 0.0, 350, 255);
                int g = (int)ClUtil.interpolar2Puntos(x, 0.0, 139, 350, 255);
                int b = (int)ClUtil.interpolar2Puntos(x, 0.0, 139, 350, 255);
                screen.SetPixel(x, y, Color.FromArgb(r, g, b));
            }

            for (int x = 350; x < w; x++)
            {
                int r = (int)ClUtil.interpolar2Puntos(x, 350, 255, 700, 0);
                int g = (int)ClUtil.interpolar2Puntos(x, 350, 255, 700, 139);
                int b = (int)ClUtil.interpolar2Puntos(x, 350, 255, 700, 139);
                screen.SetPixel(x, y, Color.FromArgb(r, g, b));
            }*/
            int r, g, b;
            
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    // (100,100,150) a (255,255,255)
                    if (x<=350)
                    {
                        r = (int)(0.44 * x) + 100;
                        g = (int)(0.44 * x) + 100;
                        b = (int)(0.3 * x) + 150;
                        screen.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                    // (255,255,255) a (100,100,150)
                    else
                    {
                        r = (int)((-0.44 * x) + 410);
                        g = (int)((-0.44 * x) + 410);
                        b = (int)((-0.3 * x) + 360);
                        screen.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                   
                }
            }
            PBViewPort.Image = screen; //Carga el bitmap en el picturebox
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            Vector3D vector3d = new Vector3D();
            Vector3D vector3d2 = new Vector3D();
            Vector3D vector3d3 = new Vector3D();

            float t = 0f;
            float t2 = 0f;
            float t3 = 0f;

            vector3d.color0 = Color.Blue;
            vector3d2.color0 = Color.Purple;
            vector3d3.color0 = Color.Gray;

            do
            {
                vector3d.x0 = 1 + (0.5 * Math.Cos(t)) + 1;
                vector3d.y0 = 1 + (0.5 * Math.Sin(t)) + 1;
                vector3d.z0 = t / 30;
                vector3d.Encender(screen);
                t = t + 0.00002f;
            }
            while (t <= 40);

            do
            {
                /*
                vector3d2.x0 = -2 + (1 * Math.Cos(t2)) - 2;
                vector3d2.y0 = -3 + (1 * Math.Sin(t2)) - 2;
                vector3d2.z0 = t2 / 30; //factor para estirar espiral
                */
                vector3d2.x0 = 1 + (2.5 * Math.Cos(t2));
                vector3d2.y0 = -2 + (2 * Math.Sin(t2));
                vector3d2.z0 = t2 / 20;
                vector3d2.Encender(screen);
                t2 = t2 + 0.03f;
            }
            while (t2 <= 20); //número de vueltas


            do
            {
                vector3d3.x0 = 0.2 + (1 * Math.Cos(t3)) + 7;
                vector3d3.y0 = 0.2 + 7;
                vector3d3.z0 = t3 / 18 + (1 * Math.Sin(t3));
                vector3d3.Encender(screen);
                t3 = t3 + 0.0001f;
            }
            while (t3 <= 100);

            PBViewPort.Image = screen;
        }

        private void btnSegmento3D_Click(object sender, EventArgs e)
        {
            ClSegmento3D seg3d = new ClSegmento3D(4, 5, 2);
            seg3d.x0 = 0;
            seg3d.y0 = 0;
            seg3d.z0 = 0;
            seg3d.color0 = Color.Purple;
            seg3d.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnEjes3D_Click(object sender, EventArgs e)
        {
            //EJE Z
            ClSegmento3D seg3d1 = new ClSegmento3D(0,0,4);
            seg3d1.x0 = 0;
            seg3d1.y0 = 0;
            seg3d1.z0 = 0;
            seg3d1.color0 = Color.Black;
            seg3d1.Encender(screen);

            //EJE Y
            ClSegmento3D seg3d2 = new ClSegmento3D(0,5,0);
            seg3d2.x0 = 0;
            seg3d2.y0 = 0;
            seg3d2.z0 = 0;
            seg3d2.color0 = Color.Black;
            seg3d2.Encender(screen);

            //Eje X
            ClSegmento3D seg3d3 = new ClSegmento3D(8,0,0);
            seg3d3.x0 = 0;
            seg3d3.y0 = 0;
            seg3d3.z0 = 0;
            seg3d3.color0 = Color.Black;
            seg3d3.Encender(screen);



            PBViewPort.Image= screen;
        }

        private void btnCubo3D_Click(object sender, EventArgs e)
        {
            ClSegmento3D s3D1 = new ClSegmento3D(0, 0, 4);
            s3D1.x0 = 0;
            s3D1.y0 = 0;
            s3D1.z0 = 0;
            s3D1.color0 = Color.Black;
            s3D1.Encender(screen);

            ClSegmento3D s3D5 = new ClSegmento3D(0, 5, 4);
            s3D5.x0 = 0;
            s3D5.y0 = 5;
            s3D5.z0 = 0;
            s3D5.color0 = Color.Black;
            s3D5.Encender(screen);

            ClSegmento3D s3D2 = new ClSegmento3D(8, 0, 0);
            s3D2.x0 = 0;
            s3D2.y0 = 0;
            s3D2.z0 = 0;
            s3D2.color0 = Color.Black;
            s3D2.Encender(screen);

            ClSegmento3D s3D6 = new ClSegmento3D(0, 5, 0);
            s3D6.x0 = 8;
            s3D6.y0 = 5;
            s3D6.z0 = 0;
            s3D6.color0 = Color.Black;
            s3D6.Encender(screen);

            ClSegmento3D s3D9 = new ClSegmento3D(8, 0, 4);
            s3D9.x0 = 0;
            s3D9.y0 = 0;
            s3D9.z0 = 4;
            s3D9.color0 = Color.Black;
            s3D9.Encender(screen);

            ClSegmento3D s3D8 = new ClSegmento3D(8, 0, 4);
            s3D8.x0 = 8;
            s3D8.y0 = 0;
            s3D8.z0 = 0;
            s3D8.color0 = Color.Black;
            s3D8.Encender(screen);

            ClSegmento3D s3D3 = new ClSegmento3D(0, 5, 0);
            s3D3.x0 = 0;
            s3D3.y0 = 0;
            s3D3.z0 = 0;
            s3D3.color0 = Color.Black;
            s3D3.Encender(screen);

            ClSegmento3D s3D4 = new ClSegmento3D(0, 5, 4);
            s3D4.x0 = 0;
            s3D4.y0 = 0;
            s3D4.z0 = 4;
            s3D4.color0 = Color.Black;
            s3D4.Encender(screen);

            ClSegmento3D s3D7 = new ClSegmento3D(8, 5, 0);
            s3D7.x0 = 8;
            s3D7.y0 = 0;
            s3D7.z0 = 0;
            s3D7.color0 = Color.Black;
            s3D7.Encender(screen);


            PBViewPort.Image = screen;
        }

        private void btnSuperficie3D_Click(object sender, EventArgs e)
        {
            ClSuperficie3D sup3d = new ClSuperficie3D(1.2);
            sup3d.x0 = 3;
            sup3d.y0 = 1.2;
            sup3d.z0 = -1.25;
            sup3d.tipo = 1;
            sup3d.color0 = Color.Red;

            sup3d.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnEsfera3d_Click(object sender, EventArgs e)
        {
            ClSuperficie3D sup3d = new ClSuperficie3D(1);
            sup3d.x0 = 2;
            sup3d.y0 = 3.5;
            sup3d.z0 = 2;
            sup3d.tipo = 2;
            sup3d.color0 = Color.Blue;

            sup3d.Encender(screen);
            PBViewPort.Image = screen;

        }

        private void btnCuboFig3d_Click(object sender, EventArgs e)
        {
            btnCubo3D_Click(sender, e);
            btnSuperficie3D_Click(sender, e);
            btnEsfera3d_Click(sender, e);
        }

        private void btnSuperfr3d_Click(object sender, EventArgs e)
        {
            
            SuperficieR3D supr3d = new SuperficieR3D(0.12);
            supr3d.tipo = 1; //Paraboloide
            supr3d.color0 = Color.DarkCyan;
            /*supr3d.x0 = 1;
            supr3d.y0 = 2;
            supr3d.z0 = 3;*/
            supr3d.Encender(screen);

            PBViewPort.Image = screen;

        }

        private void btnHiperbol1hoja_Click(object sender, EventArgs e)
        {
            ClSuperficie3D hip1 = new ClSuperficie3D();
            
            hip1.x0 = 0.85;
            hip1.y0 = 1;
            hip1.z0 = 1;
            
            hip1.tipo = 4;
            hip1.color0 = Color.Blue;
            hip1.Encender(screen);
            PBViewPort.Image = screen;
        }

        private void btnParaboloideH_Click(object sender, EventArgs e)
        {
            SuperficieR3D parabh = new SuperficieR3D(0.1);

            parabh.tipo = 2; //Paraboloide hiperbolico
            parabh.color0 = Color.SaddleBrown;
            parabh.Encender(screen);

            PBViewPort.Image = screen;

        }


        private void cBTapete_SelectedIndexChanged(object sender, EventArgs e)
        {
            int colorT;
            Color c;
            switch (cBTapete.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Sqrt(i) * j / 100);
                            
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 1:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Exp(Math.Sin(i * Math.PI / 10)));
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 2:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Pow(i - j, 2)/20);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 3:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int) ((i + j) * 3.14 % w);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 4:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(5*i + j/20);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 5:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            
                            colorT = (int)(Math.Sqrt(i) * j * 3);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 6:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Pow(i + j, 2) / 10);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 7:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            
                            colorT = (int)(Math.Sin(i)+j/5); 
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 8:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            
                            colorT = (int)(Math.Pow(i, 3) + j / 10 * 10); 
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 9:
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Pow(i, 2) + Math.Pow(j, 3) - i / 30 + j);
                            c = llenarPaleta(1)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 10: //textura madera
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.Sqrt(i) * j / 100);
                            c = llenarPaleta(2)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;

                case 11: //textura nieve
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            colorT = (int)(Math.E * (i / 2) + Math.PI * (Math.Pow(j, 2)) + j * i) % 6;
                            c = llenarPaleta(3)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;
                case 12: //textura piedra

                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {

                            //colorT = (int)(Math.Sqrt(i) *j * 50);
                            colorT = (int)(Math.Sqrt(i*j) * j % 1000);
                            c = llenarPaleta(4)[colorT % 15];
                            screen.SetPixel(i, j, c);
                        }
                    }
                    PBViewPort.Image = screen;
                    break;



            }
        }

        private void btnParabola_Click(object sender, EventArgs e)
        {
            ClVector v = new ClVector();
            
            double x;
            
            x = -7;
            do
            {
                v.x0 = x;
                //v.y0 = - ((x - 7) * (x + 7)) / 18;
                //v.y0 = ((49 - Math.Pow(x,2)) / 18);
                v.y0 = ClUtil.interpolar3Puntos(x, 7, 0, 0, 3, -7, 0); //punto medio y altura (4to y 5to parametro)
                v.color0 = Color.CadetBlue;
                v.Encender(screen);
                x = x + 0.001;

            } while (x <= 7);
            PBViewPort.Image = screen;
            
        }

        private void PBViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            double x, y;

            ClCircunferencia circunferencia = new ClCircunferencia(0.2);
            circunferencia.color0 = Color.ForestGreen;
            circunferencia.Transforma(e.X, e.Y, out x, out y);
            circunferencia.x0 = x;
            circunferencia.y0 = y;
            circunferencia.Encender(screen);

            //double yf = -((x - 7) * (x + 7)) / 18;
            double yf = (49 - Math.Pow(x, 2)) / 18;
            yf = (Math.Truncate(yf*1000)/1000);

            ClSegmento segm = new ClSegmento();
            segm.color0 = Color.Yellow;
            segm.x0 = x;
            segm.y0 = y;
            segm.xf = x;
            segm.yf = yf;
            segm.Encender(screen);

            ClSegmento rayo = new ClSegmento();
            rayo.x0 = segm.xf;
            rayo.y0 = segm.yf;

            //y-yp = m(x-xp)
            //mn = - 1/f'(xp)

            if (rayo.x0 < 0)
            {
                rayo.color0 = Color.Red;

                rayo.xf = 7;
                rayo.yf = (9 / x) * (7 - x) + yf;
                
            }
            else
            {
                rayo.color0 = Color.Red;
                rayo.xf = -7;
                rayo.yf = (9 / segm.xf) * (-7 - segm.xf) + segm.yf;
            }
            rayo.Encender(screen);

            PBViewPort.Image = screen;

        }

        private void btnEpsilon_Click(object sender, EventArgs e)
        {
            SuperficieR3D supr3d = new SuperficieR3D(1.5);
            supr3d.tipo = 3;
            supr3d.color0 = Color.DarkCyan;
            /*supr3d.x0 = 1;
            supr3d.y0 = 2;
            supr3d.z0 = 3;*/
            supr3d.Encender(screen);

            PBViewPort.Image = screen;
        }

        private void btnOnda_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda(2);
            onda.Graf(screen);
            PBViewPort.Image = screen;
        }

        private async void btnReloj_Click(object sender, EventArgs e)
        {
            ClCircunferencia circ = new ClCircunferencia(2); //radio 2
            circ.color0 = Color.DarkCyan;
            circ.x0 = 2;
            circ.y0 = 2;
            circ.Encender(screen);

            PBViewPort.Image = screen;


            double t, dt;
            t = 0;
            dt = 0.1;

            ClSegmento seg = new ClSegmento();
            seg.x0 = 2;
            seg.y0 = 2;
            
            do
            {
                seg.xf = seg.x0 + ((circ.rd -0.05) * Math.Sin(t));
                seg.yf = seg.y0 + ((circ.rd -0.05) * Math.Cos(t));
                seg.color0 = Color.Green;
                seg.Encender(screen);
                PBViewPort.Image = screen;
                PBViewPort.Refresh();
                await Task.Delay(50);
                //Thread.Sleep(60);
                seg.Apagar(screen);
                PBViewPort.Image = screen;
                t = t + dt;
            } while (t <= 2 * Math.PI);

        }

        private void btnInterferenciaO_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda(0);
            onda.Interferencia(screen);
            PBViewPort.Image = screen;
        }

        private void btnInterferencia3F_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda(0);
            onda.Interferencia3(screen);
            PBViewPort.Image = screen;
        }

        private async void btnOndaTiempos_ClickAsync(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda();
            onda.t = 0;
            do 
            {
                onda.Graf(screen);
                onda.t = onda.t + 0.05;
                PBViewPort.Image = screen;
                await Task.Delay(10);
                //PBViewPort.Refresh();
            } while(onda.t <= 6 * Math.PI);
        }

        private async void btnInterferenciaOAnim_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda();
            onda.t = 0;
            do
            {
                onda.Interferencia(screen);
                onda.t = onda.t + 0.05;
                await Task.Delay(10);
                PBViewPort.Image = screen;
            }while(onda.t <= 6 * Math.PI); 
        }

        private async void btnInterferencia3Anim_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda();
            onda.t = 0;
            do
            {
                onda.Interferencia3(screen);
                onda.t = onda.t + 0.05;
                await Task.Delay(5);
                PBViewPort.Image = screen;
            } while (onda.t <= 6 * Math.PI);
        }

        private void btnOnda3D_Click(object sender, EventArgs e)
        {
            ClOnda onda3d = new ClOnda();
            onda3d.t = 0;
            onda3d.Onda3D(screen,Color.DarkCyan);
            PBViewPort.Image = screen;
        }

        private void btnInterferencia3d_Click(object sender, EventArgs e)
        {
            ClOnda onda3d = new ClOnda();
            onda3d.t = 0;
            onda3d.Interferencia3d(screen,Color.DarkBlue);
            PBViewPort.Image = screen;
        }

        private void btnInterferencia3d3f_Click(object sender, EventArgs e)
        {
            ClOnda onda3d = new ClOnda(0);
            onda3d.Interferencia3f(screen,Color.DarkRed);
            PBViewPort.Image = screen;
        }

        private async void btnAnim1Fuente_Click(object sender, EventArgs e)
        {
            ClOnda onda3 = new ClOnda();
            onda3.t = 0;
            onda3.dt = 0.05;
            do
            {
                onda3.Onda3D(screen,Color.Green);
                await Task.Delay(200);
                onda3.Onda3D(screen,Color.White);
                PBViewPort.Image = screen;
                onda3.t = onda3.dt;
                onda3.dt += onda3.t;
            } while (onda3.t <= 6 * Math.PI);

        }

        private async void btnAnim2Fuente_Click(object sender, EventArgs e)
        {
            ClOnda onda2 = new ClOnda();
            onda2.t = 0;
            onda2.dt = 0.05;
            do
            {
                onda2.Interferencia3d(screen, Color.Red);
                await Task.Delay(150);
                onda2.Interferencia3d(screen, Color.White);
                PBViewPort.Image = screen;
                onda2.t = onda2.dt;
                onda2.dt += onda2.t;
            } while (onda2.t <= 6 * Math.PI);
        }

        private async void btnAnim3Fuente_Click(object sender, EventArgs e)
        {
            ClOnda onda3f = new ClOnda();
            onda3f.t = 0;
            onda3f.dt = 0.05;
            do
            {
                onda3f.Interferencia3f(screen, Color.DarkBlue);
                await Task.Delay(200);
                onda3f.Interferencia3f(screen, Color.White);
                PBViewPort.Image = screen;
                onda3f.t = onda3f.dt;
                onda3f.dt += onda3f.t;
            } while (onda3f.t <= 6 * Math.PI);
        }

        private void btnBorrarCirc_Click(object sender, EventArgs e)
        {
            ClCircunferencia circunferencia = new ClCircunferencia(2);
            circunferencia.x0 = 1;
            circunferencia.y0 = 1;
            circunferencia.Apagar(screen);

            PBViewPort.Image = screen;
        }

        private async void btnAnimCuerdaVib_Click(object sender, EventArgs e)
        {
            ClCuerdaV cuerdaVi = new ClCuerdaV();
            double t = 10;
            do
            {
                cuerdaVi.t = t;
                cuerdaVi.color0 = Color.DarkCyan;
                cuerdaVi.Graficar(screen);
                await Task.Delay(10);
                cuerdaVi.color0 = Color.White;
                cuerdaVi.Graficar(screen);
                PBViewPort.Image = screen;
                t += 0.035;
                //Console.WriteLine("Valor t "+ t);

            } while (true);

        }

        private void btnPruebaP3_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda();
            /*
            onda.t = 1;
            onda.Huyguens(screen);
            PBViewPort.Image = screen;*/
            onda.t = 1.2;
            onda.v = 9.3;
            onda.w = 1.5;
            onda.Huyguens(screen);
            PBViewPort.Image = screen;
        }

        private void btnProyectoF_Click(object sender, EventArgs e)
        {
            ClOnda onda = new ClOnda();
            onda.t = 0.2;
            onda.Interferencia2w3d(screen,Color.Red);
            PBViewPort.Image = screen;
        }

        private void btnProyectoF2D_Click(object sender, EventArgs e)
        {
            ClOnda onda2 = new ClOnda();
            onda2.t = 0.5;
            onda2.Interferencia2w2d(screen);
            PBViewPort.Image = screen;
        }

        /*
private double f(double x)
{
   return ((-x) * (x - 3)) / 2;
}

private double g(double x)
{
   return 1;
}

private void Fourier(double t, double x, out double fou)
{
   double pi = Math.PI;
   double ak, bk, l = 4;
   double c = 1; //constante

   int n = 0;
   double SumF = 0;

   do
   {
       n += 1;
       //ak = (2/3) * (0 + 4 * f(2) * Math.Sin(n * pi * 1 / 2) + f(4) * Math.Sin(n * pi));
       ak = (2 / 3) * (0 + 4 * f(2) * Math.Sin(n * pi / 2) + f(4) * Math.Sin(n * pi));
       ak *= 0.5;

       //bk = 0.667 * (0 + 4 * g(2) * Math.Sin(n * pi * 1 / 2) + g(4) * Math.Sin(n * pi));
       bk = 0.667 * (0 + 4 * g(2) * Math.Sin(n * pi / 2) + g(4) * Math.Sin(n * pi));
       bk *= 2 / (n * pi * c);

       SumF += (ak * Math.Cos((n * pi * c * t) / l) + bk * Math.Sin((n * pi * c * t) / l)) * Math.Sin((n * pi * x) / l);

   } while (n <= 20);
   fou = SumF;
}*/

        private void btnCuerdaV_Click(object sender, EventArgs e)
        {
            ClCuerdaV cuerdaV = new ClCuerdaV(0.75);
            cuerdaV.color0 = Color.Cyan;
            cuerdaV.Graficar(screen);
            PBViewPort.Image = screen;
        }

        
    }
}
