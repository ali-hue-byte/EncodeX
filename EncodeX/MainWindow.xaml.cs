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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
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
        Brush color = Brushes.Green;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_password_Click(object sender, RoutedEventArgs e)
        {
            if (password_field.IsReadOnly == true)
            {
                button_password.Foreground = color;
                password_field.IsReadOnly = false;
                Border_pss.BorderBrush = color;
                errorLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                button_password.Foreground = Brushes.Gray;
                password_field.Text = "";
                password_field.IsReadOnly = true;
                Border_pss.BorderBrush = Brushes.Gray;
                errorLabel.Visibility = Visibility.Hidden;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = password_field.Text;
            string plainText = input_field.Text;

            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Hidden;
                password = "password@1010^";

            }
            else if (password == "")
            {
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if (password.Length < 8)
            {
                errorLabel.Content = "Password must be at least 8 characters long";
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(password, @"[A-Z]"))
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
                Border_pss.BorderBrush = color;

            }
            encrypted_field.Text = encrypt(password, plainText);


        }

        private void decrypt_txt(object sender, RoutedEventArgs e)
        {
            string password = password_field.Text;
            string plainText = encrypted_field.Text;

            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Hidden;
                password = "password@1010^";

            }
            else if (password == "")
            {
                errorLabel.Visibility = Visibility.Visible;
                Border_pss.BorderBrush = Brushes.Red;
                return;
            }



            else
            {
                errorLabel.Visibility = Visibility.Collapsed;
                Border_pss.BorderBrush = color;

            }
            decrypt(password, plainText);
        }
        public string encrypt(string password, string text)
        {
            string encrypted;
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] key = kdf.GetBytes(32);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                byte[] iv = aes.IV;
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(salt, 0, salt.Length);
                    ms.Write(iv, 0, iv.Length);
                    using(CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(text);
                        cs.Write(plainBytes, 0, plainBytes.Length);
                    }
                    encrypted = Convert.ToBase64String(ms.ToArray());
                }
                
                ;
            }
            return encrypted;
        }

        public void decrypt(string password, string text)
        {

        }

        public void decrypt_clicked(object sender, RoutedEventArgs e)
        {
            Anim2(input_field);
            Anim2(encrypted_field);
            button_Decrypt.Foreground = new SolidColorBrush(Colors.Gray);

            ColorAnimation text_anim = new ColorAnimation
            {
                To = (Color)ColorConverter.ConvertFromString("#2563EB"),
                Duration = TimeSpan.FromMilliseconds(400)
            };

            ColorAnimation text_anim2 = new ColorAnimation
            {
                To = Colors.Gray,
                Duration = TimeSpan.FromMilliseconds(400)
            };


            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Border_haha.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            DropShadowEffect effect2 = Border_haha.Effect as DropShadowEffect;
            ColorAnimation dropShadowAnim = new ColorAnimation
            {
                To = (Color)ColorConverter.ConvertFromString("#2563EB"),
                Duration = TimeSpan.FromMilliseconds(400)
            };
            effect2.BeginAnimation(DropShadowEffect.ColorProperty, dropShadowAnim);
            if (encrypt_btn.Opacity == 1.0)
            {
                Anim(1.0, 0.0, encrypt_btn, decrypt_btn);
                Anim(0.0, 1.0, decrypt_btn, decrypt_btn);
                

            }
            if (password_field.IsReadOnly == false)
            {
                button_password.Foreground = new SolidColorBrush(Colors.Green);
                Border_pss.BorderBrush = new SolidColorBrush(Colors.Green);

                button_password.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);

                Border_pss.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
                errorLabel.Visibility = Visibility.Hidden;
                


            }
            color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB"));

            input_field.IsReadOnly = true;
            encrypted_field.IsReadOnly = false;
            button_password.Tag = "Locked";
        }

        public void Anim(double x, double y, Button target, Button final)
        {
            final.Visibility = Visibility.Visible;
            final.Opacity = 0;
            var anim = new DoubleAnimation
            {
                From = x,
                To = y,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            if (final != decrypt_btn) {
                anim.Completed += (s, ev) =>
                {
                    decrypt_btn.Visibility = Visibility.Hidden;
                };
            }
            

            target.BeginAnimation(Button.OpacityProperty, anim);
            final.Visibility = Visibility.Visible;
            
        }
        public void Anim2(TextBox textbox)
        {
            DoubleAnimation anim2 = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(300)
            };
            anim2.Completed += (s, ev) =>
            {
                textbox.Text = "";
                DoubleAnimation anim3 = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromMilliseconds(100)
                };
                textbox.BeginAnimation(TextBox.OpacityProperty, anim3);
            };
            textbox.BeginAnimation(TextBox.OpacityProperty, anim2);
        }
        public void encrypt_clicked(object sender, RoutedEventArgs e)
        {
            input_field.IsReadOnly = false;
            encrypted_field.IsReadOnly = true;
            if (button_Encrypt.Foreground is SolidColorBrush scb && scb.Color == (Color)ColorConverter.ConvertFromString("#149414"))
            {
                return;
            }


            Anim2(input_field);
            Anim2(encrypted_field);
            ColorAnimation text_anim2 = new ColorAnimation
            {
                To = (Color)ColorConverter.ConvertFromString("#149414"),
                Duration = TimeSpan.FromMilliseconds(400)
            };

            ColorAnimation text_anim = new ColorAnimation
            {
                To = Colors.Gray,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_haha.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            DropShadowEffect effect1 = Border_haha.Effect as DropShadowEffect;
            ColorAnimation dropShadowAnim = new ColorAnimation
            {
                To = (Color)ColorConverter.ConvertFromString("#3CFF3C"),
                Duration = TimeSpan.FromMilliseconds(400)
            };
            effect1.BeginAnimation(DropShadowEffect.ColorProperty, dropShadowAnim);

            if (decrypt_btn.Opacity == 1.0)
            {
                Anim(1.0, 0.0, decrypt_btn, encrypt_btn);
                Anim(0.0, 1.0, encrypt_btn, encrypt_btn);
                


            }
            {

                color = Brushes.Green;

                if (password_field.IsReadOnly == false)
                {
                    button_password.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);

                    Border_pss.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
                    errorLabel.Visibility = Visibility.Hidden;
                }
                button_password.Tag = "not Locked";
            }
        }
    }
}

