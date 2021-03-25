namespace EasyCodeBuilder
{
    partial class MainMethod
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
            this.label1 = new System.Windows.Forms.Label();
            this.statementBlock1 = new EasyCodeBuilder.StatementBlock();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 3);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(475, 374);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(475, 304);
            this.button3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mainメソッド";
            // 
            // statementBlock1
            // 
            this.statementBlock1.BackColor = System.Drawing.SystemColors.Menu;
            this.statementBlock1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statementBlock1.ForeColor = System.Drawing.Color.Black;
            this.statementBlock1.Location = new System.Drawing.Point(3, 32);
            this.statementBlock1.MinimumSize = new System.Drawing.Size(517, 336);
            this.statementBlock1.Name = "statementBlock1";
            this.statementBlock1.Size = new System.Drawing.Size(517, 336);
            this.statementBlock1.TabIndex = 11;
            // 
            // MainMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = false;
            this.AutoSize = true;
            this.Controls.Add(this.statementBlock1);
            this.Controls.Add(this.label1);
            this.Name = "MainMethod";
            this.Size = new System.Drawing.Size(523, 400);
            this.Load += new System.EventHandler(this.MainMethod_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.statementBlock1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public StatementBlock statementBlock1;
    }
}
