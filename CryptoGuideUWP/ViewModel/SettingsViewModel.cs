using CryptoGuideUWP.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace CryptoGuideUWP.View
{
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        //У останніх версіях Windows 10 не підтримується, через можливість встановлення теми за замовчуванням у налаштуваннях
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            //if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
            //{
            //    Application.Current.RequestedTheme = ApplicationTheme.Light;
            //}
            //else
            //{
            //    Application.Current.RequestedTheme = ApplicationTheme.Dark;
            //}
        }
    }
}
