using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;            
using System.Windows.Media.Animation;  
using System.Windows.Shapes;
using System.IO.Compression;


namespace EncodeX
{
    public partial class MainWindow
    {
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
                    FileName = get_name(password, file)
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
                };
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

                        ms.Write(fileNameLengthBytes, 0, fileNameLengthBytes.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length);
                            byte[] buffer = new byte[200 * 1024 * 1024];
                            long totalbytes = fs.Length;
                            long bytesread = 0;
                            int bytesRead;
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cs.Write(buffer, 0, bytesRead);
                                bytesread += bytesRead;
                                double progress = (double)bytesread / totalbytes;
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
                    };
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
                            byte[] buffer = new byte[200 * 1024 * 1024];
                            long totalBytes = ms.Length;
                            int bytesRead;
                            long total = 0;
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
                        errorLabel.Content = "Error decrypting file";
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

        public string Encrypt_folder(String password, String folder, String destination)
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
                String fileName = System.IO.Path.GetFileName(folder) + ".zip";


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
                                    byte[] buffer = new byte[200 * 1024 * 1024];
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

                return "File Path: " + destination + "\n" + "File Name: " + name + "\n" + "File size: " + sizeText;
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                errorLabel.Content = "Error encrypting folder",
                errorLabel.Visibility = Visibility.Visible);

                return "";
            }
        }

    }
}