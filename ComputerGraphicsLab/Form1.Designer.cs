namespace ComputerGraphicsLab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBar1 = new TrackBar();
            label2 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            trackBar2 = new TrackBar();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(610, 96);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(181, 45);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 50;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.KeyDown += Form1_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(610, 48);
            label2.Name = "label2";
            label2.Size = new Size(161, 15);
            label2.TabIndex = 2;
            label2.Text = "Повернуть деталь(градусы):";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(613, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(40, 23);
            textBox1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Ось вращения (1)", "Ось вращения (2)" });
            comboBox1.Location = new Point(614, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(177, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.KeyDown += Form1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(613, 147);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 5;
            label1.Text = "Скорость робота:";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(614, 165);
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(177, 45);
            trackBar2.TabIndex = 6;
            trackBar2.Value = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            trackBar2.KeyDown += Form1_KeyDown;
            // 
            // button1
            // 
            button1.Location = new Point(716, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Справка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(trackBar2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(trackBar1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            Text = "Компьютерная графика: Робот";
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar trackBar1;
        private Label label2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label1;
        private TrackBar trackBar2;
        private Button button1;
    }
}
