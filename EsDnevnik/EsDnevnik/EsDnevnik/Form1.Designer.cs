namespace EsDnevnik
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sifarniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osobaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skolskaGodinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predmetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raspodelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upisnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odeljenjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = global::EsDnevnik.Properties.Resources.images;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sifarniciToolStripMenuItem,
            this.raspodelaToolStripMenuItem,
            this.upisnicaToolStripMenuItem,
            this.odeljenjaToolStripMenuItem,
            this.oceneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(461, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sifarniciToolStripMenuItem
            // 
            this.sifarniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osobaToolStripMenuItem,
            this.skolskaGodinaToolStripMenuItem,
            this.smerToolStripMenuItem,
            this.predmetToolStripMenuItem});
            this.sifarniciToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.sifarniciToolStripMenuItem.Name = "sifarniciToolStripMenuItem";
            this.sifarniciToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.sifarniciToolStripMenuItem.Text = "Sifarnici";
            // 
            // osobaToolStripMenuItem
            // 
            this.osobaToolStripMenuItem.Name = "osobaToolStripMenuItem";
            this.osobaToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.osobaToolStripMenuItem.Text = "Osoba";
            this.osobaToolStripMenuItem.Click += new System.EventHandler(this.osobaToolStripMenuItem_Click);
            // 
            // skolskaGodinaToolStripMenuItem
            // 
            this.skolskaGodinaToolStripMenuItem.Name = "skolskaGodinaToolStripMenuItem";
            this.skolskaGodinaToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.skolskaGodinaToolStripMenuItem.Text = "Skolska godina";
            this.skolskaGodinaToolStripMenuItem.Click += new System.EventHandler(this.skolskaGodinaToolStripMenuItem_Click);
            // 
            // smerToolStripMenuItem
            // 
            this.smerToolStripMenuItem.Name = "smerToolStripMenuItem";
            this.smerToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.smerToolStripMenuItem.Text = "Smer";
            this.smerToolStripMenuItem.Click += new System.EventHandler(this.smerToolStripMenuItem_Click);
            // 
            // predmetToolStripMenuItem
            // 
            this.predmetToolStripMenuItem.Name = "predmetToolStripMenuItem";
            this.predmetToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.predmetToolStripMenuItem.Text = "Predmet";
            this.predmetToolStripMenuItem.Click += new System.EventHandler(this.predmetToolStripMenuItem_Click);
            // 
            // raspodelaToolStripMenuItem
            // 
            this.raspodelaToolStripMenuItem.Name = "raspodelaToolStripMenuItem";
            this.raspodelaToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.raspodelaToolStripMenuItem.Text = "Raspodela";
            this.raspodelaToolStripMenuItem.Click += new System.EventHandler(this.raspodelaToolStripMenuItem_Click);
            // 
            // upisnicaToolStripMenuItem
            // 
            this.upisnicaToolStripMenuItem.Name = "upisnicaToolStripMenuItem";
            this.upisnicaToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.upisnicaToolStripMenuItem.Text = "Upisnica";
            this.upisnicaToolStripMenuItem.Click += new System.EventHandler(this.upisnicaToolStripMenuItem_Click);
            // 
            // odeljenjaToolStripMenuItem
            // 
            this.odeljenjaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.odeljenjaToolStripMenuItem.Name = "odeljenjaToolStripMenuItem";
            this.odeljenjaToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.odeljenjaToolStripMenuItem.Text = "Odeljenja";
            this.odeljenjaToolStripMenuItem.Click += new System.EventHandler(this.odeljenjaToolStripMenuItem_Click);
            // 
            // oceneToolStripMenuItem
            // 
            this.oceneToolStripMenuItem.Name = "oceneToolStripMenuItem";
            this.oceneToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.oceneToolStripMenuItem.Text = "Ocene";
            this.oceneToolStripMenuItem.Click += new System.EventHandler(this.oceneToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.Image = global::EsDnevnik.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(687, 207);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 157);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "EsDnevnik";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sifarniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skolskaGodinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predmetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odeljenjaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem raspodelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upisnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oceneToolStripMenuItem;
    }
}

