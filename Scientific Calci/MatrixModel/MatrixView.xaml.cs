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

namespace Scientific_Calci.MatrixModel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MatrixView : Page
    {
        public MatrixView()
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
        private void Matrix_A_SectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MatrixA != null)
            {
                R1.Text = "";
                R2.Text = "";
                R3.Text = "";
                R4.Text = "";
                R5.Text = "";
                R6.Text = "";
                R7.Text = "";
                R8.Text = "";
                R9.Text = "";
                result.Text = "";
                if (MatrixA.SelectedIndex == 0)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                if (MatrixA.SelectedIndex == 1)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixA.SelectedIndex == 2)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                }
                if (MatrixA.SelectedIndex == 3)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixA.SelectedIndex == 4)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixA.SelectedIndex == 5)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixA.SelectedIndex == 6)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixA.SelectedIndex == 7)
                {
                    A1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    A3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    A9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
        }

        private void Matrix_B_SectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MatrixB != null)
            {
                R1.Text = "";
                R2.Text = "";
                R3.Text = "";
                R4.Text = "";
                R5.Text = "";
                R6.Text = "";
                R7.Text = "";
                R8.Text = "";
                R9.Text = "";
                result.Text = "";
                if (MatrixB.SelectedIndex == 0)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                if (MatrixB.SelectedIndex == 1)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixB.SelectedIndex == 2)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                }
                if (MatrixB.SelectedIndex == 3)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixB.SelectedIndex == 4)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixB.SelectedIndex == 5)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixB.SelectedIndex == 6)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (MatrixB.SelectedIndex == 7)
                {
                    B1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    B3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    B9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
        }

        private void MatrixAddition(object sender, RoutedEventArgs e)
        {
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            result.Text = "";
            try
            {
                if (MatrixA.SelectedIndex == MatrixB.SelectedIndex)
                {
                    if (MatrixA.SelectedIndex == 0)
                    {
                        R1.Text = (double.Parse(A1.Text) + double.Parse(B1.Text)).ToString();
                        R2.Text = (double.Parse(A2.Text) + double.Parse(B2.Text)).ToString();
                        R3.Text = (double.Parse(A3.Text) + double.Parse(B3.Text)).ToString();
                        R4.Text = (double.Parse(A4.Text) + double.Parse(B4.Text)).ToString();
                        R5.Text = (double.Parse(A5.Text) + double.Parse(B5.Text)).ToString();
                        R6.Text = (double.Parse(A6.Text) + double.Parse(B6.Text)).ToString();
                        R7.Text = (double.Parse(A7.Text) + double.Parse(B7.Text)).ToString();
                        R8.Text = (double.Parse(A8.Text) + double.Parse(B8.Text)).ToString();
                        R9.Text = (double.Parse(A9.Text) + double.Parse(B9.Text)).ToString();
                    }
                    if (MatrixA.SelectedIndex == 4)
                    {
                        R1.Text = (double.Parse(A1.Text) + double.Parse(B1.Text)).ToString();
                        R2.Text = (double.Parse(A2.Text) + double.Parse(B2.Text)).ToString();
                        
                        R4.Text = (double.Parse(A4.Text) + double.Parse(B4.Text)).ToString();
                        R5.Text = (double.Parse(A5.Text) + double.Parse(B5.Text)).ToString();
                        
                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void MatrixSubstraction(object sender, RoutedEventArgs e)
        {
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            result.Text = "";
            try
            {
                if (MatrixA.SelectedIndex == MatrixB.SelectedIndex)
                {
                    if (MatrixA.SelectedIndex == 0)
                    {
                        R1.Text = (double.Parse(A1.Text) - double.Parse(B1.Text)).ToString();
                        R2.Text = (double.Parse(A2.Text) - double.Parse(B2.Text)).ToString();
                        R3.Text = (double.Parse(A3.Text) - double.Parse(B3.Text)).ToString();
                        R4.Text = (double.Parse(A4.Text) - double.Parse(B4.Text)).ToString();
                        R5.Text = (double.Parse(A5.Text) - double.Parse(B5.Text)).ToString();
                        R6.Text = (double.Parse(A6.Text) - double.Parse(B6.Text)).ToString();
                        R7.Text = (double.Parse(A7.Text) - double.Parse(B7.Text)).ToString();
                        R8.Text = (double.Parse(A8.Text) - double.Parse(B8.Text)).ToString();
                        R9.Text = (double.Parse(A9.Text) - double.Parse(B9.Text)).ToString();
                    }
                    if (MatrixA.SelectedIndex == 4)
                    {
                        R1.Text = (double.Parse(A1.Text) - double.Parse(B1.Text)).ToString();
                        R2.Text = (double.Parse(A2.Text) - double.Parse(B2.Text)).ToString();

                        R4.Text = (double.Parse(A4.Text) - double.Parse(B4.Text)).ToString();
                        R5.Text = (double.Parse(A5.Text) - double.Parse(B5.Text)).ToString();

                    }
                }
                else
                    throw new Exception();
            }
            catch
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void MatrixMultiplication(object sender, RoutedEventArgs e)
        {
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            result.Text = "";
            try
            {
                if (MatrixA.SelectedValue.ToString().ElementAt(MatrixA.SelectedValue.ToString().Length-1) == MatrixB.SelectedValue.ToString().ElementAt(0))
                {
                    double temp = double.Parse(A1.Text) * double.Parse(B1.Text);
                    double i, j;
                    if (double.TryParse(A2.Text, out i) && double.TryParse(B4.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A3.Text, out i) && double.TryParse(B7.Text, out j))
                    {
                        temp += i * j;
                    }
                    R1.Text = temp.ToString();
                    

                    if (double.TryParse(A1.Text, out i) && double.TryParse(B2.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A2.Text, out i) && double.TryParse(B5.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A3.Text, out i) && double.TryParse(B8.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A1.Text, out i) && double.TryParse(B2.Text, out j))
                        R2.Text = temp.ToString();

                    if (double.TryParse(A1.Text, out i) && double.TryParse(B3.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A2.Text, out i) && double.TryParse(B6.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A3.Text, out i) && double.TryParse(B9.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A1.Text, out i) && double.TryParse(B3.Text, out j))
                        R3.Text = temp.ToString();

                    if (double.TryParse(A4.Text, out i) && double.TryParse(B1.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A5.Text, out i) && double.TryParse(B4.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A6.Text, out i) && double.TryParse(B7.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A4.Text, out i) && double.TryParse(B1.Text, out j))
                        R4.Text = temp.ToString();

                    if (double.TryParse(A4.Text, out i) && double.TryParse(B2.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A5.Text, out i) && double.TryParse(B5.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A6.Text, out i) && double.TryParse(B8.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A4.Text, out i) && double.TryParse(B2.Text, out j))
                         R5.Text = temp.ToString();

                    if (double.TryParse(A4.Text, out i) && double.TryParse(B3.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A5.Text, out i) && double.TryParse(B6.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A6.Text, out i) && double.TryParse(B9.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A4.Text, out i) && double.TryParse(B3.Text, out j))
                         R6.Text = temp.ToString();

                    if (double.TryParse(A7.Text, out i) && double.TryParse(B1.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A8.Text, out i) && double.TryParse(B4.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A9.Text, out i) && double.TryParse(B7.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A7.Text, out i) && double.TryParse(B1.Text, out j))
                        R7.Text = temp.ToString();

                    if (double.TryParse(A7.Text, out i) && double.TryParse(B2.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A8.Text, out i) && double.TryParse(B5.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A9.Text, out i) && double.TryParse(B8.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A7.Text, out i) && double.TryParse(B2.Text, out j))
                        R8.Text = temp.ToString();

                    if (double.TryParse(A7.Text, out i) && double.TryParse(B3.Text, out j))
                    {
                        temp = i * j;
                    }
                    if (double.TryParse(A8.Text, out i) && double.TryParse(B6.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A9.Text, out i) && double.TryParse(B9.Text, out j))
                    {
                        temp += i * j;
                    }
                    if (double.TryParse(A7.Text, out i) && double.TryParse(B3.Text, out j))
                        R9.Text = temp.ToString();
                }
                else
                    throw new Exception();
            }
            catch
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void Modulus_A(object sender, RoutedEventArgs e)
        {

            FlyoutModulus.Hide();
            try
            {
                if (MatrixA.SelectedIndex == 0 || MatrixA.SelectedIndex == 4)
                {
                    if (MatrixA.SelectedIndex == 0)
                    {
                        double i = double.Parse(A5.Text) * double.Parse(A9.Text) - double.Parse(A8.Text) * double.Parse(A6.Text);
                        double j = double.Parse(A4.Text) * double.Parse(A9.Text) - double.Parse(A7.Text) * double.Parse(A6.Text);
                        double k = double.Parse(A4.Text) * double.Parse(A8.Text) - double.Parse(A7.Text) * double.Parse(A5.Text);
                        result.Text = "|A|= " + (double.Parse(A1.Text) * i - double.Parse(A2.Text) * j + double.Parse(A3.Text) * k).ToString();
                    }
                    else
                    {
                        result.Text ="|A|= "+ (double.Parse(A1.Text)*double.Parse(A5.Text)-double.Parse(A4.Text)*double.Parse(A2.Text)).ToString();
                    }
                }
                else
                    throw new Exception();
            }
            catch 
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void Modulus_B(object sender, RoutedEventArgs e)
        {
            FlyoutModulus.Hide();
            try
            {
                if (MatrixB.SelectedIndex == 0 || MatrixB.SelectedIndex == 4)
                {
                    if (MatrixB.SelectedIndex == 0)
                    {
                        double i = double.Parse(B5.Text) * double.Parse(B9.Text) - double.Parse(B8.Text) * double.Parse(B6.Text);
                        double j = double.Parse(B4.Text) * double.Parse(B9.Text) - double.Parse(B7.Text) * double.Parse(B6.Text);
                        double k = double.Parse(B4.Text) * double.Parse(B8.Text) - double.Parse(B7.Text) * double.Parse(B5.Text);
                        result.Text = "|B|= " + (double.Parse(B1.Text) * i - double.Parse(B2.Text) * j + double.Parse(B3.Text) * k).ToString();
                    }
                    else
                    {
                        result.Text = "|B|= " + (double.Parse(B1.Text) * double.Parse(B5.Text) - double.Parse(B4.Text) * double.Parse(B2.Text)).ToString();
                    }
                }
                else
                    throw new Exception();
            }
            catch {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void Transpose_A(object sender, RoutedEventArgs e)
        {
            result.Text = "";
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            
            FlyoutTranspose.Hide();
            try
            {
                R1.Text = A1.Text;
                if(A4.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R2.Text = A4.Text;
                if (A7.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R3.Text = A7.Text;
                if (A2.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R4.Text = A2.Text;
                if (A5.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R5.Text = A5.Text;
                if (A8.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R6.Text = A8.Text;
                if (A3.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R7.Text = A3.Text;
                if (A6.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R8.Text = A6.Text;
                if (A9.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R9.Text = A9.Text;
            }
            catch
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void Transpose_B(object sender, RoutedEventArgs e)
        {
            result.Text = "";
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            FlyoutTranspose.Hide();
            try
            {
                R1.Text = B1.Text;
                if (B4.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R2.Text = B4.Text;
                if (B7.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R3.Text = B7.Text;
                if (B2.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R4.Text = B2.Text;
                if (B5.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R5.Text = B5.Text;
                if (B8.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R6.Text = B8.Text;
                if (B3.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R7.Text = B3.Text;
                if (B6.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R8.Text = B6.Text;
                if (B9.Visibility != Windows.UI.Xaml.Visibility.Collapsed)
                    R9.Text = B9.Text;
            }
            catch
            {
                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void Dismiss(object sender, RoutedEventArgs e)
        {
            ErrorFlyout.Hide();
            
            
        }

        private void EigenValuesMethod(object sender, RoutedEventArgs e)
        {
            MatrixModel.Eigen.EigenStruct value;
            double[,] coff = new double[3, 3];
            EigenValue.Hide();
            result.Text = "λ= ";
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            try
            {

            
                if (((Button)sender).Content.ToString() == "Matrix A")
                {
                    if (MatrixA.SelectedIndex == 0)
                    {
                        if (double.TryParse(A1.Text, out coff[0, 0]))
                            if (double.TryParse(A2.Text, out coff[0, 1]))
                                if (double.TryParse(A3.Text, out coff[0, 2]))
                                    if (double.TryParse(A4.Text, out coff[1, 0]))
                                        if (double.TryParse(A5.Text, out coff[1, 1]))
                                            if (double.TryParse(A6.Text, out coff[1, 2]))
                                                if (double.TryParse(A7.Text, out coff[2, 0]))
                                                    if (double.TryParse(A8.Text, out coff[2, 1]))
                                                        if (double.TryParse(A9.Text, out coff[2, 2]))
                                                        {
                                                            value = MatrixModel.Eigen.EigenVector(coff);
                                                            for (int i = 0; i < value.wr.Length; i++)
                                                            {
                                                                result.Text += value.wr[i].ToString() + "+" + value.wi[i].ToString() + "i , ";
                                                            }
                                                        }
                    }
                    else
                    {
                        ErrorFlyout.ShowAt((Button)sender);
                    }
                    
                }
                else
                {
                    if (MatrixB.SelectedIndex == 0)
                    {


                        if (double.TryParse(B1.Text, out coff[0, 0]))
                            if (double.TryParse(B2.Text, out coff[0, 1]))
                                if (double.TryParse(B3.Text, out coff[0, 2]))
                                    if (double.TryParse(B4.Text, out coff[1, 0]))
                                        if (double.TryParse(B5.Text, out coff[1, 1]))
                                            if (double.TryParse(B6.Text, out coff[1, 2]))
                                                if (double.TryParse(B7.Text, out coff[2, 0]))
                                                    if (double.TryParse(B8.Text, out coff[2, 1]))
                                                        if (double.TryParse(B9.Text, out coff[2, 2]))
                                                        {
                                                            value = MatrixModel.Eigen.EigenVector(coff);
                                                            for (int i = 0; i < value.wr.Length; i++)
                                                            {
                                                                result.Text += value.wr[i].ToString() + "+" + value.wi[i].ToString() + "i , ";
                                                            }
                                                        }
                    }else
                        ErrorFlyout.ShowAt((Button)sender);
                    
                }
            }
            catch (Exception)
            {

                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void EigenVectorMethod(object sender, RoutedEventArgs e)
        {
            MatrixModel.Eigen.EigenStruct value;
            double[,] coff = new double[3, 3];

            EigenVector.Hide();
            result.Text = "";
            R1.Text = "";
            R2.Text = "";
            R3.Text = "";
            R4.Text = "";
            R5.Text = "";
            R6.Text = "";
            R7.Text = "";
            R8.Text = "";
            R9.Text = "";
            try
            {


                if (((Button)sender).Content.ToString() == "Matrix A")
                {
                    if (MatrixA.SelectedIndex == 0)
                    {
                        if (double.TryParse(A1.Text, out coff[0, 0]))
                            if (double.TryParse(A2.Text, out coff[0, 1]))
                                if (double.TryParse(A3.Text, out coff[0, 2]))
                                    if (double.TryParse(A4.Text, out coff[1, 0]))
                                        if (double.TryParse(A5.Text, out coff[1, 1]))
                                            if (double.TryParse(A6.Text, out coff[1, 2]))
                                                if (double.TryParse(A7.Text, out coff[2, 0]))
                                                    if (double.TryParse(A8.Text, out coff[2, 1]))
                                                        if (double.TryParse(A9.Text, out coff[2, 2]))
                                                        {
                                                            value = MatrixModel.Eigen.EigenVector(coff);
                                                            Eginvectorview.Visibility = Windows.UI.Xaml.Visibility.Visible;
                                                            E1.Text = value.vr[0, 0].ToString();
                                                            E2.Text = value.vr[0, 1].ToString();
                                                            E3.Text = value.vr[0, 2].ToString();
                                                            E4.Text = value.vr[1, 0].ToString();
                                                            E5.Text = value.vr[1, 1].ToString();
                                                            E6.Text = value.vr[1, 2].ToString();
                                                            E7.Text = value.vr[2, 0].ToString();
                                                            E8.Text = value.vr[2, 1].ToString();
                                                            E9.Text = value.vr[2, 2].ToString();
                                                        }
                    }
                    else
                        ErrorFlyout.ShowAt((Button)sender);

                }
                else
                {
                    if (MatrixB.SelectedIndex == 0)
                    {
                        if (double.TryParse(B1.Text, out coff[0, 0]))
                            if (double.TryParse(B2.Text, out coff[0, 1]))
                                if (double.TryParse(B3.Text, out coff[0, 2]))
                                    if (double.TryParse(B4.Text, out coff[1, 0]))
                                        if (double.TryParse(B5.Text, out coff[1, 1]))
                                            if (double.TryParse(B6.Text, out coff[1, 2]))
                                                if (double.TryParse(B7.Text, out coff[2, 0]))
                                                    if (double.TryParse(B8.Text, out coff[2, 1]))
                                                        if (double.TryParse(B9.Text, out coff[2, 2]))
                                                        {
                                                            value = MatrixModel.Eigen.EigenVector(coff);
                                                            Eginvectorview.Visibility = Windows.UI.Xaml.Visibility.Visible;
                                                            E1.Text = value.vr[0, 0].ToString();
                                                            E2.Text = value.vr[0, 1].ToString();
                                                            E3.Text = value.vr[0, 2].ToString();
                                                            E4.Text = value.vr[1, 0].ToString();
                                                            E5.Text = value.vr[1, 1].ToString();
                                                            E6.Text = value.vr[1, 2].ToString();
                                                            E7.Text = value.vr[2, 0].ToString();
                                                            E8.Text = value.vr[2, 1].ToString();
                                                            E9.Text = value.vr[2, 2].ToString();

                                                        }
                    }else
                        ErrorFlyout.ShowAt((Button)sender);
                }
            }
            catch (Exception)
            {

                ErrorFlyout.ShowAt((Button)sender);
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Eginvectorview.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void TextboxLostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)(sender)).Text.Contains("*") ||((TextBox)(sender)).Text.Contains("#") ||((TextBox)(sender)).Text.Contains(" "))
                result.Text = "Error at " + ((TextBox)(sender)).Name ;
        }

        
    }
}
