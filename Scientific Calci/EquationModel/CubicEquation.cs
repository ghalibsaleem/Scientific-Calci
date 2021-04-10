using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_Calci.EquationModel
{
    class CubicEquation
    {
        public double[,] solution(double[] coff)
        {
            double s, r, t, term1, des, q, r13, dum1;
            double[,] result = new double[3,2];
            result[0, 1] = result[1, 1] = result[2, 1] = 0;
            

            q = (3 * coff[2] - coff[1] * coff[1]) / 9;
            r = -27 * coff[3] + coff[1] * (9 * coff[2] - 2 * coff[1] * coff[1]);
            r /= 54.0;
            des = Math.Pow(q,3) + Math.Pow(r,2);
            term1 = coff[1] / 3;
            if (des > 0)
            {
                s = r + Math.Sqrt(des);
                t = r - Math.Sqrt(des);
                s = ((s < 0) ? -Math.Pow(-s, (1.0 / 3.0)) : Math.Pow(s, (1.0 / 3.0)));
                t = ((t < 0) ? -Math.Pow(-t, (1.0 / 3.0)) : Math.Pow(t, (1.0 / 3.0)));

                result[0,0] = -term1 + s + t;
                result[0, 1] = 0;
                term1 += ((t + s) / 2);
                result[1, 0] = result[2, 0] = -term1;
                term1 = Math.Sqrt(3.0) * ((-t + s) / 2);
                result[1, 1] = term1;
                result[2, 1] = -term1;
            }
            
            if (des == 0)
            {
                r13 = ((r < 0) ? -Math.Pow(-r, (1.0 / 3.0)) : Math.Pow(r, (1.0 / 3.0)));
                result[0, 0] = -term1 + 2.0 * r13;
                result[1, 0] = result[2, 0] = -(r13 + term1);
            }

            if (des < 0)
            {
                
                q = -q;
                dum1 = q * q * q;
                dum1 = Math.Acos(r / Math.Sqrt(dum1));
                r13 = 2.0 * Math.Sqrt(q);

                result[0, 0] = -term1 + r13 * Math.Cos(dum1 / 3.0);
                result[1, 0] =-term1 + r13*Math.Cos((dum1 + 2.0*Math.PI)/3.0);
                result[2, 0] = -term1 + r13 * Math.Cos((dum1 + 4.0 * Math.PI) / 3.0);
            }
            

            
            return result;
        }
    }
}
