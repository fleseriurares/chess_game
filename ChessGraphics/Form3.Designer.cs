using System.Security.Cryptography.X509Certificates;

namespace ChessGUI
{
    partial class Form3
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
        public Label Label1
        {
            get { return label1; }
        }

        public Label Label2
        {
            get { return label2; }
        }

        public Label Label3
        {
            get { return label3; }
        }

        public Label Label4
        {
            get { return label4; }
        }

        public Label Label5
        {
            get { return label5; }
        }

        public Label Label6
        {
            get { return label6; }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(153, 35);
            label1.TabIndex = 0;
            label1.Text = "Player White";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(220, 35);
            label2.Name = "label2";
            label2.Size = new Size(139, 35);
            label2.TabIndex = 1;
            label2.Text = "PlayerBlack";

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 90);
            label3.Name = "label3";
            label3.Text = "";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 2;

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 90);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 3;
            label4.Text = "Time left:";

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(218, 90);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 4;
            label5.Text = "Time left:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(295, 90);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 5;
            label6.Text = "";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(400, 156);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}