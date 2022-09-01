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
    public partial class OverViewForm : Form
    {
        public OverViewForm()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
        }

        public void listView1_update(List<List<object>> dataList, List<List<int>> countList, int nowPoint)
        {
            this.listView1.Clear();

            this.listView1.Columns.Add("名稱", 130, HorizontalAlignment.Left);
            this.listView1.Columns.Add("✔", 30, HorizontalAlignment.Left);
            this.listView1.Columns.Add("O", 30, HorizontalAlignment.Left);
            this.listView1.Columns.Add("X", 30, HorizontalAlignment.Left);
            this.listView1.Columns.Add("最快答對時間", 85, HorizontalAlignment.Left);

            for (int i=0; i < countList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(dataList[countList[i][0]][0].ToString());
                lvi.SubItems.Add(countList[i][1].ToString()); // 連續答對次數
                lvi.SubItems.Add(countList[i][5].ToString()); // 單場答對次數
                lvi.SubItems.Add(countList[i][6].ToString()); // 單場答錯次數
                lvi.SubItems.Add(TimeSpan.FromMilliseconds(countList[i][7]).ToString("hh':'mm':'ss'.'ff")); // 最快答題時間

                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();

            this.listView1.Items[nowPoint].Selected = true;
            this.listView1.EnsureVisible(nowPoint);
        }

        private void OverViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                MainForm.learnForm.btOverView_ClickFunction();
            }
        }
    }
}
