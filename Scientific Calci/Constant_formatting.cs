using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_Calci
{
    class Constant_formatting
    {
        public string expr_formatting(string expr)
        {
            char[] op = { '(', ')', '+', '-', '*', '/', '^', '×', '÷' };

            
            expr = expr.Replace("Na", "6.0221*10^23"); 
            
            expr = expr.Replace("u", "1.6605402*10^(-27)");
            
            expr = expr.Replace("μb", "9.27400899*10^(-24)");
            
            expr = expr.Replace("ao", "5.291772083*10^(-11)");
            
            expr = expr.Replace("k", "1.3806509*10^(-23)");
            
            expr = expr.Replace("el", "1.602176462*10^(-19)");
           
            expr = expr.Replace("F", "96485.3415");
           
            expr = expr.Replace("G", "6.67259*10^(-11)");
            
            expr = expr.Replace("me", "9.10938188*10^(-31)");
            
            expr = expr.Replace("mn", "1.67492716*10^(-27)");
            
            expr = expr.Replace("mp", "1.67262158*10^(-27)");
            
            expr = expr.Replace("R", "8.314472");
            
            expr = expr.Replace("μo", "1.256637061*10^(-6)");
            
            expr = expr.Replace("εo", "8.854187817*10^(-12)");
           
            expr = expr.Replace("hp", "6.62606876*10^(-34)");
            
            expr = expr.Replace("h_", "1.0545727*10^(-34)");
           
            expr = expr.Replace("R∞", "10973731.57");
            
            expr = expr.Replace("cl", "299792458");
           
            
            expr = expr.Replace("σ", "5.6704*10^(-8)");
           
            expr = expr.Replace("b", "2.897756*10^(-3)");
           
            expr = expr.Replace("c1", "3.74177101*10^(-16)");
            
            expr = expr.Replace("c2", "0.014387752");
            
            expr = expr.Replace("π", "3.14159265358979323846");
            
            expr = expr.Replace("α", "7.297352533*10^(-3)");
            
            expr = expr.Replace("Zo", "376.7303135");
            
            expr = expr.Replace("Φo", "2.067833636*10^(-15)");
            
            expr = expr.Replace("Vm", "0.022413996");

            
            expr = expr.Replace("e", "2.718281828");
            
            expr = expr.Replace("s2.718281828c", "sec");
            
            expr = expr.Replace("E+", "*10^");
        while (expr.Contains("E-"))
            expr = expr.Replace("E", "*10^");
            
            expr = expr.Replace("³", "^3");

            return expr;
        }

        public string backspace(string expr)
        {
            string temp = expr;
            if (expr.LastIndexOf("sin(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length-4,4);
            if (expr.LastIndexOf("cos(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length - 4, 4);
            if (expr.LastIndexOf("tan(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length - 4, 4);
            if (expr.LastIndexOf("cot(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length - 4, 4);
            if (expr.LastIndexOf("cosec(") == expr.Length - 6 && expr.Length > 5)
                expr = expr.Remove(expr.Length - 6, 6);
            if (expr.LastIndexOf("sec(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length - 4, 4);
            if (expr.LastIndexOf("sinh(") == expr.Length - 5 && expr.Length > 4)
                expr = expr.Remove(expr.Length - 5, 5);
            if (expr.LastIndexOf("tanh(") == expr.Length - 5 && expr.Length > 4)
                expr = expr.Remove(expr.Length - 5, 5);
            if (expr.LastIndexOf("cosnh(") == expr.Length - 5 && expr.Length > 4)
                expr = expr.Remove(expr.Length - 5, 5);
            if (expr.LastIndexOf("cosh(") == expr.Length - 5 && expr.Length > 4)
                expr = expr.Remove(expr.Length - 5, 5);
            if (expr.LastIndexOf("log(") == expr.Length - 4 && expr.Length > 3)
                expr = expr.Remove(expr.Length - 4, 4);
            if (temp == expr)
            {
                if (expr == "Syntax Error")
                    expr = "";
                if (expr != "")
                    expr = expr.Remove(expr.Length - 1, 1);
                if (expr == "Out of Bond")
                    expr = "";
            }
               
            return expr;
        }
    }
}
