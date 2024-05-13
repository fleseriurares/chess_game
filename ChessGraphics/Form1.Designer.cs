namespace ChessGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelStart = new Label();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // labelStart
            // 
            labelStart.BackColor = Color.Transparent;
            labelStart.Dock = DockStyle.Top;
            labelStart.Font = new Font("Segoe UI", 40F);
            labelStart.ForeColor = SystemColors.ButtonHighlight;
            labelStart.ImageAlign = ContentAlignment.TopCenter;
            labelStart.Location = new Point(0, 0);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(582, 122);
            labelStart.TabIndex = 0;
            labelStart.Text = "Chess";
            labelStart.TextAlign = ContentAlignment.MiddleCenter;
         
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.White;
            buttonStart.Font = new Font("Segoe UI", 25F);
            buttonStart.Location = new Point(197, 176);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(161, 71);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.TextAlign = ContentAlignment.TopCenter;
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += ButtonStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(582, 603);
            Controls.Add(buttonStart);
            Controls.Add(labelStart);
            Name = "2PlayerChessGame";
            Text = "2 Player Chess Game";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label labelStart;
        private Button buttonStart;
    }
}
