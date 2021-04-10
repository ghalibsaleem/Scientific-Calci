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
    public sealed partial class Vectors : Page
    {
        public Vectors()
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

        private void conversions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (conversions != null && conversions.SelectedIndex == 0)
            {
                Two_D_grid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Three_D_grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            if (conversions != null && conversions.SelectedIndex == 1)
            {
                Two_D_grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                Three_D_grid.Visibility = Windows.UI.Xaml.Visibility.Visible;

            }
        }

        

        

        private void Textbox_LostFocus_3d(object sender, RoutedEventArgs e)
        {
            try
            {


                if (((TextBox)sender).Text != "-")
                {
                    if (a_three.Text != "" && b_three.Text != "" && c_three.Text != "")
                    {
                        mod_u_three.Text = (Math.Pow((Math.Pow(double.Parse(a_three.Text), 2) + Math.Pow(double.Parse(b_three.Text), 2) + Math.Pow(double.Parse(c_three.Text), 2)), 0.5)).ToString();
                    }

                    if (x_three.Text != "" && y_three.Text != "" && z_three.Text != "")
                    {
                        mod_v_three.Text = (Math.Pow((Math.Pow(double.Parse(x_three.Text), 2) + Math.Pow(double.Parse(y_three.Text), 2) + Math.Pow(double.Parse(z_three.Text), 2)), 0.5)).ToString();
                    }

                    if (a_three.Text != "" && b_three.Text != "" && c_three.Text != "" && x_three.Text != "" && y_three.Text != "" && z_three.Text != "")
                    {
                        u_dot_v_three.Text = (double.Parse(a_three.Text) * double.Parse(x_three.Text) + double.Parse(b_three.Text) * double.Parse(y_three.Text) + double.Parse(c_three.Text) * double.Parse(z_three.Text)).ToString();
                        u_cross_v_three.Text = (double.Parse(b_three.Text) * double.Parse(z_three.Text) - double.Parse(c_three.Text) * double.Parse(y_three.Text)).ToString() + "i+(";
                        u_cross_v_three.Text += (double.Parse(a_three.Text) * double.Parse(z_three.Text) - double.Parse(c_three.Text) * double.Parse(x_three.Text)).ToString() + ")j+(";
                        u_cross_v_three.Text += (double.Parse(a_three.Text) * double.Parse(y_three.Text) - double.Parse(b_three.Text) * double.Parse(x_three.Text)).ToString() + ")k";
                    }
                }
                else
                {
                    ((TextBox)sender).Text = "";
                }
            }
            catch 
            {
                
                u_dot_v_three.Text = "Input Error!";
                u_cross_v_three.Text = "Input Error!";
            }
        }

        private void Textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                if (((TextBox)sender).Text != "-")
                {
                    if (a.Text != "" && b.Text != "")
                    {
                        mod_u.Text = (Math.Pow((Math.Pow(double.Parse(a.Text), 2) + Math.Pow(double.Parse(b.Text), 2)), 0.5)).ToString();
                    }

                    if (x.Text != "" && y.Text != "")
                    {
                        mod_v.Text = (Math.Pow((Math.Pow(double.Parse(x.Text), 2) + Math.Pow(double.Parse(y.Text), 2)), 0.5)).ToString();
                    }

                    if (a.Text != "" && b.Text != "" && x.Text != "" && y.Text != "")
                    {
                        u_dot_v.Text = (double.Parse(a.Text) * double.Parse(x.Text) + double.Parse(b.Text) * double.Parse(y.Text)).ToString();
                        u_cross_v.Text = (double.Parse(a.Text) * double.Parse(y.Text) + double.Parse(b.Text) * double.Parse(x.Text)).ToString() + "k";

                    }
                }
                else
                {
                    ((TextBox)sender).Text = "";
                }
            }
            catch
            {
                u_dot_v.Text = "Input Error!";
                u_cross_v.Text = "Input Error!";
            }
        }

        private void Textbox_TextChanged_3d(object sender, TextChangedEventArgs e)
        {

        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
