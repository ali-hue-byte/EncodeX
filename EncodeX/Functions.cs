using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;         
using System.Windows.Media.Animation; 
using System.Windows.Media;


namespace EncodeX
{
    public partial class MainWindow
    {
        // AES operations

        // Multiplies a byte by 2 in the GF(2^8) field 
        static byte Mul2(byte x)
        {
            return (byte)((x << 1) ^ ((x & 0x80) != 0 ? 0x1B : 0x00));
        }

        // Multiplies a byte by 3 in the GF(2^8) field, which is equivalent to multiplying by 2 and then adding the original byte
        static byte Mul3(byte x)
        {
            return (byte)(Mul2(x) ^ x);
        }
        // Rotates a 4-byte word, and returns a string representation of the rotated word (used for display purposes in the key expansion process)
        public string RotWord(byte[] w)
        {
            byte[] roted = new byte[] { w[1], w[2], w[3], w[0] };
            return "[ " + string.Join(", ", roted) + " ]";
        }
        // Rotates a 4-byte word, and returns the rotated word as a byte array (used in the key expansion process)
        public byte[] RotWord_2(byte[] w)
        {
            byte[] roted = new byte[] { w[1], w[2], w[3], w[0] };
            return roted;
        }

        // Applies the AES S-box substitution to each byte of a 4-byte word, and returns the substituted word as a byte array (used in the key expansion process)
        public byte[] SubWord(byte[] w)
        {

            return new byte[]
             {
        SBox[w[0] & 0xFF],
        SBox[w[1]& 0xFF],
        SBox[w[2]& 0xFF],
        SBox[w[3]& 0xFF]
                  };
        }

        // Padding operations

        // Pads the input byte array using PKCS7 padding scheme, which adds bytes with values equal to the number of padding bytes added (used for AES encryption)
        public byte[] pad1(byte[] c)
        {
            byte[] result;
            if (c.Length == 16)
            {
                result = new byte[32];
                byte[] arr = new byte[16];

                Array.Copy(c, 0, arr, 0, c.Length);
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (byte)(arr[i]);
                }
                for (int i = 16; i < 32; i++)
                {
                    result[i] = (byte)(16);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                for (int i = c.Length; i < 16; i++)
                {
                    result[i] = (byte)(16 - c.Length);
                }
            }
            return result;
        }

        // Pads the input byte using Zeros padding scheme, which adds bytes with value 0 until the block size is reached (used for AES encryption)
        public byte[] pad3(byte[] c)
        {
            byte[] result;
            if (c.Length == 16)
            {
                result = new byte[32];
                byte[] arr = new byte[16];

                Array.Copy(c, 0, arr, 0, c.Length);
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (byte)(arr[i]);
                }
                for (int i = 16; i < 32; i++)
                {
                    result[i] = (byte)(0);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                for (int i = c.Length; i < 16; i++)
                {
                    result[i] = (byte)(0);
                }
            }
            return result;
        }

        // Pads the input byte array using ISO 7816-4 padding scheme, which adds a byte with value 0x80 followed by bytes with value 0 until the block size is reached (used for AES encryption)
        public byte[] pad2(byte[] c)
        {
            byte[] result;
            if (c.Length == 16)
            {
                result = new byte[32];
                byte[] arr = new byte[16];

                Array.Copy(c, 0, arr, 0, c.Length);
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (byte)(arr[i]);
                }
                result[16] = 0x80;
                for (int i = 17; i < 32; i++)
                {
                    result[i] = (byte)(0);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                result[c.Length] = 0x80;
                for (int i = c.Length + 1; i < 16; i++)
                {
                    result[i] = (byte)(0);
                }
            }
            return result;
        }

        // Pads the input byte array using Space Padding, which adds bytes with value 0x20 (space character) until the block size is reached (used for AES encryption)
        public byte[] pad4(byte[] c)
        {
            byte[] result;
            if (c.Length == 16)
            {
                result = new byte[32];
                byte[] arr = new byte[16];

                Array.Copy(c, 0, arr, 0, c.Length);
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (byte)(arr[i]);
                }
                for (int i = 16; i < 32; i++)
                {
                    result[i] = (byte)(32); // ASCII value for space character
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                for (int i = c.Length; i < 16; i++)
                {
                    result[i] = (byte)(32); // ASCII value for space character
                }
            }
            return result;
        }

        // Pads the input byte array using Random Padding, which adds bytes with random values until the block size is reached (used for AES encryption)
        public byte[] pad5(byte[] c)
        {
            byte[] result;
            Random n = new Random();
            if (c.Length == 16)
            {
                result = new byte[32];
                byte[] arr = new byte[16];

                Array.Copy(c, 0, arr, 0, c.Length);
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (byte)(arr[i]);
                }
                for (int i = 16; i < 32; i++)
                {
                    
                    int next = n.Next(0, 256);
                    result[i] = (byte)(next);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                for (int i = c.Length; i < 16; i++)
                {
                    int next = n.Next(0, 256);
                    result[i] = (byte)(next);
                }
            }
            return result;
        }

        // Creates a shake animation on the HMAC box to indicate computation is happening
        public async Task vibrate()
        {
            Thickness start = new Thickness(667, 334, 0, 0);
            await Task.Delay(4000);
            ThicknessAnimation anim = new ThicknessAnimation
            {
                From = HMAC.Margin,
                To = new Thickness(HMAC.Margin.Left + 20, HMAC.Margin.Top, HMAC.Margin.Right - 20, HMAC.Margin.Bottom),
                Duration = TimeSpan.FromMilliseconds(50),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(20)
            };
            anim.Completed += (s, e) =>
            {
                ThicknessAnimation anim2 = new ThicknessAnimation
                {
                    From = HMAC.Margin,
                    To = new Thickness(HMAC.Margin.Left - 20, HMAC.Margin.Top, HMAC.Margin.Right + 20, HMAC.Margin.Bottom),
                    Duration = TimeSpan.FromMilliseconds(50)
                };

            };
            HMAC.BeginAnimation(MarginProperty, anim);

        }

        // Reads the encrypted file/folder name
        public String get_name(String password, String filepath)
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

        // Opens a file dialog for the user to select a file, and updates the input field with the selected file path
        private void Select_(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                try
                {
                    string filePath = openFileDialog.FileName;

                    input_field1.Text = filePath;
                    choice = "file"; // Update choice variable to indicate a file has been selected
                }
                catch (Exception)
                {
                    errorLabel.Content = "Error reading file";
                    errorLabel.Visibility = Visibility.Visible;
                }
            }

        }

        // Opens a folder dialog for the user to select a folder, and updates the input field with the selected folder path
        private void Select_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFolderDialog openFileDialog = new Microsoft.Win32.OpenFolderDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                try
                {
                    string filePath = openFileDialog.FolderName;

                    input_field1.Text = filePath;
                    choice = "folder"; // Update choice variable to indicate a folder has been selected
                }
                catch (Exception)
                {
                    errorLabel.Content = "Error reading folder ";
                    errorLabel.Visibility = Visibility.Visible;
                }
            }

        }

        // Animates the width of a progress bar (parada) based on the given progress value, creating a visual representation of encryption/decryption progress
        public void update_arrow(double progress)
        {
            Rect rect;
            var parada = progress1;
            if (mode == "encrypt")
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
                To = new Rect(totalWidth * (1 - progress), 0, totalWidth, parada.Height),
                Duration = TimeSpan.FromMilliseconds(500),
                FillBehavior = FillBehavior.HoldEnd,
            };


            clip.BeginAnimation(RectangleGeometry.RectProperty, anim);
        }

        // Generates a random string of 15 characters
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
            }
            ;
            return output;

        }

        // Lock screen mini-game: reveals the hidden letters on hover
        // and resets all buttons to their encrypted state when one is clicked
        public void get_key(object sender, RoutedEventArgs e)
        {
            Dictionary<Button, List<String>> text_dict = new Dictionary<Button, List<String>>
            {
                { D,  new List<string> { "X", "D" } },
                { a3,  new List<string> { "q", "a" } },
                { t3,  new List<string> { "9", "t" } },
                { a2, new List<string> { "A", "a" } },
                { m,  new List<string> { "k", "m" } },
                { a, new List<string> { "P", "a" } },
                { t2, new List<string> { "7", "t" } },
                { t, new List<string> { "L", "t" } },
                { e2,  new List<string> { "r", "e" } },
                { r2,  new List<string> { "T", "r" } },
                { s,  new List<string> { "z", "s" } },
                { S,  new List<string> { "Z", "S" } },
                { e10, new List<string> { "R", "e" } },
                { c,  new List<string> { "4", "c" } },
                { u,  new List<string> { "u", "u" } },
                { r, new List<string> { "@", "r" } },
                { i,  new List<string> { "T", "i" } },
                { t8, new List<string> { "1", "t" } },
                { y,  new List<string> { "Q", "y" } },
                { f,  new List<string> { "Q", "f" } },
                { i3, new List<string> { "m", "i" } },
                { r5, new List<string> { "8", "r" } },
                { s3, new List<string> { "s", "s" } },
                { t7, new List<string> { "N", "t" } },
                { E,  new List<string> { "9", "E" } },
                { n2,  new List<string> { "F", "n" } },
                { c4, new List<string> { "q", "c" } },
                { r3, new List<string> { "L", "r" } },
                { y2, new List<string> { "2", "y" } },
                { p,  new List<string> { "o", "p" } },
                { t4, new List<string> { "x", "t" } },
                { a5, new List<string> { "a", "a" } },
                { n, new List<string> { "z", "n" } },
                { d, new List<string> { "7", "d" } },
                { d2, new List<string> { "R", "d" } },
                { e3, new List<string> { "n", "e" } },
                { c2, new List<string> { "4", "c" } },
                { r4, new List<string> { "r", "r" } },
                { y3, new List<string> { "1", "y" } },
                { p2, new List<string> { "p", "p" } },
                { t5, new List<string> { "z", "t" } },
                { w, new List<string> { "u", "w" } },
                { i2, new List<string> { "T", "i" } },
                { t6, new List<string> { "8", "t" } },
                { h, new List<string> { "K", "h" } },
                { e4, new List<string> { "E", "e" } },
                { a4, new List<string> { "2", "a" } },
                { s2, new List<string> { "s", "s" } },
                { e6, new List<string> { "9", "e" } },
            };

            foreach (KeyValuePair<Button, List<String>> b in text_dict)
            {

                b.Key.MouseEnter += (sender, e) => hover_txt(b.Key, b.Value[1], 25);
                b.Key.MouseLeave += (sender, e) => hover_txt(b.Key, b.Value[0], 20);
                b.Key.Click += (sender, e) => reset(text_dict);

            }
            // Apply custom cursor to lock screen elements
            string cursorPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "cursor.cur");
            Lock.Cursor = new Cursor(cursorPath);
            btn_lock.Cursor = new Cursor(cursorPath);
            Encrypted.Cursor = new Cursor(cursorPath);
            foreach (KeyValuePair<Button, List<String>> k in text_dict)
            {
                k.Key.Cursor = new Cursor(cursorPath);
            }
            Instructions.Content = "Click to see the magic!";
        }
    }
}
