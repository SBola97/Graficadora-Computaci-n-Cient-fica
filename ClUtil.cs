using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewPort_6617
{
    internal class ClUtil
    {

        public static double interpolar2Puntos(double x, double x1, double y1, double x2, double y2)
        {
            return ((y1 * ((x - x2) / (x1 - x2))) + (y2 * ((x - x1) / (x2 - x1))));
        }
        public static double interpolar3Puntos(double x,
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            return ((y1 * (((x - x2) * (x - x3)) / ((x1 - x2) * (x1 - x3)))) +
                    (y2 * (((x - x1) * (x - x3)) / ((x2 - x1) * (x2 - x3)))) +
                    (y3 * (((x - x1) * (x - x2)) / ((x3 - x1) * (x3 - x2)))));
        }
    }
}
