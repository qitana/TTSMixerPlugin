namespace Qitana.TTSMixerPlugin
{
    partial class AudioDeviceConfigControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioDeviceConfigControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonPlaybackEnqueue = new System.Windows.Forms.RadioButton();
            this.radioButtonPlaybackEnqueuePriority = new System.Windows.Forms.RadioButton();
            this.radioButtonPlaybackImmediately = new System.Windows.Forms.RadioButton();
            this.labelPlaybackMode = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.labelVolumeValue);
            this.groupBox1.Controls.Add(this.labelVolume);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.labelPlaybackMode);
            this.groupBox1.Controls.Add(this.checkBoxEnabled);
            this.groupBox1.Controls.Add(this.trackBarVolume);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // labelVolumeValue
            // 
            resources.ApplyResources(this.labelVolumeValue, "labelVolumeValue");
            this.labelVolumeValue.Name = "labelVolumeValue";
            // 
            // labelVolume
            // 
            resources.ApplyResources(this.labelVolume, "labelVolume");
            this.labelVolume.Name = "labelVolume";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonPlaybackEnqueue);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonPlaybackEnqueuePriority);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonPlaybackImmediately);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonPlaybackEnqueue
            // 
            resources.ApplyResources(this.radioButtonPlaybackEnqueue, "radioButtonPlaybackEnqueue");
            this.radioButtonPlaybackEnqueue.Name = "radioButtonPlaybackEnqueue";
            this.radioButtonPlaybackEnqueue.TabStop = true;
            this.radioButtonPlaybackEnqueue.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlaybackEnqueuePriority
            // 
            resources.ApplyResources(this.radioButtonPlaybackEnqueuePriority, "radioButtonPlaybackEnqueuePriority");
            this.radioButtonPlaybackEnqueuePriority.Name = "radioButtonPlaybackEnqueuePriority";
            this.radioButtonPlaybackEnqueuePriority.TabStop = true;
            this.radioButtonPlaybackEnqueuePriority.UseVisualStyleBackColor = true;
            // 
            // radioButtonPlaybackImmediately
            // 
            resources.ApplyResources(this.radioButtonPlaybackImmediately, "radioButtonPlaybackImmediately");
            this.radioButtonPlaybackImmediately.Name = "radioButtonPlaybackImmediately";
            this.radioButtonPlaybackImmediately.TabStop = true;
            this.radioButtonPlaybackImmediately.UseVisualStyleBackColor = true;
            // 
            // labelPlaybackMode
            // 
            resources.ApplyResources(this.labelPlaybackMode, "labelPlaybackMode");
            this.labelPlaybackMode.Name = "labelPlaybackMode";
            // 
            // checkBoxEnabled
            // 
            resources.ApplyResources(this.checkBoxEnabled, "checkBoxEnabled");
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // trackBarVolume
            // 
            resources.ApplyResources(this.trackBarVolume, "trackBarVolume");
            this.trackBarVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.TickFrequency = 10;
            // 
            // AudioDeviceConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Name = "AudioDeviceConfigControl";
            resources.ApplyResources(this, "$this");
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Label labelPlaybackMode;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonPlaybackEnqueue;
        private System.Windows.Forms.RadioButton radioButtonPlaybackEnqueuePriority;
        private System.Windows.Forms.RadioButton radioButtonPlaybackImmediately;
        private System.Windows.Forms.Label labelVolumeValue;
    }
}
