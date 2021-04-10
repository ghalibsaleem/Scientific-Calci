using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_Calci.EquationModel
{
    class LinearEquations
    {
        public double[] EquationSolution(double[,] mat)
        {
            double[] r={0,0,0};
            for (int i = 0; i < 2; i++ )
            {
                for (int j = i + 1; j < 3; j++ )
                {
                    double t = mat[j, i] / mat[i, i];
                    for (int k = 0; k < 4; k++ )
                    {
                        mat[j, k] -= t * mat[i, k];
                    }
                }
            }

            for (int i = 2; i >=  0; i-- )
            {
                double s = 0;
                for (int j = i + 1; j < 3; j++ )
                {
                    s+=r[j]*mat[i,j];
                }
                r[i] = (mat[i, 3] - s) / mat[i, i];
            }
            return r;
        }
    }
}
