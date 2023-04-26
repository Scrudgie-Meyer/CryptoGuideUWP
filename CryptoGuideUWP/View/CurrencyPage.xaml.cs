using CryptoGuideUWP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LiveCharts.Wpf.Components;

namespace CryptoGuideUWP.View
{
    public sealed partial class CurrencyPage : Page
    {
        Currency currency = new Currency();
        public CurrencyPage()
        {
            this.InitializeComponent();
            RefreshChart();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshChart();
        }

        private void RefreshChart()
        {
            List<CryptoPrice> data = new List<CryptoPrice>();
            // Clear any existing data points from the chart
            Chart.Series.Clear();

            // Create a new line series and bind it to the data list
            LineSeries series = new LineSeries();
            series.ItemsSource = data;
            series.
            series.IndependentValuePath = "Date";
            series.DependentValuePath = "PriceUsd";


        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            currency=e.Parameter as Currency;
            Name.Text = currency.name + " " + currency.symbol;
        }
        private async void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri($"https://crypto.com/price/{currency.id}");

            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
