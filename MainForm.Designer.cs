
namespace NoiseGenerator
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.barVolume = new System.Windows.Forms.TrackBar();
            this.barFrequency = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(8, 8);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(43, 12);
            this.lblVolume.TabIndex = 0;
            this.lblVolume.Text = "Volume";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(8, 64);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(58, 12);
            this.lblFrequency.TabIndex = 1;
            this.lblFrequency.Text = "Frequency";
            // 
            // barVolume
            // 
            this.barVolume.Location = new System.Drawing.Point(0, 24);
            this.barVolume.Maximum = 100;
            this.barVolume.Name = "barVolume";
            this.barVolume.Size = new System.Drawing.Size(800, 45);
            this.barVolume.TabIndex = 2;
            this.barVolume.Value = 20;
            this.barVolume.Scroll += new System.EventHandler(this.barVolume_Scroll);
            // 
            // barFrequency
            // 
            this.barFrequency.Location = new System.Drawing.Point(0, 80);
            this.barFrequency.Maximum = 100;
            this.barFrequency.Name = "barFrequency";
            this.barFrequency.Size = new System.Drawing.Size(800, 45);
            this.barFrequency.TabIndex = 3;
            this.barFrequency.Value = 20;
            this.barFrequency.Scroll += new System.EventHandler(this.barFrequency_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 120);
            this.Controls.Add(this.barFrequency);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.barVolume);
            this.Controls.Add(this.lblVolume);
            this.Name = "MainForm";
            this.Text = "NoiseGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TrackBar barVolume;
        private System.Windows.Forms.TrackBar barFrequency;
    }
}

