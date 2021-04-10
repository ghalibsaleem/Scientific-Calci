using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Scientific_Calci
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Equationsxaml : Page
    {
        public Equationsxaml()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        double[,] mat =new double[3,4];
        int flag = 0;

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }

        private void Two_variable_click(object sender, RoutedEventArgs e)
        {
            try
            {
                y_TwoVariable.Text = ((double.Parse(c12.Text) / double.Parse(a12.Text) - double.Parse(c22.Text) / double.Parse(a22.Text)) / (double.Parse(b12.Text) / double.Parse(a12.Text) - double.Parse(b22.Text) / double.Parse(a22.Text))).ToString();
                x_TwoVariable.Text = ((double.Parse(c12.Text) / double.Parse(b12.Text) - double.Parse(c22.Text) / double.Parse(b22.Text)) / (double.Parse(a12.Text) / double.Parse(b12.Text) - double.Parse(a22.Text) / double.Parse(b22.Text))).ToString();
        
            }
            catch 
            {
                y_TwoVariable.Text = "Input Error!";
                x_TwoVariable.Text = "Input Error!";                
            }
           }

        private void quadretic_click(object sender, RoutedEventArgs e)
        {
            try
            {
                double i;
                i = (double.Parse(bq.Text) * double.Parse(bq.Text) - 4 * double.Parse(aq.Text) * double.Parse(cq.Text));
                if (i >= 0)
                {
                    X_quad1.Text = ((Math.Pow(i, 0.5) - double.Parse(bq.Text)) / (2 * double.Parse(aq.Text))).ToString();
                    X_quad2.Text = (-(Math.Pow(i, 0.5) + double.Parse(bq.Text)) / (2 * double.Parse(aq.Text))).ToString();
                }
                else
                    X_quad1.Text = X_quad2.Text = "Imaginary root";
            }
            catch 
            {
                X_quad2.Text = "Input Error!";
                X_quad1.Text = "Input Error!";
            }
            
        }

        private void Conversions_changed(object sender, SelectionChangedEventArgs e)
        {
            
            if (Equations != null)
            {
                
                if (Equations.SelectedIndex == 0)
                {
                    TwoVariable.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    ThreeVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    QuadraticEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    CubicEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (Equations.SelectedIndex == 1)
                {
                    TwoVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    ThreeVariable.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    QuadraticEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    CubicEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (Equations.SelectedIndex == 2)
                {
                    TwoVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    ThreeVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    QuadraticEq.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    CubicEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (Equations.SelectedIndex == 3)
                {
                    
                    TwoVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    ThreeVariable.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    QuadraticEq.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    CubicEq.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
            }
        }

        private void textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            double ToArray;
            if (double.TryParse(((TextBox)sender).Text, out ToArray))
                flag--;
            ((TextBox)(sender)).Text="";
        }

        private void textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if(((TextBox)(sender)).Text=="")
                ((TextBox)(sender)).Text = "0";
            else
            {
                if (Equations != null && Equations.SelectedIndex == 3)
                {
                    if (!((TextBox)(sender)).Text.Contains("*") && !((TextBox)(sender)).Text.Contains("#") && !((TextBox)(sender)).Text.Contains(" "))
                    {

                        double[] coff = new double[4];

                        if (double.TryParse(ac.Text, out coff[0]))
                            if (double.TryParse(bc.Text, out coff[1]))
                                if (double.TryParse(cc.Text, out coff[2]))
                                    if (double.TryParse(dc.Text, out coff[3]))
                                    {
                                        coff[1] /= coff[0];
                                        coff[2] /= coff[0];
                                        coff[3] /= coff[0];
                                        coff[0] = 1;
                                        EquationModel.CubicEquation cqeq = new EquationModel.CubicEquation();
                                        double[,] result = cqeq.solution(coff);
                                        X1_cubic.Text = result[0, 0].ToString() + " + " + result[0, 1].ToString() + "i";
                                        X2_cubic.Text = result[1, 0].ToString() + " + " + result[1, 1].ToString() + "i";
                                        X3_cubic.Text = result[2, 0].ToString() + " + " + result[2, 1].ToString() + "i";
                                    }
                    }
                    else
                        X1_cubic.Text = "Error at " + ((TextBox)(sender)).Name.ElementAt(0);
                }
                
            }
            
        }

       
        private void threeVariable_lostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                double ToArray;
                if (((TextBox)sender).Text == "")
                    ((TextBox)sender).Text = ((((TextBox)sender).Name).Remove(((TextBox)sender).Name.Length - 1, 1)).ToUpper();

                if (double.TryParse(((TextBox)sender).Text, out ToArray))
                {

                    // mat[0,0] = 0;
                    mat[int.Parse((((TextBox)sender).Name.Remove(0, 1)).Remove(1, 1)) - 1, ((TextBox)sender).Name.ElementAt(0) - 97] = ToArray;
                    flag++;
                }

                if (flag == 12)
                {
                    double[] r;
                    EquationModel.LinearEquations eq = new EquationModel.LinearEquations();
                    r = eq.EquationSolution(mat);

                    x3.Text = (-1 * r[0]).ToString();
                    y3.Text = (-1 * r[1]).ToString();
                    z3.Text = (-1 * r[2]).ToString();
                }
            }
            catch 
            {
                x3.Text = "Input Error!";
                y3.Text = "Input Error!";
                z3.Text = "Input Error!";
                
            }
            

             
        }

       
        

        //private void three_variable(object sender, RoutedEventArgs e)
        //{
        //    Double a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3;
        //    a1 = double.Parse(a13.Text);
        //    b1 = double.Parse(b13.Text);
        //    c1 = double.Parse(c13.Text);
        //    d1 = double.Parse(d13.Text);
        //    a2 = double.Parse(a23.Text);
        //    b2 = double.Parse(b23.Text);
        //    c2 = double.Parse(c23.Text);
        //    d2 = double.Parse(d23.Text);
        //    a3 = double.Parse(a33.Text);
        //    b3 = double.Parse(b33.Text);
        //    c3 = double.Parse(c33.Text);
        //    d3 = double.Parse(d33.Text);

        //    X_three.Text = ((2 * d1 - d3) / a1 * (b2 - b1) / b1 * (c3 - c2) / (2 * c1 - c2)).ToString();

        //}
    }
}
