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
    public sealed partial class Base_N : Page
    {
        public Base_N()
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

        int j;

        private void binary_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
                if (Binary_no.Text != "")
                   Decimal_no.Text = Convert.ToInt32(Binary_no.Text, 2).ToString();
            }
            catch (Exception q)
            {
                q.ToString();
                Binary_no.Text =  Binary_no.Text.Remove(Binary_no.Text.Length-1);
            }
        }

        private void decimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;

            if (int.TryParse(Decimal_no.Text, out i))
            {
                octal_no.Text = Convert.ToString(i, 8);
                hexadecimal_no.Text = Convert.ToString(i, 16);
                Binary_no.Text = Convert.ToString(i, 2);
            }
        }

        private void hexadecimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            try
            {

                if(hexadecimal_no.Text != "")
                Decimal_no.Text = Convert.ToInt32(hexadecimal_no.Text, 16).ToString();
            }
            catch (Exception q)
            {
                q.ToString();
              hexadecimal_no.Text =  hexadecimal_no.Text.Remove(hexadecimal_no.Text.Length-1);
            }
        }

        private void octal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(octal_no.Text != "")
                Decimal_no.Text = Convert.ToInt32(octal_no.Text, 8).ToString();
            }catch(Exception q){
                q.ToString();
                octal_no.Text = octal_no.Text.Remove(octal_no.Text.Length-1);
            }
        }

        private void one(object sender, RoutedEventArgs e)
        {
            if (j == 0)
                Binary_no.Text += "1";
            if (j == 1)
                Decimal_no.Text += "1";
            if (j == 2)
                hexadecimal_no.Text += "1";
            if (j == 3)
                octal_no.Text += "1";
        }

        private void Binary_no_GotFocus(object sender, RoutedEventArgs e)
        {
            j = 0;
            BinaryKeyboard.Visibility = Windows.UI.Xaml.Visibility.Visible;
            DecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            HexaDecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            OctalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Decimal_no_GotFocus(object sender, RoutedEventArgs e)
        {
            j = 1;
            BinaryKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            DecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Visible;
            HexaDecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            OctalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void hexadecimal_no_GotFocus(object sender, RoutedEventArgs e)
        {
            j = 2;
            BinaryKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            DecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            HexaDecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Visible;
            OctalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void octal_no_GotFocus(object sender, RoutedEventArgs e)
        {
            j = 3;
            BinaryKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            DecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            HexaDecimalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            OctalKeyboard.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            Decimal_no.Text = "0";
        }


        private void zero(object sender, RoutedEventArgs e)
        {

            if (j == 0)
                Binary_no.Text += "0";
            if (j == 1)
                Decimal_no.Text += "0";
            if (j == 2)
                hexadecimal_no.Text += "0";
            if (j == 3)
                octal_no.Text += "0";
        }

        private void backspace(object sender, RoutedEventArgs e)
        {
            
            if (j == 0)
                if (Binary_no.Text != "")
                    Binary_no.Text = Binary_no.Text.Remove(Binary_no.Text.Length-1,1);
            if (j == 1)
                if (Decimal_no.Text != "")
                    Decimal_no.Text = Decimal_no.Text.Remove(Decimal_no.Text.Length-1,1);
            if (j == 2)
                if (hexadecimal_no.Text != "")
                    hexadecimal_no.Text = hexadecimal_no.Text.Remove(hexadecimal_no.Text.Length-1,1);
            if (j == 3)
                if (octal_no.Text != "")
                    octal_no.Text = octal_no.Text.Remove(octal_no.Text.Length-1,1);
        }

        private void two(object sender, RoutedEventArgs e)
        {
            
            if (j == 1)
                Decimal_no.Text += "2";
            if (j == 2)
                hexadecimal_no.Text += "2";
            if (j == 3)
                octal_no.Text += "2";
        }

        private void three(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "3";
            if (j == 2)
                hexadecimal_no.Text += "3";
            if (j == 3)
                octal_no.Text += "3";
        }

        private void four(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "4";
            if (j == 2)
                hexadecimal_no.Text += "4";
            if (j == 3)
                octal_no.Text += "4";
        }

        private void five(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "5";
            if (j == 2)
                hexadecimal_no.Text += "5";
            if (j == 3)
                octal_no.Text += "5";
        }

        private void six(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "6";
            if (j == 2)
                hexadecimal_no.Text += "6";
            if (j == 3)
                octal_no.Text += "6";
        }

        private void seven(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "7";
            if (j == 2)
                hexadecimal_no.Text += "7";
            if (j == 3)
                octal_no.Text += "7";
        }

        private void eight(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "8";
            if (j == 2)
                hexadecimal_no.Text += "8";
            
        }

        private void nine(object sender, RoutedEventArgs e)
        {
            if (j == 1)
                Decimal_no.Text += "9";
            if (j == 2)
                hexadecimal_no.Text += "9";
        }

        private void a_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "a";
        }

        private void b_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "b";
        }

        private void c_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "c";
        }

        private void d_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "d";
        }

        private void e_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "e";
        }

        private void f_click(object sender, RoutedEventArgs e)
        {
            hexadecimal_no.Text += "f";
        }
    }
}
