using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace EncodeX
{
    public partial class MainWindow
    {
        // Fade animations used across the app
        public DoubleAnimation oopac = new DoubleAnimation // Fade in (1s)
        {
            From = 0.0,
            To = 1.0,
            Duration = TimeSpan.FromMilliseconds(1000),
        };
        public DoubleAnimation oopac2 = new DoubleAnimation // Fade out (1s)
        {
            From = 1.0,
            To = 0.0,
            Duration = TimeSpan.FromMilliseconds(1000),
        };

        public DoubleAnimation oopac_h = new DoubleAnimation // Fade in (1.8s)
        {
            From = 0.0,
            To = 1.0,
            Duration = TimeSpan.FromMilliseconds(1800)
        };

        // Horizontal slide animations
        public DoubleAnimation animX = new DoubleAnimation // Slide right (300ms)
        {
            From = 339,
            To = 439,
            Duration = TimeSpan.FromMilliseconds(300),
        };

        public DoubleAnimation animX2 = new DoubleAnimation // Slide left (300ms)
        {
            From = 439,
            To = 339,
            Duration = TimeSpan.FromMilliseconds(300),
        };

        // Shifts a UI element 100px to the right
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

        // Moves a UI element to a specific position defined by a margin string
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

        // Moves a UI element from one margin position to another
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

        // Changes the foreground color of an element with an animation
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

        // Animates the opacity of a UI element from x to y, with an optional tooltip handling 
        public void opacity_anim(FrameworkElement button, double x, double y, Button btn = null, int d = 400)
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

        // Used to switch between encrypt and decrypt buttons with a fade animation
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

        }

        // Fades out a TextBox, clears its text, then fades it back in
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


        // Animates a Label's margin to create a vertical movement effect, repeating indefinitely
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
        // Animates the scaling of the Lock button when hovered, creating a zoom-in effect
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

        // Animates the scaling of the Lock button back to its original size when unhovered, creating a zoom-out effect
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

        // Changes the text and font size of a button when hovered, providing visual feedback to the user
        public void hover_txt(Button btn, String x, int d)
        {
            btn.Content = x;
            btn.FontSize = d;
        }

        // Resets the UI by fading out buttons and other elements, then hiding them 
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
    }
}
