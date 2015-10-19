namespace SpotifyAPI
{
    partial class mainForm
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
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblArtist = new System.Windows.Forms.Label();
            this.pbArtist = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbArtist)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(149, 28);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(100, 20);
            this.txtArtist.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(277, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(12, 35);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(111, 13);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Enter an Artist\'s Name";
            // 
            // pbArtist
            // 
            this.pbArtist.Location = new System.Drawing.Point(12, 75);
            this.pbArtist.Name = "pbArtist";
            this.pbArtist.Size = new System.Drawing.Size(363, 272);
            this.pbArtist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArtist.TabIndex = 3;
            this.pbArtist.TabStop = false;
            this.pbArtist.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pbArtist_LoadCompleted);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 354);
            this.Controls.Add(this.pbArtist);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtArtist);
            this.Name = "mainForm";
            this.Text = "Artist Search";
            ((System.ComponentModel.ISupportInitialize)(this.pbArtist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.PictureBox pbArtist;

    }
}

