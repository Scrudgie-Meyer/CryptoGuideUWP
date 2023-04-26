using CryptoGuideUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoGuideUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Currencies : Page
    {
        private List<Currency> currencies = new List<Currency>();  
        public Currencies()
        {
            InitializeComponent();
            currencies=CustomJSONparser.GetCurrencies();          
            Cryptos.ItemsSource = currencies;
        }
        private void Cryptos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currency = (Currency)e.ClickedItem;
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
                List<Currency> filteredCurrencies = currencies.Where(c => c.name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                Cryptos.ItemsSource = filteredCurrencies;
            }
            else
            {
                Cryptos.ItemsSource = currencies;
            }
        }
    }
}
