namespace AssetNorm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxJsonName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSaveJsonTemplate = new System.Windows.Forms.Button();
            this.btnOpenJsonEditor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxJsonEditor = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.labelSelectFillHint = new System.Windows.Forms.Label();
            this.labelSelectFill = new System.Windows.Forms.Label();
            this.btnCancelFill = new System.Windows.Forms.Button();
            this.btnAffirmFill = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxFastEdit = new System.Windows.Forms.CheckBox();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.listData = new System.Windows.Forms.ListView();
            this.btnGenerateJsonRead = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelHint = new System.Windows.Forms.Panel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.textLast = new System.Windows.Forms.TextBox();
            this.textFirst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewAssetNorm = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelHint.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 569);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "JSON自动化";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabel2.Location = new System.Drawing.Point(70, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "(未保存)";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "正在编辑:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl2.Location = new System.Drawing.Point(3, 33);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(897, 533);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxJsonName);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.btnSaveJsonTemplate);
            this.tabPage3.Controls.Add(this.btnOpenJsonEditor);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBoxJsonEditor);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(889, 507);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "编辑JSON模板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxJsonName
            // 
            this.textBoxJsonName.Location = new System.Drawing.Point(514, 313);
            this.textBoxJsonName.Name = "textBoxJsonName";
            this.textBoxJsonName.Size = new System.Drawing.Size(264, 21);
            this.textBoxJsonName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "JSON名称";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabel1.Location = new System.Drawing.Point(425, 175);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(383, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/LitJSON/litjson/releases (下载LitJson最新版)";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnSaveJsonTemplate
            // 
            this.btnSaveJsonTemplate.Location = new System.Drawing.Point(514, 379);
            this.btnSaveJsonTemplate.Name = "btnSaveJsonTemplate";
            this.btnSaveJsonTemplate.Size = new System.Drawing.Size(264, 23);
            this.btnSaveJsonTemplate.TabIndex = 5;
            this.btnSaveJsonTemplate.Text = "保存当前模板";
            this.btnSaveJsonTemplate.UseVisualStyleBackColor = true;
            this.btnSaveJsonTemplate.Click += new System.EventHandler(this.btnSaveJsonTemplate_Click);
            // 
            // btnOpenJsonEditor
            // 
            this.btnOpenJsonEditor.Location = new System.Drawing.Point(514, 350);
            this.btnOpenJsonEditor.Name = "btnOpenJsonEditor";
            this.btnOpenJsonEditor.Size = new System.Drawing.Size(264, 23);
            this.btnOpenJsonEditor.TabIndex = 4;
            this.btnOpenJsonEditor.Text = "打开已有模板编辑";
            this.btnOpenJsonEditor.UseVisualStyleBackColor = true;
            this.btnOpenJsonEditor.Click += new System.EventHandler(this.btnOpenJsonEditor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(423, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(429, 140);
            this.label4.TabIndex = 3;
            this.label4.Text = "仅支持 string int float bool 4种数据类型定义,不需要加分号, 注释//\r\n例如:\r\n\tstring Name //姓名\r\n\tint age" +
    " //年龄\r\n\tfloat income\r\n\tbool married\r\n\t";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(423, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "语法说明:";
            // 
            // textBoxJsonEditor
            // 
            this.textBoxJsonEditor.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJsonEditor.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxJsonEditor.Location = new System.Drawing.Point(6, 6);
            this.textBoxJsonEditor.Multiline = true;
            this.textBoxJsonEditor.Name = "textBoxJsonEditor";
            this.textBoxJsonEditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxJsonEditor.Size = new System.Drawing.Size(410, 495);
            this.textBoxJsonEditor.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.labelSelectFillHint);
            this.tabPage4.Controls.Add(this.labelSelectFill);
            this.tabPage4.Controls.Add(this.btnCancelFill);
            this.tabPage4.Controls.Add(this.btnAffirmFill);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.checkBoxFastEdit);
            this.tabPage4.Controls.Add(this.btnDelItem);
            this.tabPage4.Controls.Add(this.btnAddItem);
            this.tabPage4.Controls.Add(this.listData);
            this.tabPage4.Controls.Add(this.btnGenerateJsonRead);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(889, 507);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "编辑数据";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // labelSelectFillHint
            // 
            this.labelSelectFillHint.AutoSize = true;
            this.labelSelectFillHint.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectFillHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSelectFillHint.Location = new System.Drawing.Point(315, 478);
            this.labelSelectFillHint.Name = "labelSelectFillHint";
            this.labelSelectFillHint.Size = new System.Drawing.Size(264, 16);
            this.labelSelectFillHint.TabIndex = 16;
            this.labelSelectFillHint.Text = "请单击需要填充的表项, 选择后点√";
            this.labelSelectFillHint.Visible = false;
            // 
            // labelSelectFill
            // 
            this.labelSelectFill.AutoSize = true;
            this.labelSelectFill.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectFill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSelectFill.Location = new System.Drawing.Point(540, 451);
            this.labelSelectFill.Name = "labelSelectFill";
            this.labelSelectFill.Size = new System.Drawing.Size(72, 16);
            this.labelSelectFill.TabIndex = 15;
            this.labelSelectFill.Text = "已选择:0";
            this.labelSelectFill.Visible = false;
            // 
            // btnCancelFill
            // 
            this.btnCancelFill.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelFill.ForeColor = System.Drawing.Color.Red;
            this.btnCancelFill.Location = new System.Drawing.Point(512, 448);
            this.btnCancelFill.Name = "btnCancelFill";
            this.btnCancelFill.Size = new System.Drawing.Size(22, 23);
            this.btnCancelFill.TabIndex = 14;
            this.btnCancelFill.Text = "×";
            this.btnCancelFill.UseVisualStyleBackColor = true;
            this.btnCancelFill.Visible = false;
            this.btnCancelFill.Click += new System.EventHandler(this.btnCancelFill_Click);
            // 
            // btnAffirmFill
            // 
            this.btnAffirmFill.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAffirmFill.ForeColor = System.Drawing.Color.Lime;
            this.btnAffirmFill.Location = new System.Drawing.Point(490, 448);
            this.btnAffirmFill.Name = "btnAffirmFill";
            this.btnAffirmFill.Size = new System.Drawing.Size(22, 23);
            this.btnAffirmFill.TabIndex = 13;
            this.btnAffirmFill.Text = "√";
            this.btnAffirmFill.UseVisualStyleBackColor = true;
            this.btnAffirmFill.Visible = false;
            this.btnAffirmFill.Click += new System.EventHandler(this.btnAffirmFill_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "选择文件作为填充数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBoxFastEdit
            // 
            this.checkBoxFastEdit.AutoSize = true;
            this.checkBoxFastEdit.Location = new System.Drawing.Point(6, 448);
            this.checkBoxFastEdit.Name = "checkBoxFastEdit";
            this.checkBoxFastEdit.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFastEdit.TabIndex = 11;
            this.checkBoxFastEdit.Text = "快速编辑";
            this.checkBoxFastEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelItem
            // 
            this.btnDelItem.Location = new System.Drawing.Point(105, 478);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(152, 23);
            this.btnDelItem.TabIndex = 10;
            this.btnDelItem.Text = "删除选中 (Del键)";
            this.btnDelItem.UseVisualStyleBackColor = true;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(105, 448);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(152, 23);
            this.btnAddItem.TabIndex = 9;
            this.btnAddItem.Text = "添加一项 (+ 键)";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // listData
            // 
            this.listData.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listData.AutoArrange = false;
            this.listData.BackColor = System.Drawing.Color.White;
            this.listData.FullRowSelect = true;
            this.listData.GridLines = true;
            this.listData.Location = new System.Drawing.Point(6, 6);
            this.listData.Margin = new System.Windows.Forms.Padding(0);
            this.listData.Name = "listData";
            this.listData.Size = new System.Drawing.Size(877, 429);
            this.listData.TabIndex = 8;
            this.listData.UseCompatibleStateImageBehavior = false;
            this.listData.View = System.Windows.Forms.View.Details;
            this.listData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listData_KeyUp);
            this.listData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listData_MouseClick);
            this.listData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listData_MouseDoubleClick);
            // 
            // btnGenerateJsonRead
            // 
            this.btnGenerateJsonRead.Location = new System.Drawing.Point(713, 450);
            this.btnGenerateJsonRead.Name = "btnGenerateJsonRead";
            this.btnGenerateJsonRead.Size = new System.Drawing.Size(170, 54);
            this.btnGenerateJsonRead.TabIndex = 7;
            this.btnGenerateJsonRead.Text = "        生成\r\n        LitJson代码\r\n        JSON文件";
            this.btnGenerateJsonRead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateJsonRead.UseVisualStyleBackColor = true;
            this.btnGenerateJsonRead.Click += new System.EventHandler(this.btnGenerateJsonRead_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelHint);
            this.tabPage1.Controls.Add(this.btnSaveAs);
            this.tabPage1.Controls.Add(this.textLast);
            this.tabPage1.Controls.Add(this.textFirst);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listViewAssetNorm);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 569);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "资源规范";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelHint
            // 
            this.panelHint.Controls.Add(this.labelProgress);
            this.panelHint.Controls.Add(this.progressBar1);
            this.panelHint.Location = new System.Drawing.Point(183, 127);
            this.panelHint.Name = "panelHint";
            this.panelHint.Size = new System.Drawing.Size(562, 333);
            this.panelHint.TabIndex = 7;
            this.panelHint.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProgress.Location = new System.Drawing.Point(254, 138);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(60, 38);
            this.labelProgress.TabIndex = 1;
            this.labelProgress.Text = "0%";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 179);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(488, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(825, 7);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 6;
            this.btnSaveAs.Text = "保存到";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // textLast
            // 
            this.textLast.Location = new System.Drawing.Point(627, 10);
            this.textLast.Name = "textLast";
            this.textLast.Size = new System.Drawing.Size(61, 21);
            this.textLast.TabIndex = 5;
            this.textLast.WordWrap = false;
            this.textLast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textFirst
            // 
            this.textFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textFirst.Location = new System.Drawing.Point(307, 10);
            this.textFirst.Name = "textFirst";
            this.textFirst.Size = new System.Drawing.Size(225, 21);
            this.textFirst.TabIndex = 3;
            this.textFirst.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "后缀开始数";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "规范名前缀";
            // 
            // listViewAssetNorm
            // 
            this.listViewAssetNorm.Location = new System.Drawing.Point(8, 39);
            this.listViewAssetNorm.Name = "listViewAssetNorm";
            this.listViewAssetNorm.Size = new System.Drawing.Size(892, 526);
            this.listViewAssetNorm.TabIndex = 1;
            this.listViewAssetNorm.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 595);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(911, 595);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拯救贾维斯 - 火星最强小组开发日常小工具Beta1.0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelHint.ResumeLayout(false);
            this.panelHint.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelHint;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.TextBox textLast;
        private System.Windows.Forms.TextBox textFirst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewAssetNorm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBoxJsonEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenJsonEditor;
        private System.Windows.Forms.Button btnSaveJsonTemplate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBoxJsonName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerateJsonRead;
        private System.Windows.Forms.ListView listData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.CheckBox checkBoxFastEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCancelFill;
        private System.Windows.Forms.Button btnAffirmFill;
        private System.Windows.Forms.Label labelSelectFill;
        private System.Windows.Forms.Label labelSelectFillHint;
    }
}

