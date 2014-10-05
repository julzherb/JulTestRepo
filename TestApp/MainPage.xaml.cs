using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///
    public sealed partial class MainPage : Page
    {
        public double sconvert(string category, double inp, string sFrom, string sTo)
        {
            string ts = "Tempurature";
            if (category == "Tempurature")
            {
                return convertToTemperature(inp, sFrom, sTo);
            }
            else //if (category == "Distance")
            {
                return convertToDistance(inp, sFrom, sTo);
				Console.Write("This is fake code for testing");
            }
            //return -1;
        }
    }

    //determines which category conversions are chosen and calls the appropriate convert functions
    public double convertToTemperature(double inp, string sFrom, string sTo)
    {
        if (sFrom == "C")
        {
            if (sTo == "F")
            {
                double outp = toFahrenheit(inp, sFrom, sTo);
                return outp;
            }
            else if (sTo == "K")
            {
                double outp = toKelvin(inp, sFrom, sTo);
                return outp;
            }
        }
        else if (sFrom == "F")
        {
            if (sTo == "C")
            {
                double outp = toCelsius(inp, sFrom, sTo);
                return outp;
            }
            else if (sTo == "K")
            {
                double outp = toKelvin(inp, sFrom, sTo);
                return outp;
            }
        }
        else if (sFrom == "K")
        {
            if (sTo == "C")
            {
                double outp = toCelsius(inp, sFrom, sTo);
                return outp;
            }
            else if (sTo == "F")
            {
                double outp = toFahrenheit(inp, sFrom, sTo);
                return outp;
            }
        }
        return 0;
    }
    //converts to C from F or K
    public double toCelsius(double inp, string sFrom, string sTo)
    {
        double celsius;
        if (sFrom == "F")
        {
            celsius = (inp - 32) * 5 / 9;
            return celsius;
        }
        if (sFrom == "K")
        {
            celsius = inp - 273.15;
            return celsius;
        }
        return 0;
    }
    //converts to F from K or C
    public double toFahrenheit(double inp, string sFrom, string sTo)
    {
        double fahrenheit;
        if (sFrom == "C")
        {
            fahrenheit = (inp + 32) * 9 / 5;
            return fahrenheit;
        }
        else if (sFrom == "K")
        {
            fahrenheit = toCelsius(inp, sFrom, sTo) + 273.15;
            return fahrenheit;
        }
        return 0;
    }
    //converts to K from C or F
    public double toKelvin(double inp, string sFrom, string sTo)
    {
        double kelvin;
        if (sFrom == "C")
        {
            kelvin = inp - 273.15;
            return kelvin;
        }
        else if (sFrom == "F")
        {
            kelvin = toCelsius(inp, sFrom, sTo) + 273.15;
            return kelvin;
        }
        return 0;
    }


    //Converting distances
    public double convertToDistance(double inp, string sFrom, string sTo)
    {
        //input equals output
        if (sFrom == sTo)
        {
            return inp;
        }
        //mm conversion
        else if (sFrom == "mm" && sTo == "cm")
        {
            return inp / 10.0;
        }
        else if (sFrom == "mm" && sTo == "m")
        {
            return inp / 1000.0;
        }
        else if (sFrom == "mm" && sTo == "km")
        {
            return inp / 1000000.0;
        } //cm conversion
        else if (sFrom == "cm" && sTo == "mm")
        {
            return inp * 10.0;
        }
        else if (sFrom == "cm" && sTo == "m")
        {
            return inp / 100.0;
        }
        else if (sFrom == "cm" && sTo == "km")
        {
            return inp / 100000.0;
        }
        //m conversion
        else if (sFrom == "m" && sTo == "mm")
        {
            return inp * 1000.0;
        }
        else if (sFrom == "m" && sTo == "cm")
        {
            return inp * 100.0;
        }
        else if (sFrom == "m" && sTo == "km")
        {
            return inp / 1000.0;
        }
        //km conversion
        else if (sFrom == "km" && sTo == "mm")
        {
            return inp * 1000000.0;
        }
        else if (sFrom == "km" && sTo == "cm")
        {
            return inp * 100000.0;
        }
        else if (sFrom == "km" && sTo == "m")
        {
            return inp * 1000.0;
        }
        return 0;
    }

    public MainPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    private void Page_Loaded_1(object sender, RoutedEventArgs e)
    {
        string[] modelist = new string[] { "Distance", "Tempurature", "Time", "Power", "Speed" };
        ModeDropList.Items.Clear();
        for (int i = 0; i < modelist.Length; i++)
        {
            ModeDropList.Items.Add(modelist[i]);
        }
    }

    private void Run_ButtonDown(object sender, RoutedEventArgs e)
    {
	    int cat = ModeDropList.SelectedIndex;
	    string scategory = "Distnace";
	    if (cat == 1)
	    {
		    scategory = "Tempurature";
	    }
	    else {
		    scategory = "Distance";
	    }
	
	    double inp = Convert.ToDouble(UserIn.Text);
	    string sFrom = Convert.ToString(UnitFrom.SelectedValue);
	    string sTo = Convert.ToString(UnitTo.SelectedValue);
	    string[] modelist = new string[] { "Distance", "Tempurature" };
	
	    if (ModeDropList.SelectedIndex == -1)
	    {
		    UserIn.Text = UserIn.Text + "Please select a class";
		    UserOut.Text = UserOut.Text + "Please select a class";
	    }
	    else
	    {
		    // UserIn.Text = Convert.ToString(scategory);
		    UserOut.Text = Convert.ToString(sconvert(scategory, inp, sFrom, sTo));
	    }
    }

    private void ModeDropList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
	    string[] distance = new string[] { "mm", "cm", "m", "km" };
	    string[] tempurature = new string[] { "F", "C", "K" };
	    string[][] items = new string[][] { distance, tempurature };

	    UnitTo.Items.Clear();
	    UnitFrom.Items.Clear();
	    if (Convert.ToString(ModeDropList.SelectedItem) == "Distance")
	    {
		    for (int i = 0; i < distance.Length; i++)
		    {
			    UnitFrom.Items.Add(distance[i]);
			    UnitTo.Items.Add(distance[i]);
		    }
	    }
	    if (Convert.ToString(ModeDropList.SelectedItem) == "Tempurature")
	    {
		    for (int i = 0; i < tempurature.Length; i++)
		    {
			    UnitFrom.Items.Add(tempurature[i]);
			    UnitTo.Items.Add(tempurature[i]);
		    }
	    }
	    if (Convert.ToString(ModeDropList.SelectedItem) == "Tempurature")
	    {
		    tt.Text = "PAYPAL";
	    }

	    /*UnitTo.Items.Clear();
	    UnitFrom.Items.Clear();
	
	    for (int i = 0; i < items[ModeDropList.SelectedIndex].Length; i++)
	    {
		    UnitTo.Items.Add(items[ModeDropList.SelectedIndex][i]);
		    UnitFrom.Items.Add(items[ModeDropList.SelectedIndex][i]);
	    }
    * */
    }

    }
}

