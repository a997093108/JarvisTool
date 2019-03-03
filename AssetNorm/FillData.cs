using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Diagnostics;

namespace AssetNorm
{
    public partial class FillData : Form
    {
        private int _selectFileType = 1; //默认是只获取文件名

        public FillData()
        {
            InitializeComponent();
        }

        private void FillData_Load(object sender, EventArgs e)
        {

        }

        private void radioFullPath_CheckedChanged(object sender, EventArgs e)
        {
            _selectFileType = 0;
        }

        private void radioFileName_CheckedChanged(object sender, EventArgs e)
        {
            _selectFileType = 1;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAffirm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileOk += FileDialog_FileOk;

            fileDialog.Multiselect = true;
            fileDialog.ShowDialog();

        }

        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog fileDialog = sender as OpenFileDialog;

            string[] file = new string[fileDialog.FileNames.Length];

            if (_selectFileType == 0)//获取全路径
            {
                file = fileDialog.FileNames;
            }
            else if (_selectFileType == 1)//只获取文件名
            {
                file = fileDialog.SafeFileNames;
            }

            //去除扩展名
            if (checkWipeExpandedName.Checked)
            {
                int slash = 0;
                int point = 0;
                for (int i = 0; i < file.Length; i++)
                {
                    //为了防止文件并没有扩展名, 而寻找到前一个路径这个BUG.
                    //把最后一个 / 也取出来
                    slash = file[i].LastIndexOf('/');
                    point = file[i].LastIndexOf('.');

                    //点符号位置大于斜杠的时候, 说明是有扩展名的
                    if (point > slash)
                    {
                        file[i] = file[i].Substring(0, point);
                    }

                }
            }

            //添加前后文本
            string first = textBoxFirst.Text;
            string last = textBoxLast.Text;
            for (int i = 0; i < file.Length; i++)
            {
                file[i] = first + file[i] + last;
            }

            //加入到列表框
            Debug.Print("赵傲");
            Form1 form = new Form1();
            form.SetListData(file);
            form.HideSelectFill();


        }
    }


}
