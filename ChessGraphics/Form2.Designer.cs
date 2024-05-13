using ChessModel;
using System.Security.Cryptography;
using static ChessModel.Pieces;
namespace ChessGUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBoxExchange = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExchange).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(192, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(463, 387);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 50);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // pictureBoxExchange
            // 
            pictureBoxExchange.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxExchange.BackColor = Color.DarkOrange;
            pictureBoxExchange.Location = new Point((3) * this.pictureBox1.Width / 8, (4) * this.pictureBox1.Height / 8);
            pictureBoxExchange.Name = "pictureBoxExchange";
            pictureBoxExchange.Size = new Size(this.pictureBox1.Width / 2, this.pictureBox1.Width / 8);
            pictureBoxExchange.TabIndex = 1;
            pictureBoxExchange.TabStop = false;
            //pictureBoxExchange.Visible = false;
            //pictureBoxExchange.Enabled = false;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.queen_white;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(358, 240);
            button1.Name = "button1";
            button1.Size = new Size(49, 52);
            button1.TabIndex = 2;
           // button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Parent = pictureBoxExchange;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.rook_white;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(403, 240);
            button2.Name = "button2";
            button2.Size = new Size(54, 52);
            button2.TabIndex = 3;
         //   button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Parent = pictureBoxExchange;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.bishop_white;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(451, 240);
            button3.Name = "button3";
            button3.Size = new Size(49, 52);
            button3.TabIndex = 4;
           // button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Parent = pictureBoxExchange;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.knight_white;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Location = new Point(497, 240);
            button4.Name = "button4";
            button4.Size = new Size(38, 52);
            button4.TabIndex = 5;
           // button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Parent = pictureBoxExchange;
            button4.Click += Button4_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(700, 850);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBoxExchange);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "2 Player Chess Game";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExchange).EndInit();
            ResumeLayout(false);
        }

        private void Button1_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox1;

        private PictureBox pictureBox3;
        public Tuple<Pieces, PictureBox>[] pieces;
        private PictureBox[] pictureBoxArray;
        private PictureBox pictureBoxExchange;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}