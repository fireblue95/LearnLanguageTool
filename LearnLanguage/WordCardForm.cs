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
    public partial class WordCardForm : Form
    {

        List<List<object>> dataList = null;
        int num = 0;
        int progressCount = 0;
        bool displayCN = false;
        bool[] progressNum = null;
        bool showWordCardSearchForm = false;


        public WordCardForm()
        {
            InitializeComponent();
        }

        private void Label1Update()
        {
            if (!progressNum[num])
            {
                progressNum[num] = true;
                progressCount++;
            }
            this.progressBar1.Value = progressCount;
            this.lbProgress.Text = Math.Round((((float)progressCount / (float)progressNum.Length) * 100.0), 2) + "%";
            displayCN = false;
            this.label1.Text = dataList[num][0].ToString();
        }

        private void Label1UpdateCN()
        {
            displayCN = !displayCN;

            if (displayCN)
                this.label1.Text = dataList[num][1].ToString();
            else
                this.label1.Text = dataList[num][0].ToString();
        }

        public void WordCardFormInit(List<List<object>> data)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = data.Count;

            progressCount = 0;
            progressNum = new bool[data.Count];
            
            var rnd = new Random();
            dataList = data.OrderBy(Item => rnd.Next()).ToList();
            num = 0;
            Label1Update();
        }

        private void WordCardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnPre_ClickFunction()
        {
            num = (num - 1 + dataList.Count) % dataList.Count;
            Label1Update();

            if (showWordCardSearchForm)
            {
                MainForm.wordCardSearchForm.listView1_update(dataList, num);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            btnPre_ClickFunction();
        }

        private void btnNext_ClickFunction()
        {
            num = (num + 1) % dataList.Count;
            Label1Update();

            if (showWordCardSearchForm)
            {
                MainForm.wordCardSearchForm.listView1_update(dataList, num);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext_ClickFunction();
        }

        private void btnBack_ClickFunction()
        {
            if (showWordCardSearchForm)
            {
                btnWordCardSearch_ClickFunction();
            }
            this.Visible = false;
            MainForm.choiceDataForm.Visible = true;
            MainForm.choiceDataForm.listView1_Init();
            MainForm.choiceDataForm.listView2_update(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack_ClickFunction();
        }

        private void WordCardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                btnPre_ClickFunction();
            }
            else if (e.KeyCode == Keys.D)
            {
                btnNext_ClickFunction();
            }
            else if (e.KeyCode == Keys.S)
            {
                Label1UpdateCN();
            }
            else if (e.KeyCode == Keys.F && showWordCardSearchForm)
            {
                MainForm.wordCardSearchForm.tbSearchFocus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnBack_ClickFunction();
            }else if (e.KeyCode == Keys.ControlKey)
            {
                btnWordCardSearch_ClickFunction();
            }

        }

        public void btnWordCardSearch_ClickFunction()
        {
            if (MainForm.wordCardSearchForm == null)
            {
                MainForm.wordCardSearchForm = new WordCardSearchForm();
            }

            if (showWordCardSearchForm)//已經顯示, 按下後要關閉
            {

                showWordCardSearchForm = false;
                MainForm.wordCardSearchForm.tbSearchClear();
                MainForm.wordCardSearchForm.Visible = false;
            }
            else//未顯示, 按下後顯示
            {
                showWordCardSearchForm = true;
                MainForm.wordCardSearchForm.Visible = true;
                MainForm.wordCardSearchForm.Location = new Point(
                    this.Location.X + this.Width - 15, this.Location.Y);
                MainForm.wordCardSearchForm.listView1_update(dataList, num);
            }

            this.Focus();
        }

        private void btnWordCardSearch_Click(object sender, EventArgs e)
        {
            btnWordCardSearch_ClickFunction();
        }

        private void WordCardForm_LocationChanged(object sender, EventArgs e)
        {
            if (showWordCardSearchForm)
            {
                MainForm.wordCardSearchForm.Location = new Point(
                    this.Location.X + this.Width - 15, this.Location.Y);
            }
        }

        private void btnCheckTans_Click(object sender, EventArgs e)
        {
            Label1UpdateCN();
        }
    }
}
