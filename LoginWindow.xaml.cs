using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PolestarSpain
{
    public partial class LoginWindow : Window
    {
        // Diccionario estático para conservar los usuarios registrados.
        private static readonly Dictionary<string, string> RegisteredUsers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "user_encargado@hotmail.com", "user_encargado" }
        };

        public LoginWindow()
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

        private void GoToGallery_Click(object sender, RoutedEventArgs e)
        {
            GalleryWindow gallery = new GalleryWindow();
            gallery.Left = this.Left;
            gallery.Top = this.Top;
            gallery.Show();
            this.Close();
        }

        
        private bool ValidateInputs(out string email, out string password, string actionTitle)
        {
            email = TxtUsername.Text.Trim();
            password = PwdBox.Password;

            ErrorBanner.Visibility = Visibility.Collapsed;
            SuccessBanner.Visibility = Visibility.Collapsed;
            TxtUsername.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));
            PwdBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError(actionTitle, "Por favor, completa tanto el correo electrónico como la contraseña.");
                if (string.IsNullOrEmpty(email)) TxtUsername.BorderBrush = Brushes.Crimson;
                if (string.IsNullOrEmpty(password)) PwdBox.BorderBrush = Brushes.Crimson;
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError(actionTitle, "Introduce una dirección de correo electrónico válida (ej. usuario@dominio.com).");
                TxtUsername.BorderBrush = Brushes.Crimson;
                return false;
            }

            if (password.Length < 4)
            {
                ShowError(actionTitle, "La contraseña es demasiado corta (debe tener al menos 4 caracteres).");
                PwdBox.BorderBrush = Brushes.Crimson;
                return false;
            }

            return true;
        }

        // Botón: Iniciar Sesión
        private void BtnSubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs(out string email, out string password, "Error de identificación"))
                return;

            // Comprobar si el correo existe y la contraseña coincide
            if (RegisteredUsers.TryGetValue(email, out string savedPassword) && savedPassword == password)
            {
                SuccessBanner.Visibility = Visibility.Visible;
                TxtSuccessMessage.Text = $"✔ ¡Sesión iniciada con éxito! Bienvenido/a, {email}.";
                PwdBox.Clear();
            }
            else if (!RegisteredUsers.ContainsKey(email))
            {
                ShowError("Usuario no encontrado", "Este correo no está registrado. Pulsa en 'Registrarme' para crear tu cuenta.");
                TxtUsername.BorderBrush = Brushes.Crimson;
            }
            else
            {
                ShowError("Contraseña incorrecta", "La contraseña introducida no coincide con la cuenta indicada.");
                PwdBox.BorderBrush = Brushes.Crimson;
            }
        }

        // Botón: Registrarme
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs(out string email, out string password, "Error en el registro"))
                return;

            
            if (RegisteredUsers.ContainsKey(email))
            {
                ShowError("Cuenta ya existente", "Este correo electrónico ya está registrado. Pulsa en 'Iniciar Sesión' para acceder.");
                TxtUsername.BorderBrush = Brushes.Crimson;
                return;
            }

            
            RegisteredUsers.Add(email, password);

            SuccessBanner.Visibility = Visibility.Visible;
            TxtSuccessMessage.Text = $"✔ Cuenta registrada correctamente para {email}. Ya puedes pulsar en 'Iniciar Sesión'.";
            PwdBox.Clear();
        }

        private void ShowError(string title, string msg)
        {
            ErrorBanner.Visibility = Visibility.Visible;
            TxtErrorTitle.Text = title;
            TxtErrorMessage.Text = msg;
        }
    }
}
