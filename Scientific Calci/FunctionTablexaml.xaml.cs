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
    public sealed partial class FunctionTablexaml : Page
    {
        TextBox textbox_handler = new TextBox();
        
        public FunctionTablexaml()
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

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)e.OriginalSource).Text == ((TextBox)e.OriginalSource).Name)
                ((TextBox)e.OriginalSource).Text = "";
            textbox_handler = ((TextBox)e.OriginalSource);
        }

       
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (((TextBox)e.OriginalSource).Text == "")
            //    ((TextBox)e.OriginalSource).Text = ((TextBox)e.OriginalSource).Name;
        }

        private void Calculate_click(object sender, RoutedEventArgs e)
        { 
            int j=1; 
            exprsolution exprsolution_obj = new exprsolution();
            try
            {
                if (X1.Text != "X1" && X2.Text != "X2" && h.Text != "h")
                    for (double i = double.Parse(X1.Text); i <= double.Parse(X2.Text); i += double.Parse(h.Text))
                    {

                        if (ƒx.Text.Contains('x'))
                            output_table.Text += "\n" + j.ToString() + "     " + i.ToString() + "      " + exprsolution_obj.exprsol(ƒx.Text.Replace("x", i.ToString()));
                        else
                            output_table.Text += "\n" + j.ToString() + "     " + i.ToString() + "      " + exprsolution_obj.exprsol(ƒx.Text.Replace("X", i.ToString()));
                        j++;
                    }
            }catch(Exception g){
                g.ToString();
                output_table.Text += "\nSyntax Error";
            }
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            output_table.Text = "S.no.        X               ƒx";
        }

        private void sine(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "sin(";
            
             
        }

        private void cosine(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "cos(";
           
           
        }

        private void tangent(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "tan(";
        }

        private void sine_hyperbolic(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "sinh(";
        }

        private void cosine_hyperbolic(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "cosh(";
        }

        private void tagnet_hyperbolic(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "tanh(";
        }

        private void log10(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "log(";
        }

        private void loge(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "(";
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "+";
        }

        private void multiply(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "*";
        }

        private void divide(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "/";
        }

        private void power(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "^";
        }

        private void xbutton(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "x";
        }

        private void modulus(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += ")";
        }

        private void minus(object sender, RoutedEventArgs e)
        {
            textbox_handler.Text += "-";
        }
    }
}
