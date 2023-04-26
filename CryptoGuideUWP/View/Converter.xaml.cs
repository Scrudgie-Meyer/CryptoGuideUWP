using CryptoGuideUWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoGuideUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Converter : Page
    {
        private List<Currency> currencies = new List<Currency>();
        public Converter()
        {
            this.InitializeComponent();
            currencies = CustomJSONparser.GetCurrencies();
            ComboBox1.ItemsSource = currencies;
            ComboBox1.DisplayMemberPath = "name";
            ComboBox2.ItemsSource = currencies;
            ComboBox2.DisplayMemberPath = "name";
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInput2();
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInput2();
        }

        private void Input1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateInput2();
        }

        //private void Input2_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    UpdateInput1();
        //}

        private void UpdateInput2()
        {
            if (ComboBox1.SelectedItem != null && ComboBox2.SelectedItem != null && !string.IsNullOrEmpty(Input1.Text))
            {
                var fromCurrency = (Currency)ComboBox1.SelectedItem;
                var toCurrency = (Currency)ComboBox2.SelectedItem;
                if (decimal.TryParse(Input1.Text, out decimal value))
                {
                    decimal? convertedValue = value * toCurrency.priceUSD / fromCurrency.priceUSD;
                    Input2.Text = convertedValue?.ToString("F8");
                }
            }
        }

        private void UpdateInput1()
        {
            if (ComboBox1.SelectedItem != null && ComboBox2.SelectedItem != null && !string.IsNullOrEmpty(Input2.Text))
            {
                var fromCurrency = (Currency)ComboBox2.SelectedItem;
                var toCurrency = (Currency)ComboBox1.SelectedItem;
                if (decimal.TryParse(Input2.Text, out decimal value))
                {
                    decimal? convertedValue = value * toCurrency.priceUSD / fromCurrency.priceUSD;
                    Input1.Text = convertedValue?.ToString("F8");
                }
            }
        }

    }
}
