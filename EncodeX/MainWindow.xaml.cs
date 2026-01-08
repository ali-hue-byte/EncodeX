using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

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
            Border_haha.MouseEnter += (s, e) =>
            {
                animation(encrypt_btn);
                animation(button_Encrypt);
                animation(button_Decrypt);
                animation(button_password);
                animation(Border_pss);
                animation(Border_encrypt);
                animation(Border_decrypt);
                animation(decrypt_btn);
                animation(arrow);
                animation(File_input);
                animation(Select_file);
                DoubleAnimation animX = new DoubleAnimation
                {
                    From = 389,
                    To = 489,
                    Duration = TimeSpan.FromMilliseconds(300),
                };
                errorLabel.BeginAnimation(Canvas.LeftProperty, animX);
            };
            Border_haha.MouseLeave += (s, e) =>
            {
                animation2(encrypt_btn, "319,223,71,66");
                animation2(button_Encrypt, "153,0,69,0");
                animation2(button_Decrypt, "129,0,69,0");
                animation2(button_password, "294,0,46,0");
                animation2(Border_pss, "296,24,48,0");
                animation2(Border_encrypt, "33,24,33,192");
                animation2(Border_decrypt, "98,24,114,192");
                animation2(decrypt_btn, "319,223,71,66");
                animation2(arrow, "328,2,80,246");
                animation2(File_input, "34,37,33,310");
                animation2(Select_file, "120,57,120,232");
                DoubleAnimation animX = new DoubleAnimation
                {
                    From = 489,
                    To = 389,
                    Duration = TimeSpan.FromMilliseconds(300),
                };
                errorLabel.BeginAnimation(Canvas.LeftProperty, animX);
            };
        }
        public void animation(FrameworkElement thing)
        {
            Thickness current = thing.Margin;
            ThicknessAnimation animation = new ThicknessAnimation
            {
                From = current,
                To = new Thickness(current.Left + 100, current.Top, current.Right - 100, current.Bottom),
                Duration = TimeSpan.FromMilliseconds(300),
            };
            thing.BeginAnimation(FrameworkElement.MarginProperty, animation);
        }
        public void animation2(FrameworkElement thing, string end)
        {
            string[] strings = end.Split(',');
            Thickness End = new Thickness(double.Parse(strings[0]), double.Parse(strings[1]), double.Parse(strings[2]), double.Parse(strings[3]));
            Thickness current = thing.Margin;
            ThicknessAnimation animation = new ThicknessAnimation
            {
                From = current,
                To = End,
                Duration = TimeSpan.FromMilliseconds(300),
            };
            thing.BeginAnimation(FrameworkElement.MarginProperty, animation);
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

            if (plainText == "")
            {
                encrypted_field.Text = "";
                return;
            }

            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Hidden;
                password = "password@1010^";

            }


            else if (password.Length < 8 || password == "")
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
            SolidColorBrush newBrush = new SolidColorBrush(Colors.Green);
            arrowProgress.Fill = newBrush;
            arrowProgress.Width = 0;
            arrowTranslate.X = 0;
            DoubleAnimation widthAnim = new DoubleAnimation
            {
                From = 0,
                To = 20,
                Duration = TimeSpan.FromMilliseconds(200),
                FillBehavior = FillBehavior.Stop
            };

            widthAnim.Completed += (s1, e1) =>
            {
                arrowProgress.Width = 20;

                DoubleAnimation posAnim = new DoubleAnimation
                {
                    From = 0,
                    To = -20,
                    Duration = TimeSpan.FromMilliseconds(100),
                    FillBehavior = FillBehavior.Stop
                };



                posAnim.Completed += (s2, e2) =>
                {
                    DoubleAnimation resetAnim = new DoubleAnimation
                    {
                        From = 20,
                        To = 0,
                        Duration = TimeSpan.FromMilliseconds(100),
                        FillBehavior = FillBehavior.Stop
                    };
                    DoubleAnimation moveAnim2 = new DoubleAnimation
                    {
                        From = -20,
                        To = -70,
                        Duration = TimeSpan.FromMilliseconds(150),
                        FillBehavior = FillBehavior.Stop
                    };

                    arrowProgress.BeginAnimation(FrameworkElement.WidthProperty, resetAnim);
                    arrowTranslate.BeginAnimation(TranslateTransform.XProperty, moveAnim2);


                    encrypted_field.Text = encrypt(password, plainText);



                    arrowTranslate.X = -20;

                    arrowProgress.Width = 0;




                };

                arrowTranslate.BeginAnimation(TranslateTransform.XProperty, posAnim);
            };

            arrowProgress.BeginAnimation(FrameworkElement.WidthProperty, widthAnim);







        }



        private void decrypt_txt(object sender, RoutedEventArgs e)
        {

            string password = password_field.Text;
            string plainText = encrypted_field.Text;
            if (plainText == "")
            {
                return;
            }
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
            SolidColorBrush newBrush = new SolidColorBrush(Colors.DodgerBlue);
            arrowProgress.Fill = newBrush;
            arrowProgress.Width = 0;
            arrowTranslate.X = 0;
            DoubleAnimation widthAnim = new DoubleAnimation
            {
                From = 0,
                To = 20,
                Duration = TimeSpan.FromMilliseconds(200),
                FillBehavior = FillBehavior.Stop
            };

            widthAnim.Completed += (s1, e1) =>
            {
                arrowProgress.Width = 20;

                DoubleAnimation posAnim = new DoubleAnimation
                {
                    From = 0,
                    To = -20,
                    Duration = TimeSpan.FromMilliseconds(100),
                    FillBehavior = FillBehavior.Stop
                };



                posAnim.Completed += (s2, e2) =>
                {
                    DoubleAnimation resetAnim = new DoubleAnimation
                    {
                        From = 20,
                        To = 0,
                        Duration = TimeSpan.FromMilliseconds(100),
                        FillBehavior = FillBehavior.Stop
                    };
                    DoubleAnimation moveAnim2 = new DoubleAnimation
                    {
                        From = -20,
                        To = -70,
                        Duration = TimeSpan.FromMilliseconds(150),
                        FillBehavior = FillBehavior.Stop
                    };

                    arrowProgress.BeginAnimation(FrameworkElement.WidthProperty, resetAnim);
                    arrowTranslate.BeginAnimation(TranslateTransform.XProperty, moveAnim2);


                    input_field.Text = decrypt(password, plainText);



                    arrowTranslate.X = -20;

                    arrowProgress.Width = 0;




                };

                arrowTranslate.BeginAnimation(TranslateTransform.XProperty, posAnim);
            };

            arrowProgress.BeginAnimation(FrameworkElement.WidthProperty, widthAnim);
        }
        public string encrypt(string password, string text)
        {
            if (text == "")
            {
                return "";
            }
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
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
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

        public string decrypt(string password, string text)
        {
            if (text == "")
            {
                return "";
            }
            string decrypted;

            try
            {

                byte[] encrypted = Convert.FromBase64String(text);
                byte[] salt = new byte[16];
                byte[] iv = new byte[16];
                Array.Copy(encrypted, 0, salt, 0, salt.Length);
                Array.Copy(encrypted, salt.Length, iv, 0, iv.Length);
                var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] key = kdf.GetBytes(32);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    using (MemoryStream msEncrypt = new MemoryStream(encrypted, 32, encrypted.Length - 32))
                    using (CryptoStream cs = new CryptoStream(msEncrypt, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (MemoryStream msDecrypt = new MemoryStream())
                    {
                        cs.CopyTo(msDecrypt);

                        decrypted = Encoding.UTF8.GetString(msDecrypt.ToArray());
                    }
                }
            }
            catch
            {
                decrypted = "";
                errorLabel.Content = "Decryption failed. Check your input and try again.";
                errorLabel.Visibility = Visibility.Visible;

            }

            return decrypted;
        }
        public void opacity_anim(Button button, double x, double y)
        {
            DoubleAnimation opacity = new DoubleAnimation
            {
                From = x,
                To = y,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            button.BeginAnimation(Button.OpacityProperty, opacity);
        }

        public void decrypt_clicked(object sender, RoutedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Hidden;
            if (button_Decrypt.Tag as String == "Clicked")
            {
                return;
            }
            Random random = new Random();
            int[] options = [0, 360];
            int choice = options[random.Next(options.Length)];
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

            
            opacity_anim(Copy,1.0,0.0);
            opacity_anim(Copy2, 0.0, 1.0);
            Copy2.Visibility= Visibility.Visible;
            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            File_input.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Select_file.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Select_file.Tag = "Blue";
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
            arrow.RenderTransform = new RotateTransform(0);

            arrow.RenderTransformOrigin = new Point(0.5, 0.5);

            DoubleAnimation rotate = new DoubleAnimation
            {
                From = 180,
                To = choice,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate);

            button_Decrypt.Tag = "Clicked";
            button_Encrypt.Tag = "Not Clicked";
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
            if (final != decrypt_btn)
            {
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
            errorLabel.Visibility = Visibility.Hidden;
            Random random = new Random();
            int[] options = { 180, 540 };
            int choice = options[random.Next(options.Length)];
            input_field.IsReadOnly = false;
            encrypted_field.IsReadOnly = true;
            if (button_Encrypt.Tag as String == "Clicked")
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
            opacity_anim(Copy2, 1.0, 0.0);
            opacity_anim(Copy, 0.0, 1.0);
            Copy.Visibility = Visibility.Visible;
            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            File_input.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Select_file.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Select_file.Tag = "Green";
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
                arrow.RenderTransform = new RotateTransform(0);

                arrow.RenderTransformOrigin = new Point(0.5, 0.5);

                DoubleAnimation rotate = new DoubleAnimation
                {
                    From = 360,
                    To = choice,
                    Duration = TimeSpan.FromMilliseconds(400)
                };
                arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate);
                button_Encrypt.Tag = "Clicked";
                button_Decrypt.Tag = "Not Clicked";
            }
        }

        private void button_files_Click(object sender, RoutedEventArgs e)
        {
            input_field.IsReadOnly = true;
            Border_encrypt.Visibility = Visibility.Hidden;
            Select_file.Visibility = Visibility.Visible;
            File_input.Visibility = Visibility.Visible;
            Border border_files = (Border)button_files.Template.FindName("border_files", button_files);
            Border border = (Border)Button_text.Template.FindName("border", Button_text);
            border_files.BorderThickness = new Thickness(3);
            border.BorderThickness = new Thickness(1);

        }
        private void button_Text_Click(object sender, RoutedEventArgs e)
        {
            input_field.IsReadOnly = false;
            Border_encrypt.Visibility = Visibility.Visible;
            Select_file.Visibility = Visibility.Hidden;
            File_input.Visibility = Visibility.Hidden;
            Border border_files = (Border)button_files.Template.FindName("border_files", button_files);
            Border border = (Border)Button_text.Template.FindName("border", Button_text);
            border_files.BorderThickness = new Thickness(1);
            border.BorderThickness = new Thickness(3);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(encrypted_field.Text);
            ToolTip tt = new ToolTip
            {
                Content = "Copied to Clipboard!",
                IsOpen = true,
                StaysOpen = false,
                PlacementTarget = Copy,
                Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1AAE1A")),
                Foreground= Brushes.White,
                FontFamily = new FontFamily("Arial Black"),
                FontSize = 11
            };
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(input_field.Text);
            ToolTip tt = new ToolTip
            {
                Content = "Copied to Clipboard!",
                IsOpen = true,
                StaysOpen = false,
                PlacementTarget = Copy2,
                Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")),
                Foreground = Brushes.White,
                FontFamily = new FontFamily("Arial Black"),
                FontSize = 11
            };
        }
    }
}
