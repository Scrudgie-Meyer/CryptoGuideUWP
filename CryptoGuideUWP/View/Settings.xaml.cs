using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoGuideUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }
        private void Ukrainian_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {

        }
        private void German_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            //if ((sender as ToggleSwitch).IsOn == true)
            //{
            //    // Встановлюємо тему на темну
            //    Application.Current.RequestedTheme = ApplicationTheme.Dark;
            //}
            //else
            //{
            //    // Встановлюємо тему на світлу
            //    Application.Current.RequestedTheme = ApplicationTheme.Light;
            //}
        }
    }
}
