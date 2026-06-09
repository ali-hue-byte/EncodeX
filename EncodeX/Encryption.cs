using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.IO.Compression;


namespace EncodeX
{
    public partial class MainWindow
    {

        // Encrypts the given text using the provided password and returns the encrypted string in Base64 format
        public string encrypt(string password, string text)
        {
            if (text == "")
            {
                return "";
            }
            string encrypted;
            // Random salt for key derivation
            byte[] salt = new byte[16]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // Derive a key from the password and salt using PBKDF2
            var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] key = kdf.GetBytes(32);
            // Encrypt the text using AES
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                byte[] iv = aes.IV; // Random IV for encryption
                // Opens a memory stream to write the salt, IV, and encrypted data
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(salt, 0, salt.Length);
                    ms.Write(iv, 0, iv.Length);
                    // Encrypt the text and write it to the memory stream
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

        // Decrypts the given encrypted text using the provided password and returns the decrypted string
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
                Array.Copy(encrypted, 0, salt, 0, salt.Length); // Extracts the salt from the encrypted data
                Array.Copy(encrypted, salt.Length, iv, 0, iv.Length); // Extracts the IV from the encrypted data
                var kdf = new Rfc2898DeriveBytes(password, salt, 100000); // Derives the key from the password and salt using PBKDF2
                byte[] key = kdf.GetBytes(32);
                // Decrypts the encrypted data using AES and returns the decrypted string
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    // Opens a memory stream to read the encrypted data (skipping the salt and IV) and decrypts it using a CryptoStream
                    using (MemoryStream msEncrypt = new MemoryStream(encrypted, 32, encrypted.Length - 32))
                    using (CryptoStream cs = new CryptoStream(msEncrypt, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (MemoryStream msDecrypt = new MemoryStream())
                    {
                        cs.CopyTo(msDecrypt); // Copies the decrypted data to msDecrypt memory stream

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


        // Encrypts the file at the given file path using the provided password and saves it to the specified destination.
        // Returns a string with details about the encrypted file.
        public string encrypt_file(string password, string filePath, string destination)
        {
            try
            {
                // Disable UI elements during encryption to prevent user interaction
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

                string fileName = Path.GetFileName(filePath); // Provided file

                // Random salt for key derivation
                byte[] salt = new byte[16]; 
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                // Derive a key from the password and salt using PBKDF2
                var kdf = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] key = kdf.GetBytes(32);
                // Encrypt the file using AES and write the salt, IV, and encrypted data to the destination file
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.GenerateIV();
                    byte[] iv = aes.IV; // Random IV for encryption
                    // Open the source file for reading and the destination file for writing
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (FileStream ms = new FileStream(destination, FileMode.Create, FileAccess.Write))
                    {
                        ms.Write(salt, 0, salt.Length); // Writes the salt
                        ms.Write(iv, 0, iv.Length); // Writes the IV
                        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName); 
                        byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length); 

                        ms.Write(fileNameLengthBytes, 0, fileNameLengthBytes.Length);// Writes the length of the file name
                        // Encrypts the file content and writes it to the destination file, while also updating the progress
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length); // Writes the file name
                            byte[] buffer = new byte[200 * 1024 * 1024]; // Buffer for reading the file in chunks (200 MB)
                            long totalbytes = fs.Length;
                            long bytesread = 0;
                            int bytesRead;
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cs.Write(buffer, 0, bytesRead); // Writes the encrypted chunk to the destination file
                                bytesread += bytesRead;
                                double progress = (double)bytesread / totalbytes;
                                this.Dispatcher.BeginInvoke(() =>
                                {
                                    update_arrow(progress); // Updates the progress indicator in the UI (arrow)
                                });
                            }
                            cs.FlushFinalBlock();
                        }
                        // Get encrypted file details
                        String name = Path.GetFileName(destination);
                        Double size = new FileInfo(destination).Length;
                        String unit = "bytes";
                        // Convert file size to appropriate unit (KB, MB, GB) for display
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
            catch (Exception)
            {
                this.Dispatcher.Invoke(() =>
                errorLabel.Content = "Error encrypting file",
                errorLabel.Visibility = Visibility.Visible);
                return "";
            }
        }

        // Decrypts the file at the given file path using the provided password and saves it to the specified destination
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
                    ss.Read(encryptedBytes, 0, 36); // Reads the first 36 bytes (salt + IV + fileNameLength) from the encrypted file
                }

                byte[] salt = new byte[16];
                byte[] iv = new byte[16];
                byte[] fileNameLengthBytes = new byte[4];
                // Extracts the salt, IV, and file name length from the encrypted file header
                Array.Copy(encryptedBytes, 0, salt, 0, salt.Length);
                Array.Copy(encryptedBytes, salt.Length, iv, 0, iv.Length);
                Array.Copy(encryptedBytes, salt.Length + iv.Length, fileNameLengthBytes, 0, 4);

                int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes);


                var kdf = new Rfc2898DeriveBytes(password, salt, 100000); // Derives the key from the password and salt using PBKDF2
                byte[] key = kdf.GetBytes(32);

                // Decrypts the file using AES and writes the decrypted content to the destination file, while also updating the progress
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    // Opens the encrypted file for reading and the destination file for writing
                    using (FileStream ms = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        ms.Position = 36;
                        byte[] fileNameBytes = new byte[fileNameLength];
                        int totalRead = 0;
                        while (totalRead < fileNameLength)
                        {
                            int bytesRead = cs.Read(fileNameBytes, totalRead, fileNameLength - totalRead); // Decrypts the file name

                            totalRead += bytesRead;
                        }
                        string fileName = Encoding.UTF8.GetString(fileNameBytes);

                        using (FileStream msContent = new FileStream(destination, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[200 * 1024 * 1024]; // Buffer for reading the encrypted file content in chunks (200 MB)
                            long totalBytes = ms.Length; 
                            int bytesRead; 
                            long total = 0; 
                            while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0) 
                            { 
                                msContent.Write(buffer, 0, bytesRead);  // Writes the decrypted chunk to the destination file
                                total += bytesRead; 
                                double progress = (double)total / totalBytes; 
                                this.Dispatcher.Invoke(() => update_arrow(progress)); // updates the progress indicator in the UI (arrow) based on the decryption progress
                            }
                            // Get decrypted file details
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
            catch (Exception)
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


        // Encrypts a folder at the given path using the provided password and saves it to the specified destination as a zip file.
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
                String fileName = Path.GetFileName(folder) + ".zip";

                // Random salt
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                var kdf = new Rfc2898DeriveBytes(password, salt, 100000); // Derives a key from the password and salt using PBKDF2
                byte[] key = kdf.GetBytes(32);
                // Encrypts the folder by creating a zip archive and writing it to the destination file, while also updating the progress
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.GenerateIV();

                    byte[] iv = aes.IV;
                    // Opens a file stream to write the encrypted zip archive to the destination file
                    using FileStream fs2 = new FileStream(destination, FileMode.Create, FileAccess.Write);
                    {

                        fs2.Write(salt, 0, salt.Length); // writes salt
                        fs2.Write(iv, 0, iv.Length); // writes IV

                        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                        byte[] fileNameLengthBytes = BitConverter.GetBytes(fileNameBytes.Length);


                        fs2.Write(fileNameLengthBytes, 0, fileNameLengthBytes.Length); // writes the length of the file name
                        using (CryptoStream cs = new CryptoStream(fs2, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(fileNameBytes, 0, fileNameBytes.Length); // writes the file name
                            // Creates a zip archive in the crypto stream
                            using (var archive = new ZipArchive(cs, ZipArchiveMode.Create, true))
                            {
                                var files = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);
                                int processed = 0;
                                int totalFiles = files.Count();

                                foreach (var file in files)
                                {
                                    string entryName = Path.GetRelativePath(folder, file);
                                    var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);

                                    using var entryStream = entry.Open();
                                    using var fileStream = File.OpenRead(file);
                                    byte[] buffer = new byte[200 * 1024 * 1024]; // Buffer for reading the file in chunks (200 MB)
                                    int bytesRead;
                                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        entryStream.Write(buffer, 0, bytesRead); // writes file data
                                    }

                                    processed++;
                                    double progress = (double)processed / totalFiles;
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        update_arrow(progress); // updates the progress indicator in the UI (arrow) based on the encryption progress of the folder
                                    });
                                }
                            }

                            cs.FlushFinalBlock();
                        }

                    };
                }

                // Get encrypted file details
                String name = Path.GetFileName(destination);
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
