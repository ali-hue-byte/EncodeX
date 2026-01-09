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
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace EncodeX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        
        string mode = "encrypt";
        string choice ="text";
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
                animation(Select_folder);
                animation(Copy);
                animation(paste);
                animation(Save);
                animation(paste2);
                animation(Save2);
                animation(Copy2);
                DoubleAnimation animX = new DoubleAnimation
                {
                    From = 339,
                    To = 439,
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
                animation2(File_input, "34,37,33,286");
                animation2(Select_file, "110,57,101,232");
                animation2(Select_folder, "110,103,101,186");
                animation2(Copy, "26,0,0,0");
                animation2(paste, "0,0,-6,0");
                animation2(Copy2, "110,0,0,0");
                animation2(Save2, "192,0,0,0");
                animation2(paste2, "68,0,0,0");
                animation2(Save, "108,0,0,0");
                DoubleAnimation animX = new DoubleAnimation
                {
                    From = 439,
                    To = 339,
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
            string file = input_field1.Text;

            if (plainText == "" && choice == "text")
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

                    if (choice == "text")
                    {
                        encrypted_field.Text = encrypt(password, plainText);
                    }
                    else if(choice == "file")
                    {
                        encrypted_field.Text = encrypt_file(password, file);
                    }




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
            string file = input_field1.Text;
            if (plainText == "" && file == "")
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

                    if (choice == "text")
                    {
                        input_field.Text = decrypt(password, plainText);
                    }
                    else
                    {
                        encrypted_field.Text = decrypt_file(password, file)[1];
                    }




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

        public string encrypt_file(string password, string filePath)
        {

            try
            {
                string encrypted;
                string fileName = System.IO.Path.GetFileName(filePath);
               
                Console.WriteLine(fileName);
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
                        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                        byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);
                        
                        ms.Write(fileNameLengthBytes, 0,fileNameLengthBytes.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] fileBytes = File.ReadAllBytes(filePath);
                            
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length);
                            cs.Write(fileBytes, 0, fileBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        encrypted = Convert.ToBase64String(ms.ToArray());
                    }
                    

                    ;
                }
                
                return encrypted;
            }
            catch (Exception ex)
            {
                errorLabel.Content = "Error reading file: " + ex.Message;
                errorLabel.Visibility = Visibility.Visible;
                return "";
            }
        }

        public List<string> decrypt_file(string password, string filepath)
        {
            try
            {
                if (string.IsNullOrEmpty(filepath)) return new List<string> { "" };

                List<string> result = new List<string>();

                string encrypted = File.ReadAllText(filepath);
                byte[] encryptedBytes = Convert.FromBase64String(encrypted);

                byte[] salt = new byte[16];
                byte[] iv = new byte[16];
                byte[] fileNameLengthBytes = new byte[4];

                Array.Copy(encryptedBytes, 0, salt, 0, salt.Length);
                Array.Copy(encryptedBytes, salt.Length, iv, 0, iv.Length);
                Array.Copy(encryptedBytes, salt.Length + iv.Length, fileNameLengthBytes, 0, 4);

                int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes);
                

                var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] key = kdf.GetBytes(32);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (MemoryStream ms = new MemoryStream(encryptedBytes, 36, encryptedBytes.Length - 36))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] fileNameBytes = new byte[fileNameLength];
                        int totalRead = 0;
                        while (totalRead < fileNameLength)
                        {
                            int bytesRead = cs.Read(fileNameBytes, totalRead, fileNameLength - totalRead);
                            if (bytesRead == 0)
                                throw new Exception("Unexpected end of stream while reading filename");
                            totalRead += bytesRead;
                        }
                        string fileName = Encoding.UTF8.GetString(fileNameBytes);
                        

                        using (MemoryStream msContent = new MemoryStream())
                        {
                            cs.CopyTo(msContent);
                            string decryptedContentBase64 = Convert.ToBase64String(msContent.ToArray());

                            result.Add(fileName);
                            result.Add(decryptedContentBase64);
                        }
                    }
                }

                return result;
            }
            catch
            {
                errorLabel.Content = "Error reading file";
                errorLabel.Visibility = Visibility.Visible;
                return new List<string> { "" };
            }
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
        public void opacity_anim(FrameworkElement button, double x, double y, Button btn = null)
        {
            ToolTip tt = null;

            if (button.ToolTip != null)
            {
                button.Tag = button.ToolTip;
            }
            
            object tt2 = button.Tag;
            
            
            DoubleAnimation opacity = new DoubleAnimation
            {
                From = x,
                To = y,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            button.BeginAnimation(FrameworkElement.OpacityProperty, opacity);
            
            if (btn != null && y == 0.0)
            {
                button.ToolTip = tt;
            }
            else
            {
                button.ToolTip = tt2;
            }
        }

        public void decrypt_clicked(object sender, RoutedEventArgs e)
        {
            if (button_Decrypt.Tag as String == "Clicked")
            {
                return;
            }
            if (choice != "text")
            {
                if (!(Border_decrypt.RenderTransform is TranslateTransform))
                {
                    Border_decrypt.RenderTransform = new TranslateTransform();
                }
                ;
                
                if (!(File_input.RenderTransform is TranslateTransform))
                {
                    File_input.RenderTransform = new TranslateTransform();
                }
                ;


                var transform4 = (TranslateTransform)Border_decrypt.RenderTransform;
                transform4.X = -405;
                transform4.Y = 0;
                var group = (TransformGroup)Select_file.RenderTransform;
                
                var transform42 = (TranslateTransform)group.Children[1];
                transform42.X = 405;
                transform42.Y = 0;
                var transform43 = (TranslateTransform)File_input.RenderTransform;
                transform43.X = 405;
                transform43.Y = 0;
                opacity_anim(Border_decrypt, 0.0, 1.0);
                opacity_anim(Select_file, 0.0, 1.0);
                opacity_anim(File_input, 0.0, 1.0);
                opacity_anim(Select_folder, 1.0, 0.0);
                Select_folder.Visibility = Visibility.Hidden;
                
                
            }
            mode = "decrypt";
            errorLabel.Visibility = Visibility.Hidden;
            
            Random random = new Random();
            int[] options = [0, 360];
            int choice1 = options[random.Next(options.Length)];
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

            opacity_anim(Save, 1.0, 0.0,Save);
            opacity_anim(Save2, 0.0, 1.0);
            opacity_anim(Copy, 1.0, 0.0,Copy);
            opacity_anim(Copy2, 0.0, 1.0);
            opacity_anim(paste, 1.0, 0.0,paste);
            opacity_anim(paste2, 0.0, 1.0);
            
            Copy2.Visibility = Visibility.Visible;
            Save2.Visibility = Visibility.Visible;
            paste2.Visibility = Visibility.Visible;
            
            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            File_input.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Select_file.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Select_file.Tag = "Blue";
            Select_folder.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            Select_folder.Tag = "Blue";
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
                To = choice1,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate);

            button_Decrypt.Tag = "Clicked";
            button_Encrypt.Tag = "Not Clicked";

            if(choice != "text")
            {
                encrypted_field.IsReadOnly = true;
            };
            Select_file.Tag = "Blue";
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
            if (button_Encrypt.Tag as String == "Clicked")
            {
                return;
            }
            mode = "encrypt";
            if(choice != "text")
            {
                if (!(Border_decrypt.RenderTransform is TranslateTransform))
                {
                    Border_decrypt.RenderTransform = new TranslateTransform();
                }
                ;
                

                if (!(File_input.RenderTransform is TranslateTransform))
                {
                    File_input.RenderTransform = new TranslateTransform();
                }
                ;


                var transform4 = (TranslateTransform)Border_decrypt.RenderTransform;
                transform4.X = 1;
                transform4.Y = 0;
                var group = (TransformGroup)Select_file.RenderTransform;
               

                var transform42 = (TranslateTransform)group.Children[1];
                transform42.X = -1;
                transform42.Y = 0;
                var transform43 = (TranslateTransform)File_input.RenderTransform;
                transform43.X = -1;
                transform43.Y = 0;
                opacity_anim(Border_decrypt, 0.0, 1.0);
                opacity_anim(Select_file, 0.0, 1.0);
                opacity_anim(File_input, 0.0, 1.0);
                opacity_anim(Select_folder, 0.0, 1.0);
                Select_folder.Visibility = Visibility.Visible;
            }
            errorLabel.Visibility = Visibility.Hidden;
            Random random = new Random();
            int[] options = { 180, 540 };
            int choice1 = options[random.Next(options.Length)];
            input_field.IsReadOnly = false;
            encrypted_field.IsReadOnly = true;
            


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
            opacity_anim(Copy2, 1.0, 0.0,Copy2);
            opacity_anim(Copy, 0.0, 1.0);
            opacity_anim(Save2, 1.0, 0.0,Save2);
            opacity_anim(Save, 0.0, 1.0);
            opacity_anim(paste2, 1.0, 0.0,paste2);
            opacity_anim(paste, 0.0, 1.0);
            Copy.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Visible;
            paste.Visibility = Visibility.Visible;
            button_Decrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim);
            button_Encrypt.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_encrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Border_decrypt.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            File_input.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Select_file.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Select_file.Tag = "Green";
            Select_folder.Background.BeginAnimation(SolidColorBrush.ColorProperty, text_anim2);
            Select_folder.Tag = "Green";
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
                    To = choice1,
                    Duration = TimeSpan.FromMilliseconds(400)
                };
                arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate);
                button_Encrypt.Tag = "Clicked";
                button_Decrypt.Tag = "Not Clicked";
            }
        }
        public void AnimatePosition(FrameworkElement element, Thickness from, Thickness to, int durationMs = 300)
        {
            ThicknessAnimation anim = new ThicknessAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(durationMs),
                FillBehavior = FillBehavior.HoldEnd
            };
            element.BeginAnimation(FrameworkElement.MarginProperty, anim);
        }
        private void button_files_Click(object sender, RoutedEventArgs e)
        {
            
            
            choice = "file";
            
            Border_encrypt.Visibility = Visibility.Hidden;
            Select_folder.Visibility = Visibility.Visible;
            Select_file.Visibility = Visibility.Visible;
            File_input.Visibility = Visibility.Visible;
            if (mode == "decrypt")
            {
                Select_folder.Visibility = Visibility.Hidden;
                if (!(Border_decrypt.RenderTransform is TranslateTransform))
                {
                    Border_decrypt.RenderTransform = new TranslateTransform();
                };
                
                if (!(File_input.RenderTransform is TranslateTransform))
                {
                    File_input.RenderTransform = new TranslateTransform();
                }
                ;


                var transform = (TranslateTransform)Border_decrypt.RenderTransform;
                transform.X = -405; 
                transform.Y = 0;
                var group = (TransformGroup)Select_file.RenderTransform;
               
                var transform2 = (TranslateTransform)group.Children[1];
                transform2.X = 405;
                transform2.Y = 0;
                var transform3 = (TranslateTransform)File_input.RenderTransform;
                transform3.X = 405;
                transform3.Y = 0;
                opacity_anim(Border_decrypt,0.0, 1.0);
                opacity_anim(Select_file,0.0 ,1.0);
                opacity_anim(File_input, 0.0, 1.0);
                Select_folder.Tag = "Blue";
                Select_file.Tag = "Blue";

            }
            opacity_anim(Select_folder, 0.0, 1.0);
            opacity_anim(Select_file, 0.0, 1.0);
            opacity_anim(Border_encrypt, 1.0, 0.0);
            opacity_anim(File_input, 0.0, 1.0);
            Border border_files = (Border)button_files.Template.FindName("border_files", button_files);
            Border border = (Border)Button_text.Template.FindName("border", Button_text);
            border_files.BorderThickness = new Thickness(3);
            border.BorderThickness = new Thickness(1);
            encrypted_field.IsReadOnly = true;

            if (mode == "encrypt")
            {
                Select_folder.Tag = "Green";
                Select_file.Tag = "Green";
            }
        }
        private void button_Text_Click(object sender, RoutedEventArgs e)
        {
            if (choice != "text")
            {
                if (!(Border_decrypt.RenderTransform is TranslateTransform))
                {
                    Border_decrypt.RenderTransform = new TranslateTransform();
                }
                ;
               

                if (!(File_input.RenderTransform is TranslateTransform))
                {
                    File_input.RenderTransform = new TranslateTransform();
                }
                ;


                var transform4 = (TranslateTransform)Border_decrypt.RenderTransform;
                transform4.X = 1;
                transform4.Y = 0;
                var group = (TransformGroup)Select_file.RenderTransform;
              
                var transform42 = (TranslateTransform)group.Children[1];
                transform42.X = -1;
                transform42.Y = 0;
                var transform43 = (TranslateTransform)File_input.RenderTransform;
                transform43.X = -1;
                transform43.Y = 0;
                opacity_anim(Border_decrypt, 0.0, 1.0);
                
                
            }
            opacity_anim(Select_folder, 1.0, 0.0);
            opacity_anim(Select_file, 1.0, 0.0);
            opacity_anim(Border_encrypt, 0.0, 1.0);
            opacity_anim(File_input, 1.0, 0.0);
            choice = "text";
            encrypted_field.Text = "";
            if (mode == "encrypt")
            {
                input_field.IsReadOnly = false;
            }
            
            Border_encrypt.Visibility = Visibility.Visible;
            Select_file.Visibility = Visibility.Hidden;
            Select_folder.Visibility = Visibility.Hidden;
            File_input.Visibility = Visibility.Hidden;
            Border border_files = (Border)button_files.Template.FindName("border_files", button_files);
            Border border = (Border)Button_text.Template.FindName("border", Button_text);
            border_files.BorderThickness = new Thickness(1);
            border.BorderThickness = new Thickness(3);

            if (mode == "decrypt")
            {
               
                encrypted_field.IsReadOnly = false;
            };

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
                Foreground = Brushes.White,
                FontFamily = new FontFamily("Arial Black"),
                FontSize = 11
            };
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (choice == "text")
            {
                Clipboard.SetText(input_field.Text);
            }
            else
            {
                Clipboard.SetText(encrypted_field.Text);
            };

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
        
        private void Select_(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                
                try
                {
                    string filePath = openFileDialog.FileName;

                    input_field1.Text = filePath;
                    choice = "file";
                }
                catch (Exception ex)
                {
                    errorLabel.Content = "Error reading file: " + ex.Message;
                    errorLabel.Visibility = Visibility.Visible;
                }
            }

        }

        private void Select_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFolderDialog openFileDialog = new Microsoft.Win32.OpenFolderDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                try
                {
                    string filePath = openFileDialog.FolderName;

                    input_field1.Text = filePath;
                    choice = "folder";
                }
                catch (Exception ex)
                {
                    errorLabel.Content = "Error reading folder: " + ex.Message;
                    errorLabel.Visibility = Visibility.Visible;
                }
            }

        }
        private void Paste(object sender, RoutedEventArgs e)
        {
            if (choice == "text")
            {
                input_field.Text = Clipboard.GetText();
            }
            else
            {
                input_field1.Text = Clipboard.GetText();
            }
        }

        private void Paste2(object sender, RoutedEventArgs e)
        {
            if (choice == "text")
            {
                encrypted_field.Text = Clipboard.GetText();
            }
            else
            {
                input_field1.Text = Clipboard.GetText();
            }
            
        }

        private void Save_File(object sender, RoutedEventArgs e)
        {
            if (choice == "text" || mode == "encrypt")
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Encrypted file (*.enc)|*.enc|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                    DefaultExt = ".enc",
                    AddExtension = true
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, encrypted_field.Text);
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Error saving file: " + ex.Message;
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }
            
        }

        private void Save_File2(object sender, RoutedEventArgs e)
        {
            if (choice == "text")
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*",
                    DefaultExt = ".enc",
                    AddExtension = true
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, input_field.Text);
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Error saving file: " + ex.Message;
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }
            else


            {
                string password;
                if (password_field.IsReadOnly == true)
                {
                    password = "password@1010^";

                }
                else
                {
                    password = password_field.Text;
                }
                    List<String> data = decrypt_file(password, input_field1.Text);
                String extension = System.IO.Path.GetExtension(data[0]);
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    FileName = data[0],
                    Filter = "All files (*.*)|*.*",
                    AddExtension = false
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        byte[] data2 = Convert.FromBase64String(data[1]);
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllBytes(filePath, data2);
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Error saving file: " + ex.Message;
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }

        }
    }
}
