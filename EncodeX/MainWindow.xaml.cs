using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EncodeX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        
        private List<System.Timers.Timer> activeTimers = new List<System.Timers.Timer>();

        private System.Timers.Timer timing;
        private System.Timers.Timer timing3;
        private System.Timers.Timer timing2;
        private System.Timers.Timer timing4;
        private System.Timers.Timer timing5;
        private System.Timers.Timer timing6;
        private System.Timers.Timer timing7;
        private System.Timers.Timer timing8;
        private System.Timers.Timer timing9;
        private System.Timers.Timer final_timer;

        System.Timers.Timer timing3_1;
        bool gotten_key = false;
        string mode = "encrypt";
        string choice = "text";
        Brush color = Brushes.Green;
        int skipping = 0;
        byte[] pu_key = new byte[32];
        byte[] pu_salt = new byte[16];
        List<byte> words_4_7 = new List<byte>();
        string con;
        string con1;
        string con2;
        string con3;
        List<byte[]> lst = new List<byte[]> { };
        List<System.Timers.Timer> timers = new List<System.Timers.Timer> { };
        List<Action> functions = new List<Action> { };
        public MainWindow()
        {
            functions = new List<Action> {action0, action1, action2 ,actions3,action4,action5,action6,action7};

            InitializeComponent();

            btn_lock.MouseEnter += (s, e) =>
            {
                Lock_Hovered(s, e);
            };
            btn_lock.MouseLeave += (s, e) =>
            {
                Lock_unHovered(s, e);
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

            foreach (KeyValuePair<Label, List<int>> label in dict)
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

        public void move(FrameworkElement elem, String x, String y, int duration)
        {
            string[] start = x.Split(",");
            string[] end = y.Split(",");
            ThicknessAnimation move = new ThicknessAnimation
            {
                From = new Thickness(double.Parse(start[0]), double.Parse(start[1]), double.Parse(start[2]), double.Parse(start[3])),
                To = new Thickness(double.Parse(end[0]), double.Parse(end[1]), double.Parse(end[2]), double.Parse(end[3])),
                Duration = TimeSpan.FromMilliseconds(duration)
            };
            elem.BeginAnimation(FrameworkElement.MarginProperty, move);
        }
        public void change_color(Label elem, string x, int duration)
        {
            SolidColorBrush col = elem.Foreground as SolidColorBrush;
            if (col == null || col.IsFrozen)
            {
                col = new SolidColorBrush(((SolidColorBrush)elem.Foreground).Color);
                elem.Foreground = col;
            }
            ColorAnimation chan = new ColorAnimation
            {
                To = (Color)ColorConverter.ConvertFromString(x),
                Duration = TimeSpan.FromMilliseconds(duration)
            };
            col.BeginAnimation(SolidColorBrush.ColorProperty, chan);
        }
        public void action0()
        {
            DoubleAnimation oopac = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1000),
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1000),
            };
            intro.BeginAnimation(OpacityProperty, oopac2);
            enc_steps.BeginAnimation(OpacityProperty, oopac);
            
            encr_steps_Copy1.BeginAnimation(OpacityProperty, oopac);
            encr_steps_Copy2.BeginAnimation(OpacityProperty, oopac);
            encr_steps_Copy3.BeginAnimation(OpacityProperty, oopac);
            encr_steps_Copy4.BeginAnimation(OpacityProperty, oopac);
            enc_steps.Visibility = Visibility.Visible;
            encr_steps.Visibility = Visibility.Visible;
            
            encr_steps_Copy1.Visibility = Visibility.Visible;
            encr_steps_Copy2.Visibility = Visibility.Visible;
            encr_steps_Copy3.Visibility = Visibility.Visible;
            encr_steps_Copy4.Visibility = Visibility.Visible;
        }
        public void action1()
        {
            intro.Visibility = Visibility.Hidden;
            Label last = str_1_b;
            List<Label> labels_txt = new List<Label> { str_1, str_2, str_3, str_4, str_5, str_6, str_7, str_8, str_9, str_10, str_11, str_12, str_13, str_14, str_15, str_16 };
            List<Label> labels_b = new List<Label> { str_1_b, str_2_b, str_3_b, str_4_b, str_5_b, str_6_b, str_7_b, str_8_b, str_9_b, str_10_b, str_11_b, str_12_b, str_13_b, str_14_b, str_15_b, str_16_b };

            String txt = input_field.Text;
            List<Rune> runes = txt.EnumerateRunes().ToList();
            DoubleAnimation oopac = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1000),
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1000),
            };
            enc_steps.BeginAnimation(OpacityProperty, oopac2);
            move(encr_steps, "0,161,0,0", "0,54,0,0", 1000);
            change_color(encr_steps, "#22C55E", 800);
            move(encr_steps_Copy4, "0,215,0,0", "1050,228,0,0", 1000);
            
            move(encr_steps_Copy2, "0,323,0,0", "1084,323,0,0", 1000);
            move(encr_steps_Copy1, "0,377,0,0", "-2022,377,0,0", 1000);
            move(encr_steps_Copy3, "0,269,0,0", "-1923,269,0,0", 1000);
            title.BeginAnimation(OpacityProperty, oopac);
            info.BeginAnimation(OpacityProperty, oopac);
            title.Visibility = Visibility.Visible;
            info.Visibility = Visibility.Visible;

            int it = runes.Count;
            if (it > 16)
            {
                it = 16;
            }
            for (int i = 0; i < it; i++)
            {
                Rune c = runes[i];
                labels_txt[i].Content = c;
                labels_txt[i].BeginAnimation(OpacityProperty, oopac);
                labels_txt[i].Visibility = Visibility.Visible;
                last = labels_b[i];
            }
            byte[] texts_bytes = Encoding.UTF8.GetBytes(txt);
            List<Label> lbls = new List<Label> { str_9_b, str_10_b, str_11_b, str_12_b, str_13_b, str_14_b, str_15_b, str_16_b };
            for (int i = 0; i < it; i++)
            {
                int index = i;
                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    System.Timers.Timer timer = new System.Timers.Timer(2000 * (index + 1));
                    timer.AutoReset = false;
                    activeTimers.Add(timer);
                    timer.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (lbls.Contains(labels_b[index]))
                            {
                                Arr.Visibility = Visibility.Collapsed;

                            }
                            else
                            {
                                Arr.Visibility = Visibility.Visible;
                            }


                            DoubleAnimation po = new DoubleAnimation
                            {
                                To = Canvas.GetLeft(Arr) + 35,
                                Duration = TimeSpan.FromMilliseconds(1200)
                            };

                            string to_show = "";
                            Rune c = runes[index];
                            byte[] b = Encoding.UTF8.GetBytes(c.ToString());
                            foreach (byte c2 in b)
                            {
                                to_show += c2.ToString();
                                to_show += "\n";
                            }
                            labels_b[index].Content = to_show;
                            labels_b[index].BeginAnimation(OpacityProperty, oopac);
                            labels_b[index].Visibility = Visibility.Visible;

                            if (labels_b[index] != str_8_b && labels_b[index] != last)
                            {
                                Arr.BeginAnimation(Canvas.LeftProperty, po);
                            }
                            else
                            {
                                Arr.BeginAnimation(OpacityProperty, oopac2);
                            }

                        });
                    };
                    timer.Start();

                }));
            }
        }
        public void action2()
        {

            foreach (var timer in activeTimers)
            {
                timer.Stop();
                timer.Dispose();
            }
            activeTimers.Clear();
            Arr.Visibility = Visibility.Hidden;
            List<Label> labels_txt = new List<Label> { str_1, str_2, str_3, str_4, str_5, str_6, str_7, str_8, str_9, str_10, str_11, str_12, str_13, str_14, str_15, str_16 };
            List<Label> labels_b = new List<Label> { str_1_b, str_2_b, str_3_b, str_4_b, str_5_b, str_6_b, str_7_b, str_8_b, str_9_b, str_10_b, str_11_b, str_12_b, str_13_b, str_14_b, str_15_b, str_16_b };
            foreach (Label label in labels_txt)
            {
                label.Visibility = Visibility.Hidden;

            }
            foreach (Label label in labels_b)
            {
                label.Visibility = Visibility.Hidden;

            }

            opacity_anim(info, 1.0, 0.0);
            opacity_anim(title, 1.0, 0.0);
            title.Content = "2. Padding";
            info.Content = "AES encryption works on fixed-size 16-byte blocks, meaning  \n" +
                "that the algorithm can only process data in chunks of exactly 16 \n" +
                "bytes.\n" +
                "After converting text into bytes, the byte array representing \n" +
                "your text may not always be a multiple of 16 bytes, especially \n" +
                "if the text length is short or if it contains characters that \n" +
                "use multiple bytes in UTF-8. \n" +
                "To ensure that each block is exactly 16 bytes, we add  \n" +
                "padding to the last block. \n" +
                "Padding is a set of extra bytes appended to the byte array \n" +
                "to fill out the block to 16 bytes. Without padding, AES \n" +
                "would not be able to encrypt the last block \n" +
                "properly, and the encryption would fail or produce incorrect \n" +
                "results.\n" +
                "\n" +
                "Note: If the last block is already 16 bytes, a full extra block of \n" +
                "padding is added.";
            opacity_anim(info, 0.0, 1.0);
            opacity_anim(title, 0.0, 1.0);
        }

        public void actions3()
        {
            foreach (var timer in activeTimers)
            {
                timer.Stop();
                timer.Dispose();
            }
            String txt = input_field.Text;
            byte[] c = Encoding.UTF8.GetBytes(txt);
            opacity_anim(info, 1.0, 0.0);

            info.Content = "There are several common padding schemes : (dec= decimal) \n" +

    "1. **PKCS7 / CMS Padding**:\n" +
    "   - Each added byte is the number of padding bytes. \n" +
    "   - If 11 bytes are needed, each byte = 0x0B hex (11 dec).\n" +
    "   - Pros: Widely used, unambiguous.\n" +

    "2. **Bit / ISO 7816-4 Padding**:\n" +
    "   - First byte = 0x80 hex (80 dec), remaining bytes = 0x00.\n" +
    "   - Pros: Simple, often used in smart cards.\n" +

    "3. **Zero Padding**:\n" +
    "   - Fills remaining bytes with 0x00 hex (0 dec).\n" +
    "   - Note: Can be ambiguous if plaintext ends with zeros.\n" +

    "4. **Null Padding**:\n" +
    "   - Same as Zero Padding, used for text or string data.\n" +

    "5. **Space Padding**:\n" +
    "   - Fills remaining bytes with ASCII spaces = 0x20 (32 dec).\n" +
    "   - Only suitable if plaintext doesn’t end with spaces.\n"

    ;
            String last16;
            if (txt.Length >= 16)
            {
                int start = ((txt.Length / 16) * 16);
                last16 = txt.Substring(start);
                if (last16 == "")
                {
                    last16 = txt.Substring(txt.Length - 16);
                }
            }
            else
            {
                last16 = txt;
            }


            opacity_anim(info, 0.0, 1.0);

            String str_to_show = "";
            byte[] bytes_last16 = Encoding.UTF8.GetBytes(last16);
            byte[] ss = pad1(bytes_last16);
            if (ss.Length == 16)
            {
                pad_info1_Copy.Content = "Last Block : " + last16;
                pad_info1.Content = "Padding needed : " + (16 - bytes_last16.Length).ToString();
                pad_info2.Content = "Number of Bytes : " + (bytes_last16.Length).ToString();
                str_to_show += "[";
                str_to_show += string.Join(", ", ss);
                str_to_show += "]";
            }
            else
            {
                pad_info1_Copy.Content = "Last Block : " + last16;
                pad_info1.Content = "Padding needed : " + "16";
                pad_info2.Content = "Number of Bytes : " + (bytes_last16.Length).ToString();
                byte[] first = new byte[16];
                byte[] second = new byte[16];
                Array.Copy(ss, 0, first, 0, 16);
                Array.Copy(ss, 16, second, 0, 16);
                str_to_show += "[";
                str_to_show += string.Join(", ", first);
                str_to_show += "]\n";
                str_to_show += "[";
                str_to_show += string.Join(", ", second);
                str_to_show += "]";

            }

            System.Timers.Timer timing = new System.Timers.Timer(2000);
            timing.AutoReset = false;
            timing.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    pad_show.Content = str_to_show;
                    opacity_anim(pad_show, 0.0, 1.0);
                    opacity_anim(pad_info1_Copy, 0.0, 1.0);
                    pad_info1_Copy.Visibility = Visibility.Visible;
                    pad_show.Visibility = Visibility.Visible;
                    opacity_anim(pad_info1, 0.0, 1.0);
                    pad_info1.Visibility = Visibility.Visible;
                    opacity_anim(pad_info2, 0.0, 1.0);
                    pad_info2.Visibility = Visibility.Visible;

                    String str_to_show_2 = "";
                    byte[] ss2 = pad2(bytes_last16);
                    if (ss2.Length == 16)
                    {

                        str_to_show_2 += "[";
                        str_to_show_2 += string.Join(", ", ss2);
                        str_to_show_2 += "]";
                    }
                    else
                    {

                        byte[] first = new byte[16];
                        byte[] second = new byte[16];
                        Array.Copy(ss2, 0, first, 0, 16);
                        Array.Copy(ss2, 16, second, 0, 16);
                        str_to_show_2 += "[";
                        str_to_show_2 += string.Join(", ", first);
                        str_to_show_2 += "]\n";
                        str_to_show_2 += "[";
                        str_to_show_2 += string.Join(", ", second);
                        str_to_show_2 += "]";
                    }

                    System.Timers.Timer timing2 = new System.Timers.Timer(8000);
                    timing2.AutoReset = false;
                    timing2.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            pad_show.Margin = new Thickness(pad_show.Margin.Left, pad_show.Margin.Top + 90, pad_show.Margin.Right, pad_show.Margin.Bottom - 90);
                            pad_show.Content = str_to_show_2;
                            opacity_anim(pad_show, 0.0, 1.0);

                            pad_show.Visibility = Visibility.Visible;

                            System.Windows.Application.Current.Dispatcher.Invoke(() =>
                            {
                                pad_show.Content = str_to_show_2;
                                opacity_anim(pad_show, 0.0, 1.0);

                                pad_show.Visibility = Visibility.Visible;


                                String str_to_show_3 = "";
                                byte[] ss3 = pad3(bytes_last16);
                                if (ss3.Length == 16)
                                {

                                    str_to_show_3 += "[";
                                    str_to_show_3 += string.Join(", ", ss3);
                                    str_to_show_3 += "]";
                                }
                                else
                                {

                                    byte[] first = new byte[16];
                                    byte[] second = new byte[16];
                                    Array.Copy(ss3, 0, first, 0, 16);
                                    Array.Copy(ss3, 16, second, 0, 16);
                                    str_to_show_3 += "[";
                                    str_to_show_3 += string.Join(", ", first);
                                    str_to_show_3 += "]\n";
                                    str_to_show_3 += "[";
                                    str_to_show_3 += string.Join(", ", second);
                                    str_to_show_3 += "]";
                                }

                                System.Timers.Timer timing22 = new System.Timers.Timer(8000);
                                timing22.AutoReset = false;
                                timing22.Elapsed += (s, e) =>
                                {
                                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                    {
                                        pad_show.Margin = new Thickness(pad_show.Margin.Left, pad_show.Margin.Top + 90, pad_show.Margin.Right, pad_show.Margin.Bottom - 90);
                                        pad_show.Content = str_to_show_3;
                                        opacity_anim(pad_show, 0.0, 1.0);

                                        pad_show.Visibility = Visibility.Visible;


                                        String str_to_show_4 = "";
                                        byte[] ss4 = pad4(bytes_last16);
                                        if (ss4.Length == 16)
                                        {

                                            str_to_show_4 += "[";
                                            str_to_show_4 += string.Join(", ", ss4);
                                            str_to_show_4 += "]";
                                        }
                                        else
                                        {

                                            byte[] first = new byte[16];
                                            byte[] second = new byte[16];
                                            Array.Copy(ss4, 0, first, 0, 16);
                                            Array.Copy(ss4, 16, second, 0, 16);
                                            str_to_show_4 += "[";
                                            str_to_show_4 += string.Join(", ", first);
                                            str_to_show_4 += "]\n";
                                            str_to_show_4 += "[";
                                            str_to_show_4 += string.Join(", ", second);
                                            str_to_show_4 += "]";
                                        }
                                        System.Timers.Timer timing222 = new System.Timers.Timer(8000);
                                        timing222.AutoReset = false;
                                        timing222.Elapsed += (s, e) =>
                                        {
                                            System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                pad_show.Margin = new Thickness(pad_show.Margin.Left, pad_show.Margin.Top + 80, pad_show.Margin.Right, pad_show.Margin.Bottom - 80);
                                                pad_show.Content = str_to_show_4;
                                                opacity_anim(pad_show, 0.0, 1.0);

                                                pad_show.Visibility = Visibility.Visible;


                                                String str_to_show_5 = "";
                                                byte[] ss5 = pad5(bytes_last16);
                                                if (ss5.Length == 16)
                                                {

                                                    str_to_show_5 += "[";
                                                    str_to_show_5 += string.Join(", ", ss5);
                                                    str_to_show_5 += "]";
                                                }
                                                else
                                                {

                                                    byte[] first = new byte[16];
                                                    byte[] second = new byte[16];
                                                    Array.Copy(ss5, 0, first, 0, 16);
                                                    Array.Copy(ss5, 16, second, 0, 16);
                                                    str_to_show_5 += "[";
                                                    str_to_show_5 += string.Join(", ", first);
                                                    str_to_show_5 += "]\n";
                                                    str_to_show_5 += "[";
                                                    str_to_show_5 += string.Join(", ", second);
                                                    str_to_show_5 += "]";
                                                }
                                                System.Timers.Timer timing2222 = new System.Timers.Timer(8000);
                                                timing2222.AutoReset = false;
                                                timing2222.Elapsed += (s, e) =>
                                                {
                                                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                    {
                                                        pad_show.Margin = new Thickness(pad_show.Margin.Left, 206, pad_show.Margin.Right, 0);
                                                        pad_show.Content = str_to_show_5;
                                                        opacity_anim(pad_show, 0.0, 1.0);
                                                        opacity_anim(info, 0.0, 1.0);
                                                        info.Content = "6. **Random Padding**:\n- Fills remaining bytes with random values.\n- Often combined with other encryption modes to add \nextra randomness.\n \n \nAfter padding, AES can safely encrypt the full 16-byte blocks, \nand the ciphertext can later be decrypted correctly, \nremoving the padding automatically.";
                                                    });
                                                }; timing2222.Start();
                                                activeTimers.Add(timing2222);
                                            });

                                        }; timing222.Start();
                                        activeTimers.Add(timing222);
                                    });
                                };
                                timing22.Start();
                                activeTimers.Add(timing22);

                            });

                        });
                    };
                    timing2.Start();
                    activeTimers.Add(timing2);

                });
            };
            timing.Start();
            activeTimers.Add(timing);



        }

        public void action4()
        {
            foreach (var timer in activeTimers)
            {
                timer.Stop();
                timer.Dispose();
            }
            activeTimers.Clear();
            string password;
            string mss;
            string opassword;
            if (password_field.Text == "")
            {
                password = "password@1010^";
                opassword = "password@1010^";
                mss = "(Use Your own password !)";
                
            }
            else
            {
                password = password_field.Text;
                opassword = password_field.Text;
                mss = "(Keep your passwords secret !)";
            }

            if (password.Length > 14)
            {
                password = password.Substring(0, 12) + "...";
            }
            
            byte[] bytes_index = BitConverter.GetBytes(1);
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);  
            }
            byte[] msg = salt.Concat(bytes_index).ToArray();
            String U1;
            using (var smh = new HMACSHA256(Encoding.UTF8.GetBytes(opassword)))
            {
                byte[] u1 = smh.ComputeHash(msg);
                U1 = string.Join(", ", u1);
            }
            
            DoubleAnimation oopac = new DoubleAnimation
            {

                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {

                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac_h = new DoubleAnimation
            {
                From= 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1800)
            };
            encr_steps_Copy4.BeginAnimation(OpacityProperty, oopac);
            move(encr_steps_Copy4, "0,161,0,0", "0,54,0,0", 1000);
            move(encr_steps, "0,54,0,0", "0,-54,0,0", 1000);
            change_color(encr_steps_Copy4, "#22C55E", 1100);
            title.BeginAnimation(OpacityProperty, oopac2);
            info.BeginAnimation(OpacityProperty, oopac2);
            pad_show.BeginAnimation(OpacityProperty, oopac2);
            pad_info1.BeginAnimation(OpacityProperty, oopac2);
            pad_info2.BeginAnimation(OpacityProperty, oopac2);
            pad_info1_Copy.BeginAnimation(OpacityProperty, oopac2);
            info.Content =
"Passwords cannot be used directly as AES keys.\n" +
"AES requires a fixed-length, random-looking key.\n" +
"A Key Derivation Function (KDF) transforms your password\n" +
"into a secure key.\n" +
"One common KDF is PBKDF2 (Password-Based Key Derivation \n" +
"Function 2).\n" +

"The password is combined with a random salt and processed\n" +
"through many hash iterations.\n" +
"The salt is public and ensures identical passwords produce\n" +
"different keys.\n" +
"Each iteration depends on the previous one, creating a \n" +
"chain of hashes.\n" +

"PBKDF2 produces the final key in blocks (only if \n" +
"more bytes are required !!!).\n" +
"PBKDF2 can derive a key of any length. You specify how many\nbytes you want.\r\n" +
"Each block has a unique number called the block index.";


            info.BeginAnimation(OpacityProperty, oopac);
            System.Timers.Timer tio = new System.Timers.Timer(3000);
            tio.AutoReset = false;
            tio.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    pad_info1_Copy.Foreground = (Brush)new BrushConverter().ConvertFromString("#22C55E");
                    pad_info1.Foreground = (Brush)new BrushConverter().ConvertFromString("#F59E0B");
                    pad_info2.Foreground = (Brush)new BrushConverter().ConvertFromString("#38BDF8");
                    pad_info2.Content = "   Salt: **Some Random 16 Bytes** \n     (128bits => 2¹²⁸ possibilities!)";
                    pad_info1_Copy.Content = "Password: "+password;
                    pad_info1.Content = mss;
                    pad_info2.BeginAnimation(OpacityProperty, oopac);
                    pad_info1_Copy.BeginAnimation(OpacityProperty, oopac);
                    pad_info1.BeginAnimation(OpacityProperty, oopac);
                    pad_info2.Visibility= Visibility.Visible;
                    pad_info1.Visibility = Visibility.Visible;
                    pad_info1_Copy.Visibility = Visibility.Visible;
                });
            };tio.Start();
            activeTimers.Add(tio);
            System.Timers.Timer gg = new System.Timers.Timer(25000);
            gg.AutoReset = false;
            gg.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    info.BeginAnimation(OpacityProperty, oopac2);
                    info.Content = "Each block is computed like this:\n" +
"U1 = HMAC(password, salt || blockIndex)\r\n" +
"U2 = HMAC(password, U1)\r\n" +
"U3 = HMAC(password, U2)\r\n" +
"...\r\n" +
"Uc = HMAC(password, Uc-1)\n" +
"\n" +
"*HMAC: a secure way to hash data using a secret key.\n" +
"*PBKDF2 combines all the U-values (usually via XOR) \n" +
"to produce each block of the final key.\n" +
"*The block index ensures that each block is unique, even\n" +
"if the password and salt are the same.\n" +
"*AES-256 requires a 32-byte key, so only one PBKDF2 block \nis needed.(AES-192 => 24-bytes // AES-128 => 16-bytes)\nEven with long key provided, AES takes only the number \nof bytes needed"

;
                    info.BeginAnimation(OpacityProperty, oopac_h);
                    
                    HMAC.BeginAnimation(OpacityProperty, oopac_h);
                    HMAC.Visibility = Visibility.Visible;
                    System.Timers.Timer timing_s = new System.Timers.Timer(2000);
                    timing_s.AutoReset = false;
                    timing_s.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            DoubleAnimation o = new DoubleAnimation
                            {
                                From = 0.0,
                                To = 1.0,
                                Duration = TimeSpan.FromMilliseconds(800),
                                AutoReverse = false
                            };
                            o.Completed += (s, e) =>
                            {
                                opacity_anim(indx_anim, 1.0, 0.0);
                                
                            };
                            indx_anim.BeginAnimation(OpacityProperty, o);
                            indx_anim.Visibility = Visibility.Visible;
                            pss_anim.Visibility = Visibility.Visible;
                            salt_anim.Content += " || 1" ;
                            salt_anim.Visibility= Visibility.Visible;
                            move(salt_anim, "737,136,0,0", "690,334,0,0",3000);
                            move(pss_anim, "574,136,0,0", "690,334,0,0", 3000);
                            System.Timers.Timer timing_s2 = new System.Timers.Timer(3300);
                            timing_s2.AutoReset = false;
                            timing_s2.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    pss_anim.Visibility = Visibility.Hidden;
                                    salt_anim.Visibility = Visibility.Hidden;
                                    pss_anim.Margin = new Thickness(574,136,0,0);
                                    
                                    
                                   
                                });
                            }; timing_s2.Start();
                            activeTimers.Add(timing_s2);


                            vibrate();
                            System.Timers.Timer timing_s21 = new System.Timers.Timer(9000);
                            timing_s21.AutoReset = false;
                            timing_s21.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    salt_anim.Foreground = (Brush)new BrushConverter().ConvertFromString("#00CC99");
                                    salt_anim.Content = "U1";
                                    salt_anim.Visibility = Visibility.Visible;
                                    move(salt_anim, "710, 334, 0, 0", "710,284,0,0", 300);
                                    System.Timers.Timer timing_s211 = new System.Timers.Timer(1000);
                                    timing_s211.AutoReset = false;
                                    timing_s211.Elapsed += (s, e) =>
                                    {
                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                        {
                                            
                                            
                                            opacity_anim(Hmac_im_arr, 0.0, 1.0);
                                            Hmac_im_arr.Visibility = Visibility.Visible;
                                            opacity_anim(U1_info, 0.0, 1.0);
                                            U1_info.Visibility = Visibility.Visible;
                                            U1_show.Content = "U1: [ " + U1.Substring(0,40) + "..." + U1.Substring(U1.Length-3)+" ]";
                                            opacity_anim(U1_show, 0.0, 1.0);
                                            U1_show.Visibility = Visibility.Visible;

                                            System.Timers.Timer timing_s2111 = new System.Timers.Timer(8500);
                                            timing_s2111.AutoReset = false;
                                            timing_s2111.Elapsed += (s, e) =>
                                            {
                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                {


                                                    opacity_anim(Hmac_im_arr, 1.0, 0.0);
                                                  
                                                    opacity_anim(U1_info, 1.0, 0.0);
                                                    pss_anim.Visibility = Visibility.Visible;
                                                    move(pss_anim, "574,136,0,0", "690,334,0,0", 1000);
                                                    move(salt_anim, "710, 284, 0, 0", "710,334,0,0", 2000);

                                                    opacity_anim(U1_show, 1.0, 0.0);
                                                    System.Timers.Timer timing_s2 = new System.Timers.Timer(2300);
                                                    timing_s2.AutoReset = false;
                                                    timing_s2.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {
                                                            pss_anim.Visibility = Visibility.Hidden;
                                                            salt_anim.Visibility = Visibility.Hidden;
                                                            pss_anim.Margin = new Thickness(574, 136, 0, 0);
                                                            System.Timers.Timer timing_ez= new System.Timers.Timer(7300);

                                                            timing_ez.AutoReset = false;
                                                            timing_ez.Elapsed += (s, e) =>
                                                            {
                                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                                {
                                                                    salt_anim.Content = "U2";
                                                                    salt_anim.Visibility = Visibility.Visible;
                                                                    move(salt_anim, "710, 334, 0, 0", "710,284,0,0", 300);
                                                                    System.Timers.Timer timing_ez1 = new System.Timers.Timer(3300);
                                                                    timing_ez1.AutoReset = false;
                                                                    timing_ez1.Elapsed += (s, e) =>
                                                                    {
                                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                                        {
                                                                            pss_anim.Margin = new Thickness(574, 136, 0, 0);
                                                                            pss_anim.Visibility = Visibility.Visible;
                                                                            move(pss_anim, "574,136,0,0", "690,334,0,0", 1000);
                                                                            move(salt_anim, "710, 284, 0, 0", "710,334,0,0", 2000);
                                                                            System.Timers.Timer tim = new System.Timers.Timer(1300);
                                                                        
                                                                        tim.AutoReset = false;
                                                                        tim.Elapsed += (s, e) =>
                                                                        {

                                                                            vibrate();
                                                                           
                                                                        };tim.Start();
                                                                          activeTimers.Add(tim);

                                                                        });
                                                                    }; timing_ez1.Start();
                                                                    activeTimers.Add(timing_ez1);
                                                                });
                                                            };timing_ez.Start();
                                                            activeTimers.Add(timing_ez);


                                                                });
                                                    }; timing_s2.Start();
                                                    activeTimers.Add(timing_s2);
                                                    vibrate();


                                                });
                                            }; timing_s2111.Start();
                                            activeTimers.Add(timing_s2111);


                                        });
                                    }; timing_s211.Start();
                                    activeTimers.Add(timing_s211);


                                });
                            }; timing_s21.Start();
                            activeTimers.Add(timing_s21);
                        });
                    };timing_s.Start();
                    activeTimers.Add(timing_s);
                });
            };gg.Start();
            activeTimers.Add(gg);

            System.Timers.Timer timing_ez7 = new System.Timers.Timer(66000);

            timing_ez7.AutoReset = false;
            timing_ez7.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    pss_anim.Visibility = Visibility.Hidden;
                    salt_anim.Content = "U3";
                    salt_anim.Visibility = Visibility.Visible;
                    move(salt_anim, "710, 334, 0, 0", "710,284,0,0", 300);
                    
                });
            };
            timing_ez7.Start();
            activeTimers.Add(timing_ez7);

            System.Timers.Timer timing_ = new System.Timers.Timer(70000);

            timing_.AutoReset = false;
            timing_.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    U1_show.Content = "Block = U1 ⊕ U2 ⊕ U3 ⊕ ... ⊕ Uc";
                    info.Content = "⊕ => XOR (exclusive OR) is a bitwise operation.\r\n\r\n" +
                    "For two bits:\r\n" +
                    "- The result is 1 if the bits are different\r\n" +
                    "- The result is 0 if the bits are the same\r\n\r\n" +
                    "Truth table:\r\n" +
                    "0 ⊕ 0 = 0" +
                    "\r\n" +
                    "0 ⊕ 1 = 1\r\n" +
                    "1 ⊕ 0 = 1\r\n" +
                    "1 ⊕ 1 = 0\r\n\r\n" +
                    "When applied to bytes, XOR is performed bit by bit.\r\n" +
                    "When applied to byte arrays, XOR is performed byte by \n" +
                    "byte at the same index.\r\n\r\n";
                    
                    U1_show.Margin = new Thickness(490,330,0,0);
                    opacity_anim(U1_show, 0.0, 1.0,null, 1200);
                    opacity_anim(info, 0.0, 1.0, null, 1200);
                    U1_show.Visibility = Visibility.Visible;
                    info.Visibility = Visibility.Visible;
                    opacity_anim(HMAC,1.0,0.0,null,700);
                    opacity_anim(salt_anim, 1.0, 0.0, null, 700);

                    System.Timers.Timer ne = new System.Timers.Timer(15000);
                    ne.AutoReset = false;
                    ne.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                           
                            opacity_anim(info, 1.0, 0.0, null, 800);
                            opacity_anim(info, 0.0, 1.0, null, 800);
                            info.Content = "Example: XOR of two bytes\r\n\r\nNumber A = 172  (binary: 10101100)\r\nNumber B = 197  (binary: 11000101)\r\n\r\nCompute XOR (A ⊕ B) bit by bit:\r\n\r\n  1 0 1 0 1 1 0 0   (A)\r\n⊕ 1 1 0 0 0 1 0 1   (B)\r\n-------------------\r\n  0 1 1 0 1 0 0 1   (Result)\r\n\r\nResult in decimal = 105\r\n\r\nSo:\r\n172 ⊕ 197 = 105\r\n";
                            
                            System.Timers.Timer ne = new System.Timers.Timer(15000);
                            ne.AutoReset = false;
                            ne.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {

                                    opacity_anim(info, 1.0, 0.0, null, 800);
                                    opacity_anim(info, 0.0, 1.0, null, 800);
                                    info.Content =
                                     "In PBKDF2, all intermediate results (U1, U2, U3, …) have the \n" +
                            "same length. The final block is computed by XORing all these \nvalues:\r\n\r\n" +
                            "Block = U1 ⊕ U2 ⊕ U3 ⊕ … ⊕ Uc\r\n\r\n" +
                            "XOR is used because it combines all iterations, preserves \nentropy, " +
                            "and ensures that every iteration influences the \nfinal derived key.\r\n";
                                });
                            }; ne.Start();
                            activeTimers.Add(ne);
                        });
                    };ne.Start();
                    activeTimers.Add(ne);


                });
            };
            timing_.Start();
            activeTimers.Add(timing_);
        }
        byte[] w8 = new byte[4];
        byte[] result = new byte[4];
        byte[] SBox = new byte[256]
{
    99,124,119,123,242,107,111,197,48,1,103,43,254,215,171,118,
    202,130,201,125,250,89,71,240,173,212,162,175,156,164,114,192,
    183,253,147,38,54,63,247,204,52,165,229,241,113,216,49,21,
    4,199,35,195,24,150,5,154,7,18,128,226,235,39,178,117,
    9,131,44,26,27,110,90,160,82,59,214,179,41,227,47,132,
    83,209,0,237,32,252,177,91,106,203,190,57,74,76,88,207,
    208,239,170,251,67,77,51,133,69,249,2,127,80,60,159,168,
    81,163,64,143,146,157,56,245,188,182,218,33,16,255,243,210,
    205,12,19,236,95,151,68,23,196,167,126,61,100,93,25,115,
    96,129,79,220,34,42,144,136,70,238,184,20,222,94,11,219,
    224,50,58,10,73,6,36,92,194,211,172,98,145,149,228,121,
    231,200,55,109,141,213,78,169,108,86,244,234,101,122,174,8,
    186,120,37,46,28,166,180,198,232,221,116,31,75,189,139,138,
    112,62,181,102,72,3,246,14,97,53,87,185,134,193,29,158,
    225,248,152,17,105,217,142,148,155,30,135,233,206,85,40,223,
    140,161,137,13,191,230,66,104,65,153,45,15,176,84,187,22
};
        public void action5()
        {
            string password;
            string text = input_field.Text;
            byte[] text_bytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] first16Bytes1 = text_bytes.Take(16).ToArray();
            byte[] first16Bytes = pad1(first16Bytes1);
            if (password_field.Text == "")
            {
                password = "password@1010^";
                

            }
            else
            {
                password = password_field.Text;
                
            }

            foreach (var time in activeTimers)
            {
                time.Stop();
                time.Dispose();
            }
            activeTimers.Clear();
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            pu_salt = salt;
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

            byte[] key = pbkdf2.GetBytes(32);
            pu_key = key;
            string key_str = string.Join(", ", key);
            string to_show = "Key: [ " + key_str.Substring(0, 40) + " ... " + key_str.Substring(key_str.Length - 9) + " ]";
            
            for (int i = 0; i < 32; i += 4)
            {
                byte[] slice = new byte[4];
                Array.Copy(key, i, slice, 0, 4);
                lst.Add(slice);
            };
            for(int i =16 ;i<32 ; i++)
            {
                words_4_7.Add(key[i]);
            }
            DoubleAnimation oopac = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {

                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac_h = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1800)
            };
            encr_steps_Copy3.BeginAnimation(OpacityProperty, oopac);
            move(encr_steps_Copy3, "0,161,0,0", "0,54,0,0", 1000);
            move(encr_steps_Copy4, "0,54,0,0", "0,-54,0,0", 1000);
            change_color(encr_steps_Copy3, "#22C55E", 1100);
            
            U1_show.BeginAnimation(OpacityProperty,oopac2);
            pad_info1.BeginAnimation(OpacityProperty, oopac2);
            pad_info1_Copy.BeginAnimation(OpacityProperty, oopac2);
            pad_info2.BeginAnimation(OpacityProperty, oopac2);
            info.Content = "Before AES rounds begin, the first 16-byte data block \n" +
                "is mixed with the secret key to inject the password into the \n" +
                "encryption. \n\n" +
                "- The AES key (From Step 2) is then expanded into a series of \n16-byte" +
                "round keys using the AES key expansion.\n" +
                "- The number of round keys depends on the AES variant:\r\n\r\n   " +
                "• AES-128 => 16-byte key => 10 rounds => 11 round keys  \r\n   " +
                "• AES-192 => 24-byte key => 12 rounds => 13 round keys  \r\n   " +
                "• AES-256 => 32-byte key => 14 rounds => 15 round keys  \r\n\n" +
                "- Step 3 uses only the first round key (16 bytes) to \nXOR with " +
                "the 16-byte data block. \r\n" +
                "- This ensures that the encryption immediately depends on the \n" +
                "user’s password, and all later rounds continue to mix the \n" +
                "remaining round keys into the data.";
            info.BeginAnimation(OpacityProperty, oopac);

            System.Timers.Timer timer = new System.Timers.Timer(20000);
            timer.AutoReset = false;
            timer.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {


                    title.Content = "AES Key Expansion. How does it work ?";
                    
                    info.Content =
                                    "1.Start with the master key derived from the password.\n" +
                                    "   -The key is divided into fixed-size words (4 bytes).\n\n" +
                                    "2.The key expansion algorithm generates a sequence of words \nto form all round keys:\n" +
                                    "   -Each new word is computed from previous words using \n    transformations:\n" +
                                    "         a) A rotation operation(RotWord) that cyclically shifts \n            bytes.\n" +
                                    "         b) A substitution operation(SubWord) that applies a \n            non-linear mapping.\n" +
                                    "         c) A round constant(Rcon) is optionally added to certain \n            words to ensure uniqueness.\n" +
                                    "   -The new word is combined with an earlier word in the \n    sequence using XOR to produce the next word.\n" +
                                    "   -This process is repeated until enough words are generated \n    for all round keys.\n\n";
                                    
                    info.BeginAnimation(OpacityProperty, oopac);
                    title.BeginAnimation(OpacityProperty, oopac);
                    System.Timers.Timer timer2 = new System.Timers.Timer(20000);
                    timer2.AutoReset = false;
                    timer2.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {


                           
                            
                            info.Content = "3.All words are stored sequentially in a key schedule array.\n" +
                                           "   - Consecutive words are grouped to form round keys.\n\n" +
                                           "4.Outcome:\n" +
                                           "   -The master key is expanded into a complete set of \n    round keys.\n" +
                                           "   - These round keys will be used in order during the\n    AES encryption rounds.";
                            info.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timer3 = new System.Timers.Timer(20000);
                            timer3.AutoReset = false;
                            timer3.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {


                                    title.Content = "AES Key Schedule – Number of Words";
                                    title.BeginAnimation(OpacityProperty, oopac);
                                    info.Content =
                                    "- AES divides the key into 4-byte words.\r\n" +
                                    "- The total number of words required depends on the AES \nvariant and the number of rounds.\n" +
                                    "1. AES-128:\r\n   " +
                                    "- Master key: 16 bytes → 4 words\r\n" +
                                    "   - Number of rounds: 10\r\n" +
                                    "   - Round keys: 11 (1 extra for initial AddRoundKey)\r\n" +
                                    "   - Total words needed: 11 × 4 = 44 words\r\n" +
                                    "   - Words to generate: 44 − 4 = 40\r\n\r\n" +
                                    "2. AES-192:\r\n" +
                                    "   - Master key: 24 bytes → 6 words\r\n" +
                                    "   - Number of rounds: 12\r\n" +
                                    "   - Round keys: 13\r\n" +
                                    "   - Total words needed: 13 × 4 = 52 words\r\n" +
                                    "   - Words to generate: 52 − 6 = 46\r\n\r\n";
                                    
                                    info.BeginAnimation(OpacityProperty, oopac);

                                    
                                });
                            }; timer3.Start();
                            activeTimers.Add(timer3);


                        });
                    }; timer2.Start();
                    activeTimers.Add(timer2);

                });
            };timer.Start();
            activeTimers.Add(timer);

            System.Timers.Timer timer4 = new System.Timers.Timer(80000);
            timer4.AutoReset = false;
            timer4.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    info.Content = "3. AES-256:\r\n" +
            "   - Master key: 32 bytes → 8 words\r\n" +
            "   - Number of rounds: 14\r\n" +
            "   - Round keys: 15\r\n" +
            "   - Total words needed: 15 × 4 = 60 words\r\n" +
            "   - Words to generate: 60 − 8 = 52\r\n";
                    info.BeginAnimation(OpacityProperty, oopac);
                });
                
            }; timer4.Start();
            activeTimers.Add(timer4);
            System.Timers.Timer timer1 = new System.Timers.Timer(92000);
            timer1.AutoReset = false;
            timer1.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    title.Content = "Example of AES-256 Key Expansion";
                    title.BeginAnimation(OpacityProperty, oopac);

                    info.Content = "   ____Step 0: Definitions____\r\n\r\n" +
                    "W[i] = i-th word (4 bytes / 32 bits) in the key schedule array." +
                    "\r\n\r\nNk = number of words in master key = 8 for AES-256." +
                    "\r\n\r\nNr = number of rounds = 14 for AES-256.\r\n\r\n" +
                    "Rcon[j] = round constant for the j-th key (32 bits).\r\n\r\n" +
                    "RotWord(x) = rotate 4-byte word x left by 1 byte.\r\n\r\n" +
                    "SubWord(x) = apply AES S-box to each byte.\r\n\r\n" +
                    "⊕ = bitwise XOR of bytes.";
                    info.BeginAnimation(OpacityProperty, oopac);
                    System.Timers.Timer timer1_1 = new System.Timers.Timer(12000);
                    timer1_1.AutoReset = false;
                    timer1_1.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            

                            info.Content = "\n\n\n\nGoal: Expand the 32-byte master key into 60 words → 15 round keys \n(4 words each, 16 bytes).";
                            info.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timer1_2 = new System.Timers.Timer(9000);
                            timer1_2.AutoReset = false;
                            timer1_2.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    U1_show.Margin = new Thickness(490, 170, 0, 0);
                                    U1_show.Content = to_show;
                                    info.Content = "\n\n\n\n   ____Step 1: Split Master Key into Words____\n" +
                                    "";
                                    info.BeginAnimation(OpacityProperty, oopac);
                                    U1_show.Visibility = Visibility.Visible;
                                    U1_show.BeginAnimation(OpacityProperty, oopac);
                                    System.Timers.Timer timer1_3 = new System.Timers.Timer(5000);
                                    timer1_3.AutoReset = false;
                                    timer1_3.Elapsed += (s, e) =>
                                    {
                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                        {
                                            W0.Content += "[ "+string.Join(", ",lst[0]) +" ]" ;
                                            W1.Content += "[ " + string.Join(", ", lst[1]) + " ]";
                                            W2.Content += "[ " + string.Join(", ", lst[2]) + " ]";
                                            W3.Content += "[ " + string.Join(", ", lst[3]) + " ]";
                                            W4.Content += "[ " + string.Join(", ", lst[4]) + " ]";
                                            W5.Content += "[ " + string.Join(", ", lst[5]) + " ]";
                                            W6.Content += "[ " + string.Join(", ", lst[6]) + " ]";
                                            W7.Content += "[ " + string.Join(", ", lst[7]) + " ]";
                                            List<Label> li = new List<Label> {W0,W1,W2,W3,W4,W5,W6,W7 };
                                            List<Label> l2 = new List<Label> { rule1,if1,rule2,if2,rule3,if3};
                                            foreach (Label i in li)
                                            {
                                                i.BeginAnimation(OpacityProperty, oopac);
                                                i.Visibility = Visibility.Visible;
                                            }
                                            System.Timers.Timer timer1_4 = new System.Timers.Timer(8000);
                                            timer1_4.AutoReset = false;
                                            timer1_4.Elapsed += (s, e) =>
                                            {
                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                {
                                                    foreach (Label i in li)
                                                    {
                                                        i.BeginAnimation(OpacityProperty, oopac2);
                                                        
                                                    }
                                                    info.BeginAnimation(OpacityProperty, oopac2);
                                                    info.Content = "   ____Step 2: Generate a New Word W[i]____\r\n\r\n" +
                                                    "Rule for each new word in the AES-256 key schedule:\r\n\r\n\n\n\n\n\n" +
                                                    
                                                    "W[i] =";
                                                    
                                                    
                                                    info.BeginAnimation(OpacityProperty,oopac);
                                                    foreach (Label i in l2)
                                                    {
                                                        i.BeginAnimation(OpacityProperty, oopac);
                                                        i.Visibility = Visibility.Visible;
                                                    }
                                                    U1_show.BeginAnimation(OpacityProperty, oopac2);
                                                    

                                                });


                                            };
                                            timer1_4.Start();
                                            activeTimers.Add(timer1_4);
                                        });


                                    };
                                    timer1_3.Start();
                                    activeTimers.Add(timer1_3);
                                });


                            };
                            timer1_2.Start();
                            activeTimers.Add(timer1_2);
                        });


                    };
                    timer1_1.Start();
                    activeTimers.Add(timer1_1);
                });

                

            };
            timer1.Start();
            activeTimers.Add(timer1);

            System.Timers.Timer timer1_5 = new System.Timers.Timer(142000);
            timer1_5.AutoReset = false;
            timer1_5.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    W8.BeginAnimation(OpacityProperty, oopac);
                    W8.Visibility = Visibility.Visible;
                    System.Timers.Timer timer1_7 = new System.Timers.Timer(900);
                    timer1_7.AutoReset = false;
                    timer1_7.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8_i.BeginAnimation(OpacityProperty, oopac);
                            W8_i.Visibility = Visibility.Visible;
                            change_color(rule1, "#22C55E", 2000);
                            change_color(if1, "#22C55E", 2000);
                            System.Timers.Timer timer1_6 = new System.Timers.Timer(4000);
                            timer1_6.AutoReset = false;
                            timer1_6.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    W8_i.BeginAnimation(OpacityProperty, oopac2);
                                    W8.Content = "W[8] = W[0] ⊕ SubWord(RotWord(W[7])) ⊕ Rcon[1]";
                                    System.Timers.Timer timer1_8 = new System.Timers.Timer(3000);
                                    timer1_8.AutoReset = false;
                                    timer1_8.Elapsed += (s, e) =>
                                    {
                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                        {
                                            move(W8, "490,170,0,0", "490,140,0,0", 600);
                                            W8_r.BeginAnimation(OpacityProperty, oopac);
                                            W8_r.Visibility = Visibility.Visible;
                                            System.Timers.Timer timer1_8 = new System.Timers.Timer(3000);
                                            timer1_8.AutoReset = false;
                                            timer1_8.Elapsed += (s, e) =>
                                            {
                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                {
                                                    W8.Margin = new Thickness(490, 140, 0, 0);
                                                    W8_app.BeginAnimation(OpacityProperty, oopac);
                                                    W8_app.Visibility = Visibility.Visible;
                                                    W8_app.Content = "W[7] = " + "[ " + string.Join(", ", lst[7]) + " ]";
                                                    System.Timers.Timer timer1_8 = new System.Timers.Timer(3000);
                                                    timer1_8.AutoReset = false;
                                                    timer1_8.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {

                                                            W8_re.BeginAnimation(OpacityProperty, oopac);
                                                            W8_re.Visibility = Visibility.Visible;
                                                            W8_re.Content = "RotWord(W[7]) = " + RotWord(lst[7]);
                                                            System.Timers.Timer timer1_8 = new System.Timers.Timer(3000);
                                                            timer1_8.AutoReset = false;
                                                            timer1_8.Elapsed += (s, e) =>
                                                            {
                                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                                {
                                                                    W8_r.Content = "SubWord(W) => SBox";
                                                                    W8_r.BeginAnimation(OpacityProperty, oopac);
                                                                    W8_app.BeginAnimation(OpacityProperty, oopac2);
                                                                    W8_r.Visibility = Visibility.Visible;
                                                                   
                                                                    activeTimers.Add(timer1_8);



                                                                });


                                                            };
                                                            timer1_8.Start();
                                                            activeTimers.Add(timer1_8);


                                                        });


                                                    };
                                                    timer1_8.Start();
                                                    activeTimers.Add(timer1_8);


                                                });


                                            };
                                            timer1_8.Start();
                                            activeTimers.Add(timer1_8);



                                        });


                                    };
                                    timer1_8.Start();
                                    activeTimers.Add(timer1_8);


                                });


                            };
                            timer1_6.Start();
                            activeTimers.Add(timer1_6);
                        });


                    };
                    timer1_7.Start();
                    activeTimers.Add(timer1_7);

                });


            };
            timer1_5.Start();
            activeTimers.Add(timer1_5);


            System.Timers.Timer timer1_8 = new System.Timers.Timer(165000);
            timer1_8.AutoReset = false;
            timer1_8.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {


                    W8_app.BeginAnimation(OpacityProperty, oopac);
                    W8_app.Visibility = Visibility.Visible;
                    W8_app.Content = lst[7][1].ToString() + " => " + SBox[lst[7][1]].ToString() + "\t" +
                       lst[7][2].ToString() + " => " + SBox[lst[7][2]].ToString() + "\n" +
                       lst[7][3].ToString() + " => " + SBox[lst[7][3]].ToString() + "\t" +
                    lst[7][0].ToString() + " => " + SBox[lst[7][0]].ToString();
                    System.Timers.Timer timer1_8 = new System.Timers.Timer(5000);
                    timer1_8.AutoReset = false;
                    timer1_8.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {

                            W8_re1.BeginAnimation(OpacityProperty, oopac);
                            W8_re1.Visibility = Visibility.Visible;
                            W8_re1.Content = "SubWord(RotWord(W[7])) = [ " + string.Join(", ", SubWord(RotWord_2(lst[7]))) + " ]";

                            System.Timers.Timer timer1_8 = new System.Timers.Timer(5000);
                            timer1_8.AutoReset = false;
                            timer1_8.Elapsed += (s, e) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    W8_r.Content = "Rcon[i] = [rᵢ, 0, 0, 0]";
                                    W8_r.BeginAnimation(OpacityProperty, oopac);
                                    W8_app.BeginAnimation(OpacityProperty, oopac2);
                                    W8_r.Visibility = Visibility.Visible;
                                    System.Timers.Timer timer1_8 = new System.Timers.Timer(5000);
                                    timer1_8.AutoReset = false;
                                    timer1_8.Elapsed += (s, e) =>
                                    {
                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                        {


                                            W8_app.BeginAnimation(OpacityProperty, oopac);
                                            W8_app.Visibility = Visibility.Visible;
                                            W8_app.Content = "r₁ = 1        rᵢ = { 2·rᵢ₋₁                  if rᵢ₋₁ < 128\r\n                        (2·rᵢ₋₁ − 256) ⊕ 27     if rᵢ₋₁ ≥ 128 }\r\n";
                                            System.Timers.Timer timer1_8 = new System.Timers.Timer(5000);
                                            timer1_8.AutoReset = false;
                                            timer1_8.Elapsed += (s, e) =>
                                            {
                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                {

                                                    W8_re2.BeginAnimation(OpacityProperty, oopac);
                                                    W8_re2.Visibility = Visibility.Visible;
                                                    W8_re2.Content = "Rcon[1] = [1, 0, 0, 0] ";

                                                    System.Timers.Timer timi = new System.Timers.Timer(5000);
                                                    timi.AutoReset = false;
                                                    timi.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {
                                                            W8_r.BeginAnimation(OpacityProperty, oopac2);
                                                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                                                            W8_app.Content = "W[8] = [" + string.Join(", ",lst[0]) + "] ⊕ [" + string.Join(", ", SubWord(RotWord_2(lst[7]))) + "] ⊕ [1, 0, 0, 0]";
                                                            W8_app.BeginAnimation(OpacityProperty, oopac);
                                                        });
                                                    };timi.Start();
                                                    activeTimers.Add(timi);
                                                    System.Timers.Timer timi2 = new System.Timers.Timer(9000);
                                                    timi2.AutoReset = false;
                                                    timi2.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {
                                                            byte[] Rcon = new byte[] { 1, 0, 0, 0 };
                                                            
                                                            for (int i = 0; i < 4; i++)
                                                            {
                                                                byte s = (byte) (lst[0][i] ^ SubWord(RotWord_2(lst[7]))[i]);
                                                                byte n = (byte) (s ^ Rcon[i]);
                                                                w8[i] = n;
                                                                
                                                            }
                                                            W8_re.BeginAnimation(OpacityProperty, oopac2);
                                                            W8_re1.BeginAnimation(OpacityProperty, oopac2);
                                                            W8_re2.BeginAnimation(OpacityProperty, oopac2);

                                                            
                                                            System.Timers.Timer timi2 = new System.Timers.Timer(1000);
                                                            timi2.AutoReset = false;
                                                            timi2.Elapsed += (s, e) =>
                                                            {
                                                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                                {
                                                                    W8_re1.Content = "W[8] = [" + string.Join(", ", w8)+" ]";
                                                                    W8_re1.BeginAnimation(OpacityProperty, oopac);
                                                                });
                                                            }; timi2.Start();
                                                            activeTimers.Add(timi2);

                                                        });
                                                    }; timi2.Start();
                                                    activeTimers.Add(timi2);
                                                    System.Timers.Timer timi3 = new System.Timers.Timer(15000);
                                                    timi3.AutoReset = false;
                                                    timi3.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {
                                                            change_color(rule1, "#F0F8FF", 2000);
                                                            change_color(if1, "#FACC15", 2000);
                                                            W8_re1.BeginAnimation(OpacityProperty, oopac2);
                                                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                                                            W8.BeginAnimation(OpacityProperty, oopac2);
                                                        });
                                                    };timi3.Start();
                                                    activeTimers.Add(timi3);
                                                    System.Timers.Timer timi4 = new System.Timers.Timer(20000);
                                                    timi4.AutoReset = false;
                                                    timi4.Elapsed += (s, e) =>
                                                    {
                                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                                        {
                                                            W8.Margin = new Thickness(490, 170, 0, 0);
                                                            move(W8, "490,140,0,0", "490,170,0,0", 600);
                                                            W8.Content = "W[9] = ?";
                                                            W8.BeginAnimation(OpacityProperty, oopac);
                                                            
                                                        });

                                                    }; timi4.Start();
                                                    activeTimers.Add(timi4);
                                                   


                                                });


                                            };
                                            timer1_8.Start();
                                            activeTimers.Add(timer1_8);


                                        });


                                    };
                                    timer1_8.Start();
                                    activeTimers.Add(timer1_8);



                                });


                            };
                            timer1_8.Start();
                            activeTimers.Add(timer1_8);





                        });


                    };
                    timer1_8.Start();
                    activeTimers.Add(timer1_8);


                });


            };
            timer1_8.Start();
            activeTimers.Add(timer1_8);

            System.Timers.Timer timi4 = new System.Timers.Timer(226000);
            timi4.AutoReset = false;
            timi4.Elapsed += (s1, e1) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    W8_i.Content = "9 mod 8 = 1";
                    W8_i.BeginAnimation(OpacityProperty, oopac);
                    change_color(rule3, "#22C55E", 4000);
                    change_color(if3, "#22C55E", 4000);
                    
                });


            }; timi4.Start();
            activeTimers.Add(timi4);
            System.Timers.Timer timi41 = new System.Timers.Timer(232000);
            timi41.AutoReset = false;
            timi41.Elapsed += (s2, e2) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    W8_i.BeginAnimation(OpacityProperty, oopac2);
                    move(W8, "490,170,0,0", "490,140,0,0", 600);
                    W8_r.Content = "W[9] = W[9-8] ⊕ W[9-1]";
                    W8_r.BeginAnimation(OpacityProperty, oopac);
                    W8_r.Visibility = Visibility.Visible;
                    W8_app.Visibility = Visibility.Visible;
                    W8_app.Content = "W[9-8] = W[1] = [ " + string.Join(", ", lst[1]) + " ]   \nW[9-1] = W[8] = [ " + string.Join(", ", w8) + " ]";
                    W8_app.BeginAnimation(OpacityProperty, oopac);
                    
                });
            }; timi41.Start();
            activeTimers.Add(timi41);
            System.Timers.Timer timi42 = new System.Timers.Timer(242000);
            timi42.AutoReset = false;
            timi42.Elapsed += (s3, e3) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    
                    
                    for (int i = 0; i < 4; i++)
                    {
                        byte s = (byte)(lst[1][i] ^ w8[i]);
                        result[i] = s;
                        
                    }
                    W8_re.Content = "W[9] = [ " + string.Join(", ", result) + " ]";
                    W8_re.Visibility = Visibility.Visible;
                    W8_re.BeginAnimation(OpacityProperty, oopac);
                    System.Timers.Timer timi42 = new System.Timers.Timer(10000);
                    timi42.AutoReset = false;
                    timi42.Elapsed += (s3, e3) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8_re.BeginAnimation(OpacityProperty, oopac2);
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8_r.BeginAnimation(OpacityProperty, oopac2);
                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                            change_color(rule3, "#F0F8FF", 2000);
                            change_color(if3, "#FACC15", 2000);


                        });
                    }; timi42.Start();
                    activeTimers.Add(timi42);


                });
            }; timi42.Start();
            activeTimers.Add(timi42);

            System.Timers.Timer timi46 = new System.Timers.Timer(262000);
            timi46.AutoReset = false;
            timi46.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    W8.Margin = new Thickness(490, 170, 0, 0);
                    move(W8, "490,140,0,0", "490,170,0,0", 600);
                    W8.Content = "W[12] = ?";
                    W8.BeginAnimation(OpacityProperty, oopac);
                    System.Timers.Timer timi4 = new System.Timers.Timer(6000);
                    timi4.AutoReset = false;
                    timi4.Elapsed += (s1, e1) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8_i.Content = "Nk = 8 > 6 and 12 mod 8 = 4";
                            W8_i.BeginAnimation(OpacityProperty, oopac);
                            change_color(rule2, "#22C55E", 4000);
                            change_color(if2, "#22C55E", 4000);

                        });


                    }; timi4.Start();
                    activeTimers.Add(timi4);
                    System.Timers.Timer timi411 = new System.Timers.Timer(11000);
                    timi411.AutoReset = false;
                    timi411.Elapsed += (s2, e2) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            byte[] result_10 = new byte[4];
                            byte[] result_11 = new byte[4];
                            for (int i = 0; i < 4; i++)
                            {
                                byte s = (byte)(lst[2][i] ^ result[i]);
                                result_10[i] = s;
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                byte s = (byte)(lst[3][i] ^ result_10[i]);
                                result_11[i] = s;
                            }
                            W8_i.BeginAnimation(OpacityProperty, oopac2);
                            move(W8, "490,170,0,0", "490,140,0,0", 600);
                            W8_r.Content = "W[12] = W[12-8] ⊕ SubWord(W[12-1])";
                            W8_r.BeginAnimation(OpacityProperty, oopac);
                            W8_r.Visibility = Visibility.Visible;
                            W8_app.Visibility = Visibility.Visible;
                            W8_app.Content = "W[12-8] = W[4] = [ " + string.Join(", ", lst[4]) + " ]   \nW[12-1] = W[11] = [ " + string.Join(", ", result_11) + " ]";
                            W8_app.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timi421 = new System.Timers.Timer(6000);
                            timi421.AutoReset = false;
                            timi421.Elapsed += (s3, e3) =>
                            {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {

                                    byte[] result_12 = new byte[4];
                                    for (int i = 0; i < 4; i++)
                                    {
                                        byte s = (byte)(lst[4][i] ^ SubWord(result_11)[i]);
                                        result_12[i] = s;
                                    }
                                    W8_re.Content = "W[12] = [ " + string.Join(", ", result_12) + " ]";
                                    W8_re.Visibility = Visibility.Visible;
                                    W8_re.BeginAnimation(OpacityProperty, oopac);
                                    System.Timers.Timer timi47 = new System.Timers.Timer(10000);
                                    timi47.AutoReset = false;
                                    timi47.Elapsed += (s3, e3) =>
                                    {
                                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                        {
                                            W8_re.BeginAnimation(OpacityProperty, oopac2);
                                            W8.BeginAnimation(OpacityProperty, oopac2);
                                            W8_r.BeginAnimation(OpacityProperty, oopac2);
                                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                                            change_color(rule2, "#F0F8FF", 2000);
                                            change_color(if2, "#FACC15", 2000);


                                        });
                                    }; timi47.Start();
                                    activeTimers.Add(timi47);


                                });
                            }; timi421.Start();
                            activeTimers.Add(timi421);

                        });
                    }; timi411.Start();
                    activeTimers.Add(timi41);
                    

                });

            }; timi46.Start();
            activeTimers.Add(timi46);

            System.Timers.Timer tt = new System.Timers.Timer(290000) ;
            tt.AutoReset = false;
            tt.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    title.BeginAnimation(OpacityProperty, oopac2);
                    info.BeginAnimation(OpacityProperty, oopac2);
                    rule1.BeginAnimation(OpacityProperty, oopac2);
                    if1.BeginAnimation(OpacityProperty, oopac2);
                    rule2.BeginAnimation(OpacityProperty, oopac2);
                    if2.BeginAnimation(OpacityProperty, oopac2);
                    rule3.BeginAnimation(OpacityProperty, oopac2);
                    if3.BeginAnimation(OpacityProperty, oopac2);
                    info.Content = "After the key schedule generates all the round keys, AES begins \n" +
                    "the encryption process by combining the plaintext data with \n" +
                    "the first round key. \n\n" +
                    "This is done using a bitwise XOR operation, where each byte \n" +
                    "of the 16-byte" +
                    "plaintext block is XORed with the corresponding \nbyte of the first round key. \n\n" +
                    "The result is stored in the state matrix, which will \nundergo the AES rounds. \n\n" +
                    "This initial key mixing ensures that the plaintext is immediately \n“masked” by " +
                    "the secret key, providing the first layer of \nsecurity before the main rounds " +
                    "of SubBytes, \nShiftRows, and MixColumns begin.";
                    
                    System.Timers.Timer tt2 = new System.Timers.Timer(900);
                    tt2.AutoReset = false;
                    tt2.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                         
                            info.BeginAnimation(OpacityProperty, oopac);
                        });


                    }; tt2.Start();
                    activeTimers.Add(tt2);
                    System.Timers.Timer tt3 = new System.Timers.Timer(1800);
                    tt3.AutoReset = false;
                    tt3.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            text_title.BeginAnimation(OpacityProperty, oopac);
                            key_title.BeginAnimation(OpacityProperty, oopac);
                            text_title.Visibility = Visibility.Visible;
                            key_title.Visibility = Visibility.Visible;

                        });


                    }; tt3.Start();
                    activeTimers.Add(tt3);
                    System.Timers.Timer tt4 = new System.Timers.Timer(2700);
                    tt4.AutoReset = false;
                    tt4.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            List<Label> matrix_txt = new List<Label> { t_1, t_2, t_3, t_4, t_5, t_6, t_7, t_8, t_9, t_10, t_11,t_12, t_13, t_14, t_15, t_16  };
                            List<Label> matrix_k = new List<Label> { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9, k_10, k_11, k_12, k_13, k_14, k_15, k_16 };

                            for (int i = 0; i < 16; i++)
                            {
                                matrix_txt[i].Content = first16Bytes[i].ToString();
                            }


                            for (int word = 0; word < 4; word++)
                            {
                                for (int byteInWord = 0; byteInWord < 4; byteInWord++)
                                {
                                    matrix_k[word * 4 + byteInWord].Content = lst[word][byteInWord].ToString();
                                }
                            }


                            for (int i = 0; i < 16; i++)
                            {
                                int index = i; 
                                System.Timers.Timer showing = new System.Timers.Timer(600 * (index + 1));
                                showing.AutoReset = false;
                                showing.Elapsed += (s, e) =>
                                {
                                    Application.Current.Dispatcher.Invoke(() =>
                                    {
                                        matrix_txt[index].BeginAnimation(OpacityProperty, oopac);
                                        matrix_txt[index].Visibility = Visibility.Visible;

                                        matrix_k[index].BeginAnimation(OpacityProperty, oopac);
                                        matrix_k[index].Visibility = Visibility.Visible;
                                    });
                                };
                                showing.Start();
                                activeTimers.Add(showing);
                            }
                            System.Timers.Timer tt6 = new System.Timers.Timer(10000);
                            tt6.AutoReset = false;
                            tt6.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    text_title.BeginAnimation(OpacityProperty, oopac2);
                                    key_title.BeginAnimation(OpacityProperty, oopac2);
                                    foreach (Label myControl in matrix_txt)
                                    {
                                        ThicknessAnimation moveUp = new ThicknessAnimation
                                        {
                                            From = myControl.Margin,
                                            To = new Thickness(
                                                                   myControl.Margin.Left,
                                                                      myControl.Margin.Top - 60,   
                                                           myControl.Margin.Right,
                                                   myControl.Margin.Bottom),

                                            Duration = TimeSpan.FromMilliseconds(800),
                                            EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                                        };

                                        myControl.BeginAnimation(FrameworkElement.MarginProperty, moveUp);
                                    }
                                    foreach (Label myControl in matrix_k)
                                    {
                                        ThicknessAnimation moveUp = new ThicknessAnimation
                                        {
                                            From = myControl.Margin,
                                            To = new Thickness(
                                                                   myControl.Margin.Left,
                                                                      myControl.Margin.Top - 60,
                                                           myControl.Margin.Right,
                                                   myControl.Margin.Bottom),

                                            Duration = TimeSpan.FromMilliseconds(800),
                                            EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                                        };

                                        myControl.BeginAnimation(FrameworkElement.MarginProperty, moveUp);
                                    }
                                    for (int i = 0; i < 17; i++)
                                    {
                                        int index = i;
                                        System.Timers.Timer showing = new System.Timers.Timer(6500 * (index + 1));
                                        showing.AutoReset = false;
                                        showing.Elapsed += (s, e) =>
                                        {
                                            Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                if(index != 0 || index == 16)
                                                {
                                                    change_color(matrix_txt[index-1], "#33E0C9", 500);
                                                    change_color(matrix_k[index-1], "#FFFFFF", 500);

                                                }
                                                if(index != 16)
                                                {
                                                    change_color(matrix_txt[index], "#FF0000", 500);
                                                    change_color(matrix_k[index], "#FF0000", 500);
                                                }
                                                
                                            });
                                        };
                                        showing.Start();
                                        activeTimers.Add(showing);
                                    }
                                    List<byte> ldr = new List<byte> { };
                                    foreach(byte[] elem in lst)
                                    {
                                        for (int y =0; y < 4; y++)
                                        {
                                            ldr.Add(elem[y]);
                                        }
                                    }
                                    List<Label> matrix_r = new List<Label> {r_1,r_2,r_3,r_4,r_5, r_6, r_7, r_8, r_9, r_10, r_11, r_12, r_13, r_14, r_15, r_16 };
                                    for (int i = 0; i < 17; i++)
                                    {
                                        int index = i;
                                        System.Timers.Timer showing = new System.Timers.Timer(6500 * (index + 1));
                                        showing.AutoReset = false;
                                        showing.Elapsed += (s, e) =>
                                        {
                                            Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                if (index != 0 || index == 16)
                                                {
                                                    matrix_r[index-1].Foreground = Brushes.White;
                                                    byte res = (byte)(first16Bytes[index-1] ^ ldr[index-1]);
                                                    matrix_r[index - 1].Content = res.ToString();
                                                }
                                                if (index != 16 )
                                                {
                                                    matrix_r[index].Foreground = Brushes.Red;
                                                    matrix_r[index].Content = matrix_txt[index].Content + " ⊕ " + matrix_k[index].Content;
                                                    matrix_r[index].Visibility = Visibility.Visible;
                                                    matrix_r[index].BeginAnimation(OpacityProperty, oopac);
                                                }
                                            });
                                        };
                                        showing.Start();
                                        activeTimers.Add(showing);
                                    }

                                });
                            };
                            tt6.Start();
                            activeTimers.Add(tt6);
                            
                        });


                    }; tt4.Start();
                    activeTimers.Add(tt4);
                });
               

            };tt.Start();
            activeTimers.Add(tt);
             
        }

        public void action6()
        {
            title.Visibility = Visibility.Hidden;
            rule1.Visibility = Visibility.Hidden;
            rule2.Visibility = Visibility.Hidden;
            rule3.Visibility = Visibility.Hidden;
            if1.Visibility = Visibility.Hidden;
            if2.Visibility = Visibility.Hidden;
            if3.Visibility = Visibility.Hidden;
            foreach (var time in activeTimers)
            {
                time.Stop();
                time.Dispose();
            }
            activeTimers.Clear();
            List<byte[]> lst = new List<byte[]> { };
            for (int i = 0; i < 32; i += 4)
            {
                byte[] slice = new byte[4];
                Array.Copy(pu_key, i, slice, 0, 4);
                lst.Add(slice);
            }
            List<byte> ldr = new List<byte> { };
            foreach (byte[] elem in lst)
            {
                for (int y = 0; y < 4; y++)
                {
                    ldr.Add(elem[y]);
                }
            }
            string text = input_field.Text;
            byte[] text_bytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] first16Bytes1 = text_bytes.Take(16).ToArray();
            byte[] first16Bytes = pad1(first16Bytes1);
            List<Label> matrix_r = new List<Label> { r_1, r_2, r_3, r_4, r_5, r_6, r_7, r_8, r_9, r_10, r_11, r_12, r_13, r_14, r_15, r_16 };
            List<Label> matrix_txt = new List<Label> { t_1, t_2, t_3, t_4, t_5, t_6, t_7, t_8, t_9, t_10, t_11, t_12, t_13, t_14, t_15, t_16 };
            List<Label> matrix_k = new List<Label> { k_1, k_2, k_3, k_4, k_5, k_6, k_7, k_8, k_9, k_10, k_11, k_12, k_13, k_14, k_15, k_16 };

            foreach (Label myControl in matrix_r)
            {
                ThicknessAnimation moveUp = new ThicknessAnimation
                {
                    From = myControl.Margin,
                    To = new Thickness(
                                                                   myControl.Margin.Left,
                                                                      myControl.Margin.Top - 90,
                                                           myControl.Margin.Right,
                                                   myControl.Margin.Bottom),

                    Duration = TimeSpan.FromMilliseconds(1000),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                DoubleAnimation font = new DoubleAnimation
                {
                    To = 22,
                    Duration = TimeSpan.FromMilliseconds(800)
                };

                myControl.BeginAnimation(TextBlock.FontSizeProperty, font);
                myControl.BeginAnimation(FrameworkElement.MarginProperty, moveUp);
                

            }
            DoubleAnimation oopac = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {

                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac3 = new DoubleAnimation
            {

                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(600)
            };
            for (int i = 0; i<16; i++)
            {
                matrix_k[i].BeginAnimation(OpacityProperty, oopac3);
                matrix_txt[i].BeginAnimation(OpacityProperty, oopac3);
                matrix_r[i].Visibility = Visibility.Visible;
                byte res = (byte)(first16Bytes[i] ^ ldr[i]);
                matrix_r[i].Content = res.ToString();
            }
            
            
            encr_steps_Copy2.BeginAnimation(OpacityProperty, oopac);
            move(encr_steps_Copy2, "0,161,0,0", "0,54,0,0", 1000);
            move(encr_steps_Copy3, "0,54,0,0", "0,-54,0,0", 1000);
            change_color(encr_steps_Copy2, "#22C55E", 1100);

            info.BeginAnimation(OpacityProperty, oopac2);
            info.Content = "After the initial AddRoundKey, AES enters the main rounds of \nencryption.\r\n\r\n" +
                "Each round applies the following transformations to the state \nmatrix:\r\n\r\n" +
                "      \t   →    \t             →   \t          →    \t         \r\n\r\n" +
                "• SubBytes: Each byte is replaced using the AES S-Box \n  (non-linear substitution).\r\n" +
                "• ShiftRows: Rows of the state matrix are cyclically shifted to \n  the left.\r\n" +
                "• MixColumns: Each column is mixed using finite field \n  multiplication in GF(2⁸).\r\n" +
                "• AddRoundKey: The state is XORed with the current round key.\r\n\r\n"; 

            info.BeginAnimation(OpacityProperty, oopac);
            info_sub.BeginAnimation(OpacityProperty, oopac);
            info_shif.BeginAnimation(OpacityProperty, oopac);
            info_mix.BeginAnimation(OpacityProperty, oopac);
            info_add.BeginAnimation(OpacityProperty, oopac);
            info_add.Visibility = Visibility.Visible;
            info_sub.Visibility = Visibility.Visible;
            info_shif.Visibility = Visibility.Visible;
            info_mix.Visibility = Visibility.Visible;
            System.Timers.Timer tm = new System.Timers.Timer(8000);
            tm.AutoReset = false;
            tm.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    change_color(info_sub, "#22C55E", 2000);
                    for (int i = 0; i < 17; i++)
                    {
                        int index = i;

                        System.Timers.Timer tm2 = new System.Timers.Timer(6000 * (index + 1));
                        tm2.AutoReset = false;
                        tm2.Elapsed += (s, e) =>
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                if (index != 16)
                                {
                                    string contentStr = matrix_r[index].Content.ToString();
                                    byte value = byte.Parse(contentStr);
                                    

                                    
                                    change_color(matrix_r[index], "#FF0000", 500);
                                    W8.Content = contentStr + " => " + SBox[value].ToString();
                                    W8.BeginAnimation(OpacityProperty, oopac);
                                    W8.Visibility = Visibility.Visible;
                                }

                                if (index != 0 || index == 16)
                                {
                                    string contentStr = matrix_r[index-1].Content.ToString();


                                    byte value = byte.Parse(contentStr);
                                    change_color(matrix_r[index-1], "#FFFFFF", 500);
                                    matrix_r[index - 1].Content = SBox[value].ToString();
                                }
                                if(index == 16)
                                {
                                    W8.BeginAnimation(OpacityProperty, oopac2);
                                }
                            });

                        };
                        tm2.Start();
                        activeTimers.Add(tm2);



                    }
                });
                
            };
            tm.Start();
            activeTimers.Add(tm);

            System.Timers.Timer tt7 = new System.Timers.Timer(109000);
            tt7.AutoReset = false;
            tt7.Elapsed += (s, r) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    change_color(info_shif, "#22C55E", 2000);
                    change_color(info_sub, "#F0F8FF", 2000);
                    System.Timers.Timer tt8 = new System.Timers.Timer(5000);
                    tt8.AutoReset = false;
                    tt8.Elapsed += (s, r) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(matrix_r[0], "#FF0000", 2000);
                            change_color(matrix_r[1], "#FF0000", 2000);
                            change_color(matrix_r[2], "#FF0000", 2000);
                            change_color(matrix_r[3], "#FF0000", 2000);
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "Row[0] => No Shift";
                            W8.BeginAnimation(OpacityProperty, oopac);
                        });
                    };
                    tt8.Start();
                    activeTimers.Add(tt8);
                    System.Timers.Timer tt9 = new System.Timers.Timer(9000);
                    tt9.AutoReset = false;
                    tt9.Elapsed += (s, r) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(matrix_r[0], "#FFFFFF", 2000);
                            change_color(matrix_r[1], "#FFFFFF", 2000);
                            change_color(matrix_r[2], "#FFFFFF", 2000);
                            change_color(matrix_r[3], "#FFFFFF", 2000);
                            change_color(matrix_r[4], "#FF0000", 2000);
                            change_color(matrix_r[5], "#FF0000", 2000);
                            change_color(matrix_r[6], "#FF0000", 2000);
                            change_color(matrix_r[7], "#FF0000", 2000);
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "Row[1] => Shift Left 1";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timer = new System.Timers.Timer(4000);
                            timer.AutoReset = false;
                            timer.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[4], "604,300,0,0", "529,300,0,0", 500);
                                    move(matrix_r[5], "677,300,0,0", "604,300,0,0", 500);
                                    move(matrix_r[6], "753,300,0,0", "677,300,0,0", 500);
                                    move(matrix_r[7], "829,300,0,0", "753,300,0,0", 500);
                                   
                                    
                                });
                            };timer.Start();
                            activeTimers.Add(timer);
                            System.Timers.Timer timer2 = new System.Timers.Timer(5000);
                            timer2.AutoReset = false;
                            timer2.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[4], "529,300,0,0", "529,200,0,0", 500);
                                    
                                });
                            }; timer2.Start();
                            activeTimers.Add(timer2);
                            System.Timers.Timer timer3 = new System.Timers.Timer(6000);
                            timer3.AutoReset = false;
                            timer3.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[4], "529,200,0,0", "901,200,0,0", 500);

                                });
                            }; timer3.Start();
                            activeTimers.Add(timer3);
                            System.Timers.Timer timer4 = new System.Timers.Timer(7000);
                            timer4.AutoReset = false;
                            timer4.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[4], "901,200,0,0", "901,300,0,0", 500);

                                });
                            }; timer4.Start();
                            activeTimers.Add(timer4);
                            System.Timers.Timer timer5 = new System.Timers.Timer(8000);
                            timer5.AutoReset = false;
                            timer5.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[4], "901,300,0,0", "826,300,0,0", 500);

                                });
                            }; timer5.Start();
                            activeTimers.Add(timer5);
                        });
                    }; tt9.Start();
                    activeTimers.Add(tt9);

                    System.Timers.Timer tt10 = new System.Timers.Timer(32500);
                    tt10.AutoReset = false;
                    tt10.Elapsed += (s, r) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(matrix_r[4], "#FFFFFF", 2000);
                            change_color(matrix_r[5], "#FFFFFF", 2000);
                            change_color(matrix_r[6], "#FFFFFF", 2000);
                            change_color(matrix_r[7], "#FFFFFF", 2000);
                            change_color(matrix_r[8], "#FF0000", 2000);
                            change_color(matrix_r[9], "#FF0000", 2000);
                            change_color(matrix_r[10], "#FF0000", 2000);
                            change_color(matrix_r[11], "#FF0000", 2000);
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "Row[2] => Shift Left 2";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timer11 = new System.Timers.Timer(4000);
                            timer11.AutoReset = false;
                            timer11.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[8], "604,350,0,0", "529,350,0,0", 500);
                                    move(matrix_r[9], "677,350,0,0", "604,350,0,0", 500);
                                    move(matrix_r[10], "753,350,0,0", "677,350,0,0", 500);
                                    move(matrix_r[11], "829,350,0,0", "753,350,0,0", 500);


                                });
                            }; timer11.Start();
                            activeTimers.Add(timer11);
                            System.Timers.Timer timer211 = new System.Timers.Timer(5000);
                            timer211.AutoReset = false;
                            timer211.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[8], "529,350,0,0", "529,200,0,0", 500);
                                    
                                    move(matrix_r[9], "604,350,0,0", "529,350,0,0", 500);
                                    move(matrix_r[10], "677,350,0,0", "604,350,0,0", 500);
                                    move(matrix_r[11], "753,350,0,0", "677,350,0,0", 500);

                                });
                            }; timer211.Start();
                            activeTimers.Add(timer211);
                            System.Timers.Timer timer311 = new System.Timers.Timer(6000);
                            timer311.AutoReset = false;
                            timer311.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[8], "529,200,0,0", "901,200,0,0", 500);
                                    move(matrix_r[9], "529,350,0,0", "529,200,0,0", 500);

                                });
                            }; timer311.Start();
                            activeTimers.Add(timer311);
                            System.Timers.Timer timer411 = new System.Timers.Timer(7000);
                            timer411.AutoReset = false;
                            timer411.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[8], "901,200,0,0", "901,350,0,0", 500);
                                    move(matrix_r[9], "529,200,0,0", "901,200,0,0", 500);

                                });
                            }; timer411.Start();
                            activeTimers.Add(timer411);
                            System.Timers.Timer timer511 = new System.Timers.Timer(8000);
                            timer511.AutoReset = false;
                            timer511.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[8], "901,350,0,0", "753,350,0,0", 500);
                                    move(matrix_r[9], "901,200,0,0", "901,350,0,0", 500);
                                });
                            }; timer511.Start();
                            activeTimers.Add(timer511);
                            System.Timers.Timer timer611 = new System.Timers.Timer(9000);
                            timer611.AutoReset = false;
                            timer611.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[9], "901,350,0,0", "826,350,0,0", 500);
                                    
                                });
                            }; timer611.Start();
                            activeTimers.Add(timer611);
                        });
                    };
                    tt10.Start();
                    activeTimers.Add(tt10);

                    System.Timers.Timer tt11 = new System.Timers.Timer(70000);
                    tt11.AutoReset = false;
                    tt11.Elapsed += (s, r) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(matrix_r[8], "#FFFFFF", 2000);
                            change_color(matrix_r[9], "#FFFFFF", 2000);
                            change_color(matrix_r[10], "#FFFFFF", 2000);
                            change_color(matrix_r[11], "#FFFFFF", 2000);
                            change_color(matrix_r[12], "#FF0000", 2000);
                            change_color(matrix_r[13], "#FF0000", 2000);
                            change_color(matrix_r[14], "#FF0000", 2000);
                            change_color(matrix_r[15], "#FF0000", 2000);
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "Row[3] => Shift Left 3";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            System.Timers.Timer timer111 = new System.Timers.Timer(4000);
                            timer111.AutoReset = false;
                            timer111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[12], "604,400,0,0", "529,400,0,0", 500);
                                    move(matrix_r[13], "677,400,0,0", "604,400,0,0", 500);
                                    move(matrix_r[14], "753,400,0,0", "677,400,0,0", 500);
                                    move(matrix_r[15], "826,400,0,0", "753,400,0,0", 500);


                                });
                            }; timer111.Start();
                            activeTimers.Add(timer111);
                            System.Timers.Timer timer2111 = new System.Timers.Timer(5000);
                            timer2111.AutoReset = false;
                            timer2111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[12], "529,400,0,0", "529,200,0,0", 500);
                                    move(matrix_r[13], "604,400,0,0", "529,400,0,0", 500);
                                    move(matrix_r[14], "677,400,0,0", "604,400,0,0", 500);
                                    move(matrix_r[15], "753,400,0,0", "677,400,0,0", 500);

                                });
                            }; timer2111.Start();
                            activeTimers.Add(timer2111);
                            System.Timers.Timer timerx = new System.Timers.Timer(6000);
                            timerx.AutoReset = false;
                            timerx.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[12], "529,200,0,0", "901,200,0,0", 500);
                                    move(matrix_r[13], "529,400,0,0", "529,200,0,0", 500);
                                    move(matrix_r[14], "604,400,0,0", "529,400,0,0", 500);
                                    move(matrix_r[15], "677,400,0,0", "604,400,0,0", 500);

                                });
                            }; timerx.Start();
                            activeTimers.Add(timerx);
                            System.Timers.Timer timer3111 = new System.Timers.Timer(7000);
                            timer3111.AutoReset = false;
                            timer3111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[12], "901,200,0,0", "901,400,0,0", 500);
                                    move(matrix_r[13], "529,200,0,0", "901,200,0,0", 500);
                                    move(matrix_r[14], "529,400,0,0", "529,200,0,0", 500);

                                });
                            }; timer3111.Start();
                            activeTimers.Add(timer3111);
                            System.Timers.Timer timer4111 = new System.Timers.Timer(8000);
                            timer4111.AutoReset = false;
                            timer4111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[12], "901,400,0,0", "677,400,0,0", 500);
                                    move(matrix_r[13], "901,200,0,0", "901,400,0,0", 500);
                                    move(matrix_r[14], "529,200,0,0", "901,200,0,0", 500);

                                });
                            }; timer4111.Start();
                            activeTimers.Add(timer4111);
                            System.Timers.Timer timer5111 = new System.Timers.Timer(9000);
                            timer5111.AutoReset = false;
                            timer5111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    
                                    move(matrix_r[13], "901,400,0,0", "753,400,0,0", 500);
                                    move(matrix_r[14], "901,200,0,0", "901,400,0,0", 500);
                                });
                            }; timer5111.Start();
                            activeTimers.Add(timer5111);
                            System.Timers.Timer timer6111 = new System.Timers.Timer(10000);
                            timer6111.AutoReset = false;
                            timer6111.Elapsed += (s, e) =>
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    move(matrix_r[14], "901,400,0,0", "826,400,0,0", 500);

                                });
                            }; timer6111.Start();
                            activeTimers.Add(timer6111);
                        });
                    };
                    tt11.Start();
                    activeTimers.Add(tt11);

                });
            };
            tt7.Start();
            activeTimers.Add(tt7);

            List<Label> matrix_mix = new List<Label> {mix_1, mix_2, mix_3, mix_4, mix_5, mix_6, mix_7, mix_8, mix_9, mix_10, mix_11, mix_12, mix_13, mix_14, mix_15, mix_16 };
            System.Timers.Timer timi = new System.Timers.Timer(200000);
            timi.AutoReset = false;
            timi.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    change_color(info_shif, "#F0F8FF", 800);
                    change_color(info_mix, "#22C55E", 800);
                    foreach(Label lbl in matrix_r)
                    {
                        change_color(lbl, "#FFFFFF", 800);
                    }
                    foreach (Label lbl in matrix_mix)
                    {
                        lbl.BeginAnimation(OpacityProperty, oopac);
                        lbl.Visibility = Visibility.Visible;
                    }
                    symbol.BeginAnimation(OpacityProperty, oopac);
                    symbol.Visibility = Visibility.Visible;
                    a_0.BeginAnimation(OpacityProperty, oopac);
                    a_0.Visibility = Visibility.Visible;
                    a_1.BeginAnimation(OpacityProperty, oopac);
                    a_1.Visibility = Visibility.Visible;
                    a_2.BeginAnimation(OpacityProperty, oopac);
                    a_2.Visibility = Visibility.Visible;
                    a_3.BeginAnimation(OpacityProperty, oopac);
                    a_3.Visibility = Visibility.Visible;
                    W8.BeginAnimation(OpacityProperty, oopac2);
                    title_matrix.BeginAnimation(OpacityProperty, oopac);
                    mix.BeginAnimation(OpacityProperty, oopac);
                    mix.Visibility = Visibility.Visible;
                    title_matrix.Visibility = Visibility.Visible;
                    info.Content = "After the initial AddRoundKey, AES enters the main rounds of \nencryption.\r\n\r\n" +
                "Each round applies the following transformations to the state \nmatrix:\r\n\r\n" +
                "      \t   →    \t             →   \t          →    \t         \r\n\r\n";

                    System.Timers.Timer tt = new System.Timers.Timer(6000);
                    tt.AutoReset = false;
                    tt.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8.Content = "MixColumns works column by column";
                            change_color(matrix_r[0],"#FF0000",800);
                            change_color(matrix_r[5], "#FF0000", 800);
                            change_color(matrix_r[10], "#FF0000", 800);
                            change_color(matrix_r[15], "#FF0000", 800);
                            W8.BeginAnimation(OpacityProperty, oopac);

                        });
                    };tt.Start();
                    activeTimers.Add(tt);
                    
                    System.Timers.Timer tt2 = new System.Timers.Timer(9000);
                    tt2.AutoReset = false;
                    tt2.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            con = matrix_r[0].Content.ToString();
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "a0 = " + matrix_r[0].Content +"    a1 = "+matrix_r[5].Content+"    a2 = "+ matrix_r[10].Content + "    a3 = " + matrix_r[15].Content;
                            matrix_r[0].Content = "b0";
                            W8.BeginAnimation(OpacityProperty, oopac);

                        });
                    }; tt2.Start();
                    activeTimers.Add(tt2);

                    System.Timers.Timer tt3 = new System.Timers.Timer(11000);
                    tt3.AutoReset = false;
                    tt3.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(mix_1, "#FF0000", 800);
                            change_color(mix_2, "#FF0000", 800);
                            change_color(mix_3, "#FF0000", 800);
                            change_color(mix_4, "#FF0000", 800);
                            move(W8, "490,170,0,0", "490,120,0,0",800);
                            move(W8_app, "490,200,0,0", "490,170,0,0", 800);
                            W8_app.Visibility = Visibility.Visible;
                            W8_app.Content = "b0 = (2·a0) ⊕ (3·a1) ⊕ (1·a2) ⊕ (1·a3)";
                            
                            
                            W8_app.BeginAnimation(OpacityProperty, oopac);

                        });
                    }; tt3.Start();
                    activeTimers.Add(tt3);

                    System.Timers.Timer tt4 = new System.Timers.Timer(14000);
                    tt4.AutoReset = false;
                    tt4.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a0 = con.ToString();
                            string a1 = matrix_r[5].Content.ToString();
                            string a2 = matrix_r[10].Content.ToString();
                            string a3 = matrix_r[15].Content.ToString();
                            byte a_0 = byte.Parse(a0);
                            byte a_1 = byte.Parse(a1);
                            byte a_2 = byte.Parse(a2);
                            byte a_3 = byte.Parse(a3);

                            byte b0 = (byte) (Mul2(a_0) ^ Mul3(a_1) ^ a_2 ^ a_3);
                            matrix_r[0].Content = b0.ToString();
                            change_color(matrix_r[0], "#00FF9C", 800);

                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                            W8_app.Content = "b1 = (1·a0) ⊕ (2·a1) ⊕ (3·a2) ⊕ (1·a3)";
                            W8_app.BeginAnimation(OpacityProperty, oopac);
                            change_color(mix_1, "#FFFFFF", 800);
                            change_color(mix_2, "#FFFFFF", 800);
                            change_color(mix_3, "#FFFFFF", 800);
                            change_color(mix_4, "#FFFFFF", 800);
                            change_color(mix_5, "#FF0000", 800);
                            change_color(mix_6, "#FF0000", 800);
                            change_color(mix_7, "#FF0000", 800);
                            change_color(mix_8, "#FF0000", 800);
                            con1 = matrix_r[5].Content.ToString();
                            matrix_r[5].Content = "b1";
                        });
                    }; tt4.Start();
                    activeTimers.Add(tt4);
                    System.Timers.Timer tt5 = new System.Timers.Timer(17000);
                    tt5.AutoReset = false;
                    tt5.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a0 = con.ToString();
                            string a1 = con1.ToString();
                            string a2 = matrix_r[10].Content.ToString();
                            string a3 = matrix_r[15].Content.ToString();
                            byte a_0 = byte.Parse(a0);
                            byte a_1 = byte.Parse(a1);
                            byte a_2 = byte.Parse(a2);
                            byte a_3 = byte.Parse(a3);

                            byte b1 = (byte)(a_0 ^ Mul2(a_1) ^ Mul3(a_2) ^ a_3);
                            matrix_r[5].Content = b1.ToString();
                            change_color(matrix_r[5], "#00FF9C", 800);

                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                            W8_app.Content = "b2 = (1·a0) ⊕ (1·a1) ⊕ (2·a2) ⊕ (3·a3)";
                            W8_app.BeginAnimation(OpacityProperty, oopac);
                            change_color(mix_5, "#FFFFFF", 800);
                            change_color(mix_6, "#FFFFFF", 800);
                            change_color(mix_7, "#FFFFFF", 800);
                            change_color(mix_8, "#FFFFFF", 800);
                            change_color(mix_9, "#FF0000", 800);
                            change_color(mix_10, "#FF0000", 800);
                            change_color(mix_11, "#FF0000", 800);
                            change_color(mix_12, "#FF0000", 800);
                            con2 = matrix_r[10].Content.ToString();
                            matrix_r[10].Content = "b2";
                        });
                    }; tt5.Start();
                    activeTimers.Add(tt5);

                    System.Timers.Timer tt6 = new System.Timers.Timer(20000);
                    tt6.AutoReset = false;
                    tt6.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a0 = con.ToString();
                            string a1 = con1.ToString();
                            string a2 = con2.ToString();
                            string a3 = matrix_r[15].Content.ToString();
                            byte a_0 = byte.Parse(a0);
                            byte a_1 = byte.Parse(a1);
                            byte a_2 = byte.Parse(a2);
                            byte a_3 = byte.Parse(a3);

                            byte b2 = (byte)(a_0 ^ a_1 ^ Mul2(a_2) ^ Mul3(a_3));
                            matrix_r[10].Content = b2.ToString();
                            change_color(matrix_r[10], "#00FF9C", 800);

                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                            W8_app.Content = "b3 = (3·a0) ⊕ (1·a1) ⊕ (1·a2) ⊕ (2·a3)";
                            W8_app.BeginAnimation(OpacityProperty, oopac);
                            change_color(mix_9, "#FFFFFF", 800);
                            change_color(mix_10, "#FFFFFF", 800);
                            change_color(mix_11, "#FFFFFF", 800);
                            change_color(mix_12, "#FFFFFF", 800);
                            change_color(mix_13, "#FF0000", 800);
                            change_color(mix_14, "#FF0000", 800);
                            change_color(mix_15, "#FF0000", 800);
                            change_color(mix_16, "#FF0000", 800);
                            con3 = matrix_r[15].Content.ToString();
                            matrix_r[15].Content = "b3";
                        });
                    }; tt6.Start();
                    activeTimers.Add(tt6);
                    System.Timers.Timer tt7 = new System.Timers.Timer(23000);
                    tt7.AutoReset = false;
                    tt7.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a0 = con.ToString();
                            string a1 = con1.ToString();
                            string a2 = con2.ToString();
                            string a3 = con3.ToString();
                            byte a_0 = byte.Parse(a0);
                            byte a_1 = byte.Parse(a1);
                            byte a_2 = byte.Parse(a2);
                            byte a_3 = byte.Parse(a3);

                            byte b3 = (byte)(Mul3(a_0) ^ a_1 ^ a_2 ^ Mul2(a_3));
                            matrix_r[15].Content = b3.ToString();
                            change_color(matrix_r[15], "#00FF9C", 800);

                        });
                    }; tt7.Start();
                    activeTimers.Add(tt7);

                    System.Timers.Timer tt8 = new System.Timers.Timer(26000);
                    tt8.AutoReset = false;
                    tt8.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            change_color(mix_13, "#FFFFFF", 800);
                            change_color(mix_14, "#FFFFFF", 800);
                            change_color(mix_15, "#FFFFFF", 800);
                            change_color(mix_16, "#FFFFFF", 800);
                        });
                    };tt8.Start();
                    activeTimers.Add(tt8);

                    System.Timers.Timer timi2 = new System.Timers.Timer(31000);
                    timi2.AutoReset = false;
                    timi2.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            W8.Content = "Same with other Columns";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            W8_app.BeginAnimation(OpacityProperty, oopac2);
                            for(int i = 1; i < 16; i++)
                            {
                                if (i % 5 != 0)
                                {
                                    change_color(matrix_r[i],"#FF0000",800);
                                }
                            }
                            
                        });
                    };timi2.Start();
                    activeTimers.Add(timi2);

                    System.Timers.Timer timi3 = new System.Timers.Timer(35000);
                    timi3.AutoReset = false;
                    timi3.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a_0 = matrix_r[1].Content.ToString();
                            string a_1 = matrix_r[6].Content.ToString();
                            string a_2 = matrix_r[11].Content.ToString();
                            string a_3 = matrix_r[12].Content.ToString();

                            byte a0 = byte.Parse(a_0);
                            byte a1 = byte.Parse(a_1);
                            byte a2 = byte.Parse(a_2);
                            byte a3 = byte.Parse(a_3);
                            byte b0 = (byte)(Mul2(a0) ^ Mul3(a1) ^ a2 ^ a3);
                            byte b1 = (byte)(a0 ^ Mul2(a1) ^ Mul3(a2) ^ a3);
                            byte b2 = (byte)(a0 ^ a1 ^ Mul2(a2) ^ Mul3(a3)) ;
                            byte b3 = (byte)(Mul3(a0) ^ a1 ^ a2 ^ Mul2(a3));

                            matrix_r[1].Content = b0.ToString();
                            matrix_r[6].Content = b1.ToString();
                            matrix_r[11].Content = b2.ToString();
                            matrix_r[12].Content = b3.ToString();
                            change_color(matrix_r[1], "#00FF9C", 800);
                            change_color(matrix_r[6], "#00FF9C", 800);
                            change_color(matrix_r[11], "#00FF9C", 800);
                            change_color(matrix_r[12], "#00FF9C", 800);

                        });
                    }; timi3.Start();
                    activeTimers.Add(timi3);

                    System.Timers.Timer timi4 = new System.Timers.Timer(39000);
                    timi4.AutoReset = false;
                    timi4.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a_0 = matrix_r[2].Content.ToString();
                            string a_1 = matrix_r[7].Content.ToString();
                            string a_2 = matrix_r[8].Content.ToString();
                            string a_3 = matrix_r[13].Content.ToString();

                            byte a0 = byte.Parse(a_0);
                            byte a1 = byte.Parse(a_1);
                            byte a2 = byte.Parse(a_2);
                            byte a3 = byte.Parse(a_3);
                            byte b0 = (byte)(Mul2(a0) ^ Mul3(a1) ^ a2 ^ a3);
                            byte b1 = (byte)(a0 ^ Mul2(a1) ^ Mul3(a2) ^ a3);
                            byte b2 = (byte)(a0 ^ a1 ^ Mul2(a2) ^ Mul3(a3));
                            byte b3 = (byte)(Mul3(a0) ^ a1 ^ a2 ^ Mul2(a3));

                            matrix_r[2].Content = b0.ToString();
                            matrix_r[7].Content = b1.ToString();
                            matrix_r[8].Content = b2.ToString();
                            matrix_r[13].Content = b3.ToString();
                            change_color(matrix_r[2], "#00FF9C", 800);
                            change_color(matrix_r[7], "#00FF9C", 800);
                            change_color(matrix_r[8], "#00FF9C", 800);
                            change_color(matrix_r[13], "#00FF9C", 800);

                        });
                    }; timi4.Start();
                    activeTimers.Add(timi4);

                    System.Timers.Timer timi5 = new System.Timers.Timer(43000);
                    timi5.AutoReset = false;
                    timi5.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            string a_0 = matrix_r[3].Content.ToString();
                            string a_1 = matrix_r[4].Content.ToString();
                            string a_2 = matrix_r[9].Content.ToString();
                            string a_3 = matrix_r[14].Content.ToString();

                            byte a0 = byte.Parse(a_0);
                            byte a1 = byte.Parse(a_1);
                            byte a2 = byte.Parse(a_2);
                            byte a3 = byte.Parse(a_3);
                            byte b0 = (byte)(Mul2(a0) ^ Mul3(a1) ^ a2 ^ a3);
                            byte b1 = (byte)(a0 ^ Mul2(a1) ^ Mul3(a2) ^ a3);
                            byte b2 = (byte)(a0 ^ a1 ^ Mul2(a2) ^ Mul3(a3));
                            byte b3 = (byte)(Mul3(a0) ^ a1 ^ a2 ^ Mul2(a3));

                            matrix_r[3].Content = b0.ToString();
                            matrix_r[4].Content = b1.ToString();
                            matrix_r[9].Content = b2.ToString();
                            matrix_r[14].Content = b3.ToString();
                            change_color(matrix_r[3], "#00FF9C", 800);
                            change_color(matrix_r[4], "#00FF9C", 800);
                            change_color(matrix_r[9], "#00FF9C", 800);
                            change_color(matrix_r[14], "#00FF9C", 800);

                        });
                    }; timi5.Start();
                    activeTimers.Add(timi5);
                });
            };
            timi.Start();
            activeTimers.Add(timi);

            System.Timers.Timer timi10 = new System.Timers.Timer(250000);
            timi10.AutoReset = false;
            timi10.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach(Label mix_lbl in matrix_mix)
                    {
                        mix_lbl.BeginAnimation(OpacityProperty, oopac2);
                    }
                    symbol.BeginAnimation(OpacityProperty, oopac2);
                    a_0.BeginAnimation(OpacityProperty, oopac2);
                    a_1.BeginAnimation(OpacityProperty, oopac2);
                    a_2.BeginAnimation(OpacityProperty, oopac2);
                    a_3.BeginAnimation(OpacityProperty, oopac2);
                    mix.BeginAnimation(OpacityProperty, oopac2);
                    title_matrix.BeginAnimation(OpacityProperty, oopac2);
                    title_matrix.Content = "Round key 1 = W[4] W[5] W[6] W[7]";
                    title_matrix.BeginAnimation(OpacityProperty, oopac);
                    change_color(info_mix, "#F0F8FF", 800);
                    change_color(info_add, "#22C55E", 800);
                    W8.BeginAnimation(OpacityProperty, oopac2);
                    System.Timers.Timer tim = new System.Timers.Timer(4000);
                    tim.AutoReset = false;
                    tim.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            W8.BeginAnimation(OpacityProperty, oopac);
                            W8.Content = "W[4] = [ " + string.Join(", ",lst[4])+" ]";
                            change_color(matrix_r[0],"#FF0000",800);
                            change_color(matrix_r[2], "#FF0000", 800);
                            change_color(matrix_r[1], "#FF0000", 800);
                            change_color(matrix_r[3], "#FF0000", 800);
                            mix.Content = "\nRow0 ⊕ W4\tRow1 ⊕ W5\nRow2 ⊕ W6\tRow3 ⊕ W7";
                            mix.BeginAnimation(OpacityProperty, oopac);

                        });
                    };
                    tim.Start();
                    activeTimers.Add(tim);
                    System.Timers.Timer tim2 = new System.Timers.Timer(8000);
                    tim2.AutoReset = false;
                    tim2.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            
                            change_color(matrix_r[4], "#FF0000", 800);
                            change_color(matrix_r[5], "#FF0000", 800);
                            change_color(matrix_r[6], "#FF0000", 800);
                            change_color(matrix_r[7], "#FF0000", 800);

                            change_color(matrix_r[0], "#FFFFFF", 800);
                            change_color(matrix_r[1], "#FFFFFF", 800);
                            change_color(matrix_r[3], "#FFFFFF", 800);
                            change_color(matrix_r[2], "#FFFFFF", 800);
                            W8.Content = "W[5] = [ " + string.Join(", ", lst[5]) + " ]";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            byte a = byte.Parse(matrix_r[0].Content.ToString());
                            byte b = byte.Parse(matrix_r[1].Content.ToString());
                            byte c = byte.Parse(matrix_r[2].Content.ToString());
                            byte d = byte.Parse(matrix_r[3].Content.ToString());


                            matrix_r[0].Content = (a ^ words_4_7[0]).ToString();
                            matrix_r[1].Content = (b ^ words_4_7[1]).ToString();
                            matrix_r[2].Content = (c ^ words_4_7[2]).ToString();
                            matrix_r[3].Content = (d ^ words_4_7[3]).ToString();

                        });
                    };
                    tim2.Start();
                    activeTimers.Add(tim2);
                    System.Timers.Timer tim3 = new System.Timers.Timer(12000);
                    tim3.AutoReset = false;
                    tim3.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {

                            change_color(matrix_r[8], "#FF0000", 800);
                            change_color(matrix_r[9], "#FF0000", 800);
                            change_color(matrix_r[10], "#FF0000", 800);
                            change_color(matrix_r[11], "#FF0000", 800);

                            change_color(matrix_r[4], "#FFFFFF", 800);
                            change_color(matrix_r[5], "#FFFFFF", 800);
                            change_color(matrix_r[6], "#FFFFFF", 800);
                            change_color(matrix_r[7], "#FFFFFF", 800);
                            W8.Content = "W[6] = [ " + string.Join(", ", lst[6]) + " ]";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            byte a = byte.Parse(matrix_r[4].Content.ToString());
                            byte b = byte.Parse(matrix_r[5].Content.ToString());
                            byte c = byte.Parse(matrix_r[6].Content.ToString());
                            byte d = byte.Parse(matrix_r[7].Content.ToString());


                            matrix_r[4].Content = (a ^ words_4_7[7]).ToString();
                            matrix_r[5].Content = (b ^ words_4_7[4]).ToString();
                            matrix_r[6].Content = (c ^ words_4_7[5]).ToString();
                            matrix_r[7].Content = (d ^ words_4_7[6]).ToString();

                        });
                    };
                    tim3.Start();
                    activeTimers.Add(tim3);
                    System.Timers.Timer tim4 = new System.Timers.Timer(16000);
                    tim4.AutoReset = false;
                    tim4.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {

                            change_color(matrix_r[12], "#FF0000", 800);
                            change_color(matrix_r[13], "#FF0000", 800);
                            change_color(matrix_r[14], "#FF0000", 800);
                            change_color(matrix_r[15], "#FF0000", 800);

                            change_color(matrix_r[8], "#FFFFFF", 800);
                            change_color(matrix_r[9], "#FFFFFF", 800);
                            change_color(matrix_r[10], "#FFFFFF", 800);
                            change_color(matrix_r[11], "#FFFFFF", 800);
                            W8.Content = "W[7] = [ " + string.Join(", ", lst[7]) + " ]";
                            W8.BeginAnimation(OpacityProperty, oopac);
                            byte a = byte.Parse(matrix_r[8].Content.ToString());
                            byte b = byte.Parse(matrix_r[9].Content.ToString());
                            byte c = byte.Parse(matrix_r[10].Content.ToString());
                            byte d = byte.Parse(matrix_r[11].Content.ToString());


                            matrix_r[8].Content = (a ^ words_4_7[10]).ToString();
                            matrix_r[9].Content = (b ^ words_4_7[11]).ToString();
                            matrix_r[10].Content = (c ^ words_4_7[8]).ToString();
                            matrix_r[11].Content = (d ^ words_4_7[9]).ToString();

                        });
                    };
                    tim4.Start();
                    activeTimers.Add(tim4);
                    System.Timers.Timer tim5 = new System.Timers.Timer(20000);
                    tim5.AutoReset = false;
                    tim5.Elapsed += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {

                            

                            change_color(matrix_r[12], "#FFFFFF", 800);
                            change_color(matrix_r[13], "#FFFFFF", 800);
                            change_color(matrix_r[14], "#FFFFFF", 800);
                            change_color(matrix_r[15], "#FFFFFF", 800);
                            
                            W8.BeginAnimation(OpacityProperty, oopac2);
                            byte a = byte.Parse(matrix_r[12].Content.ToString());
                            byte b = byte.Parse(matrix_r[13].Content.ToString());
                            byte c = byte.Parse(matrix_r[14].Content.ToString());
                            byte d = byte.Parse(matrix_r[15].Content.ToString());


                            matrix_r[12].Content = (a ^ words_4_7[13]).ToString();
                            matrix_r[13].Content = (b ^ words_4_7[14]).ToString();
                            matrix_r[14].Content = (c ^ words_4_7[15]).ToString();
                            matrix_r[15].Content = (d ^ words_4_7[12]).ToString();

                        });
                    };
                    tim5.Start();
                    activeTimers.Add(tim5);

                });
            };
            timi10.Start();
            activeTimers.Add(timi10);


            
        }

        public void action7()
        {
            foreach (var time in activeTimers)
            {
                time.Stop();
                time.Dispose();
            }
            activeTimers.Clear();
            DoubleAnimation oopac = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            DoubleAnimation oopac2 = new DoubleAnimation
            {

                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(1200)
            };
            List<Label> matrix_r = new List<Label> { r_1, r_2, r_3, r_4, r_5, r_6, r_7, r_8, r_9, r_10, r_11, r_12, r_13, r_14, r_15, r_16 };

            skip_btn.Content = "End";
            move(encr_steps_Copy1, "0,161,0,0", "0,54,0,0", 1000);
            move(encr_steps_Copy2, "0,54,0,0", "0,-54,0,0", 1000);
            change_color(encr_steps_Copy1, "#22C55E", 1100);
            foreach (Label l in matrix_r)
            {
                l.BeginAnimation(OpacityProperty, oopac2);
            }
            title_matrix.BeginAnimation(OpacityProperty, oopac2);
            info_sub.BeginAnimation(OpacityProperty, oopac2);

            info_shif.BeginAnimation(OpacityProperty, oopac2);

            info_add.BeginAnimation(OpacityProperty, oopac2);

            info_mix.BeginAnimation(OpacityProperty, oopac2);

            mix.BeginAnimation(OpacityProperty, oopac2);
            info.BeginAnimation(OpacityProperty, oopac2);
            info.Content = "The final round of AES encryption is slightly different from \n" +
            "the previous rounds. For each 16-byte block, the state matrix\n" +
            "undergoes SubBytes, where every byte is replaced using the \nAES " +
            "S-box, followed by ShiftRows, which cyclically shifts the \nrows to " +
            "the left by 0, 1, 2, and 3 positions for rows 0 to 3, \n" +
            "respectively. Finally, the AddRoundKey operation combines the \n" +
            "state with the final round key using a bitwise XOR. Notably, \n" +
            "MixColumns is omitted in this last round, which differentiates \n" +
            "it from the earlier rounds. After completing these steps, the \n" +
            "resulting state matrix represents the cipher text for that block. \n" +
            "This process is repeated for each 16-byte block of the input \n" +
            "message until the entire plaintext is fully encrypted.";
            info.BeginAnimation(OpacityProperty, oopac);

            System.Timers.Timer final = new System.Timers.Timer(30000);
            final.AutoReset = false;
            final.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    encr_steps.Visibility = Visibility.Hidden;
                    encr_steps_Copy1.Visibility = Visibility.Hidden;
                    encr_steps_Copy2.Visibility = Visibility.Hidden;
                    encr_steps_Copy3.Visibility = Visibility.Hidden;
                    encr_steps_Copy4.Visibility = Visibility.Hidden;
                    move(encr_steps_Copy1, "0,54,0,0", "0,377,0,0", 1000);
                    move(encr_steps_Copy2, "0,54,0,0", "0,323,0,0", 1000);
                    move(encr_steps_Copy3, "0,54,0,0", "0,269,0,0", 1000);
                    move(encr_steps_Copy4, "0,54,0,0", "0,215,0,0", 1000);
                    move(encr_steps, "0,54,0,0", "0,161,0,0", 1000);
                    change_color(encr_steps, "#FFFFFF", 200);
                    change_color(encr_steps_Copy1, "#FFFFFF", 200);
                    change_color(encr_steps_Copy2, "#FFFFFF", 200);
                    change_color(encr_steps_Copy3, "#FFFFFF", 200);
                    change_color(encr_steps_Copy4, "#FFFFFF", 200);
                    Entry.Visibility = Visibility.Hidden;
                    info.Visibility = Visibility.Hidden;

                    arrow.Visibility = Visibility.Visible;
                    ScaleTransform scale = new ScaleTransform(1.0, 1.0);
                    RotateTransform rotate = new RotateTransform(180);

                    TransformGroup group = new TransformGroup();
                    group.Children.Add(scale);
                    group.Children.Add(rotate);

                    arrow.RenderTransform = group;


                    DoubleAnimation scaleAnim = new DoubleAnimation
                    {
                        From = 30.0,
                        To = 1.0,
                        Duration = TimeSpan.FromMilliseconds(800),
                        FillBehavior = FillBehavior.HoldEnd
                    };
                    DoubleAnimation scaleAnim2 = new DoubleAnimation
                    {
                        From = 30.0,
                        To = 1.0,
                        Duration = TimeSpan.FromMilliseconds(800),
                        FillBehavior = FillBehavior.HoldEnd
                    };

                    skipping = 0;
                    scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                    scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim2);
                    skip_btn.Content = "Skip";

                    string password = "password@1010^";
                    if (password_field.IsReadOnly == false)
                    {
                        password = password_field.Text;
                    }
                    string text = input_field.Text;
                    encrypted_field.Text = encrypt(password,text);
                });
            };final.Start();
            activeTimers.Add(final);
        }
        static byte Mul2(byte x)
        {
            return (byte)((x << 1) ^ ((x & 0x80) != 0 ? 0x1B : 0x00));
        }

        
        static byte Mul3(byte x)
        {
            return (byte)(Mul2(x) ^ x);
        }
        public string RotWord(byte[] w)
        {
            byte[] roted = new byte[] { w[1], w[2], w[3], w[0] };
            return "[ "+string.Join(", ",roted)+" ]";
        }
        public byte[] RotWord_2(byte[] w)
        {
            byte[] roted = new byte[] { w[1], w[2], w[3], w[0] };
            return roted;
        }


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
        public void vibrate()
        {
            Thickness start = new Thickness(667, 334, 0, 0);
            System.Timers.Timer timing_s = new System.Timers.Timer(4000);
            timing_s.AutoReset = false;
            timing_s.Elapsed += (s, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
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
                });
            }; timing_s.Start();
            activeTimers.Add(timing_s);
            HMAC.Margin = start;


        }
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
                result[16] = 80;
                for (int i = 17; i < 32; i++)
                {
                    result[i] = (byte)(0);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                result[c.Length] = 80;
                for (int i = c.Length + 1; i < 16; i++)
                {
                    result[i] = (byte)(0);
                }
            }
            return result;
        }

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
                    result[i] = (byte)(32);
                }

            }
            else
            {
                result = new byte[16];
                Array.Copy(c, 0, result, 0, c.Length);
                for (int i = c.Length; i < 16; i++)
                {
                    result[i] = (byte)(32);
                }
            }
            return result;
        }

        public byte[] pad5(byte[] c)
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
                    Random n = new Random();
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
                    Random n = new Random();
                    int next = n.Next(0, 256);
                    result[i] = (byte)(next);
                }
            }
            return result;
        }


        public async void Button_Click(object sender, RoutedEventArgs e)
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
            else
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


                scaleAnim.Completed += (s, e) =>
                {
                    Entry.Visibility = Visibility.Visible;
                    DoubleAnimation oopac = new DoubleAnimation
                    {
                        From = 0.0,
                        To = 1.0,
                        Duration = TimeSpan.FromMilliseconds(1000),
                    };
                    DoubleAnimation oopac2 = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 0.0,
                        Duration = TimeSpan.FromMilliseconds(1000),
                    };
                    intro.BeginAnimation(OpacityProperty, oopac);
                    intro.Visibility = Visibility.Visible;
                    
                    timing2 = new System.Timers.Timer(20000);
                    timing2.AutoReset = false;
                    timing2.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {


                            action0();
                            skipping += 1;

                            
                        }
                        );

                    };
                    timing2.Start();
                    timers.Add(timing2);
                    timing3 = new System.Timers.Timer(35000);
                    timing3.AutoReset = false;
                    timing3.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action1();
                            
                        });
                    };
                    timing3.Start();
                    timers.Add(timing3);
                    timing4 = new System.Timers.Timer(75000);
                    timing4.AutoReset = false;
                    timing4.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action2();
                            
                        });
                    }; timing4.Start();
                    timers.Add(timing4);
                    timing5 = new System.Timers.Timer(105000);
                    timing5.AutoReset = false;
                    timing5.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            actions3();
                            
                        });
                    }; timing5.Start();
                    timers.Add(timing5);
                    timing6 = new System.Timers.Timer(155000);
                    timing6.AutoReset = false;
                    timing6.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action4();
                            
                            
                        });
                    }; timing6.Start();
                    timers.Add(timing6);
                    timing7 = new System.Timers.Timer(260000);
                    timing7.AutoReset = false;
                    timing7.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action5();
                            
                        });
                    }; timing7.Start();
                    timers.Add(timing7);
                    
                    timing9 = new System.Timers.Timer(676000);
                    timing9.AutoReset = false;
                    timing9.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action6();
                        });
                    }; timing9.Start();
                    timers.Add(timing9);
                    timing = new System.Timers.Timer(952000);
                    timing.AutoReset = false;
                    timing.Elapsed += (s, e) =>
                    {
                        System.Windows.Application.Current.Dispatcher.Invoke(() =>
                        {
                            skipping += 1;
                            action7();
                        });
                    }; timing.Start();
                    timers.Add(timing);
                    

                };

                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim2);


            }
        }

        
        public void Skipping_btn(object sender, EventArgs e)
        {
            if (skipping < 8)
            {
                foreach (System.Timers.Timer t in timers)
                {
                    t.Stop();
                    
                }

                functions[skipping]();
                skipping += 1;
            }else 
            {
                encr_steps.Visibility = Visibility.Hidden;
                encr_steps_Copy1.Visibility = Visibility.Hidden;
                encr_steps_Copy2.Visibility = Visibility.Hidden;
                encr_steps_Copy3.Visibility = Visibility.Hidden;
                encr_steps_Copy4.Visibility = Visibility.Hidden;
                change_color(encr_steps, "#FFFFFF", 200);
                change_color(encr_steps_Copy1, "#FFFFFF", 200);
                change_color(encr_steps_Copy2, "#FFFFFF", 200);
                change_color(encr_steps_Copy3, "#FFFFFF", 200);
                change_color(encr_steps_Copy4, "#FFFFFF", 200);
                move(encr_steps_Copy1, "0,54,0,0", "0,377,0,0", 1000);
                move(encr_steps_Copy2, "0,54,0,0", "0,323,0,0", 1000);
                move(encr_steps_Copy3, "0,54,0,0", "0,269,0,0", 1000);
                move(encr_steps_Copy4, "0,54,0,0", "0,215,0,0", 1000);
                move(encr_steps, "0,54,0,0", "0,161,0,0", 1000);
                Entry.Visibility = Visibility.Hidden;
                info.Visibility = Visibility.Hidden;

                arrow.Visibility = Visibility.Visible;
                ScaleTransform scale = new ScaleTransform(1.0, 1.0);
                RotateTransform rotate = new RotateTransform(180);

                TransformGroup group = new TransformGroup();
                group.Children.Add(scale);
                group.Children.Add(rotate);

                arrow.RenderTransform = group;


                DoubleAnimation scaleAnim = new DoubleAnimation
                {
                    From = 30.0,
                    To = 1.0,
                    Duration = TimeSpan.FromMilliseconds(800),
                    FillBehavior = FillBehavior.HoldEnd
                };
                DoubleAnimation scaleAnim2 = new DoubleAnimation
                {
                    From = 30.0,
                    To = 1.0,
                    Duration = TimeSpan.FromMilliseconds(800),
                    FillBehavior = FillBehavior.HoldEnd
                };

                skipping = 0;
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim2);
                skip_btn.Content = "Skip";
                timers.Clear();

                string password = "password@1010^";
                if (password_field.IsReadOnly == false)
                {
                    password = password_field.Text;
                }
                string text = input_field.Text;
                encrypted_field.Text = encrypt(password, text);
                return;
            }


                List<int> timing = new List<int> { };
            if (skipping == 1)
            {
                timing = new List<int> { 15000, 55000, 85000, 135000, 240000, 656000 ,932000};

                
                
            }else if (skipping == 2)
            {
                timing = new List<int> { 40000, 70000, 120000, 225000, 641000 ,917000};



            }
            else if (skipping == 3)
            {
                timing = new List<int> { 30000, 80000, 185000, 601000 ,877000};



            }
            else if (skipping == 4)
            {
                timing = new List<int> {50000, 155000, 571000 ,847000};



            }
            else if (skipping == 5)
            {
                timing = new List<int> {105000,521000 ,797000};



            }
            else if (skipping == 6)
            {
                timing = new List<int> {416000 ,692000};


            }
            else if (skipping == 7)
            {
                timing = new List<int> { 276000 };


            }
            for (int i = skipping; i < timers.Count ; i++)
                {
                    timers[i].Interval = timing[i - skipping];
                    timers[i].Start();
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
        public void opacity_anim(FrameworkElement button, double x, double y, Button btn = null, int d =400)
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
                Duration = TimeSpan.FromMilliseconds(d)
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

            if (choice != "text")
            {
                encrypted_field.IsReadOnly = true;
            }
            ;
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
                    }
                    ;

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
                    errorLabel.Content = "Error reading file";
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
        public void Timer_text(Label lbl, String text)
        {
            lbl.Content = text;

        }

        public void animate(Label label, int x, int y, int t)
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
        public void Lock_Hovered(object sender, MouseEventArgs e)
        {
            Lock.RenderTransformOrigin = new Point(0.5, 0.5);
            Lock.RenderTransform = new ScaleTransform(1, 1);
            DoubleAnimation scale = new DoubleAnimation
            {

                To = 1.3,
                Duration = TimeSpan.FromMilliseconds(400)
            };

            ((ScaleTransform)Lock.RenderTransform).BeginAnimation(ScaleTransform.ScaleXProperty, scale);
            ((ScaleTransform)Lock.RenderTransform).BeginAnimation(ScaleTransform.ScaleYProperty, scale);
        }

        public void Lock_unHovered(object sender, MouseEventArgs e)
        {
            DoubleAnimation scale2 = new DoubleAnimation
            {
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(400)
            };

            ((ScaleTransform)Lock.RenderTransform).BeginAnimation(ScaleTransform.ScaleYProperty, scale2);
            ((ScaleTransform)Lock.RenderTransform).BeginAnimation(ScaleTransform.ScaleXProperty, scale2);
        }

        public void hover_txt(Button btn, String x, int d)
        {
            btn.Content = x;
            btn.FontSize = d;
        }

        public void reset(Dictionary<Button, List<String>> dict)
        {
            DoubleAnimation opac = new DoubleAnimation
            {
                To = 0.0,
                Duration = TimeSpan.FromMilliseconds(400)
            };
            foreach (KeyValuePair<Button, List<String>> k in dict)
            {
                k.Key.BeginAnimation(OpacityProperty, opac);
                opac.Completed += (sender, e) =>
                {
                    k.Key.Visibility = Visibility.Collapsed;
                };
            }
            Encrypted.BeginAnimation(OpacityProperty, opac);

            Decrypted.Visibility = Visibility.Visible;
            Instructions.BeginAnimation(OpacityProperty, opac);
        }
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

            string cursorPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "cursor.cur");
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
