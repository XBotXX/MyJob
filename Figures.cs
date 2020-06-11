using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace Figures
{
    class Calculation
    {
        public static double figure(double radius) => Math.PI* Math.Pow(radius, 2);

        public static (string res_type, double res_S, bool res_status) figure(double a, double b, double c)
        {

            bool status = false;

            if (a + b > c && a + c > b && b + c > a)
            {
                status = true;
            }

            string type = "no equilateral triangle";

            if (a == b && b == c) type = "equilateral triangle";

            double P = (a + b + c) / 2;

            double S = Math.Sqrt(P * (P - a) * (P - b) * (P - c));

            var res = (res_type: type, res_S: S, res_status: status);

            return res;

        }
    }
}