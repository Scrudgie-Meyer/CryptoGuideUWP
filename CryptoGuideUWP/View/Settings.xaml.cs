using Windows.Storage;
using Windows.UI.ViewManagement;
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
            InitializeComponent();
        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                // Перемикач встановлено на вимкнено, тому встановлюємо світлу тему
                Application.Current.RequestedTheme = ApplicationTheme.Dark;
            }
            else
            {
                // Перемикач встановлено на увімкнено, тому встановлюємо темну тему
                Application.Current.RequestedTheme = ApplicationTheme.Dark;
            }
        }
    }
}
