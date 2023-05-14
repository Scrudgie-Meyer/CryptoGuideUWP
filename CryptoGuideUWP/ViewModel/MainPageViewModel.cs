using CryptoGuideUWP.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CryptoGuideUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Converter));
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(Settings));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "CurrenciesPage":
                        ContentFrame.Navigate(typeof(Currencies));
                        break;
                    case "ConvertPage":
                        ContentFrame.Navigate(typeof(Converter));
                        break;
                }

            }
        }
    }
}
