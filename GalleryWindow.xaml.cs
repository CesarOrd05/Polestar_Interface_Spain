using System.Windows;
using System.Windows.Controls;

namespace PolestarSpain
{
    public partial class GalleryWindow : Window
    {
        public GalleryWindow()
        {
            InitializeComponent();
        }

        private void GoToHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Left = this.Left;
            home.Top = this.Top;
            home.Show();
            this.Close();
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Left = this.Left;
            login.Top = this.Top;
            login.Show();
            this.Close();
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CardP2 == null || CardP3 == null || CardP4 == null || CardP5 == null) return;

            int index = CmbFilter.SelectedIndex;
            CardP2.Visibility = (index == 0 || index == 1) ? Visibility.Visible : Visibility.Collapsed;
            CardP5.Visibility = (index == 0 || index == 1) ? Visibility.Visible : Visibility.Collapsed;
            CardP3.Visibility = (index == 0 || index == 2) ? Visibility.Visible : Visibility.Collapsed;
            CardP4.Visibility = (index == 0 || index == 2) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SelectCar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                MessageBox.Show($"Has seleccionado el {btn.Tag}. Por favor, identifícate en el Área de Clientes para gestionar el pedido de este vehículo.",
                                "Polestar España", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}