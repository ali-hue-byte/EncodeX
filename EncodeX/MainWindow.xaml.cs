using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            
            List<Label> labels = new List<Label> {
                first,
                first_Copy,
                first_Copy1,
                first_Copy2,
                first_Copy3,
                first_Copy4,
                first_Copy5,
                first_Copy6,
                first_Copy7,
                first_Copy8, 
                first_Copy9,
                first_Copy10,
                first_Copy11,
                first_Copy12,
                first_Copy13,
                
            };

            List<Label> lbl2 = new List<Label>
            {
                first_Copy14,
                first_Copy15,
                first_Copy16,
                first_Copy17,
                first_Copy18,
                first_Copy19,
                first_Copy20,
                first_Copy21,
                first_Copy22,
                first_Copy23,
                first_Copy24,
            };

            Dictionary<Label, List<int>> dict = new Dictionary<Label, List<int>>{
    { first,        new List<int> { 206 - 400, 206 + 500, 1200} },
    { first_Copy,   new List<int> { 203 - 300, 203 + 500, 1500} },
    { first_Copy1,  new List<int> { 139 - 500, 139 + 600, 1300 } },
    { first_Copy2,  new List<int> { 312 - 400, 312 + 1000, 1800 } },
    { first_Copy3,  new List<int> { 139 - 700, 139 + 500, 1500 } },
    { first_Copy4,  new List<int> { 260 - 400, 260 + 400, 1500 } },
    { first_Copy5,  new List<int> { 183 - 400, 183 + 500, 1700 } },
    { first_Copy6,  new List<int> { 92 - 400, 92 + 500, 1500 } },
    { first_Copy7,  new List<int> { 278 - 400, 278 + 500, 1500 } },
    { first_Copy8,  new List<int> { 340 - 400, 340 + 500, 1500 } },
    { first_Copy9,  new List<int> { 203 - 400, 203 + 500, 1200 } },
    { first_Copy10, new List<int> { 139 - 800, 139 + 500, 1500 } },
    { first_Copy11, new List<int> { -95 - 400, -95 + 500, 1500 } },
    { first_Copy12, new List<int> { 279 - 600, 279 + 500, 1700 } },
    { first_Copy13, new List<int> { -45 - 700, -45 + 800, 2000 } },

    { first_Copy14, new List<int> { -134 - 400, -134 + 800, 2400 } },
    { first_Copy15, new List<int> { -95 - 400, -95 + 800, 2400 } },
    { first_Copy16, new List<int> { -45 - 800, -45 + 1000, 2400 } },
    { first_Copy17, new List<int> { -106 - 400, -106 + 800, 2400 } },
    { first_Copy18, new List<int> { -91 - 200, -91 + 800, 2400 } },
    { first_Copy19, new List<int> { -60 - 600, -60 + 700, 2400 } },
    { first_Copy20, new List<int> { 413 - 900, 413 + 800, 3100 } },
    { first_Copy21, new List<int> { 368 - 700, 368 + 900, 2200 } },
    { first_Copy22, new List<int> { -128 - 400, -128 + 800, 2400 } },
    { first_Copy23, new List<int> { -106 - 400, -106 + 800, 2400 } },
    { first_Copy24, new List<int> { 112 - 400, 112 + 800, 2400 } },
};



            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);

            foreach (KeyValuePair<Label,List<int>> label in dict)
            {
                animate(label.Key, label.Value[0], label.Value[1], label.Value[2]);
                
                    timer.Tick += (s, e) =>
                    { Timer_text(label.Key, Random_text()); };
                
                

            }

            

            timer.Start();
            
            
            
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

        private async void Button_Click(object sender, RoutedEventArgs e)
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


            if (choice == "text")
            {
                RectangleGeometry clip;
                if (arrow1.Clip == null)
                {
                    clip = new RectangleGeometry(new Rect(0, 0, arrow1.ActualWidth, arrow1.Height));
                    arrow1.Clip = clip;
                }
                else
                {
                    clip = (RectangleGeometry)arrow1.Clip;
                }
                progress1.Visibility = Visibility.Visible;
                double totalWidth = arrow1.ActualWidth;


                RectAnimation anim = new RectAnimation
                {
                    From = new Rect(0, 0, totalWidth, arrow1.Height),
                    To = new Rect(totalWidth, 0, 0, arrow1.Height),
                    Duration = TimeSpan.FromMilliseconds(200),
                    FillBehavior = FillBehavior.Stop
                };

                anim.Completed += (s, ev) =>
                        {
                            RectangleGeometry clip = (RectangleGeometry)arrow1.Clip;
                            clip.Rect = new Rect(0, 0, arrow1.ActualWidth, arrow1.Height);
                            progress1.Visibility = Visibility.Hidden;
                            encrypted_field.Text = encrypt(password, plainText);

                        };
                clip.BeginAnimation(RectangleGeometry.RectProperty, anim);

            }
            else if (choice == "file")
            {
                string filePath = "";


                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Encrypted file (*.enc)|*.enc|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                    DefaultExt = ".txt",
                    AddExtension = true
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        filePath = saveFileDialog.FileName;

                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Encryption failed ";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
                try
                {
                    encrypted_field.Text = await Task.Run(()=>encrypt_file(password, file, filePath));
                }
                catch (Exception ex)
                {
                    errorLabel.Content = "Encryption failed ";
                    errorLabel.Visibility = Visibility.Visible;
                }
                progress1.Visibility = Visibility.Hidden;
            }
            else
            {
                string filePath = "";


                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Encrypted file (*.enc)|*.enc|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                    DefaultExt = ".txt",
                    AddExtension = true
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        filePath = saveFileDialog.FileName;

                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Error saving file";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }

                try
                {
                    encrypted_field.Text = await Task.Run(() => Encrypt_folder(password, file, filePath));
                }
                catch (Exception ex)
                {
                    this.Dispatcher.Invoke(() =>
                errorLabel.Content = "Error decrypting file",
                errorLabel.Visibility = Visibility.Visible);
                }
                progress1.Visibility = Visibility.Hidden;











            }
        }


        
        private async void decrypt_txt(object sender, RoutedEventArgs e)
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
            

             if (choice == "text")
              {
                RectangleGeometry clip;
                if (arrow1.Clip == null)
                {
                    clip = new RectangleGeometry(new Rect(0, 0, arrow1.ActualWidth, arrow1.Height));
                    arrow1.Clip = clip;
                }
                else
                {
                    clip = (RectangleGeometry)arrow1.Clip;
                }
                progress2.Visibility = Visibility.Visible;
                double totalWidth = arrow1.ActualWidth;


                RectAnimation anim = new RectAnimation
                {
                    From = new Rect(0, 0, totalWidth, arrow1.Height),
                    To = new Rect(totalWidth, 0, 0, arrow1.Height),
                    Duration = TimeSpan.FromMilliseconds(200),
                    FillBehavior = FillBehavior.Stop
                };

                anim.Completed += (s, ev) =>
                {
                    RectangleGeometry clip = (RectangleGeometry)arrow1.Clip;
                    clip.Rect = new Rect(0, 0, arrow1.ActualWidth, arrow1.Height);
                    progress2.Visibility = Visibility.Hidden;
                    input_field.Text = decrypt(password, plainText);

                };
                clip.BeginAnimation(RectangleGeometry.RectProperty, anim);
               
                    }
                    else
                    {
                string filePath;
                
                
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "All files (*.*)|*.*",
                    DefaultExt = ".txt",
                    AddExtension = false,
                    FileName = get_name(password,file)
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    
                        filePath = saveFileDialog.FileName;
                        
                    
                }
                filePath = saveFileDialog.FileName;
                List<string> result = await Task.Run(() => decrypt_file(password, file, filePath));
                try
                {
                    encrypted_field.Text = result[1];
                }
                catch (Exception ex)
                {
                    return;
                }
                progress2.Visibility = Visibility.Hidden;
                
            }


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

        public string encrypt_file(string password, string filePath, string destination)
        {

            try
            {
                
                this.Dispatcher.Invoke(() =>
                {
                    encrypted_field.Text = "";
                    button_Encrypt.IsEnabled = false;
                    button_Decrypt.IsEnabled = false;
                    encrypt_btn.IsEnabled = false;
                    Select_file.IsEnabled = false;
                    Select_folder.IsEnabled = false;
                    Copy.IsEnabled = false;
                    paste.IsEnabled = false;
                    Save.IsEnabled = false;
                    Button_text.IsEnabled = false;
                    button_files.IsEnabled = false;
                    button_password.IsEnabled = false;
                });
                
                string encrypted;
                string fileName = System.IO.Path.GetFileName(filePath);
               
                
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
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (FileStream ms = new FileStream(destination, FileMode.Create, FileAccess.Write)) 
                    {
                        ms.Write(salt, 0, salt.Length);
                        ms.Write(iv, 0, iv.Length);
                        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                        byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);
                        
                        ms.Write(fileNameLengthBytes, 0,fileNameLengthBytes.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length);
                            byte[] buffer = new byte[8192];
                            long totalbytes = fs.Length;
                            long bytesread = 0;
                            int bytesRead;
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cs.Write(buffer, 0, bytesRead);
                                bytesread += bytesRead;
                                double progress = (double)bytesread/totalbytes;
                                this.Dispatcher.BeginInvoke(() =>
                                {
                                    update_arrow(progress);
                                });
                            }
                            
                            cs.FlushFinalBlock();
                        }
                        String name = System.IO.Path.GetFileName(destination);
                        Double size = new FileInfo(destination).Length;
                        String unit = "bytes";
                        if (size > 1024)
                        {
                            size = size / 1024;
                            unit = "KB";
                            if (size > 1024)
                            {
                                size = size / 1024;
                                unit = "MB";
                                if (size > 1024)
                                {
                                    size = size / 1024;
                                    unit = "GB";

                                }

                            }


                        }
                        String sizeText = size.ToString("0.00") + " " + unit;
                        this.Dispatcher.Invoke(() =>
                        {
                            button_Encrypt.IsEnabled = true;
                            button_Decrypt.IsEnabled = true;
                            encrypt_btn.IsEnabled = true;
                            Select_file.IsEnabled = true;
                            Select_folder.IsEnabled = true;
                            Copy.IsEnabled = true;
                            paste.IsEnabled = true;
                            Save.IsEnabled = true;
                            Button_text.IsEnabled = true;
                            button_files.IsEnabled = true;
                            button_password.IsEnabled = true;
                        });
                        
                        return "File Path: " + destination + "\n" + "File Name: " + name + "\n" + "File size: " + sizeText;
                    }
                    

                    ;
                }
                
                
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                errorLabel.Content = "Error encrypting file",
                errorLabel.Visibility = Visibility.Visible);
                return "";
            }
        }
        public String get_name(String password ,String filepath)
        {
            byte[] encryptedBytes = new byte[36];

            using (FileStream ms = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                ms.Read(encryptedBytes, 0, 36);


                byte[] salt = new byte[16];
                byte[] iv = new byte[16];
                byte[] fileNameLengthBytes = new byte[4];

                Array.Copy(encryptedBytes, 0, salt, 0, salt.Length);
                Array.Copy(encryptedBytes, salt.Length, iv, 0, iv.Length);
                Array.Copy(encryptedBytes, salt.Length + iv.Length, fileNameLengthBytes, 0, 4);

                int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes);
                var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] key = kdf.GetBytes(32);
                ms.Position = 36;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                       
                        byte[] fileNameBytes = new byte[fileNameLength];
                        int totalRead = 0;
                        while (totalRead < fileNameLength)
                        {
                            int bytesRead = cs.Read(fileNameBytes, totalRead, fileNameLength - totalRead);

                            totalRead += bytesRead;
                        }
                        string fileName = Encoding.UTF8.GetString(fileNameBytes);

                        return fileName;
                    }
                }
            }
        }
        public List<string> decrypt_file(string password, string filepath, string destination)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    button_Encrypt.IsEnabled = false;
                    button_Decrypt.IsEnabled = false;
                    encrypt_btn.IsEnabled = false;
                    Select_file.IsEnabled = false;
                    Select_folder.IsEnabled = false;
                    Copy.IsEnabled = false;
                    paste.IsEnabled = false;
                    Save.IsEnabled = false;
                    Button_text.IsEnabled = false;
                    button_files.IsEnabled = false;
                    button_password.IsEnabled = false;
                });
                if (string.IsNullOrEmpty(filepath)) return new List<string> { "" };

                List<string> result = new List<string>();


                byte[] encryptedBytes = new byte[36];

                using (FileStream ss = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    ss.Read(encryptedBytes, 0, 36);
                }

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

                    using (FileStream ms = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        ms.Position = 36;
                        byte[] fileNameBytes = new byte[fileNameLength];
                        int totalRead = 0;
                        while (totalRead < fileNameLength)
                        {
                            int bytesRead = cs.Read(fileNameBytes, totalRead, fileNameLength - totalRead);

                            totalRead += bytesRead;
                        }
                        string fileName = Encoding.UTF8.GetString(fileNameBytes);


                        using (FileStream msContent = new FileStream(destination, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[200*1024 * 1024];
                            long totalBytes = ms.Length;
                            int bytesRead;
                            long total =0;
                            while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                msContent.Write(buffer, 0, bytesRead);
                                total += bytesRead;
                                double progress = (double)total / totalBytes;
                                this.Dispatcher.Invoke(() => update_arrow(progress));
                            }

                            
                            Double size = new FileInfo(destination).Length;
                            String unit = "bytes";
                            if (size > 1024)
                            {
                                size = size / 1024;
                                unit = "KB";
                                if (size > 1024)
                                {
                                    size = size / 1024;
                                    unit = "MB";
                                    if (size > 1024)
                                    {
                                        size = size / 1024;
                                        unit = "GB";

                                    }

                                }


                            }
                            String sizeText = size.ToString("0.00") + " " + unit;

                            result.Add(fileName);
                            result.Add("File Name: " + fileName + "\nFilePath: " + destination + "\nFileSize: " + sizeText);
                        }
                    }
                }
                this.Dispatcher.Invoke(() =>
                {
                    button_Encrypt.IsEnabled = true;
                    button_Decrypt.IsEnabled = true;
                    encrypt_btn.IsEnabled = true;
                    Select_file.IsEnabled = true;
                    Select_folder.IsEnabled = true;
                    Copy.IsEnabled = true;
                    paste.IsEnabled = true;
                    Save.IsEnabled = true;
                    Button_text.IsEnabled = true;
                    button_files.IsEnabled = true;
                    button_password.IsEnabled = true;
                });
                return result;
            }
            catch (Exception ex)
            {
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        errorLabel.Content = "Error decrypting file" ;
                        errorLabel.Visibility = Visibility.Visible;
                    });
                    return new List<string> { "" };
                }
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
            input_field1.Text = "";
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
            input_field1.Text = "";
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
            encrypted_field.Text = "";

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
            encrypted_field.Text = "";
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
                    errorLabel.Content = "Error reading file" ;
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
                    errorLabel.Content = "Error reading folder ";
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
            if (choice == "text")
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
                        errorLabel.Content = "Error saving file ";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*",
                    DefaultExt = ".txt",
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
                        errorLabel.Content = "Error saving file ";
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
                        errorLabel.Content = "Error saving file";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }
            else
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
                        File.WriteAllText(filePath, encrypted_field.Text);
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Content = "Error saving file";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }

        }


        
        
        public void update_arrow(double progress) 
        {
            Rect rect;
            var parada = progress1;
            if(mode == "encrypt")
            { parada = progress1; }
            else
            { parada = progress2; }
            double totalWidth = parada.ActualWidth;
            if (parada.Visibility == Visibility.Hidden)
            {
                rect = new Rect(totalWidth, 0, totalWidth, parada.Height);
            }
            else
            {
                rect = ((RectangleGeometry)parada.Clip).Rect;
            }
                parada.Visibility = Visibility.Visible;

            RectangleGeometry clip;
            if (parada.Clip == null)
            {
                clip = new RectangleGeometry(new Rect(0, 0, parada.ActualWidth, parada.Height));
                parada.Clip = clip;
            }
            else
            {
                clip = (RectangleGeometry)parada.Clip;
            }
            
            


            RectAnimation anim = new RectAnimation
            {
                From = rect,
                To = new Rect(totalWidth * (1-progress), 0, totalWidth, parada.Height),
                Duration = TimeSpan.FromMilliseconds(500),
                FillBehavior = FillBehavior.HoldEnd,
            };

            
            clip.BeginAnimation(RectangleGeometry.RectProperty, anim);
        }

        public string  Encrypt_folder(String password,String folder,String destination)
        {

            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    encrypted_field.Text = "";
                    button_Encrypt.IsEnabled = false;
                    button_Decrypt.IsEnabled = false;
                    encrypt_btn.IsEnabled = false;
                    Select_file.IsEnabled = false;
                    Select_folder.IsEnabled = false;
                    Copy.IsEnabled = false;
                    paste.IsEnabled = false;
                    Save.IsEnabled = false;
                    Button_text.IsEnabled = false;
                    button_files.IsEnabled = false;
                    button_password.IsEnabled = false;
                });
                

                String encrypted;
                String fileName = System.IO.Path.GetFileName(folder) +".zip";

                
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
                    
                    using FileStream fs2 = new FileStream(destination, FileMode.Create, FileAccess.Write);
                    {

                        fs2.Write(salt, 0, salt.Length);
                        fs2.Write(iv, 0, iv.Length);

                        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                        byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);


                        fs2.Write(fileNameLengthBytes, 0, fileNameLengthBytes.Length);
                        using (CryptoStream cs = new CryptoStream(fs2, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length);
                            using (var archive = new ZipArchive(cs, ZipArchiveMode.Create, true))
                            {
                                var files = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);
                                int processed = 0;
                                int totalFiles = files.Count();

                                foreach (var file in files)
                                {
                                    string entryName = System.IO.Path.GetRelativePath(folder, file);
                                    var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);

                                    using var entryStream = entry.Open();
                                    using var fileStream = File.OpenRead(file);
                                    byte[] buffer = new byte[8000];
                                    int bytesRead;
                                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        entryStream.Write(buffer, 0, bytesRead);
                                    }

                                    processed++;
                                    double progress = (double)processed / totalFiles;
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        update_arrow(progress);
                                    });
                                }
                            }
                        
                        cs.FlushFinalBlock();
                    }
                        
                    }


                    ;
                }
                String name = System.IO.Path.GetFileName(destination);
                Double size = new FileInfo(destination).Length;
                String unit = "bytes";
                if (size > 1024)
                {
                    size = size / 1024;
                    unit = "KB";
                    if (size > 1024)
                    {
                        size = size / 1024;
                        unit = "MB";
                        if (size > 1024)
                        {
                            size = size / 1024;
                            unit = "GB";

                        }

                    }


                }
                String sizeText = size.ToString("0.00") + " " + unit;
                this.Dispatcher.Invoke(() =>
                {
                    button_Encrypt.IsEnabled = true;
                    button_Decrypt.IsEnabled = true;
                    encrypt_btn.IsEnabled = true;
                    Select_file.IsEnabled = true;
                    Select_folder.IsEnabled = true;
                    Copy.IsEnabled = true;
                    paste.IsEnabled = true;
                    Save.IsEnabled = true;
                    Button_text.IsEnabled = true;
                    button_files.IsEnabled = true;
                    button_password.IsEnabled = true;
                });
               
                return "File Path: "+destination + "\n" +"File Name: "+name+"\n"+"File size: "+sizeText;
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                errorLabel.Content = "Error encrypting folder",
                errorLabel.Visibility = Visibility.Visible);
                
                return "";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            DoubleAnimation opac = new DoubleAnimation
            {
                From =1.0 ,
                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(300),
                FillBehavior = FillBehavior.Stop,
            };

            DoubleAnimation opac2 = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(800),
                FillBehavior = FillBehavior.Stop,
            };
            Border_haha.BeginAnimation(OpacityProperty, opac2);
            Border_encrypt.BeginAnimation(OpacityProperty, opac2);
            Border_decrypt.BeginAnimation(OpacityProperty, opac2);
            Border_pss.BeginAnimation(OpacityProperty, opac2);
            encrypt_btn.BeginAnimation(OpacityProperty, opac2);
            button_password.BeginAnimation(OpacityProperty, opac2);
            button_Encrypt.BeginAnimation(OpacityProperty, opac2);

            opac.Completed += (s, e) => 
            {
                MainFrame.Visibility = Visibility.Collapsed;
                First.Visibility = Visibility.Collapsed;
                Lock.Visibility = Visibility.Collapsed;
                

            };

            MainFrame.BeginAnimation(OpacityProperty, opac);
            Lock.BeginAnimation(OpacityProperty, opac);
            First.BeginAnimation(OpacityProperty, opac);
            
        }

        public static String Random_text()
        {
            String output = "";
            String choices = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+/";
            var ran = new Random();
            for (int i = 0; i < 15; i++) 
            {
                char next = choices[ran.Next(choices.Length)];
                output += "\n";
                output += next;
            };
            return output;

        }
        public void Timer_text(Label lbl, String text)
        {
            lbl.Content = text;
            
        }

         public void animate (Label label, int x, int y, int t)
        {
            ThicknessAnimation mov = new ThicknessAnimation
            {
                From = new Thickness(label.Margin.Left, x, label.Margin.Right, label.Margin.Bottom),
                To = new Thickness(label.Margin.Left, y, label.Margin.Right, label.Margin.Bottom),
                Duration = TimeSpan.FromMilliseconds(t),
                RepeatBehavior = RepeatBehavior.Forever
            };
            label.BeginAnimation(Label.MarginProperty, mov);
        }
    }
}
