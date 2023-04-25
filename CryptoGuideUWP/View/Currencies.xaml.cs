﻿using CryptoGuideUWP.Model;
using System.Collections.Generic;
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
    }
}
