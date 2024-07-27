namespace Qitana.TTSMixerPlugin
{
    partial class ProfileConfigTabPanel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTextToSpeechSettings = new System.Windows.Forms.TabPage();
            this.tabPageAudioDevices = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelAudioDevices = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTestText = new System.Windows.Forms.TextBox();
            this.buttonRunTest = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAudioDevices.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTextToSpeechSettings);
            this.tabControl1.Controls.Add(this.tabPageAudioDevices);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(8, 4);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 346);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTextToSpeechSettings
            // 
            this.tabPageTextToSpeechSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageTextToSpeechSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTextToSpeechSettings.Name = "tabPageTextToSpeechSettings";
            this.tabPageTextToSpeechSettings.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tabPageTextToSpeechSettings.Size = new System.Drawing.Size(583, 318);
            this.tabPageTextToSpeechSettings.TabIndex = 0;
            this.tabPageTextToSpeechSettings.Text = "Text-To-Speech Settings";
            this.tabPageTextToSpeechSettings.UseVisualStyleBackColor = true;
            // 
            // tabPageAudioDevices
            // 
            this.tabPageAudioDevices.Controls.Add(this.flowLayoutPanelAudioDevices);
            this.tabPageAudioDevices.Location = new System.Drawing.Point(4, 24);
            this.tabPageAudioDevices.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageAudioDevices.Name = "tabPageAudioDevices";
            this.tabPageAudioDevices.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tabPageAudioDevices.Size = new System.Drawing.Size(583, 318);
            this.tabPageAudioDevices.TabIndex = 1;
            this.tabPageAudioDevices.Text = "Audio Devices";
            this.tabPageAudioDevices.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelAudioDevices
            // 
            this.flowLayoutPanelAudioDevices.AutoScroll = true;
            this.flowLayoutPanelAudioDevices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanelAudioDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAudioDevices.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanelAudioDevices.Name = "flowLayoutPanelAudioDevices";
            this.flowLayoutPanelAudioDevices.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelAudioDevices.Size = new System.Drawing.Size(583, 316);
            this.flowLayoutPanelAudioDevices.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 392);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxTestText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRunTest, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 355);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(591, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBoxTestText
            // 
            this.textBoxTestText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxTestText.Location = new System.Drawing.Point(3, 8);
            this.textBoxTestText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.textBoxTestText.Name = "textBoxTestText";
            this.textBoxTestText.Size = new System.Drawing.Size(405, 19);
            this.textBoxTestText.TabIndex = 0;
            this.textBoxTestText.Text = "Testing, testing, one, two, three.";
            // 
            // buttonRunTest
            // 
            this.buttonRunTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRunTest.Location = new System.Drawing.Point(414, 3);
            this.buttonRunTest.Name = "buttonRunTest";
            this.buttonRunTest.Size = new System.Drawing.Size(174, 28);
            this.buttonRunTest.TabIndex = 1;
            this.buttonRunTest.Text = "Run Test";
            this.buttonRunTest.UseVisualStyleBackColor = true;
            this.buttonRunTest.Click += new System.EventHandler(this.buttonRunTest_Click);
            // 
            // ProfileConfigTabPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProfileConfigTabPanel";
            this.Padding = new System.Windows.Forms.Padding(3, 8, 0, 0);
            this.Size = new System.Drawing.Size(600, 400);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAudioDevices.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTextToSpeechSettings;
        private System.Windows.Forms.TabPage tabPageAudioDevices;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAudioDevices;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxTestText;
        private System.Windows.Forms.Button buttonRunTest;
    }
}
