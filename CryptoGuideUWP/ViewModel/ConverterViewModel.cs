using CryptoGuideUWP.Model;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace CryptoGuideUWP.View
{
    public sealed partial class Converter : Page
    {
        private List<CurrencyTableObject> currencies = new List<CurrencyTableObject>();
        public Converter()
        {
            this.InitializeComponent();
            currencies = ResponseParser.CurrencyTableData();
            ComboBox1.ItemsSource = currencies;
            ComboBox1.DisplayMemberPath = "name";
            ComboBox2.ItemsSource = currencies;
            ComboBox2.DisplayMemberPath = "name";
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInput();
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInput();
        }

        private void Input1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateInput();
        }
        private void UpdateInput()
        {
            if (ComboBox1.SelectedItem != null && ComboBox2.SelectedItem != null && !string.IsNullOrEmpty(Input1.Text))
            {
                var fromCurrency = (CurrencyTableObject)ComboBox1.SelectedItem;
                var toCurrency = (CurrencyTableObject)ComboBox2.SelectedItem;
                if (decimal.TryParse(Input1.Text, out decimal value))
                {
                    decimal? convertedValue = value * toCurrency.priceUSD / fromCurrency.priceUSD;
                    Input2.Text = convertedValue?.ToString("F8");
                }
            }
        }
    }
}
