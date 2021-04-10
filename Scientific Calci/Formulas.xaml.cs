using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
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
    public sealed partial class Formulas : Page
    {
        public  Formulas()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            
            //functionWhereNeedReeding();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected  override  void OnNavigatedTo(NavigationEventArgs e)
        {
            readtextfile();
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

        //public async Task<string> ReadFileContentsAsync(string fileName)
        //{
        //    var folder = ApplicationData.Current.LocalFolder;

        //    try
        //    {
        //        var file = await folder.OpenStreamForReadAsync(fileName);

        //        using (var streamReader = new StreamReader(file))
        //        {
        //            return streamReader.ReadToEnd();
        //        }
        //    }
        //    catch (Exception)
        //    {
                
        //        return string.Empty;
        //    }
        //}
        
        //private async void functionWhereNeedReeding()
        //{
        //    string contents = await this.ReadFileContentsAsync("Form.txt");
        //    formula_textblock.Text = contents;
        //}

        public   void readtextfile()
        {
         
            formula_textblock.Text = "Geometry formulas:\n" +

"\nPerimeter:" +

"\nPerimeter of a square: 4s" +
"\ns:length of one side\n" +

"\nPerimeter of a rectangle: 2(l + b)" +
"\nl: length" +
"\nb: breadth\n" +

"\nPerimeter of a triangle: a + b + c" +
"\na, b, and c: lengths of the 3 sides\n" +

"\nArea:" +

"\nArea of a square: s × s" +
"\ns: length of one side\n" +

"\nArea of a rectangle: l × b" +
"\nl: length" +
"\nw: breadth\n" +

"\nArea of a triangle: (b × h)/2" +
"\nb: length of base" +
"\nh: length of height\n" +

"\nArea of a trapezoid: (b1 + b2) × h/2" +
"\nb1 and b2: parallel sides or the bases" +
"\nh: length of height\n" +

"\nvolume:" +

"\nVolume of a cube: s³" +
"\ns: length of one side\n" +

"\nVolume of a box: l × b × h" +
"\nl: length" +
"\nb: breadth" +
"\nh: height\n" +

"\nVolume of a sphere: (4/3) × pi × r3" +

"\nr: radius of sphere\n" +

"\nVolume of a triangular prism:\n area of triangle × Height\n = (1/2 base × height) × Height" +
"\nbase: length of the base of the triangle" +
"\nheight: height of the triangle" +
"\nHeight: height of the triangular prism\n" +

"\nVolume of a cylinder:pi × r2 × Height"+
"\n*****************************************"+
"\nLaws of Exponents"+

"\n\n(a^m)(a^n) = a^(m+n)"+
"\n(ab)^m = a^m b%m"+
"\n(a^m)^n = a^(mn)"+

"\nFractional Exponents"+
"\na^0 = 1"+
"\n(a^m)/(a^n) = a^(m-n)"+
"\na^-m= 1/(a^m)"+
"\n*****************************************"+
"\nBinomial Theorem"+

"\n(a + b)^1 = a + b"+
"\n(a + b)^2 = a2 + 2ab + b2"+
"\n(a + b)^3 = a3 + 3a2b + 3ab2 + b3"+
"\na + b)^4\n= a4 + 4a3b + 6a2b2 + 4ab3 + b4..."+
"\n*****************************************" +
"\nDifference of Squares"+

"\na^2 - b^2 = (a - b)(a + b)"+
"\n*****************************************" +
"\nRules of Zero"+

"\n0/x = 0 where x is not equal to 0."+
"\na^0 = 1"+
"\n0^a = 0"+
"\na*0 = 0"+
"\na/0 is undefined (you can't do it)";

                
        }

        
    }
}
