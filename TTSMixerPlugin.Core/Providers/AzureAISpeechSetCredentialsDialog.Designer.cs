namespace Qitana.TTSMixerPlugin.Providers
{
    partial class AzureAISpeechSetCredentialsDialog
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
            this.labelRegion = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxRegeion = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCheckCredentials = new System.Windows.Forms.Button();
            this.labelCredentialsStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(23, 20);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(40, 12);
            this.labelRegion.TabIndex = 0;
            this.labelRegion.Text = "Region";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(23, 48);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(24, 12);
            this.labelKey.TabIndex = 1;
            this.labelKey.Text = "Key";
            // 
            // textBoxRegeion
            // 
            this.textBoxRegeion.Location = new System.Drawing.Point(129, 17);
            this.textBoxRegeion.Name = "textBoxRegeion";
            this.textBoxRegeion.Size = new System.Drawing.Size(247, 19);
            this.textBoxRegeion.TabIndex = 2;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(129, 45);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(247, 19);
            this.textBoxKey.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(420, 132);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 25);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(334, 132);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 25);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.buttonCheckCredentials);
            this.flowLayoutPanel1.Controls.Add(this.labelCredentialsStatus);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(488, 40);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // buttonCheckCredentials
            // 
            this.buttonCheckCredentials.AutoSize = true;
            this.buttonCheckCredentials.Location = new System.Drawing.Point(3, 3);
            this.buttonCheckCredentials.Name = "buttonCheckCredentials";
            this.buttonCheckCredentials.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonCheckCredentials.Size = new System.Drawing.Size(115, 25);
            this.buttonCheckCredentials.TabIndex = 0;
            this.buttonCheckCredentials.Text = "Check Credentials";
            this.buttonCheckCredentials.UseVisualStyleBackColor = true;
            this.buttonCheckCredentials.Click += new System.EventHandler(this.buttonCheckCredentials_Click);
            // 
            // labelCredentialsStatus
            // 
            this.labelCredentialsStatus.AutoSize = true;
            this.labelCredentialsStatus.Location = new System.Drawing.Point(124, 9);
            this.labelCredentialsStatus.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.labelCredentialsStatus.Name = "labelCredentialsStatus";
            this.labelCredentialsStatus.Size = new System.Drawing.Size(0, 12);
            this.labelCredentialsStatus.TabIndex = 1;
            // 
            // AzureAISpeechSetCredentialsDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(512, 169);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxRegeion);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelRegion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AzureAISpeechSetCredentialsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Credentials";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxRegeion;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCheckCredentials;
        private System.Windows.Forms.Label labelCredentialsStatus;
    }
}