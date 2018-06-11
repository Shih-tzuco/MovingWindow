using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
    public partial class Window : Form
    {
        private const int step = 6;
        private string buttonDirection;
        private int width = Screen.PrimaryScreen.Bounds.Width;
        private int height = Screen.PrimaryScreen.Bounds.Height;

        public Window()
        {
            InitializeComponent();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            KeysCode(e.KeyCode);
        }

        private void KeysCode(Keys key)
        {
            timer.Start();
            switch (key)
            {
                case Keys.Down:
                    buttonDirection = "Down";
                    break;
                case Keys.Up:
                    buttonDirection = "Up";
                    break;
                case Keys.Right:
                    buttonDirection = "Right";
                    break;
                case Keys.Left:
                    buttonDirection = "Left";
                    break;
                case Keys.Enter:
                    timer.Stop();
                    CenterToScreen();
                    break;
            }
        }

        private void Window_PressDown(object sender, EventArgs e)
        {
            if (buttonDirection == "Down")
            {
                if (Location.Y + Height != height)
                {
                    if (Location.Y + step + Height <= height)
                    {
                        Location = new Point(Location.X, Location.Y + step);
                    }
                    else
                    {
                        Location = new Point(Location.X, height - Height);
                    }
                }
                else
                {
                    KeysCode(Keys.Up);
                }
            }
            else if (buttonDirection == "Up")
            {
                if (Location.Y != 0)
                {
                    if (Location.Y - step >= 0)
                    {
                        Location = new Point(Location.X, Location.Y - step);
                    }
                    else
                    {
                        Location = new Point(Location.X, 0);
                    }
                }
                else
                {
                    KeysCode(Keys.Down);
                }
            }
            else if (buttonDirection == "Right")
            {
                if (Location.X + Width != width)
                {
                    if (Location.X + step + Width <= width)
                    {
                        Location = new Point(Location.X + step, Location.Y);
                    }
                    else
                    {
                        Location = new Point(width - Width, Location.Y);
                    }
                }
                else
                {
                    KeysCode(Keys.Left);
                }
            }
            else if (buttonDirection == "Left")
            {
                if (Location.X != 0)
                {
                    if (Location.X - step >= 0)
                    {
                        Location = new Point(Location.X - step, Location.Y);
                    }
                    else
                    {
                        Location = new Point(0, Location.Y);
                    }
                }
                else
                {
                    KeysCode(Keys.Right);
                }
            }
        }
    }
}