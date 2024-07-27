namespace Qitana.TTSMixerPlugin.Providers
{
    partial class AzureAISpeechConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxVoice = new System.Windows.Forms.ComboBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.textBoxRegion = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonSetCredentials = new System.Windows.Forms.Button();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.labelVoice = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelRate = new System.Windows.Forms.Label();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.labelPitch = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.labelRateValue = new System.Windows.Forms.Label();
            this.labelPitchValue = new System.Windows.Forms.Label();
            this.groupBoxCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxVoice
            // 
            this.comboBoxVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoice.FormattingEnabled = true;
            this.comboBoxVoice.Location = new System.Drawing.Point(6, 36);
            this.comboBoxVoice.Name = "comboBoxVoice";
            this.comboBoxVoice.Size = new System.Drawing.Size(292, 20);
            this.comboBoxVoice.TabIndex = 0;
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(8, 23);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(40, 12);
            this.labelRegion.TabIndex = 1;
            this.labelRegion.Text = "Region";
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegion.Location = new System.Drawing.Point(70, 20);
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.ReadOnly = true;
            this.textBoxRegion.Size = new System.Drawing.Size(190, 19);
            this.textBoxRegion.TabIndex = 2;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(8, 48);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(24, 12);
            this.labelKey.TabIndex = 3;
            this.labelKey.Text = "Key";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKey.Location = new System.Drawing.Point(70, 45);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.ReadOnly = true;
            this.textBoxKey.Size = new System.Drawing.Size(190, 19);
            this.textBoxKey.TabIndex = 4;
            this.textBoxKey.UseSystemPasswordChar = true;
            // 
            // buttonSetCredentials
            // 
            this.buttonSetCredentials.AutoSize = true;
            this.buttonSetCredentials.Location = new System.Drawing.Point(8, 76);
            this.buttonSetCredentials.Name = "buttonSetCredentials";
            this.buttonSetCredentials.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonSetCredentials.Size = new System.Drawing.Size(102, 25);
            this.buttonSetCredentials.TabIndex = 5;
            this.buttonSetCredentials.Text = "Set Credentials";
            this.buttonSetCredentials.UseVisualStyleBackColor = true;
            this.buttonSetCredentials.Click += new System.EventHandler(this.buttonSetCredentials_Click);
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.labelRegion);
            this.groupBoxCredentials.Controls.Add(this.buttonSetCredentials);
            this.groupBoxCredentials.Controls.Add(this.labelKey);
            this.groupBoxCredentials.Controls.Add(this.textBoxKey);
            this.groupBoxCredentials.Controls.Add(this.textBoxRegion);
            this.groupBoxCredentials.Location = new System.Drawing.Point(335, 8);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxCredentials.Size = new System.Drawing.Size(268, 106);
            this.groupBoxCredentials.TabIndex = 6;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "Credentials";
            // 
            // labelVoice
            // 
            this.labelVoice.AutoSize = true;
            this.labelVoice.Location = new System.Drawing.Point(6, 21);
            this.labelVoice.Name = "labelVoice";
            this.labelVoice.Size = new System.Drawing.Size(34, 12);
            this.labelVoice.TabIndex = 7;
            this.labelVoice.Text = "Voice";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(6, 72);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(43, 12);
            this.labelVolume.TabIndex = 8;
            this.labelVolume.Text = "Volume";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(6, 87);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(253, 45);
            this.trackBarVolume.TabIndex = 9;
            this.trackBarVolume.TickFrequency = 5;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(6, 135);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(29, 12);
            this.labelRate.TabIndex = 10;
            this.labelRate.Text = "Rate";
            // 
            // trackBarRate
            // 
            this.trackBarRate.Location = new System.Drawing.Point(6, 150);
            this.trackBarRate.Maximum = 100;
            this.trackBarRate.Minimum = -50;
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(253, 45);
            this.trackBarRate.TabIndex = 11;
            this.trackBarRate.TickFrequency = 10;
            // 
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(6, 198);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(31, 12);
            this.labelPitch.TabIndex = 12;
            this.labelPitch.Text = "Pitch";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.trackBarPitch);
            this.groupBoxSettings.Controls.Add(this.trackBarRate);
            this.groupBoxSettings.Controls.Add(this.trackBarVolume);
            this.groupBoxSettings.Controls.Add(this.labelPitchValue);
            this.groupBoxSettings.Controls.Add(this.labelRateValue);
            this.groupBoxSettings.Controls.Add(this.labelVolumeValue);
            this.groupBoxSettings.Controls.Add(this.comboBoxVoice);
            this.groupBoxSettings.Controls.Add(this.labelVoice);
            this.groupBoxSettings.Controls.Add(this.labelPitch);
            this.groupBoxSettings.Controls.Add(this.labelRate);
            this.groupBoxSettings.Controls.Add(this.labelVolume);
            this.groupBoxSettings.Location = new System.Drawing.Point(8, 8);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(316, 267);
            this.groupBoxSettings.TabIndex = 13;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Location = new System.Drawing.Point(6, 213);
            this.trackBarPitch.Maximum = 50;
            this.trackBarPitch.Minimum = -50;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Size = new System.Drawing.Size(253, 45);
            this.trackBarPitch.TabIndex = 13;
            this.trackBarPitch.TickFrequency = 5;
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(265, 89);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Size = new System.Drawing.Size(11, 12);
            this.labelVolumeValue.TabIndex = 14;
            this.labelVolumeValue.Text = "0";
            // 
            // labelRateValue
            // 
            this.labelRateValue.AutoSize = true;
            this.labelRateValue.Location = new System.Drawing.Point(265, 150);
            this.labelRateValue.Name = "labelRateValue";
            this.labelRateValue.Size = new System.Drawing.Size(11, 12);
            this.labelRateValue.TabIndex = 15;
            this.labelRateValue.Text = "0";
            // 
            // labelPitchValue
            // 
            this.labelPitchValue.AutoSize = true;
            this.labelPitchValue.Location = new System.Drawing.Point(265, 213);
            this.labelPitchValue.Name = "labelPitchValue";
            this.labelPitchValue.Size = new System.Drawing.Size(11, 12);
            this.labelPitchValue.TabIndex = 16;
            this.labelPitchValue.Text = "0";
            // 
            // AzureAISpeechConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxCredentials);
            this.Name = "AzureAISpeechConfigPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(615, 288);
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVoice;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.TextBox textBoxRegion;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonSetCredentials;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.Label labelVoice;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TrackBar trackBarPitch;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.Label labelPitchValue;
        private System.Windows.Forms.Label labelRateValue;
    }
}
