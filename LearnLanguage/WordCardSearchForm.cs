using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnLanguage
{
    public partial class WordCardSearchForm : Form
    {

        List<List<object>> data = null;

        public WordCardSearchForm()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;

        }

        public void listView1_update(List<List<object>> dataList, int nowPoint)
        {
            this.listView1.Clear();

            this.listView1.Columns.Add("名稱", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("中文", 80, HorizontalAlignment.Left);

            data = dataList;

            for (int i = 0; i < dataList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dataList[i][0].ToString());
                lvi.SubItems.Add(dataList[i][1].ToString());
                

                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();

            this.listView1.Items[nowPoint].Selected = true;
        }

        private void WordCardSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                MainForm.wordCardForm.btnWordCardSearch_ClickFunction();
            }else if (e.KeyCode == Keys.Enter)
            {
                btnSearch_ClickFunction();
            }
        }

        private void btnSearch_ClickFunction()
        {
            if (this.tbSearch.Text.Trim() == "")
            {
                MessageBox.Show("請輸入要搜尋的內容");
            }
            else
            {
                bool finded = false;
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i][0].ToString().ToLower() == this.tbSearch.Text.ToLower())
                    {
                        if (this.listView1.SelectedIndices.Count > 0)
                        {
                            this.listView1.SelectedItems[0].Selected = false;
                        }

                        finded = true;
                        this.listView1.Items[i].Selected = true;
                        this.listView1.EnsureVisible(i);
                        break;
                    }
                }

                if (!finded)
                    MessageBox.Show("找不到此單字");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch_ClickFunction();
        }

        public void tbSearchFocus()
        {
            this.tbSearch.Focus();
        }

        public void tbSearchClear()
        {
            this.tbSearch.Text = "";
        }


    }
}
