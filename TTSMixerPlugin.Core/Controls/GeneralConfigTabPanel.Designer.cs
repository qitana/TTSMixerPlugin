namespace Qitana.TTSMixerPlugin
{
    partial class GeneralConfigTabPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralConfigTabPanel));
            this.cbOverrideOriginalPlayTTS = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOverrideOriginalPlaySound = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDefaultProfile = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOverrideOriginalPlayTTS
            // 
            resources.ApplyResources(this.cbOverrideOriginalPlayTTS, "cbOverrideOriginalPlayTTS");
            this.cbOverrideOriginalPlayTTS.Name = "cbOverrideOriginalPlayTTS";
            this.cbOverrideOriginalPlayTTS.UseVisualStyleBackColor = true;
            this.cbOverrideOriginalPlayTTS.CheckedChanged += new System.EventHandler(this.cbOverrideOriginalPlayTTS_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDefaultProfile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbOverrideOriginalPlaySound);
            this.groupBox1.Controls.Add(this.cbOverrideOriginalPlayTTS);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbOverrideOriginalPlaySound
            // 
            resources.ApplyResources(this.cbOverrideOriginalPlaySound, "cbOverrideOriginalPlaySound");
            this.cbOverrideOriginalPlaySound.Name = "cbOverrideOriginalPlaySound";
            this.cbOverrideOriginalPlaySound.UseVisualStyleBackColor = true;
            this.cbOverrideOriginalPlaySound.CheckedChanged += new System.EventHandler(this.cbOverrideOriginalPlaySound_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxDefaultProfile
            // 
            resources.ApplyResources(this.comboBoxDefaultProfile, "comboBoxDefaultProfile");
            this.comboBoxDefaultProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefaultProfile.FormattingEnabled = true;
            this.comboBoxDefaultProfile.Name = "comboBoxDefaultProfile";
            // 
            // GeneralConfigTabControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Name = "GeneralConfigTabControl";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbOverrideOriginalPlayTTS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOverrideOriginalPlaySound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDefaultProfile;
    }
}
