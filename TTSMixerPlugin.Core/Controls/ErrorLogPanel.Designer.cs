namespace Qitana.TTSMixerPlugin
{
    partial class ErrorLogPanel
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
            this.errorLogBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // errorLogBox
            // 
            this.errorLogBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLogBox.Location = new System.Drawing.Point(0, 0);
            this.errorLogBox.Multiline = true;
            this.errorLogBox.Name = "errorLogBox";
            this.errorLogBox.ReadOnly = true;
            this.errorLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorLogBox.Size = new System.Drawing.Size(150, 150);
            this.errorLogBox.TabIndex = 0;
            // 
            // ErrorLogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorLogBox);
            this.Name = "ErrorLogPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox errorLogBox;
    }
}
