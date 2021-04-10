using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scientific_Calci
{
    class Calculation
    {
        
        char[] op = {'^','%','÷','×','*','/','+','(',')'};
        string[] exp; 

        //Dictionary<int,double> numbers = new Dictionary<int,double>();
        //Dictionary<int,char > operators_priority1 = new Dictionary<int, char>();
        Dictionary<int, char> operators_priority2 = new Dictionary<int, char>();
        //Dictionary<int, string> functions = new Dictionary<int, string>();
        List<string> lst = new List<string>();

        string operator_priority1 = "";
       

        public string expression { get; set; }
        public string result { get; set; }

        public string arthitmatic()
        {
            result = "";
            try{
                    double temp = 0;

                    for (int i = 1; i < expression.Length; i++)
                    {
                        if (expression.ElementAt(i) == '-')
                        {
                            if (expression.ElementAt(i - 1) == '-')
                            {
                                if (i > 2 && expression.ElementAt(i - 2) > 47 && expression.ElementAt(i - 2) < 58)
                                {
                                    expression = expression.Remove(i - 1, 2);
                                    expression = expression.Insert(i - 1, "+");

                                }
                                else
                                {
                                    expression = expression.Remove(i - 1, 2);
                                }
                            }


                        }
                    }

                    double one;
                    if (double.TryParse(expression, out one))
                    {
                        return expression;
                    }

                    
                    
                    exp = expression.Split(op);

                    int j = 0, k = 0;
                    for (int i = 0; i < expression.Length; i++ )
                    {
                        if(expression.ElementAt(i) == '+'){
                            operator_priority1 += "+";
                            operators_priority2.Add(j,expression.ElementAt(i));
                            j++;
                        }
                        //if (expression.ElementAt(i) == '-')
                        //{
                        //    operator_priority1 += "-";
                        //    operators_priority2.Add(j, expression.ElementAt(i));
                        //    j++;
                        //}
                        if (expression.ElementAt(i) == '×' || expression.ElementAt(i) == '*')
                        {
                            operator_priority1 += "*";
                            k++;
                        }
                        if (expression.ElementAt(i) == '÷' || expression.ElementAt(i) == '/')
                        {
                            operator_priority1 += "/";
                            k++;
                        }
                        if (expression.ElementAt(i) == '%')
                        {
                            operator_priority1 += "%";
                            k++;
                        }
                        if (expression.ElementAt(i) == '^')
                        {
                            operator_priority1 += "^";
                            k++;
                        }

                    }


                    for (int i = 0; i < operator_priority1.Length; i++)
                    {
                        if (operator_priority1.ElementAtOrDefault(i) == '^')
                        {
                            temp = Math.Pow(double.Parse(exp[i]), double.Parse(exp[i + 1]));
                            lst = exp.ToList();
                            lst.RemoveAt(i);
                            exp = lst.ToArray();
                            //exp = exp.Where(w => w != exp[i]).ToArray();
                            operator_priority1 = operator_priority1.Remove(i, 1);
                            exp[i] = temp.ToString();
                            i--;
                        }
                    }
                    

                    for (int i = 0; i< operator_priority1.Length; i++)
                    {
                        //if (operator_priority1.ElementAtOrDefault(i) == '^')
                        //{
                        //    temp = Math.Pow(double.Parse(exp[i]), double.Parse(exp[i + 1]));
                        //    lst = exp.ToList();
                        //    lst.RemoveAt(i);
                        //    exp = lst.ToArray();
                        //    //exp = exp.Where(w => w != exp[i]).ToArray();
                        //    operator_priority1 = operator_priority1.Remove(i, 1);
                        //    exp[i] = temp.ToString();
                        //    i--;
                        //}
                        
                        if (operator_priority1.ElementAtOrDefault(i) == '*')
                        {
                            temp = double.Parse(exp[i]) * double.Parse(exp[i + 1]);
                            lst = exp.ToList();
                            lst.RemoveAt(i);
                            exp = lst.ToArray();
                            //exp = exp.Where(w => w != exp[i]).ToArray();
                            operator_priority1 = operator_priority1.Remove(i, 1);
                            exp[i] = temp.ToString();
                            i--;
                        }
                        
                        if (operator_priority1.ElementAtOrDefault(i) == '/')
                        {
                            temp = double.Parse(exp[i]) / double.Parse(exp[i + 1]);
                            lst = exp.ToList();
                            lst.RemoveAt(i);
                            exp = lst.ToArray();
                            //exp = exp.Where(w => w != exp[i]).ToArray();
                            operator_priority1 = operator_priority1.Remove(i, 1);
                            exp[i] = temp.ToString();
                            i--;
                        }
                        if (operator_priority1.ElementAtOrDefault(i) == '%')
                        {
                            temp = double.Parse(exp[i]) % double.Parse(exp[i + 1]);
                            lst = exp.ToList();
                            lst.RemoveAt(i);
                            exp = lst.ToArray();
                            //exp = exp.Where(w => w != exp[i]).ToArray();
                            operator_priority1 = operator_priority1.Remove(i, 1);
                            exp[i] = temp.ToString();
                            i--;
                        }
                    }

                    for (int i = 0; i < j; i++)
                    {
                        if (operators_priority2.ElementAtOrDefault(i).Value == '+')
                        {
                            temp = double.Parse(exp[i]) + double.Parse(exp[i+1]);
                            //exp = exp.Where(w => w != exp[i]).ToArray();
                            exp[i+1] = temp.ToString();
                    
                        }
                        //if (operators_priority2.ElementAtOrDefault(i).Value == '-')
                        //{
                        //    temp = double.Parse(exp[i]) - double.Parse(exp[i + 1]);
                        //    //exp = exp.Where(w => w != exp[i]).ToArray();
                        //    exp[i + 1] = temp.ToString();

                        //}
                    }
               
                    
                    result = temp.ToString();
                    operators_priority2.Clear();
                    operator_priority1 = "";
                    return result;
            }
            catch(Exception e){
                e.ToString();
                return "Syntax Error";
            }
        }


        
    }
}
