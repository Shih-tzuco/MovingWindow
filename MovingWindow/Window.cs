using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
    public partial class Window : Form
    { 
        private string button_Direction;
        private int width = Screen.PrimaryScreen.Bounds.Width;
        private int height = Screen.PrimaryScreen.Bounds.Height;
        private int step = 6;

        public Window()
        {
            InitializeComponent();
        }

        private void Press_Down(object sender, EventArgs e)
        {
            if (button_Direction == "Down")
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
                    Key_Code(Keys.Up);
                }
            }
            else if (button_Direction == "Up")
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
                    Key_Code(Keys.Down);
                }
            }
            else if (button_Direction == "Right")
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
                    Key_Code(Keys.Left);
                }
            }
            else if (button_Direction == "Left")
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
                    Key_Code(Keys.Right);
                }
            }
        }

        private void Key_Code(Keys key)
        {
            timer.Start();
            switch (key)
            {
                case Keys.Down:
                    button_Direction = "Down";
                    break;
                case Keys.Up:
                    button_Direction = "Up";
                    break;
                case Keys.Right:
                    button_Direction = "Right";
                    break;
                case Keys.Left:
                    button_Direction = "Left";
                    break;
                case Keys.Enter:
                    timer.Stop();
                    CenterToScreen();
                    break;
            }
        }

        private void Key_Pressed(object sender, KeyEventArgs e)
        {
            Key_Code(e.KeyCode);
        }
    }
}