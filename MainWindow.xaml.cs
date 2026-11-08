using System.Windows;

namespace PolestarSpain
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToGallery_Click(object sender, RoutedEventArgs e)
        {
            GalleryWindow gallery = new GalleryWindow();
            gallery.Left = this.Left;
            gallery.Top = this.Top;
            gallery.Show();
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
    }
}