using CryptoGuideUWP.Model;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Data;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace CryptoGuideUWP.View
{
    public sealed partial class CurrencyPage : Page
    {
        CurrencyTableObject currency = new CurrencyTableObject();
        List<CurrencyMarketsObject> markets = new List<CurrencyMarketsObject>();


        public CurrencyPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            currency = e.Parameter as CurrencyTableObject;

            Name.Text = currency.name + " " + currency.symbol;
            Name2.Text = "Current value USD: " + Convert.ToString(currency.priceUSD);
            Name3.Text = "Market cap value USD: " + Convert.ToString(currency.marketCapUsd);
            markets = ResponseParser.CurrencyObjectData(currency.id);
            Markets.ItemsSource = markets;

            RefreshChart();
        }


        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshChart();
        }


        private void RefreshChart()
        {
            List<CurrencyChartObject> data = ResponseParser.CurrencyChartData(currency.id);
            List<CurrencyChartObject> newData = new List<CurrencyChartObject>();


            int interval = data.Count / 10;
            for (int i = 0; i < data.Count; i += interval)
            {
                newData.Add(data[i]);
            }


            Chart.Series.Clear();

            LineSeries series = new LineSeries();
            series.ItemsSource = newData;


            var dateBinding = new Binding()
            {
                Path = new PropertyPath("date")
            };
            series.IndependentValueBinding = dateBinding;


            var priceBinding = new Binding()
            {
                Path = new PropertyPath("priceUsd")
            };
            series.DependentValueBinding = priceBinding;


            Chart.Series.Add(series);
        }


        private async void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri($"https://crypto.com/price/{currency.id}");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
