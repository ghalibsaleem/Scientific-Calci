using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Scientific_Calci.MatrixModel
{
    class Eigen
    {
       public struct EigenStruct
        {
            public double[] wr,wi;
            public double[,] vr,vl;
        }
        
        public static EigenStruct EigenVector(double[,] term)
        {
            EigenStruct value;
            
            double[] wr={0,0,0};
            double[] wi = { 0, 0, 0 };
            double[,] vl={{0,0,0},{0,0,0},{0,0,0}};
            double[,] vr=vl;
           
            alglib.evd.rmatrixevd(term, 3, 3, ref wr, ref wi, ref vl, ref vr);
            value.wi = wi;
            value.wr = wr;
            value.vl = vl;
            value.vr = vr;
            return value;
        }
        
    }

}
