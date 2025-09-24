using ComputerGraphicsLab.Entities;
using ComputerGraphicsLab.Enums;

namespace ComputerGraphicsLab
{
    public partial class Form1 : Form
    {
        int curGradus1 = 0;
        int curGradus2 = 0;

        int curScale1 = 0;
        int curScale2 = 0;

        int robotSpeed = 1;

        RotationAxis axis;
        PartOfStick stick;

        Pen pen_gr = new Pen(Color.Green, 4);
        Pen pen_bl = new Pen(Brushes.Black, 4);

        readonly Robot robot;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            robot = new Robot(100, 150, pen_bl, pen_gr);
            textBox1.Text = (trackBar1.Value - 50).ToString();
            trackBar1.Enabled = false;
            textBox1.Enabled = false;
            robot.LimXRight = 530;
            robot.LimXLeft = 10;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            robot.Draw(graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MoveShape(e);
            Invalidate();
        }

        private void MoveShape(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    robot.MoveShape(x: robotSpeed);
                    break;
                case Keys.A:
                    robot.MoveShape(x: -robotSpeed);
                    break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var p = trackBar1.Value - 50;
            textBox1.Text = p.ToString();

            if (axis == RotationAxis.First)
            {
                if (curGradus1 - p < 0)
                    robot.Rotation(axis, 1);
                else
                    robot.Rotation(axis, -1);

                curGradus1 = p;
            }
            else
            {
                if (curGradus2 - p < 0)
                {
                    robot.Rotation(axis, 1);
                }
                else
                {
                    robot.Rotation(axis, -1);
                }

                curGradus2 = p;
            }

            Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            trackBar1.Enabled = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    axis = RotationAxis.First;
                    textBox1.Text = curGradus1.ToString();
                    trackBar1.Value = curGradus1 + 50;
                    break;
                case 1:
                    axis = RotationAxis.Second;
                    textBox1.Text = curGradus2.ToString();
                    trackBar1.Value = curGradus2 + 50;
                    break;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            robotSpeed = trackBar2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("”правление:\na - влево\nd - вправо");
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (stick == PartOfStick.FirstStick)
            {
                if (curScale1 - trackBar3.Value < 0)
                    robot.Scale(20, stick);
                else
                    robot.Scale(-20, stick);
                curScale1 = trackBar3.Value;
            }
            if (stick == PartOfStick.SecondStick)
            {
                if (curScale2 - trackBar3.Value < 0)
                    robot.Scale(20, stick);
                else
                    robot.Scale(-20, stick);
                curScale2 = trackBar3.Value;
            }
            Invalidate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            stick = comboBox2.SelectedIndex switch
            {
                0 => PartOfStick.FirstStick,
                1 => PartOfStick.SecondStick
            };
            if (stick == PartOfStick.FirstStick)
                trackBar3.Value = curScale1;
            if (stick == PartOfStick.SecondStick)
                trackBar3.Value = curScale2;
        }
    }
}
