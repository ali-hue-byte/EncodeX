using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace EncodeX
{


    public partial class MainWindow : Window
    {
        // Token used to skip the current simulation step
        private CancellationTokenSource _skip = new();

        // Flag to indicate if the key has been obtained
        bool gotten_key = false;

        // App state variables
        string mode = "encrypt";
        string choice = "text";

        // Global variables for the application
        Brush color = Brushes.Green;
        byte[] pu_key = new byte[32];
        byte[] pu_salt = new byte[16];
        List<byte> words_4_7 = new List<byte>();
        string con;  // Used in MixColumns (Simulation)
        string con1;
        string con2;
        string con3;
        List<byte[]> lst = new List<byte[]> { };

        public MainWindow()
        {

            InitializeComponent();
            // Lock button hover effects
            btn_lock.MouseEnter += (s, e) => { Lock_Hovered(s, e); };
            btn_lock.MouseLeave += (s, e) => { Lock_unHovered(s, e); };

            // Matrix components
            Dictionary<Label, List<int>> dict = new Dictionary<Label, List<int>>
        {
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

            timer.Tick += (s, e) =>
            {
                foreach (KeyValuePair<Label, List<int>> label in dict)
                    Timer_text(label.Key, Random_text()); // Updates matrix letters text every 100ms
            };

            foreach (KeyValuePair<Label, List<int>> label in dict)
                animate(label.Key, label.Value[0], label.Value[1], label.Value[2]); // Animates the matrix 

            timer.Start();

            // Shifts UI elements when hovering over the main border
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
                
                errorLabel.BeginAnimation(Canvas.LeftProperty, animX);
            };

            // Shifts UI elements back to their original position when the mouse leaves the main border
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
                
                errorLabel.BeginAnimation(Canvas.LeftProperty, animX2);
            };
        }
    }
}
