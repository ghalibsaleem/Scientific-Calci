using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;
using Windows.UI.ViewManagement;
using System.Collections.ObjectModel;
using Scientific_Calci.DataModel;
using Windows.System;
using Windows.ApplicationModel.Store;
using Scientific_Calci.MatrixModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Scientific_Calci
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string answer = "",temp="",calculus;
        string[] op = { "+", "-", "%", "×", "÷", "(" };
        int i=0,shift=0;
        double n,n1;
        Calculation calculation_obj = new Calculation();
        Constant_formatting const_formt = new Constant_formatting();
        
        public MainPage()
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            flipview_name.SelectedIndex = 1;
           await StatusBar.GetForCurrentView().HideAsync();

           var settings = await App.DataModel.GetSetting();
           this.DataContext = settings;

           
           
           AngleNotify.Text = ((Setting)settings.ElementAt(0)).Item;
           int rate = int.Parse(((Setting)settings.ElementAt(1)).Item);
            if(rate != -2)
                  App.DataModel.ChangeSetting("Rating", (rate + 1).ToString());
           if (rate % 5 == 0 && rate != 0)
           {
               ShowContentDialog();
           }
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
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

        
        private async void ShowContentDialog()
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Rate And Review",
                Content = "Help Us To Improve This Calculator",
                PrimaryButtonText = "Love It!",
                SecondaryButtonText = "Cancel"
            };
            
            dialog.PrimaryButtonClick += dialog_PrimaryButtonClick;

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary) { /* do some more Primary logic */ }
            else if (result == ContentDialogResult.Secondary) { /* else do Secondary logic */ }
        }
        
        async void  dialog_PrimaryButtonClick(ContentDialog sender, object args)
        {
           await  Launcher.LaunchUriAsync(new Uri("zune:reviewapp?appid=" + CurrentApp.AppId));
           App.DataModel.ChangeSetting("Rating", "-9");
        }


        private void power(object sender, RoutedEventArgs e)
        {
            Display.Text += "^";
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            Display.Text += "+";
        }

        private void minus(object sender, RoutedEventArgs e)
        {
            Display.Text += "-";
        }

        private void multiply(object sender, RoutedEventArgs e)
        {
            Display.Text += "×";
        }

        private void divide(object sender, RoutedEventArgs e)
        {
            Display.Text += "÷";
        }

        private void modulus(object sender, RoutedEventArgs e)
        {
            Display.Text += "%";
        }

      
        private void one(object sender, RoutedEventArgs e)
        {
            Display.Text += "1";
        }

        private void two(object sender, RoutedEventArgs e)
        {
            Display.Text += "2";
        }

        private void three(object sender, RoutedEventArgs e)
        {
            Display.Text += "3";
        }

        private void four(object sender, RoutedEventArgs e)
        {
            Display.Text += "4";
        }

        private void five(object sender, RoutedEventArgs e)
        {
            Display.Text += "5";
        }

        private void six(object sender, RoutedEventArgs e)
        {
            Display.Text += "6";
        }

        private void seven(object sender, RoutedEventArgs e)
        {
            Display.Text += "7";
        }

        private void eight(object sender, RoutedEventArgs e)
        {
            Display.Text += "8";
        }

        private void nine(object sender, RoutedEventArgs e)
        {
            Display.Text += "9";
        }

        private void zero(object sender, RoutedEventArgs e)
        {
            Display.Text += "0";
        }

        private void point(object sender, RoutedEventArgs e)
        {
            Display.Text += ".";
        }

       

        private void equal(object sender, RoutedEventArgs e)
        {
            exprsolution exprsolution_obj = new exprsolution();
            exprsolution_obj.angle = AngleNotify.Text;
            Display.Text = const_formt.expr_formatting(Display.Text);


            if ((Display.Text).Contains("ƒ(x)="))
            {
                
                calculus = Display.Text.Remove(0,5);
                Display.Text = "X = ";
            }else
                if ((Display.Text).Contains("X = ") || (Display.Text).Contains("X2 = "))
                {
                    calculas cal = new calculas();
                   
                    double res = 0;
                    //Diffrentiation block
                    if(i==2){
                        
                        n = double.Parse((Display.Text).Remove(0, 4));
                        res = double.Parse(exprsolution_obj.exprsol(calculus.Replace("X",n.ToString())));
                        res = double.Parse(exprsolution_obj.exprsol(calculus.Replace("X", (n+0.00001).ToString())))-res;
                        res = res / 0.00001;
                        i = 0;
                        if (res.ToString().Contains('.'))
                        {
                            int k = res.ToString().IndexOf('.');
                            res = double.Parse(res.ToString().Remove(k + 3));
                        }
                        Display.Text = temp + res.ToString();
                    }
                        //integration block
                    else
                    {
                        if(i==1){
                            if (Display.Text.Contains("π"))
                                Display.Text = Display.Text.Replace("π", "3.14159265358979323846");
                            n = double.Parse((Display.Text).Remove(0, 4));
                            Display.Text = "X2 = ";
                            i--;
                        }
                        else
                        {
                            
                            n1 = double.Parse((Display.Text).Remove(0, 5));
                            if (n > n1)
                            {
                                res = cal.integration(calculus, n1, n);
                                //for (double j = n1; j <= n; j += 0.001)
                                //{
                                //    res += 0.001 * double.Parse(exprsolution_obj.exprsol(calculus.Replace("X", j.ToString())));
                                //}
                                res = -res;
                            }
                            else
                            {
                                //for (double j = n;j<=n1 ;j+=0.001 )
                                //{
                                //    res += 0.001*double.Parse(exprsolution_obj.exprsol(calculus.Replace("X", j.ToString())));
                                //}

                                res = cal.integration(calculus, n, n1);
                                
                            }
                           
                            Display.Text = temp + res.ToString();
                            i = 0;
                        }
                    }
                   
                }else
                     Display.Text = exprsolution_obj.exprsol(Display.Text);
            answer = Display.Text;
        }

        private void backspace(object sender, RoutedEventArgs e)
        {

            Display.Text = const_formt.backspace(Display.Text);
        }

        
        private void square(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "²";
            else
            {
                Display.Text += "³";
                shift = 0;
                shiftNotify.Text = "";
            }
           
        }

        private void Square_root(object sender, RoutedEventArgs e)
        {
            Display.Text += "√(";
        }

        

        private void sine(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "sin(";
            else {
                Display.Text += "cosec(";
                shift = 0;
                shiftNotify.Text = "";
            }
        }

       
        private void cosine(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "cos(";
            else
            {
                Display.Text += "sec(";
                shift = 0;
                shiftNotify.Text = "";
            }
        }

        

        private void tangent(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "tan(";
            else
            {
                Display.Text += "cot(";
                shift = 0;
                shiftNotify.Text = "";
            }
        }

        private void logarithm(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "log(";
            else
            {
                Display.Text += "ln(";
                shift = 0;
                shiftNotify.Text = "";
            }
            
        }

        

        private void forward_bracket(object sender, RoutedEventArgs e)
        {
            Display.Text += "("; 
        }

        private void backward_bracket(object sender, RoutedEventArgs e)
        {
            Display.Text += ")";
        }

        

        private void clear_screen(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
            shift = 0;
            shiftNotify.Text = "";
            i = 0;
        }

        private void Answer_click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "")
                if (!op.Contains(Display.Text.ElementAt(Display.Text.Length - 1).ToString()))
                {
                    Display.Text += "×";
                }
            Display.Text += answer;
        }

        private void ybutton(object sender, RoutedEventArgs e)
        {
            Display.Text += "^";
        }

        private void xbutton(object sender, RoutedEventArgs e)
        {
            Display.Text += "X";
        }

        

        private async void backspace_holding(object sender, HoldingRoutedEventArgs e)
        {
            for (;back.IsPressed; )
            {
                if (Display.Text != "")
                    Display.Text = const_formt.backspace(Display.Text);
                await Task.Delay(150);
            }
        }

        private void textchanged_handler(object sender, TextChangedEventArgs e)
        {
            
            //if(Display.Text.Length < 25){
            //    Display.FontSize = 30 ;
            //}
            //else
            //{
            //    if (Display.Text.Length < 72)
            //    {
            //        Display.FontSize = 20;
            //    }
            //    else
            //    {
            //        Display.FontSize = 15;
            //    }
            //}
            //if (Display.Text.Length > 153)
            //{
            //    Display.Text = "Out of Bond";
            //}
        }

        private void diffrentiation(object sender, RoutedEventArgs e)
        {
            temp = Display.Text;
            Display.Text = "ƒ(x)=";
            i = 2;
        }

        private void integration(object sender, RoutedEventArgs e)
        {
            temp = Display.Text;
            Display.Text = "ƒ(x)=";
            i = 1;
        }


        private void Angle(object sender, RoutedEventArgs e)
        {
            if(AngleNotify.Text == "Radian"){
                AngleNotify.Text = "Degree";
                App.DataModel.ChangeSetting("Angle","Degree");
            }else{
                AngleNotify.Text = "Radian";
                App.DataModel.ChangeSetting("Angle", "Radian");
            }
        }

        private void sine_hyperbolic(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "sinh(";
            else
            {
                Display.Text += "cosech(";
                shift = 0;
                shiftNotify.Text = "";
            }
            
        }

        private void cosine_hyperbolic(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "cosh(";
            else
            {
                Display.Text += "sech(";
                shift = 0;
                shiftNotify.Text = "";
            }
            
        }

        private void tangent_hyperbolic(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "tanh(";
            else
            {
                Display.Text += "coth(";
                shift = 0;
                shiftNotify.Text = "";
            }
           
        }


        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string a =((Grid)e.ClickedItem).Name;
            if (a == "matrix")
                Frame.Navigate(typeof(MatrixView));
            if (a == "equations")
                Frame.Navigate(typeof(Equationsxaml));
            if (a == "base_n")
                Frame.Navigate(typeof(Base_N));
            if (a == "table")
                Frame.Navigate(typeof(FunctionTablexaml));
            if (a == "vector")
                Frame.Navigate(typeof(Vectors));
            if (a == "conversion")
                Frame.Navigate(typeof(Conversion));
            if (a == "formulas")
                Frame.Navigate(typeof(Formulas));
            if (a == "about")
                Frame.Navigate(typeof(About));
        }

        private void constant_click(object sender, ItemClickEventArgs e)
        {
            string a = ((TextBlock)e.ClickedItem).Text;
            if(Display.Text != "")
                if (!op.Contains(Display.Text.ElementAt(Display.Text.Length-1).ToString()))
                {
                    Display.Text += "×";
                }

            if (a == "Atomic mass unit")
                Display.Text += "u";
            if (a == "Avagadro's No.")
                Display.Text += "Na";
            if (a == "Bohr magneton")
                Display.Text += "μb";
            if (a == "Bohr radius")
                Display.Text += "ao";
            if (a == "Boltzman Constant")
                Display.Text += "k";
            if (a == "Charge Of Electron")
                Display.Text += "el";
            if (a == "Faraday constant")
                Display.Text += "F";
            if (a == "Gravitation Constant")
                Display.Text += "G";
            if (a == "Mass of electron")
                Display.Text += "me";
            if (a == "Mass of neutron")
                Display.Text += "mn";
            if (a == "Mass of proton")
                Display.Text += "mp";
            if (a == "Molar Gas Constant")
                Display.Text += "R";
            if (a == "Permeability of vacuum")
                Display.Text += "μo";
            if (a == "Permittivity of vacuum")
                Display.Text += "εo";
            if (a == "Planck Constant")
                Display.Text += "hp";
            if (a == "Planck hbar")
                Display.Text += "h_";
            if (a == "Rydberg constant")
                Display.Text += " R∞";
            if (a == "Speed Of Light")
                Display.Text += "cl";
            if (a == "Stefan-Boltzmann constant")
                Display.Text += "σ";
            if (a == "Wien displacement constant")
                Display.Text += "b";
            if (a == "1st radiation constant c1")
                Display.Text += "c1";
            if (a == "2st radiation constant c2")
                Display.Text += "c2";
            if (a == "pie")
                Display.Text += "π";
            if (a == "Fine structure constant")
                Display.Text += "α";
            if (a == "Impedance of vacuum")
                Display.Text += "Zo";
            if (a == "Magnetic flux quantum")
                Display.Text += "Φo";
            if (a == "Molar volume of ideal gas Vm ")
                Display.Text += "Vm";

            flipview_name.SelectedIndex = 1;
        }

        private void Shift_Click(object sender, RoutedEventArgs e)
        {
            if(shiftNotify.Text == "Shift"){
                shift = 0;
                shiftNotify.Text = "";
            }
             else
            {
                shift = 1;
                shiftNotify.Text = "Shift";
            }
        }

        private void pie(object sender, RoutedEventArgs e)
        {
            if (shift != 1)
                Display.Text += "π";
            else
            {
                Display.Text += "e";
                shift = 0;
                shiftNotify.Text = "";
            }
        }

        private void factorial(object sender, RoutedEventArgs e)
        {
            Display.Text += "!";
        }

        private void npr(object sender, RoutedEventArgs e)
        {
            if(shift != 1)
                 Display.Text += "P(";
            else
            {
                Display.Text += "C(";
                shift = 0;
                shiftNotify.Text = "";
            }
        }

        

        

    }
}
