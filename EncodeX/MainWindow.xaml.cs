using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncodeX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_password_Click(object sender, RoutedEventArgs e)
        {
            if (password_field.IsReadOnly == true)
            {
                button_password.Foreground = Brushes.Green;
                password_field.IsReadOnly = false;
                Border_pss.BorderBrush = Brushes.Green;
                errorLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                button_password.Foreground = Brushes.Gray;
                password_field.Text = "";
                password_field.IsReadOnly = true;
                Border_pss.BorderBrush = Brushes.Gray;
                errorLabel.Visibility = Visibility.Collapsed;
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = password_field.Text;
            string plainText = input_field.Text;

            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Collapsed;
                password = "password@1010^";
                
            }
            else if (password == "")
            {
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if ( password.Length < 8)
            {
                errorLabel.Content = "Password must be at least 8 characters long";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if ( !Regex.IsMatch(password, @"[A-Z]"))
            {
                errorLabel.Content = "Password must contain at least one uppercase letter";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(password, @"[a-z]"))
            {
                errorLabel.Content = "Password must contain at least one lowercase letter";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(password, @"[0-9]"))
            {
                errorLabel.Content = "Password must contain at least one digit";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(password, @"[\W_]"))
            {
                errorLabel.Content = "Password must contain at least one special character";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }


            else
            {
                errorLabel.Visibility = Visibility.Collapsed;
                Border_pss.BorderBrush = Brushes.Green;

            }
            encrypt(password,plainText);


        }

        

        public void encrypt(string password, string plainText)
        {
            
            string encrypted;
            byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(data, 0, data.Length);
                    }
                    encrypted = Convert.ToBase64String(ms.ToArray());
                }

            }
            encrypted_field.Text = encrypted;
        }
    }
}