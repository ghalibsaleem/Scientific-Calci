using Scientific_Calci.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_Calci
{
    class exprsolution
    {
        public string angle { get; set; }
        private Calculation calculation_obj = new Calculation();
        public  string exprsol(string expression)
        {
            char[] op = { '(', ')', '+', '-', '*', '/', '^', '×', '÷' };
            string[] functions = { "Sin", "Cos", "tan", "log", "√" };
            string[] parameter = { "²" };
            
            int j,k;
            double temp;
            

            try
            {
                //Managing the string for calcuation
                for (int i = 1; i < expression.Length - 1; i++)
                {
                    
                    if (expression.ElementAt(i) == '-')
                    {
                        string str = expression.ElementAt(i-1).ToString();
                        if (expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58 || parameter.Contains(str) )
                        {
                            expression = expression.Insert(i, "+");
                        }

                    }
                    if (expression.ElementAt(i) == '(')
                    {
                        string str = expression.ElementAt(i - 1).ToString();
                        if (expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58 || parameter.Contains(str))
                        {
                            expression = expression.Insert(i, "×");
                        }

                    }
                    
                    if (expression.ElementAt(i) == ')')
                    {
                        
                        if (expression.ElementAt(i + 1) > 47 && expression.ElementAt(i + 1) < 58)
                        {
                            expression = expression.Insert(i + 1, "×");
                        }

                    }

                }


                //calculation of cosec functions
                while (expression.Contains("cosec("))
                {
                  expression =  expression.Replace("cosec","1/sin");
                }

                //calculation of sec functions
                while (expression.Contains("sec("))
                {
                   expression = expression.Replace("sec", "1/cos");
                }

                //calculation of cot functions
                while (expression.Contains("cot("))
                {
                  expression =  expression.Replace("cot", "1/tan");
                }

                //calculation of cosech functions
                while (expression.Contains("cosech("))
                {
                    expression = expression.Replace("cosech", "1/sinh");
                }

                //calculation of sech functions
                while (expression.Contains("sech("))
                {
                    expression = expression.Replace("sech", "1/cosh");
                }

                //calculation of coth functions
                while (expression.Contains("coth("))
                {
                    expression = expression.Replace("coth", "1/tanh");
                }

                //calculation of sine functions
                while (expression.Contains("sin("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("sin");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 4; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    if (angle == "Degree")
                    {
                        temp = Math.Sin(0.01745329252*double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));
                        value = temp.ToString();
                    }
                    else
                    {
                        temp = Math.Sin(double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));
                        value = temp.ToString();
                    }
                   
                    
                    if (temp < 0.00000000000001 && temp > -0.00000000000001)
                        value = "0";
                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }

                //calculation of sine hyperbolic functions
                while (expression.Contains("sinh("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("sinh");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 5; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }

                    if(angle=="Degree"){
                        value = (Math.Sinh(0.01745329252 * double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }else{
                        value = (Math.Sinh(double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }

                    

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }



                //calculation of Cosine functions
                while (expression.Contains("cos("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("cos");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 4; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    if(angle=="Degree")
                    {
                        temp = Math.Cos(0.01745329252 * double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));

                    }
                    else{
                        temp = Math.Cos(double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));
                    }
                   
                    value = temp.ToString();
                    if (temp < 0.0000000000001 && temp > -0.00000000001)
                        value = "0";
                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }

                //calculation of Cosine hyperbolic functions
                while (expression.Contains("cosh("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("cosh");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 5; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    if(angle=="Degree"){
                        value = (Math.Cosh(0.01745329252 * double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }else{
                        value = (Math.Cosh(double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }
                    

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }


                //calculation of tangent function
                while (expression.Contains("tan("))
                {
                    int i, count = 1;
                    string value ;
                    i = expression.IndexOf("tan");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 4; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }

                    if(angle=="Degree"){
                        temp = Math.Tan(0.01745329252 * double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));
                    }else{
                        temp = Math.Tan(double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))));
                    }
                    
                    value = temp.ToString();
                    if (temp < 0.00000000000001 && temp > -0.00000000000001)
                        value = "0";
                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }

                //calculation of Tangent hyperbolic functions
                while (expression.Contains("tanh("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("tanh");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 5; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    if(angle=="Degree"){
                        value = (Math.Tanh(0.01745329252 * double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }else{
                        value = (Math.Tanh(double.Parse(exprsol(expression.Substring(i + 4, l - i - 4))))).ToString();
                    }
                    

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }




                //calculation of logarithmic function
                while (expression.Contains("log"))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("log");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 4; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }

                    value = (Math.Log10(double.Parse(exprsol(expression.Substring(i + 3, l - i - 3))))).ToString();

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }

                //calculation of logarithmic e function
                while (expression.Contains("ln"))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("ln");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 3; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }

                    value = (Math.Log(double.Parse(exprsol(expression.Substring(i + 2, l - i - 2))), 2.718281828)).ToString();

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }


                //calculation of square root function
                while (expression.Contains("√"))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("√");
                    int l;
                    if (i > 0 && expression.ElementAt(i - 1) > 47 && expression.ElementAt(i - 1) < 58)
                    {
                        expression = expression.Insert(i, "×");
                        i++;
                    }
                    for (l = i + 2; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }

                    value = (Math.Sqrt(double.Parse(exprsol(expression.Substring(i + 1, l - i - 1))))).ToString();

                    expression = expression.Replace(expression.Substring(i, l - i), value);
                }

                //calculation of nPr function
                while (expression.Contains("P"))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("P");
                    int l;
                    
                    for (l = i + 2; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    int m = l;
                    int f = int.Parse(exprsol(expression.Substring(i + 1, l - i - 1))),g;
                    l = 0; count = 1;

                    if (expression.ElementAt(i - 1) == ')')
                    {
                        for (l = i - 2; count != 0; l--)
                        {
                            if (expression.ElementAt(l) == ')')
                            {
                                count++;
                            }
                            if (expression.ElementAt(l) == '(')
                            {
                                count--;
                            }
                        }
                        g = int.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        //value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        //expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    else
                    {
                        for (l = i - 1; l >= 0 && !op.Contains(expression.ElementAt(l)); l--) ;
                        g = int.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        //value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        //expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    value = g.ToString() + "!/" + (g-f).ToString()+"!";
                    expression = expression.Replace(expression.Substring(l + 1, m-l-1), value);
                }


                //calculation of nCr function
                while (expression.Contains("C("))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("C");
                    int l;

                    for (l = i + 2; count != 0; l++)
                    {
                        if (expression.ElementAt(l) == '(')
                        {
                            count++;
                        }
                        if (expression.ElementAt(l) == ')')
                        {
                            count--;
                        }

                    }
                    int m = l;
                    int f = int.Parse(exprsol(expression.Substring(i + 1, l - i - 1))), g;
                    l = 0; count = 1;

                    if (expression.ElementAt(i - 1) == ')')
                    {
                        for (l = i - 2; count != 0; l--)
                        {
                            if (expression.ElementAt(l) == ')')
                            {
                                count++;
                            }
                            if (expression.ElementAt(l) == '(')
                            {
                                count--;
                            }
                        }
                        g = int.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        //value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        //expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    else
                    {
                        for (l = i - 1; l >= 0 && !op.Contains(expression.ElementAt(l)); l--) ;
                        g = int.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        //value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        //expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    value = g.ToString() + "!/(" + (g - f).ToString() + "!*"+f.ToString()+"!)";
                    expression = expression.Replace(expression.Substring(l + 1, m - l - 1), value);
                }



                //calculation of square function like (7+8)² and 7² 
                while (expression.Contains('²'))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("²");
                    int l;
                    if (expression.ElementAt(i - 1) == ')')
                    {
                        for (l = i - 2; count != 0; l--)
                        {
                            if (expression.ElementAt(l) == ')')
                            {
                                count++;
                            }
                            if (expression.ElementAt(l) == '(')
                            {
                                count--;
                            }
                        }
                        value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    else
                    {
                        for (l = i - 1; l >= 0 && !op.Contains(expression.ElementAt(l)); l--) ;
                        value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                }

                //calculation of Factorial function  
                while (expression.Contains('!'))
                {
                    int i, count = 1;
                    string value;
                    i = expression.IndexOf("!");
                    int l;
                    if (expression.ElementAt(i - 1) == ')')
                    {
                        for (l = i - 2; count != 0; l--)
                        {
                            if (expression.ElementAt(l) == ')')
                            {
                                count++;
                            }
                            if (expression.ElementAt(l) == '(')
                            {
                                count--;
                            }
                        }
                        Int64 f = Int64.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        if (f > 1)
                            for (Int64 h = f; h > 1; h--)
                            {
                                f = f * (h - 1);
                            }
                        value = f.ToString();
                        //value = (Math.Pow(double.Parse(exprsol(expression.Substring(l + 1, i - l - 1))), 2)).ToString();
                        expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                    else
                    {
                        
                        for (l = i - 1; l >= 0 && !op.Contains(expression.ElementAt(l)); l--) ;
                        Int64 f = Int64.Parse(exprsol(expression.Substring(l + 1, i - l - 1)));
                        if(f>1)
                            for (Int64 h = f; h > 1; h--)
                            {
                                f = f * (h - 1);
                            }
                            value = f.ToString();
                        expression = expression.Replace(expression.Substring(l + 1, i - l), value);
                    }
                }


                //Passsing the string for calculation of simple equation like 1+(2+6)*7
                do
                {
                    if (expression.Contains('('))
                    {
                        j = expression.LastIndexOf('(');
                        k = expression.IndexOf(')', j);
                        calculation_obj.expression = expression.Substring(j + 1, k - j - 1);
                        expression = expression.Replace(expression.Substring(j, k - j + 1), calculation_obj.arthitmatic());
                    }
                    else
                    {
                        calculation_obj.expression = expression;
                        string a = calculation_obj.arthitmatic();
                        if ( a != "syntax error")
                        {
                            return (double.Parse(a)).ToString();
                        }
                        else
                            return a;
                    }
                } while (true);

            }catch(Exception e){
                e.ToString();
                return "Syntax Error"; 
            }
            
        }

       
       
    }
}
