using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnLanguage
{
    public partial class SearchForm : Form
    {

        List<string> files = new List<string>();
        List<List<string>> searchDataList = null;


        public SearchForm()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
        }

        public void SearchForm_Init(List<string> _files)
        {
            this.files = _files;
            searchDataList = new List<List<string>>();
        }

        private void ckBoxEn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckBoxEn.Checked && this.ckBoxCn.Checked)
            {
                this.ckBoxCn.Checked = false;
                this.textBox1.Focus();
            }
        }

        private void ckBoxCn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckBoxCn.Checked && this.ckBoxEn.Checked)
            {
                this.ckBoxEn.Checked = false;
                this.textBox1.Focus();
            }
        }


        private void btnSearch_ClickFunction()
        {
            if (!this.ckBoxEn.Checked && !this.ckBoxCn.Checked)
            {
                MessageBox.Show("請至少選擇一個要搜尋英文或中文");
            }
            else if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入要搜尋的內容");
            }
            else
            {

                changeEnabled(false);
                searchDataFromExcel();
                listView1_update();
                changeEnabled(true);
                MessageBox.Show("搜尋完成");
            }
            this.textBox1.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch_ClickFunction();
        }

        private void changeEnabled(bool changeTo)
        {
            this.ckBoxEn.Enabled = changeTo;
            this.ckBoxCn.Enabled = changeTo;
            this.textBox1.Enabled = changeTo;
            this.btnSearch.Enabled = changeTo;
        }


        private void listView1_update()
        {
            this.listView1.Clear();

            this.listView1.Columns.Add("ID", 30, System.Windows.Forms.HorizontalAlignment.Center);
            this.listView1.Columns.Add("名稱", 100, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView1.Columns.Add("英文", 100, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView1.Columns.Add("中文", 130, System.Windows.Forms.HorizontalAlignment.Left);

            for (int i = 0; i < this.searchDataList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(this.searchDataList[i][0].Trim());
                
                // Columns
                for (int k = 1; k < this.searchDataList[0].Count; k++)
                {
                    lvi.SubItems.Add(this.searchDataList[i][k].Trim());
                }
                this.listView1.Items.Add(lvi);
            }
        }


        private void searchDataFromExcel()
        {
            int allFindedCount = 0;
            this.searchDataList.Clear();


            for (int _id=0; _id < this.files.Count; _id++)
            {
                try
                {
                    IWorkbook workbook = WorkbookFactory.Create(this.files[_id]);
                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 0; i <= sheet.LastRowNum; i++) // Rows
                    {
                        List<string> temp = new List<string>();

                        IRow row = sheet.GetRow(i);
                        if (row == null)
                        {
                            MessageBox.Show("此檔案是空的, 請選擇其他資料集");
                            break;
                        }

                        if (this.ckBoxEn.Checked)
                        {
                            string targetStr = this.textBox1.Text.Trim().ToLower();
                            string findStr = row.GetCell(0).ToString().Trim().ToLower();

                            if (findStr.Contains(targetStr))
                            {
                                temp.Add((++allFindedCount).ToString());
                                temp.Add(Path.GetFileName(this.files[_id]));
                                temp.Add(row.GetCell(0).ToString());
                                temp.Add(row.GetCell(1).ToString());
                                this.searchDataList.Add(temp);
                            }

                        }else if (this.ckBoxCn.Checked)
                        {
                            string targetStr = this.textBox1.Text.Trim().ToLower();
                            string findStr = row.GetCell(1).ToString().Trim().ToLower();

                            if (findStr.Contains(targetStr))
                            {
                                temp.Add((++allFindedCount).ToString());
                                temp.Add(Path.GetFileName(this.files[_id]));
                                temp.Add(row.GetCell(0).ToString());
                                temp.Add(row.GetCell(1).ToString());
                                this.searchDataList.Add(temp);
                            }
                        }


                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("此檔案正在其他程式使用中, 此次搜尋將會跳過此檔案");
                }
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (this.ckBoxEn.Checked)
                {
                    this.ckBoxEn.Checked = false;
                    this.ckBoxCn.Checked = true;
                    this.textBox1.Focus();
                }else if (this.ckBoxCn.Checked)
                {
                    this.ckBoxEn.Checked = true;
                    this.ckBoxCn.Checked = false;
                    this.textBox1.Focus();
                }
            }else if (e.KeyCode == Keys.Enter)
            {
                btnSearch_ClickFunction();
            }else if (e.KeyCode == Keys.Escape)
            {
                btnClose_ClickFunction();
            }

        }

        private void btnClose_ClickFunction()
        {
            this.Visible = false;
            //MainForm.mainForm.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose_ClickFunction();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                MainForm.choiceDataForm.listView1_selectedFromFiles(this.searchDataList[this.listView1.SelectedIndices[0]][1]);
                MainForm.choiceDataForm.listView2_selectedFromFiles(this.searchDataList[this.listView1.SelectedIndices[0]][2]);
                
                Console.WriteLine(this.searchDataList[this.listView1.SelectedIndices[0]][1]);
            }
        }

        public void textBox1_Focus()
        {
            this.textBox1.Focus();
        }
    }
}
