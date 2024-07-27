namespace Qitana.TTSMixerPlugin.Providers
{
    partial class MicrosoftSpeechSynthesizerConfigPanel
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
            this.labelVoiceName = new System.Windows.Forms.Label();
            this.comboBoxVoiceName = new System.Windows.Forms.ComboBox();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelRate = new System.Windows.Forms.Label();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.labelRateValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVoiceName
            // 
            this.labelVoiceName.AutoSize = true;
            this.labelVoiceName.Location = new System.Drawing.Point(8, 10);
            this.labelVoiceName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelVoiceName.Name = "labelVoiceName";
            this.labelVoiceName.Size = new System.Drawing.Size(67, 12);
            this.labelVoiceName.TabIndex = 0;
            this.labelVoiceName.Text = "Voice Name";
            // 
            // comboBoxVoiceName
            // 
            this.comboBoxVoiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoiceName.FormattingEnabled = true;
            this.comboBoxVoiceName.Location = new System.Drawing.Point(10, 25);
            this.comboBoxVoiceName.Name = "comboBoxVoiceName";
            this.comboBoxVoiceName.Size = new System.Drawing.Size(349, 20);
            this.comboBoxVoiceName.TabIndex = 1;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(8, 58);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(43, 12);
            this.labelVolume.TabIndex = 2;
            this.labelVolume.Text = "Volume";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(8, 73);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(310, 45);
            this.trackBarVolume.SmallChange = 5;
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.TickFrequency = 5;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(8, 109);
            this.labelRate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(29, 12);
            this.labelRate.TabIndex = 4;
            this.labelRate.Text = "Rate";
            // 
            // trackBarRate
            // 
            this.trackBarRate.LargeChange = 2;
            this.trackBarRate.Location = new System.Drawing.Point(10, 124);
            this.trackBarRate.Minimum = -10;
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(227, 45);
            this.trackBarRate.TabIndex = 0;
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(322, 73);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Size = new System.Drawing.Size(23, 12);
            this.labelVolumeValue.TabIndex = 5;
            this.labelVolumeValue.Text = "100";
            // 
            // labelRateValue
            // 
            this.labelRateValue.AutoSize = true;
            this.labelRateValue.Location = new System.Drawing.Point(243, 124);
            this.labelRateValue.Name = "labelRateValue";
            this.labelRateValue.Size = new System.Drawing.Size(11, 12);
            this.labelRateValue.TabIndex = 6;
            this.labelRateValue.Text = "0";
            // 
            // MicrosoftSpeechSynthesizerConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRateValue);
            this.Controls.Add(this.labelVolumeValue);
            this.Controls.Add(this.trackBarRate);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.comboBoxVoiceName);
            this.Controls.Add(this.labelVoiceName);
            this.Name = "MicrosoftSpeechSynthesizerConfigPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(446, 204);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVoiceName;
        private System.Windows.Forms.ComboBox comboBoxVoiceName;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.Label labelRateValue;
    }
}
