using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LitJson;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AssetNorm
{
    public partial class Form1 : Form
    {
        //选中的表项
        private ListViewItem.ListViewSubItem _selectItem = null;

        //用来编辑表项的编辑框
        private TextBox _textEdit = new TextBox();

        //表项颜色
        private Color _listColorFore = Color.Black;
        private Color _listColorBack = Color.FromArgb(208, 229, 249);
        SynchronizationContext mContext = null;

        //选中需要填充的表项
        private static List<ListViewItem.ListViewSubItem> _selectFill = new List<ListViewItem.ListViewSubItem>();

        //进入编辑模式
        private bool _isSelectFill;

        private Image _OtherImg;
        private ImageList _imgList = new ImageList();

        public Form1()
        {
            InitializeComponent();
            mContext = SynchronizationContext.Current;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _OtherImg = Resource1.other;
            _imgList.ImageSize = new Size(100, 100);
            _imgList.ColorDepth = ColorDepth.Depth32Bit;

            //初始化JSON模板目录
            if (!Directory.Exists("./JsonTemplate"))
            {
                Directory.CreateDirectory("./JsonTemplate");
            }

            //设置表项编辑框的委托事件
            _textEdit.KeyDown += _textEdit_KeyDown;
            _textEdit.Leave += _textEdit_Leave;
            _textEdit.Visible = false;
        }

        private string GetTimeString()
        {
            string time = DateTime.Now.ToLocalTime().ToString();
            //2019-1-29 上午 12:00:00
            time = time.Replace(':', '.');
            return time;
        }


        private void _textEdit_Leave(object sender, EventArgs e)
        {
            if (_selectItem != null)
            {
                _selectItem.Text = _textEdit.Text;
                _textEdit.Text = null;
                _selectItem = null;
                _textEdit.Visible = false;
            }
        }

        private void _textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (_selectItem != null)
            {
                _selectItem.Text = _textEdit.Text;
                _textEdit.Text = null;
                _selectItem = null;
                _textEdit.Visible = false;
            }
        }

        private void SetText(object pro)
        {
            labelProgress.Text = pro.ToString() + "%";
            progressBar1.Value = (int)pro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReadFile));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void ReadFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.ShowDialog();

            string[] arr = file.FileNames;
            if (arr.Length == 0)
            {
                return;
            }


            Regex reg = new Regex(@"\.jpg$|\.png$|\.bmp$|\.ttf$");

            #region 让进度显示出来
            Action proUi = () =>
            {
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                panelHint.Visible = true;
            };
            this.Invoke(proUi);
            #endregion


            #region 开始列表刷新
            Action beginList = () =>
              {
                  listViewAssetNorm.BeginUpdate();
              };
            listViewAssetNorm.Invoke(beginList);
            #endregion

            for (int i = 0; i < arr.Length; i++)
            {
                Match mc = reg.Match(arr[i]);

                int index = 0;
                Action imgUi = () =>
                {
                    if (mc.Success)
                    {
                        _imgList.Images.Add(Image.FromFile(arr[i]));
                    }
                    else
                    {
                        _imgList.Images.Add(_OtherImg);
                    }

                    index = _imgList.Images.Count - 1;
                };

                listViewAssetNorm.Invoke(imgUi);

                ListViewItem vItem = new ListViewItem();
                vItem.ToolTipText = arr[i];

                //在列表只显示文件的文件名
                int last = arr[i].LastIndexOf('\\') + 1;
                vItem.Text = arr[i].Substring(last);

                vItem.ImageIndex = index;

                #region 加入列表item
                Action<ListViewItem> listAdd = (ListViewItem item) =>
                {
                    listViewAssetNorm.Items.Add(item);
                };
                listViewAssetNorm.Invoke(listAdd, new object[] { vItem });
                #endregion


                //算百分比
                float current = Convert.ToSingle(i);
                float total = Convert.ToSingle(arr.Length);
                float pro = current / total * 100f;

                mContext.Post(SetText, Convert.ToInt32(pro));
            }

            #region 将图片更新到列表框
            Action refreshImage = () =>
            {
                listViewAssetNorm.LargeImageList = _imgList;
                listViewAssetNorm.EndUpdate();
            };
            listViewAssetNorm.Invoke(refreshImage);
            #endregion

            #region 让进度关闭
            Action proUi2 = () =>
            {
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                panelHint.Visible = false;
            };
            this.Invoke(proUi2);
            #endregion


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ImageSaveAs));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ImageSaveAs()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string savePath = dialog.SelectedPath;
            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("保存的指定路径不存在!", "保存失败:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //没有点击取消则开始保存
            #region 显示进度条
            Action showPro = () =>
            {
                labelProgress.Text = "0%";
                progressBar1.Value = 0;
                panelHint.Visible = true;
            };
            progressBar1.Invoke(showPro);
            #endregion

            #region UI更新
            //开始复制文件到新指定的文件夹
            Action actionList = () =>
            {
                string first = textFirst.Text;
                if (textLast.Text == "")
                {
                    textLast.Text = "0";
                }

                int last = Convert.ToInt32(textLast.Text);


                for (int i = 0; i < listViewAssetNorm.Items.Count; i++)
                {
                    int pos = listViewAssetNorm.Items[i].Text.LastIndexOf('.');
                    string extension = listViewAssetNorm.Items[i].Text.Substring(pos);

                    try
                    {
                        File.Copy(listViewAssetNorm.Items[i].ToolTipText, savePath + "\\" + first + (last + i) + extension);
                    }
                    catch
                    {

                    }


                    //算百分比
                    float current = Convert.ToSingle(i);
                    float total = Convert.ToSingle(listViewAssetNorm.Items.Count);
                    float pro = current / total * 100f;

                    mContext.Post(SetText, Convert.ToInt32(pro));

                }
            };

            listViewAssetNorm.Invoke(actionList);
            #endregion



            #region 隐藏进度条
            Action hintPro = () =>
            {
                labelProgress.Text = "0%";
                progressBar1.Value = 0;
                panelHint.Visible = false;

                System.Diagnostics.Process.Start("explorer.exe", savePath);
            };
            progressBar1.Invoke(hintPro);
            #endregion

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/LitJSON/litjson/releases");
        }


        private void FormattingCode()
        {
            if (string.IsNullOrEmpty(textBoxJsonEditor.Text))
            {
                return;
            }
        }

        private void ReopenJsonModule()
        {
            string content = File.ReadAllText(linkLabel2.Text);

            JsonData json = JsonMapper.ToObject(content);

            if (!json.ContainsKey("JsonName") || !json.ContainsKey("Modules") || !json.ContainsKey("Data"))
            {
                MessageBox.Show("不是标准的Json模板文件");
                return;
            }

            textBoxJsonName.Text = json["JsonName"].ToString();

            string str = "";
            for (int i = 0; i < json["Modules"].Count; i++)
            {
                string key = null;
                foreach (string item in json["Modules"][i].Keys)
                {
                    key = item;
                    break;
                }
                if (!string.IsNullOrEmpty(key))
                {
                    str += key + " "
                           + json["Modules"][i][key].ToString() + " "
                           + json["Modules"][i]["Comment"].ToString() + "\r\n";
                }
            }

            textBoxJsonEditor.Text = str;
            JsonOperate.CurrentOpenJson = json;

 
            DataToList();
        }


        private void btnOpenJsonEditor_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            file.Filter = "JSON模板文件|*.json";


            file.InitialDirectory = Application.StartupPath + "\\JsonTemplate";

            file.ShowDialog();

            string path = file.FileName;
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            string content = File.ReadAllText(path);

            JsonData json = JsonMapper.ToObject(content);

            if (!json.ContainsKey("JsonName") || !json.ContainsKey("Modules") || !json.ContainsKey("Data"))
            {
                MessageBox.Show("不是标准的Json模板文件");
                return;
            }

            textBoxJsonName.Text = json["JsonName"].ToString();

            string str = "";
            for (int i = 0; i < json["Modules"].Count; i++)
            {
                string key = null;
                foreach (string item in json["Modules"][i].Keys)
                {
                    key = item;
                    break;
                }
                if (!string.IsNullOrEmpty(key))
                {
                    str += key + " "
                           + json["Modules"][i][key].ToString() + " "
                           + json["Modules"][i]["Comment"].ToString() + "\r\n";
                }
            }

            textBoxJsonEditor.Text = str;
            JsonOperate.CurrentOpenJson = json;

            linkLabel2.Text = path;

            DataToList();

          
        }

        private void btnSaveJsonTemplate_Click(object sender, EventArgs e)
        {
            //判断是否代码编辑是否为空
            if (string.IsNullOrEmpty(textBoxJsonEditor.Text))
            {
                MessageBox.Show("请写代码后再生成");
                return;
            }

            //判断JsonName是否符合规则
            Match matchJsonName = Regex.Match(textBoxJsonName.Text, "^[A-Z]");
            if (!matchJsonName.Success)
            {
                MessageBox.Show("输入的Json名称有误");
                return;
            }

            //转换代码
            string jsonName = textBoxJsonName.Text;

            SaveFileDialog file = new SaveFileDialog();

            file.Filter = "JSON模板文件|*.json";
            file.InitialDirectory = Application.StartupPath + "\\JsonTemplate";

            file.FileName = textBoxJsonName.Text;

            file.ShowDialog();

            string path = file.FileName;
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            string info = "";
            if (!JsonOperate.ConvertToList(textBoxJsonEditor.Text, out info))
            {
                MessageBox.Show(info);
                return;
            }

            JsonData json = new JsonData();

            json["JsonName"] = jsonName;

            json["Modules"] = new JsonData();
            json["Modules"].SetJsonType(JsonType.Array);

            for (int i = 0; i < JsonOperate.JsonModules.Count; i++)
            {
                string type = JsonOperate.JsonModules[i].type;
                string name = JsonOperate.JsonModules[i].name;
                string comment = JsonOperate.JsonModules[i].comment;

                JsonData temp = new JsonData();
                temp[type] = name;
                temp["Comment"] = comment;
                json["Modules"].Add(temp);

            }

            json["Data"] = new JsonData();
            json["Data"].SetJsonType(JsonType.Array);



            File.WriteAllText(path, json.ToJson());

            linkLabel2.Text = path;

            ReopenJsonModule();

        }

        private void DataToList()
        {
            //将打开的模板文件的json导入到列表框
            if (JsonOperate.CurrentOpenJson == null)
            {
                MessageBox.Show("未打开模板文件");
                return;
            }

            //初始化列表框
            listData.Clear();
            listData.FullRowSelect = true;

            listData.BeginUpdate();

            //从Json中获取列数据
            int column = JsonOperate.CurrentOpenJson["Modules"].Count;
            ColumnHeader[] heads = new ColumnHeader[column];

            int width = listData.Width / column;

            for (int i = 0; i < column; i++)
            {
                //设置列属性
                heads[i] = new ColumnHeader();

                heads[i].TextAlign = HorizontalAlignment.Left;
                heads[i].Width = width;

                //获取变量数据类型
                string type = null;
                foreach (string key in JsonOperate.CurrentOpenJson["Modules"][i].Keys)
                {
                    type = key;
                    break;
                }

                //获取变量名称
                string name = JsonOperate.CurrentOpenJson["Modules"][i][type].ToString();
                heads[i].Text = name + "(" + type + ")";
            }
            listData.Columns.AddRange(heads);

            for (int i = 0; i < JsonOperate.CurrentOpenJson["Data"].Count; i++)
            {
                //判断这一行的JSON是否有数据,如果为空则不添加到离不开
                if (JsonOperate.CurrentOpenJson["Data"][i].Count == 0)
                {
                    continue;
                }

                //=============
                //获取所有的keys
                bool flag = false;
                foreach (string keyName in JsonOperate.CurrentOpenJson["Data"][i].Keys)
                {
                    //将第一个值作为 ListViewItem 给list添加一行
                    if (!flag)
                    {
                        flag = true;

                        ListViewItem item = new ListViewItem()
                        {
                            Text = JsonOperate.CurrentOpenJson["Data"][i][keyName].ToString(),
                            ForeColor = _listColorFore,
                            BackColor = _listColorBack
                        };

                        //让每项都不继承父项的样式 , 使得每一项都拥有自己的样式
                        item.UseItemStyleForSubItems = false;
                        listData.Items.Add(item);
                    }
                    else
                    {
                        //添加其他的项
                        listData.Items[i].SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = JsonOperate.CurrentOpenJson["Data"][i][keyName].ToString(),
                            ForeColor = _listColorFore,
                            BackColor = _listColorBack
                        });
                    }
                }



                //=============


                ////循环添加其他的项
                //for (int j = 1; j < JsonOperate.CurrentOpenJson["Data"][i].Count; j++)
                //{
                //    listData.Items[i].SubItems.Add(new ListViewItem.ListViewSubItem()
                //    {
                //        Text = JsonOperate.CurrentOpenJson["Data"][i][j].ToString(),
                //        ForeColor = _listColorFore,
                //        BackColor = _listColorBack
                //    });
                //}

            }


            listData.EndUpdate();
        }

        private void btnGenerateJsonRead_Click_1(object sender, EventArgs e)
        {
            #region 重新整理数据表
            JsonData list = new JsonData();

            //从列表框导出数据
            for (int i = 0; i < listData.Items.Count; i++)
            {
                //取出列的数据类型,与name
                //添加每一项的数据
                JsonData tempObj = new JsonData();
                for (int j = 0; j < JsonOperate.CurrentOpenJson["Modules"].Count; j++)
                {
                    //取出key, 得知是什么数据类型
                    string key = "";
                    foreach (string item in JsonOperate.CurrentOpenJson["Modules"][j].Keys)
                    {
                        key = item;
                        break;
                    }

                    //获取变量名
                    string name = JsonOperate.CurrentOpenJson["Modules"][j][key].ToString();

                    //判断数据类型, 添加对应类型数据

                    //从列表框获取数据
                    string val = listData.Items[i].SubItems[j].Text;
                    
                    switch (key)
                    {
                        case "string":
                            tempObj[name] = val;
                            break;

                        case "int":
                            int tempInt = 0;
                            try
                            {
                                tempInt = int.Parse(val);
                            }
                            catch (Exception)
                            {

                                tempInt = 0;
                            }

                            tempObj[name] = tempInt;
                            break;

                        case "float":
                            double tempFloat = 0;
                            try
                            {
                                tempFloat = Convert.ToDouble(val);
                            }
                            catch (Exception)
                            {

                                tempFloat = 0;
                            }

                            tempObj[name] = tempFloat;
                            break;

                        case "bool":
                            bool tempBool = false;
                            try
                            {
                                tempBool = Convert.ToBoolean(val);
                            }
                            catch (Exception)
                            {

                                tempBool = false;
                            }
                            tempObj[name] = tempBool;
                            break;
                    }
                    
                }
                //添加到Data
                list.Add(tempObj);

            }

            //赋值给数据表
            JsonOperate.CurrentOpenJson["Data"] = list;
            #endregion

            //写出Json文件
            if (Directory.Exists(Application.StartupPath + "/GenerateFile"))
            {
                Directory.CreateDirectory(Application.StartupPath + "/GenerateFile");
            }

            //在上面的目录下生成对应的JSON名为文件夹
            string path = Application.StartupPath + "/GenerateFile/" + textBoxJsonName.Text + "_" + GetTimeString();

            Directory.CreateDirectory(path);

            //然后导出保存json文件到文件夹
            File.WriteAllText(path + "/" + textBoxJsonName.Text + ".json", JsonOperate.CurrentOpenJson.ToJson());

            //实现生成LitJson代码, 成文件.cs的形式
            string info = "";

            if (JsonOperate.ConvertToList(textBoxJsonEditor.Text, out info))
            {
                string code = JsonOperate.GenerateCode(textBoxJsonName.Text, textBoxJsonName.Text);

                File.WriteAllText(path + "/" + textBoxJsonName.Text + ".cs", code);
            }
            else
            {
                if (string.IsNullOrEmpty(info))
                {
                    MessageBox.Show("LitJson 代码文件生成失败\r\n");
                }
                else
                {
                    MessageBox.Show("LitJson 代码文件生成失败\r\n原因:" + info);
                }
            }

            //打开到刚刚保存的目录
            System.Diagnostics.Process.Start(path);
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text == "(未保存)")
            {
                return;
            }

            if (File.Exists(linkLabel2.Text))
            {
                Process.Start("explorer", "/select,\"" + linkLabel2.Text + "\"");
            }

        }

        private void listData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //如果是已经选中过则取消编辑框显示
            if (_textEdit.Visible)
            {
                _textEdit.Visible = false;
                _selectItem = null;
                return;
            }

            ListViewItem lv = listData.GetItemAt(e.X, e.Y);
            ListViewItem.ListViewSubItem item = lv.GetSubItemAt(e.X, e.Y);
            int index = lv.SubItems.IndexOf(item);

            Rectangle rect = lv.GetBounds(ItemBoundsPortion.Entire);
            Debug.Print("---------");
            Debug.Print(rect.Width + "");

            //起到编辑框的左边显示位置
            for (int i = 0; i < index; i++)
            {
                rect.X += listData.Columns[i].Width;
                //Debug.Print(rect.X.ToString());
            }

            rect.Width = listData.Columns[index].Width;
            _textEdit.Multiline = true;
            _textEdit.Parent = listData;
            _textEdit.Bounds = rect;

            _textEdit.Text = item.Text;
            _textEdit.SelectAll();

            _textEdit.Visible = true;
            _textEdit.Focus();
            _selectItem = item;
        }

        private void listData_MouseClick(object sender, MouseEventArgs e)
        {
            //如果是选择填充的时候则选择后直接返回
            if (_isSelectFill)
            {
                //取消选中
                listData.SelectedItems.Clear();

                //加入选择项目
                ListViewItem lv = listData.GetItemAt(e.X, e.Y);
                ListViewItem.ListViewSubItem item = lv.GetSubItemAt(e.X, e.Y);

                //判断是否添加过,如果没添加则添加, 已添加则取消选择
                if (!_selectFill.Contains(item))
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.FromArgb(0, 224, 128);
                    _selectFill.Add(item);
                }
                else
                {
                    item.ForeColor = _listColorFore;
                    item.BackColor = _listColorBack;
                    _selectFill.Remove(item);
                }

                labelSelectFill.Text = "已选择:" + _selectFill.Count;

                return;
            }

            //如果是已经选中过则取消编辑框显示
            if (_textEdit.Visible)
            {
                if (_selectItem != null)
                {
                    _selectItem.Text = _textEdit.Text;
                    _textEdit.Text = null;
                    _selectItem = null;
                    _textEdit.Visible = false;
                }
                return;
            }

            //当选中后可以单击就编辑
            if (checkBoxFastEdit.Checked)
            {
                ListViewItem lv = listData.GetItemAt(e.X, e.Y);
                ListViewItem.ListViewSubItem item = lv.GetSubItemAt(e.X, e.Y);
                int index = lv.SubItems.IndexOf(item);

                Rectangle rect = lv.GetBounds(ItemBoundsPortion.Entire);

                //起到编辑框的左边显示位置
                for (int i = 0; i < index; i++)
                {
                    rect.X += listData.Columns[i].Width;
                    //Debug.Print(rect.X.ToString());
                }

                rect.Width = listData.Columns[index].Width;
                _textEdit.Multiline = true;
                _textEdit.Parent = listData;
                _textEdit.Bounds = rect;

                _textEdit.Text = item.Text;
                _textEdit.SelectAll();

                _textEdit.Visible = true;
                _textEdit.Focus();
                _selectItem = item;
            }


        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            DelItem();
        }

        private void listData_KeyUp(object sender, KeyEventArgs e)
        {
            //如果没有表数据则返回
            if (JsonOperate.CurrentOpenJson == null || listData.Columns.Count == 0)
            {
                return;
            }


            //快捷键设置
            if (e.KeyCode == Keys.Add)//增加表项
            {
                AddItem();
            }

            if (e.KeyCode == Keys.Delete)
            {
                DelItem();
            }
        }

        private void AddItem()
        {
            //如果没有表数据则返回
            if (JsonOperate.CurrentOpenJson == null || listData.Columns.Count == 0)
            {
                return;
            }

            //添加表项
            ListViewItem item = new ListViewItem();
            item.Text = "";
            item.BackColor = _listColorBack;
            item.ForeColor = _listColorFore;

            //让每项都不继承父项的样式 , 使得每一项都拥有自己的样式
            item.UseItemStyleForSubItems = false;

            for (int i = 0; i < listData.Columns.Count - 1; i++)
            {
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem();
                sub.Text = "";
                sub.ForeColor = _listColorFore;
                sub.BackColor = _listColorBack;

                item.SubItems.Add(sub);
            }

            listData.Items.Add(item);

            //跟随滚动条显示刚刚添加的表项
            listData.EnsureVisible(listData.Items.Count - 1);

            ListViewItem.ListViewSubItem subItem = listData.Items[listData.Items.Count - 1].SubItems[0];

            //将焦点放到刚才新建的表项上, 并且打开编辑
            Rectangle rect = subItem.Bounds;

            //设置标记文本框
            _textEdit.Multiline = true;
            _textEdit.Text = "";
            _textEdit.Bounds = rect;
            _textEdit.Parent = listData;
            _textEdit.Width = rect.Width;
            _textEdit.Visible = true;
            _textEdit.Focus();

            _selectItem = subItem;

        }

        private void DelItem()
        {
            ListView.SelectedIndexCollection collection = listData.SelectedIndices;
            for (int i = collection.Count; i > 0; i--)
            {
                listData.Items.RemoveAt(collection[i - 1]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isSelectFill = true;
            btnAffirmFill.Visible = true;
            btnCancelFill.Visible = true;

            labelSelectFill.Visible = true;

            checkBoxFastEdit.Checked = false;

            labelSelectFillHint.Visible = true;
        }


        public void SetListData(string[] arr)
        {
            //如果选择的文件数量小于选择表项,则不操作
            if (arr.Length != _selectFill.Count)
            {
                MessageBox.Show(string.Format(
                    "选择文件数量:{0}\r\n" +
                    "选择表项数量:{1}\r\n" +
                    "\r\n" +
                    "数量不匹配, 请准确选择后操作"
                    , arr.Length
                    , _selectFill.Count
                    ));

                return;
            }

            //获取选中的列索引
            for (int i = 0; i < arr.Length; i++)
            {
                _selectFill[i].Text = arr[i];
                _selectFill[i].ForeColor = _listColorFore;
                _selectFill[i].BackColor = _listColorBack;
            }

        }

        public void HideSelectFill()
        {
            for (int i = 0; i < _selectFill.Count; i++)
            {
                _selectFill[i].BackColor = _listColorBack;
                _selectFill[i].ForeColor = _listColorFore;
            }

            _selectFill.Clear();
            _isSelectFill = false;

            btnAffirmFill.Visible = false;
            btnCancelFill.Visible = false;

            labelSelectFill.Visible = false;

            labelSelectFillHint.Visible = false;
        }

        private void btnCancelFill_Click(object sender, EventArgs e)
        {
            HideSelectFill();
        }



        private void btnAffirmFill_Click(object sender, EventArgs e)
        {
            if (_selectFill.Count == 0)
            {
                MessageBox.Show("请选中需要填充的表项");
                return;
            }
            Debug.Print(_selectFill.Count + "");
            FillData fillData = new FillData();
            fillData.ShowDialog();


        }
    }
}