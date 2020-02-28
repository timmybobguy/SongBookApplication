namespace SongBookApp
{
    partial class SettingsMenu
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
            this.trackBarValue = new System.Windows.Forms.TrackBar();
            this.sliderValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarValue
            // 
            this.trackBarValue.Location = new System.Drawing.Point(138, 159);
            this.trackBarValue.Maximum = 50;
            this.trackBarValue.Minimum = 10;
            this.trackBarValue.Name = "trackBarValue";
            this.trackBarValue.Size = new System.Drawing.Size(104, 45);
            this.trackBarValue.TabIndex = 0;
            this.trackBarValue.Value = 10;
            this.trackBarValue.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // sliderValueLabel
            // 
            this.sliderValueLabel.AutoSize = true;
            this.sliderValueLabel.Location = new System.Drawing.Point(163, 113);
            this.sliderValueLabel.Name = "sliderValueLabel";
            this.sliderValueLabel.Size = new System.Drawing.Size(58, 13);
            this.sliderValueLabel.TabIndex = 1;
            this.sliderValueLabel.Text = "sliderValue";
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 309);
            this.Controls.Add(this.sliderValueLabel);
            this.Controls.Add(this.trackBarValue);
            this.Name = "SettingsMenu";
            this.Text = "SettingsMenu";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarValue;
        private System.Windows.Forms.Label sliderValueLabel;
    }
}