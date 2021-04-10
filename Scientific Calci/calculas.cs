using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_Calci
{
    class calculas
    {
        public double integration(string expr,double n,double n1)
        {
            double res = 0;
            int i = (int)((n1 - n) / 0.1), k=0;
            exprsolution exprsolution_obj = new exprsolution();
            for (double j = n; k <= i; j += 0.1)
            {
                if(k==0||k==i)
                    res += double.Parse(exprsolution_obj.exprsol(expr.Replace("X", j.ToString())));
                else
                    res += 2*double.Parse(exprsolution_obj.exprsol(expr.Replace("X", j.ToString())));
                k++;
            }

            res = res * 0.1 / 2;
            return res;
        }
    }
}
