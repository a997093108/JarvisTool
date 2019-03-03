namespace AssetNorm
{
    partial class FillData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkWipeExpandedName = new System.Windows.Forms.CheckBox();
            this.radioFileName = new System.Windows.Forms.RadioButton();
            this.radioFullPath = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.textBoxLast = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAffirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkWipeExpandedName);
            this.groupBox1.Controls.Add(this.radioFileName);
            this.groupBox1.Controls.Add(this.radioFullPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获得文件选项";
            // 
            // checkWipeExpandedName
            // 
            this.checkWipeExpandedName.AutoSize = true;
            this.checkWipeExpandedName.Location = new System.Drawing.Point(260, 64);
            this.checkWipeExpandedName.Name = "checkWipeExpandedName";
            this.checkWipeExpandedName.Size = new System.Drawing.Size(84, 16);
            this.checkWipeExpandedName.TabIndex = 2;
            this.checkWipeExpandedName.Text = "去除扩展名";
            this.checkWipeExpandedName.UseVisualStyleBackColor = true;
            // 
            // radioFileName
            // 
            this.radioFileName.AutoSize = true;
            this.radioFileName.Checked = true;
            this.radioFileName.Location = new System.Drawing.Point(52, 63);
            this.radioFileName.Name = "radioFileName";
            this.radioFileName.Size = new System.Drawing.Size(95, 16);
            this.radioFileName.TabIndex = 1;
            this.radioFileName.TabStop = true;
            this.radioFileName.Text = "只获取文件名";
            this.radioFileName.UseVisualStyleBackColor = true;
            this.radioFileName.CheckedChanged += new System.EventHandler(this.radioFileName_CheckedChanged);
            // 
            // radioFullPath
            // 
            this.radioFullPath.AutoSize = true;
            this.radioFullPath.Location = new System.Drawing.Point(52, 28);
            this.radioFullPath.Name = "radioFullPath";
            this.radioFullPath.Size = new System.Drawing.Size(83, 16);
            this.radioFullPath.TabIndex = 0;
            this.radioFullPath.Text = "获取全路径";
            this.radioFullPath.UseVisualStyleBackColor = true;
            this.radioFullPath.CheckedChanged += new System.EventHandler(this.radioFullPath_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "在文本前添加";
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Location = new System.Drawing.Point(101, 138);
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.Size = new System.Drawing.Size(363, 21);
            this.textBoxFirst.TabIndex = 3;
            // 
            // textBoxLast
            // 
            this.textBoxLast.Location = new System.Drawing.Point(101, 177);
            this.textBoxLast.Name = "textBoxLast";
            this.textBoxLast.Size = new System.Drawing.Size(363, 21);
            this.textBoxLast.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "在文本后添加";
            // 
            // buttonAffirm
            // 
            this.buttonAffirm.Location = new System.Drawing.Point(335, 251);
            this.buttonAffirm.Name = "buttonAffirm";
            this.buttonAffirm.Size = new System.Drawing.Size(129, 23);
            this.buttonAffirm.TabIndex = 6;
            this.buttonAffirm.Text = "确定开始选择文件";
            this.buttonAffirm.UseVisualStyleBackColor = true;
            this.buttonAffirm.Click += new System.EventHandler(this.buttonAffirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(254, 251);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FillData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 286);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAffirm);
            this.Controls.Add(this.textBoxLast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFirst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FillData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填充数据选项:";
            this.Load += new System.EventHandler(this.FillData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkWipeExpandedName;
        private System.Windows.Forms.RadioButton radioFileName;
        private System.Windows.Forms.RadioButton radioFullPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.TextBox textBoxLast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAffirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}