using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Scientific_Calci
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Conversion : Page
    {
        double i = 1, j = 1 , count = 0;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources"); 
        public Conversion()
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

       

        private void Conversions_changed(object sender, SelectionChangedEventArgs e)
        {
            if (conversions!=null && conversions.SelectedIndex == 0)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                
                unit2.Items.Add("Inches");
                unit2.Items.Add("feet");
                unit2.Items.Add("Yard");
                unit2.Items.Add("Miles");
                unit2.Items.Add("CentiMeters");
                unit2.Items.Add("Meters");
                unit2.Items.Add("KiloMeters");
                

                unit1.Items.Add("Inches");
                unit1.Items.Add("feet");
                unit1.Items.Add("Yard");
                unit1.Items.Add("Miles");
                unit1.Items.Add("CentiMeters");
                unit1.Items.Add("Meters");
                unit1.Items.Add("KiloMeters");
               
                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }

            if (conversions != null && conversions.SelectedIndex == 1)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Kelvin");
                unit2.Items.Add("Celsius");
                unit2.Items.Add("Fahrenheit");
                unit2.Items.Add("");
                unit2.Items.Add("");
                unit2.Items.Add("");
               

                unit1.Items.Add("Kelvin");
                unit1.Items.Add("Celsius");
                unit1.Items.Add("Fahrenheit");
                unit1.Items.Add("");
                unit1.Items.Add("");
                unit1.Items.Add("");
                
                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
                
            }

            if (conversions != null && conversions.SelectedIndex == 2)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Ounces");
                unit2.Items.Add("Pounds");
                unit2.Items.Add("Tons(US)");
                unit2.Items.Add("MTons");
                unit2.Items.Add("Tons(UK)");
                unit2.Items.Add("Grams");
                unit2.Items.Add("KiloGrams");

                unit1.Items.Add("Ounces");
                unit1.Items.Add("Pounds");
                unit1.Items.Add("Tons(US)");
                unit1.Items.Add("MTons");
                unit1.Items.Add("Tons(UK)");
                unit1.Items.Add("Grams");
                unit1.Items.Add("KiloGrams");
                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;

            }

            if (conversions != null && conversions.SelectedIndex == 3)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Km/H");
                unit2.Items.Add("MPH");
                unit2.Items.Add("");
                unit2.Items.Add("");
                unit2.Items.Add("");
                unit2.Items.Add("");
               
                unit1.Items.Add("Km/H");
                unit1.Items.Add("MPH");
                unit1.Items.Add("");
                unit1.Items.Add("");
                unit1.Items.Add("");
                unit1.Items.Add("");

                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }

            if (conversions != null && conversions.SelectedIndex == 6)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Cubic Meters");
                unit2.Items.Add("Cubic Foot");
                unit2.Items.Add("Cubic CentiMeters");
                unit2.Items.Add("Gallon(US)");
                unit2.Items.Add("Gallons(UK)");
                unit2.Items.Add("Liters");
                unit2.Items.Add("Ounces(US)");
                unit2.Items.Add("Ounces(UK)");
                unit2.Items.Add("Pints(UK)");
                unit2.Items.Add("Quarts");

                unit1.Items.Add("Cubic Meters");
                unit1.Items.Add("Cubic Foot");
                unit1.Items.Add("Cubic CentiMeters");
                unit1.Items.Add("Gallon(US)");
                unit1.Items.Add("Gallons(UK)");
                unit1.Items.Add("Liters");
                unit1.Items.Add("Ounces(US)");
                unit1.Items.Add("Ounces(UK)");
                unit1.Items.Add("Pints(UK)");
                unit1.Items.Add("Quarts");
                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }

            if (conversions != null && conversions.SelectedIndex == 5)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Degree");
                unit2.Items.Add("Radians");
                unit2.Items.Add("Gradians");
                unit2.Items.Add("");
                unit2.Items.Add("");
                unit2.Items.Add("");


                unit1.Items.Add("Degree");
                unit1.Items.Add("Radians");
                unit1.Items.Add("Gradians");
                unit1.Items.Add("");
                unit1.Items.Add("");
                unit1.Items.Add("");
                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }

            if (conversions != null && conversions.SelectedIndex == 4)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("MilliSeconds");
                unit2.Items.Add("Seconds");
                unit2.Items.Add("Minutes");
                unit2.Items.Add("Hours");
                unit2.Items.Add("Days");
                unit2.Items.Add("Years");

                unit1.Items.Add("MilliSeconds");
                unit1.Items.Add("Seconds");
                unit1.Items.Add("Minutes");
                unit1.Items.Add("Hours");
                unit1.Items.Add("Days");
                unit1.Items.Add("Years");

                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }

            if (conversions != null && conversions.SelectedIndex == 7)
            {
                unit2.Items.Clear();
                unit1.Items.Clear();
                unit2.Items.Add("Sqln");
                unit2.Items.Add("Sqft");
                unit2.Items.Add("SqYard");
                unit2.Items.Add("Acre");
                unit2.Items.Add("SqMi");
                unit2.Items.Add("SqMi");
                unit2.Items.Add("SqMm");
                unit2.Items.Add("SqCm");
                unit2.Items.Add("SqM");

                unit1.Items.Add("Sqln");
                unit1.Items.Add("Sqft");
                unit1.Items.Add("SqYard");
                unit1.Items.Add("Acre");
                unit1.Items.Add("SqMi");
                unit1.Items.Add("SqMi");
                unit1.Items.Add("SqMm");
                unit1.Items.Add("SqCm");
                unit1.Items.Add("SqM");

                unit1.SelectedIndex = 0;
                unit2.SelectedIndex = 0;
            }
         
        }

        private async void unit1_changed(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(200);
            if (unit1 != null && unit1.SelectedValue.ToString() != "")
            {
                i = double.Parse(resourceLoader.GetString(unit1.SelectedValue.ToString()));
                unit1_text.Text = "0";
            }
            
        }

        private async void unit2_changed(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(200);
            if (unit2 != null && unit2.SelectedValue.ToString() != "")
            {
               
                j = double.Parse(resourceLoader.GetString(unit2.SelectedValue.ToString()));
                unit2_text.Text = "0";
            }
        }

        private async void unit1_text_TextChanged(object sender, TextChangedEventArgs e)
        {
           
                await Task.Delay(100);
                if (conversions != null && conversions.SelectedIndex != 1)
                {
                    if (unit2 != null && unit2.SelectedValue.ToString() != "" && unit1_text.Text != "")
                    {

                        unit2_text.Text = ((i / j) * double.Parse(unit1_text.Text)).ToString();
                    }
                }
                else
                {
                    if (conversions != null && count == 0)
                    {
                        if (unit1.SelectedValue.ToString() == "Fahrenheit")
                        {
                            if (unit2.SelectedValue.ToString() == "Celsius" && unit1_text.Text != "")
                                unit2_text.Text = ((double.Parse(unit1_text.Text) - 32) * 5 / 9).ToString();
                            if (unit2.SelectedValue.ToString() == "Kelvin" && unit1_text.Text != "")
                                unit2_text.Text = ((double.Parse(unit1_text.Text) - 32) * 5 / 9 + 273.15).ToString();
                            if (unit2.SelectedValue.ToString() == "Fahrenheit" && unit1_text.Text != "")
                                unit2_text.Text = unit1_text.Text;
                        }
                        if (unit1.SelectedValue.ToString() == "Celsius")
                        {
                            if (unit2.SelectedValue.ToString() == "Celsius" && unit1_text.Text != "")
                                unit2_text.Text = unit1_text.Text;
                            if (unit2.SelectedValue.ToString() == "Kelvin" && unit1_text.Text != "")
                                unit2_text.Text = (double.Parse(unit1_text.Text) + 273.15).ToString();
                            if (unit2.SelectedValue.ToString() == "Fahrenheit" && unit1_text.Text != "")
                                unit2_text.Text = ((double.Parse(unit1_text.Text) * 9 / 5) + 32).ToString();
                        }
                        if (unit1.SelectedValue.ToString() == "Kelvin")
                        {
                            if (unit2.SelectedValue.ToString() == "Kelvin" && unit1_text.Text != "")
                                unit2_text.Text = unit1_text.Text;
                            if (unit2.SelectedValue.ToString() == "Celsius" && unit1_text.Text != "")
                                unit2_text.Text = (double.Parse(unit1_text.Text) - 273.15).ToString();
                            if (unit2.SelectedValue.ToString() == "Fahrenheit" && unit1_text.Text != "")
                                unit2_text.Text = (((double.Parse(unit1_text.Text) - 273.15) * 9 / 5) + 32).ToString();
                        }
                        count = 1;
                    }
                    else
                        count = 0;
                    
                }
                
            
        }

        private async void unit2_text_TextChanged(object sender, TextChangedEventArgs e)
        {
                await Task.Delay(100);
                if (conversions != null && conversions.SelectedIndex != 1)
                {
                    if (unit2 != null && unit2.SelectedValue.ToString() != "" && unit2_text.Text != "")
                    {

                        unit1_text.Text = ((j / i) * double.Parse(unit2_text.Text)).ToString();
                    }
                }
                else
                {
                    if (conversions != null && count == 0)
                    {
                        if (unit2.SelectedValue.ToString() == "Fahrenheit")
                        {
                            if (unit1.SelectedValue.ToString() == "Celsius" && unit2_text.Text != "")
                                unit1_text.Text = ((double.Parse(unit2_text.Text) - 32) * 5 / 9).ToString();
                            if (unit1.SelectedValue.ToString() == "Kelvin" && unit2_text.Text != "")
                                unit1_text.Text = ((double.Parse(unit2_text.Text) - 32) * 5 / 9 + 273.15).ToString();
                            if (unit1.SelectedValue.ToString() == "Fahrenheit" && unit2_text.Text != "")
                                unit1_text.Text = unit2_text.Text;
                        }
                        if (unit2.SelectedValue.ToString() == "Celsius")
                        {
                            if (unit1.SelectedValue.ToString() == "Celsius" && unit2_text.Text != "")
                                unit1_text.Text = unit2_text.Text;
                            if (unit1.SelectedValue.ToString() == "Kelvin" && unit2_text.Text != "")
                                unit1_text.Text = (double.Parse(unit2_text.Text) + 273.15).ToString();
                            if (unit1.SelectedValue.ToString() == "Fahrenheit" && unit2_text.Text != "")
                                unit1_text.Text = ((double.Parse(unit2_text.Text) * 5 / 9) + 32).ToString();
                        }
                        if (unit2.SelectedValue.ToString() == "Kelvin")
                        {
                            if (unit1.SelectedValue.ToString() == "Kelvin" && unit2_text.Text != "")
                                unit1_text.Text = unit2_text.Text;
                            if (unit1.SelectedValue.ToString() == "Celsius" && unit2_text.Text != "")
                                unit1_text.Text = (double.Parse(unit2_text.Text) - 273.15).ToString();
                            if (unit1.SelectedValue.ToString() == "Fahrenheit" && unit2_text.Text != "")
                                unit1_text.Text = (((double.Parse(unit2_text.Text) - 273.15) * 5 / 9) + 32).ToString();
                        }
                        count = 1;
                    }
                    else
                        count = 0;
                }
                
           
        }

        private void Unit_text_GotFocus(object sender, RoutedEventArgs e)
        {
            unit1_text.Text = "";
            unit2_text.Text = "";
             
        }
    }
}
