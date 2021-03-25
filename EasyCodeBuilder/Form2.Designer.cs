namespace EasyCodeBuilder
{
    partial class Form2
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
            this.addVariableDefineButton = new System.Windows.Forms.Button();
            this.addOutputConsoleButton = new System.Windows.Forms.Button();
            this.addConditionsButton = new System.Windows.Forms.Button();
            this.addCalculationButton = new System.Windows.Forms.Button();
            this.ImputConsoleButton = new System.Windows.Forms.Button();
            this.addLoopButton = new System.Windows.Forms.Button();
            this.CanselButton = new System.Windows.Forms.Button();
            this.ListDefine = new System.Windows.Forms.Button();
            this.ArrayDefineButton = new System.Windows.Forms.Button();
            this.AddCaseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddAssignmentButton = new System.Windows.Forms.Button();
            this.AddReturnMold = new System.Windows.Forms.Button();
            this.AddBreakButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addVariableDefineButton
            // 
            this.addVariableDefineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addVariableDefineButton.Location = new System.Drawing.Point(6, 20);
            this.addVariableDefineButton.Name = "addVariableDefineButton";
            this.addVariableDefineButton.Size = new System.Drawing.Size(115, 23);
            this.addVariableDefineButton.TabIndex = 0;
            this.addVariableDefineButton.Text = "変数を宣言";
            this.addVariableDefineButton.UseVisualStyleBackColor = true;
            this.addVariableDefineButton.Click += new System.EventHandler(this.AddVariableDefineButton_Click);
            // 
            // addOutputConsoleButton
            // 
            this.addOutputConsoleButton.Location = new System.Drawing.Point(6, 259);
            this.addOutputConsoleButton.Name = "addOutputConsoleButton";
            this.addOutputConsoleButton.Size = new System.Drawing.Size(115, 23);
            this.addOutputConsoleButton.TabIndex = 1;
            this.addOutputConsoleButton.Text = "値をコンソールに表示";
            this.addOutputConsoleButton.UseVisualStyleBackColor = true;
            this.addOutputConsoleButton.Click += new System.EventHandler(this.AddOutputConsoleButton_Click);
            // 
            // addConditionsButton
            // 
            this.addConditionsButton.Location = new System.Drawing.Point(6, 189);
            this.addConditionsButton.Name = "addConditionsButton";
            this.addConditionsButton.Size = new System.Drawing.Size(115, 23);
            this.addConditionsButton.TabIndex = 2;
            this.addConditionsButton.Text = "条件を追加";
            this.addConditionsButton.UseVisualStyleBackColor = true;
            this.addConditionsButton.Click += new System.EventHandler(this.AddConditionsButton_Click);
            // 
            // addCalculationButton
            // 
            this.addCalculationButton.Location = new System.Drawing.Point(6, 148);
            this.addCalculationButton.Name = "addCalculationButton";
            this.addCalculationButton.Size = new System.Drawing.Size(115, 23);
            this.addCalculationButton.TabIndex = 3;
            this.addCalculationButton.Text = "計算し代入する";
            this.addCalculationButton.UseVisualStyleBackColor = true;
            this.addCalculationButton.Click += new System.EventHandler(this.AddCalculationButton_Click);
            // 
            // ImputConsoleButton
            // 
            this.ImputConsoleButton.Location = new System.Drawing.Point(6, 288);
            this.ImputConsoleButton.Name = "ImputConsoleButton";
            this.ImputConsoleButton.Size = new System.Drawing.Size(115, 23);
            this.ImputConsoleButton.TabIndex = 4;
            this.ImputConsoleButton.Text = "文字、数字を入力";
            this.ImputConsoleButton.UseVisualStyleBackColor = true;
            this.ImputConsoleButton.Click += new System.EventHandler(this.AddImputConsoleButton_Click);
            // 
            // addLoopButton
            // 
            this.addLoopButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addLoopButton.Location = new System.Drawing.Point(6, 218);
            this.addLoopButton.Name = "addLoopButton";
            this.addLoopButton.Size = new System.Drawing.Size(115, 23);
            this.addLoopButton.TabIndex = 5;
            this.addLoopButton.Text = "ループを追加";
            this.addLoopButton.UseVisualStyleBackColor = true;
            this.addLoopButton.Click += new System.EventHandler(this.AddLoopButton_Click);
            // 
            // CanselButton
            // 
            this.CanselButton.Location = new System.Drawing.Point(333, 292);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(68, 23);
            this.CanselButton.TabIndex = 6;
            this.CanselButton.Text = "キャンセル";
            this.CanselButton.UseVisualStyleBackColor = true;
            this.CanselButton.Click += new System.EventHandler(this.CanselButton_Click);
            // 
            // ListDefine
            // 
            this.ListDefine.Location = new System.Drawing.Point(148, 292);
            this.ListDefine.Name = "ListDefine";
            this.ListDefine.Size = new System.Drawing.Size(115, 23);
            this.ListDefine.TabIndex = 7;
            this.ListDefine.Text = "リストを宣言する";
            this.ListDefine.UseVisualStyleBackColor = true;
            this.ListDefine.Visible = false;
            this.ListDefine.Click += new System.EventHandler(this.ListDefine_Click);
            // 
            // ArrayDefineButton
            // 
            this.ArrayDefineButton.Location = new System.Drawing.Point(6, 49);
            this.ArrayDefineButton.Name = "ArrayDefineButton";
            this.ArrayDefineButton.Size = new System.Drawing.Size(115, 23);
            this.ArrayDefineButton.TabIndex = 8;
            this.ArrayDefineButton.Text = "配列を宣言する";
            this.ArrayDefineButton.UseVisualStyleBackColor = true;
            this.ArrayDefineButton.Click += new System.EventHandler(this.ArrayDefineButton_Click);
            // 
            // AddCaseButton
            // 
            this.AddCaseButton.Location = new System.Drawing.Point(12, 12);
            this.AddCaseButton.Name = "AddCaseButton";
            this.AddCaseButton.Size = new System.Drawing.Size(115, 23);
            this.AddCaseButton.TabIndex = 11;
            this.AddCaseButton.Text = "swichのcaseを追加";
            this.AddCaseButton.UseVisualStyleBackColor = true;
            this.AddCaseButton.Click += new System.EventHandler(this.AddCaseButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addCalculationButton);
            this.panel1.Controls.Add(this.ImputConsoleButton);
            this.panel1.Controls.Add(this.AddAssignmentButton);
            this.panel1.Controls.Add(this.addOutputConsoleButton);
            this.panel1.Controls.Add(this.AddReturnMold);
            this.panel1.Controls.Add(this.addConditionsButton);
            this.panel1.Controls.Add(this.addVariableDefineButton);
            this.panel1.Controls.Add(this.addLoopButton);
            this.panel1.Controls.Add(this.ArrayDefineButton);
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 320);
            this.panel1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "コンソール";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "コントロール";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "変数に代入";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "宣言";
            // 
            // AddAssignmentButton
            // 
            this.AddAssignmentButton.Location = new System.Drawing.Point(6, 90);
            this.AddAssignmentButton.Name = "AddAssignmentButton";
            this.AddAssignmentButton.Size = new System.Drawing.Size(115, 23);
            this.AddAssignmentButton.TabIndex = 10;
            this.AddAssignmentButton.Text = "値を代入する";
            this.AddAssignmentButton.UseVisualStyleBackColor = true;
            this.AddAssignmentButton.Click += new System.EventHandler(this.AddAssignmentButton_Click);
            // 
            // AddReturnMold
            // 
            this.AddReturnMold.Location = new System.Drawing.Point(6, 119);
            this.AddReturnMold.Name = "AddReturnMold";
            this.AddReturnMold.Size = new System.Drawing.Size(115, 23);
            this.AddReturnMold.TabIndex = 9;
            this.AddReturnMold.Text = "型を変換して代入";
            this.AddReturnMold.UseVisualStyleBackColor = true;
            this.AddReturnMold.Click += new System.EventHandler(this.AddReturnMold_Click);
            // 
            // AddBreakButton
            // 
            this.AddBreakButton.Location = new System.Drawing.Point(152, 12);
            this.AddBreakButton.Name = "AddBreakButton";
            this.AddBreakButton.Size = new System.Drawing.Size(111, 23);
            this.AddBreakButton.TabIndex = 9;
            this.AddBreakButton.Text = "breakを追加";
            this.AddBreakButton.UseVisualStyleBackColor = true;
            this.AddBreakButton.Click += new System.EventHandler(this.AddBreakButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 326);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddBreakButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.ListDefine);
            this.Controls.Add(this.AddCaseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form2";
            this.Text = "コントロールを追加";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addVariableDefineButton;
        private System.Windows.Forms.Button addOutputConsoleButton;
        private System.Windows.Forms.Button addConditionsButton;
        private System.Windows.Forms.Button addCalculationButton;
        private System.Windows.Forms.Button ImputConsoleButton;
        private System.Windows.Forms.Button addLoopButton;
        private System.Windows.Forms.Button CanselButton;
        private System.Windows.Forms.Button ListDefine;
        private System.Windows.Forms.Button ArrayDefineButton;
        private System.Windows.Forms.Button AddCaseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddBreakButton;
        private System.Windows.Forms.Button AddReturnMold;
        private System.Windows.Forms.Button AddAssignmentButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}