using System.Text.RegularExpressions; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.IO;


namespace EncodeX
{
    public partial class MainWindow
    {
        // Encrypt button click event handler
        public async void Button_Click(object sender, RoutedEventArgs e)
        {

            string password = password_field.Text; // Get the password from the password field
            string plainText = input_field.Text; // Get the plain text from the input field
            string file = input_field1.Text; // Get the file path from the input field for file encryption

           
            if (plainText == "" && choice == "text")
            {
                encrypted_field.Text = "";
                return;
            }

            // Default password for file and folder encryption if the password is disabled
            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Hidden;
                password = "password@1010^";

            }
            // Validate the password 
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

            // Perform encryption based on the selected choice (text, file, or folder)
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

                // Animate the clipping arrow to create a progress effect
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
                    encrypted_field.Text = encrypt(password, plainText); // Call the encryption method and display the encrypted text

                };
                clip.BeginAnimation(RectangleGeometry.RectProperty, anim);

            }
            else if (choice == "file")
            {
                string filePath = "";

                // Open a SaveFileDialog to allow the user to choose where to save the encrypted file
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
                    encrypted_field.Text = await Task.Run(() => encrypt_file(password, file, filePath));
                }
                catch (Exception ex)
                {
                    errorLabel.Content = "Encryption failed ";
                    errorLabel.Visibility = Visibility.Visible;

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

                }
                progress1.Visibility = Visibility.Hidden;
            }
            else if (choice == "folder")
            {
                string filePath = "";

                // Open a SaveFileDialog to allow the user to choose where to save the encrypted folder

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
            else // Learn / simulation 
            {
                if (plainText == "")
                {
                    return;
                }

                ScaleTransform scale = new ScaleTransform(1.0, 1.0);
                RotateTransform rotate = new RotateTransform(180);

                TransformGroup group = new TransformGroup();
                group.Children.Add(scale);
                group.Children.Add(rotate);

                arrow.RenderTransform = group;


                DoubleAnimation scaleAnim = new DoubleAnimation
                {
                    From = 1.0,
                    To = 30.0,
                    Duration = TimeSpan.FromMilliseconds(800),
                    FillBehavior = FillBehavior.HoldEnd
                };
                DoubleAnimation scaleAnim2 = new DoubleAnimation
                {
                    From = 1.0,
                    To = 30.0,
                    Duration = TimeSpan.FromMilliseconds(800),
                    FillBehavior = FillBehavior.HoldEnd
                };


                scaleAnim.Completed += async (s, e) =>
                {
                    Entry.Visibility = Visibility.Visible;
                    
                    intro.BeginAnimation(OpacityProperty, oopac); // Start encryption simulation
                    intro.Visibility = Visibility.Visible;
                    try { await Task.Delay(22000, _skip.Token); }
                    catch (TaskCanceledException) { }
                    await action0();

                };

                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim2);


               
            }
        }

        // Decrypt button click event handler
        private async void decrypt_txt(object sender, RoutedEventArgs e)
        {


            string password = password_field.Text;
            string plainText = encrypted_field.Text;
            string file = input_field1.Text;
            if (plainText == "" && file == "")
            {
                return;
            }
            // Default password if the password is disabled
            if (password_field.IsReadOnly == true)
            {
                errorLabel.Visibility = Visibility.Hidden;
                password = "password@1010^";

            }
            // Validate the password
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

            // Perform decryption based on the selected choice (text, file, or folder)
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


        // CancellationTokenSource to allow skipping the ongoing step in the encryption simulation
        public async void Skipping_btn(object sender, RoutedEventArgs e)
        {
            _skip.Cancel();
            _skip = new();
        }

        // Event handler for the top Decrypt button click, which manages the UI transitions and state changes for decryption mode
        public void decrypt_clicked(object sender, RoutedEventArgs e)
        {
            if (button_Decrypt.Tag as String == "Clicked")
            {
                return;
            }
            input_field1.Text = "";
            if (choice != "text" && choice != "learn")
            {
                if (!(Border_decrypt.RenderTransform is TranslateTransform))
                {
                    Border_decrypt.RenderTransform = new TranslateTransform();
                };

                if (!(File_input.RenderTransform is TranslateTransform))
                {
                    File_input.RenderTransform = new TranslateTransform();
                };


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
            
            mode = "decrypt"; // Set the mode to "decrypt"
            errorLabel.Visibility = Visibility.Hidden;

            Random random = new Random();
            int[] options = [0, 360]; 
            int choice1 = options[random.Next(options.Length)]; // Randomly select a rotation angle for the arrow (0 or 360 degrees)
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
            if (choice != "learn")
            {
                opacity_anim(Save, 1.0, 0.0, Save);
                opacity_anim(Save2, 0.0, 1.0);
                opacity_anim(Copy, 1.0, 0.0, Copy);
                opacity_anim(Copy2, 0.0, 1.0);
                opacity_anim(paste, 1.0, 0.0, paste);
                opacity_anim(paste2, 0.0, 1.0);

                Copy2.Visibility = Visibility.Visible;
                Save2.Visibility = Visibility.Visible;
                paste2.Visibility = Visibility.Visible;
            }

            // Animate the color changes for various UI elements to reflect the switch to decryption mode
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

            // Switch the visibility of encrypt and decrypt buttons with an animation
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

            // Rotation animation for the arrow
            DoubleAnimation rotate = new DoubleAnimation
            {
                From = 180,
                To = choice1,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate);

            button_Decrypt.Tag = "Clicked";
            button_Encrypt.Tag = "Not Clicked";

            if (choice != "text")
            {
                encrypted_field.IsReadOnly = true;
            };
            Select_file.Tag = "Blue";
        }

        // Event handler for the top Encrypt button click, which manages the UI transitions and state changes for encryption mode

        public void encrypt_clicked(object sender, RoutedEventArgs e)
        {
            if (button_Encrypt.Tag as String == "Clicked")
            {
                return;
            }
            input_field1.Text = "";
            mode = "encrypt";// Set the mode to "encrypt"
            if (choice != "text" && choice != "learn")
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
            int choice1 = options[random.Next(options.Length)]; // Randomly select a rotation angle for the arrow (180 or 540 degrees)
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
            if (choice != "learn")
            {
                opacity_anim(Copy2, 1.0, 0.0, Copy2);
                opacity_anim(Copy, 0.0, 1.0);
                opacity_anim(Save2, 1.0, 0.0, Save2);
                opacity_anim(Save, 0.0, 1.0);
                opacity_anim(paste2, 1.0, 0.0, paste2);
                opacity_anim(paste, 0.0, 1.0);
                Copy.Visibility = Visibility.Visible;
                Save.Visibility = Visibility.Visible;
                paste.Visibility = Visibility.Visible;
            }

            // Animate the color changes for various UI elements to reflect the switch to encryption mode
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

            // Switch the visibility of encrypt and decrypt buttons with an animation
            if (decrypt_btn.Opacity == 1.0)
            {
                Anim(1.0, 0.0, decrypt_btn, encrypt_btn);
                Anim(0.0, 1.0, encrypt_btn, encrypt_btn);

            }

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
            arrow.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotate); // Rotates the arrow
            button_Encrypt.Tag = "Clicked";
            button_Decrypt.Tag = "Not Clicked";



        }

        // Event handler for the "Files" button click, which manages the UI transitions and state changes for file encryption/decryption mode
        private void button_files_Click(object sender, RoutedEventArgs e)
        {
            if (choice != "file" && choice != "folder")
            {
                errorLabel.Visibility = Visibility.Hidden;
                if (mode == "encrypt")
                {
                    opacity_anim(Copy, 0.0, 1.0);
                    opacity_anim(paste, 0.0, 1.0);
                    opacity_anim(Save, 0.0, 1.0);
                }
                else
                {
                    opacity_anim(Copy2, 0.0, 1.0);
                    opacity_anim(paste2, 0.0, 1.0);
                    opacity_anim(Save2, 0.0, 1.0);
                    Copy2.Visibility = Visibility.Visible;
                    paste2.Visibility = Visibility.Visible;
                    Save2.Visibility = Visibility.Visible;
                }
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
                    };


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
                    opacity_anim(Border_decrypt, 0.0, 1.0);
                    opacity_anim(Select_file, 0.0, 1.0);
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
                Border border_learn = (Border)button_learn.Template.FindName("border_learn", button_learn);
                border_learn.BorderThickness = new Thickness(1);
                border_files.BorderThickness = new Thickness(3);
                border.BorderThickness = new Thickness(1);
                encrypted_field.IsReadOnly = true;

                if (mode == "encrypt")
                {
                    Select_folder.Tag = "Green";
                    Select_file.Tag = "Green";
                }
            }

        }
        // Event handler for the "Learn" button click, which manages the UI transitions and state changes for the learning/simulation section
        public void Lamp_clicked(object sender, EventArgs e)
        {
            if (choice != "learn")
            {
                errorLabel.Visibility = Visibility.Hidden;
                encrypted_field.Text = "";
                if (choice != "text")
                {

                    if (!(Border_decrypt.RenderTransform is TranslateTransform))
                    {
                        Border_decrypt.RenderTransform = new TranslateTransform();
                    };

                    if (!(File_input.RenderTransform is TranslateTransform))
                    {
                        File_input.RenderTransform = new TranslateTransform();
                    };

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
                choice = "learn";
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
                Border learn_one = (Border)button_learn.Template.FindName("border_learn", button_learn);
                border_files.BorderThickness = new Thickness(1);
                border.BorderThickness = new Thickness(1);
                learn_one.BorderThickness = new Thickness(3);
                if (mode == "encrypt")
                {
                    opacity_anim(Copy, 1.0, 0.0);
                    opacity_anim(paste, 1.0, 0.0);
                    opacity_anim(Save, 1.0, 0.0);
                }
                else
                {
                    opacity_anim(Copy2, 1.0, 0.0);

                    opacity_anim(paste2, 1.0, 0.0);

                    opacity_anim(Save2, 1.0, 0.0);
                }
            }

        }
        // Manages the UI transitions and state changes for text encryption/decryption mode
        private void button_Text_Click(object sender, RoutedEventArgs e)
        {
            if (choice != "text")
            {
                errorLabel.Visibility = Visibility.Hidden;
                if (mode == "encrypt")
                {
                    opacity_anim(Copy, 0.0, 1.0);
                    opacity_anim(paste, 0.0, 1.0);
                    opacity_anim(Save, 0.0, 1.0);
                }
                else
                {
                    opacity_anim(Copy2, 0.0, 1.0);

                    opacity_anim(paste2, 0.0, 1.0);

                    opacity_anim(Save2, 0.0, 1.0);
                }
                encrypted_field.Text = "";
                if (choice != "text")
                {

                    if (!(Border_decrypt.RenderTransform is TranslateTransform))
                    {
                        Border_decrypt.RenderTransform = new TranslateTransform();
                    };


                    if (!(File_input.RenderTransform is TranslateTransform))
                    {
                        File_input.RenderTransform = new TranslateTransform();
                    };


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
                Border border_learn = (Border)button_learn.Template.FindName("border_learn", button_learn);
                border_learn.BorderThickness = new Thickness(1);
                border_files.BorderThickness = new Thickness(1);
                border.BorderThickness = new Thickness(3);

                if (mode == "decrypt")
                {

                    encrypted_field.IsReadOnly = false;
                }
            ;
            }


        }

        // Pastes text from the clipboard into the encryption input field
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
        // Pastes text from clipboard into the decryption input field
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
        // Event handler for the "Save" button click, which Saves the encrypted text 
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
                    catch (Exception)
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
                    catch (Exception)
                    {
                        errorLabel.Content = "Error saving file ";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }

        }
        // Event handler for the "Save" button click, which Saves the decrypted text 
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
                    catch (Exception)
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
                    catch (Exception)
                    {
                        errorLabel.Content = "Error saving file";
                        errorLabel.Visibility = Visibility.Visible;
                    }
                }
            }

        }

        // Event handler for the "Copy" button click, which copies the encrypted text to the clipboard and shows a tooltip confirmation
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
        // Event handler for the "Copy" button click, which copies the decrypted text to the clipboard and shows a tooltip confirmation

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (choice == "text")
            {
                Clipboard.SetText(input_field.Text);
            }
            else
            {
                Clipboard.SetText(encrypted_field.Text);
            }
            ;

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

        // Starts the transition from the lock screen to the main application interface 
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Instructions.Visibility = Visibility.Collapsed;
            btn_lock.IsEnabled = false;
            DoubleAnimation opac = new DoubleAnimation
            {
                From = 1.0,
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
            btn_lock.Margin = new Thickness(Lock.Margin.Left, Lock.Margin.Top + 800, Lock.Margin.Right, Lock.Margin.Bottom - 800);

        }

        // Toogles password state between enable and disable
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


    }
}
