using CryptoGuideUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CryptoGuideUWP.View
{
    public sealed partial class Currencies : Page
    {
        private List<CurrencyTableObject> currencies = new List<CurrencyTableObject>();
        public Currencies()
        {
            InitializeComponent();
            OnRefresh();
        }

        private async void OnRefresh()
        {
            while(true)
            {
                currencies = ResponseParser.CurrencyTableData();
                Cryptos.ItemsSource = currencies;
                await Task.Delay(30000);
            }
        }
        private void Cryptos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currency = (CurrencyTableObject)e.ClickedItem;
            Frame.Navigate(typeof(CurrencyPage), currency);
        }
        private void Rank_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Rank.Content.ToString() == "Increase")
            {
                Rank.Content = "Decrease";
                currencies = currencies.OrderBy(c => c.rank).ToList();
            }
            else
            {
                Rank.Content = "Increase";
                currencies = currencies.OrderByDescending(c => c.rank).ToList();
            }
            Cryptos.ItemsSource = currencies;
        }

        private void Price_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Price.Content.ToString() == "Increase")
            {
                Price.Content = "Decrease";
                currencies = currencies.OrderBy(c => c.priceUSD).ToList();
            }
            else
            {
                Price.Content = "Increase";
                currencies = currencies.OrderByDescending(c => c.priceUSD).ToList();
            }
            Cryptos.ItemsSource = currencies;
        }

        private void Volume_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Volume.Content.ToString() == "Increase")
            {
                Volume.Content = "Decrease";
                currencies = currencies.OrderBy(c => c.volumeUsd24Hr).ToList();
            }
            else
            {
                Volume.Content = "Increase";
                currencies = currencies.OrderByDescending(c => c.volumeUsd24Hr).ToList();
            }
            Cryptos.ItemsSource = currencies;
        }

        private void Cap_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Cap.Content.ToString() == "Increase")
            {
                Cap.Content = "Decrease";
                currencies = currencies.OrderBy(c => c.marketCapUsd).ToList();
            }
            else
            {
                Cap.Content = "Increase";
                currencies = currencies.OrderByDescending(c => c.marketCapUsd).ToList();
            }
            Cryptos.ItemsSource = currencies;
        }

        private void SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchName.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                List<CurrencyTableObject> filteredCurrencies = currencies.Where(c => c.name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                Cryptos.ItemsSource = filteredCurrencies;
            }
            else
            {
                Cryptos.ItemsSource = currencies;
            }
        } 
    }
}
