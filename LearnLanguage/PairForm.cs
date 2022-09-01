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
    public partial class PairForm : Form
    {

        List<List<object>> dataList = null;
        List<List<int>> countList = null;
        List<List<int>> usedCountList = null;

        int nowPoint = 0;
        int answerId = -1;
        int testId = -1;

        // countList = [Id, 連續答對次數, 總答對次數, 總答錯次數, countList的ID]
        // usedList = [Id, 連續答對次數, 總答對次數, 總答錯次數, countList的ID]


        public PairForm()
        {
            InitializeComponent();
        }
        public void PairFormInit(List<List<object>> data)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = data.Count * 3;

            //progressCount = 0;
            //progressNum = new bool[data.Count];

            dataList = data;
            nowPoint = 0;

            countList = new List<List<int>>();

            for (int i=0; i < data.Count; i++)
            {
                List<int> tempList = new List<int>();
                tempList.Add(i);
                tempList.Add(0);
                tempList.Add(int.Parse(data[i][2].ToString()));
                tempList.Add(int.Parse(data[i][3].ToString()));
                tempList.Add(0);
                countList.Add(tempList);
            }


            var rnd = new Random();
            countList = countList.OrderBy(Item => rnd.Next()).ToList();
            //num = 0;
            //Label1Update();
            for(int i=0; i < countList.Count; i++)
            {
                countList[i][4] = i;
            }

            usedCountList = countList.Where(x => x[1] == 0).ToList();


            PairForm_LabelUpdate();

        }

        


        private void PairForm_LabelUpdate()
        {
            var nowCountCorrectNum = countList.Sum(x => x[1]);
            this.progressBar1.Value = nowCountCorrectNum;
            this.lbProgress.Text = Math.Round((((float)nowCountCorrectNum / ((float)countList.Count * 3)) * 100.0), 2) + "%";

            if (nowPoint >= usedCountList.Count)
            {
                nowPoint = 0;

                for (int i = 0; i < 3; i++)
                {
                    usedCountList = countList.Where(x => x[1] == i).ToList();
                    if (usedCountList.Count > 0)
                    {
                        Random rrnd = new Random();
                        usedCountList = usedCountList.OrderBy(Item => rrnd.Next()).ToList();
                        break;
                    }
                }
                if (usedCountList.Count == 0)
                {
                    MessageBox.Show("恭喜!\n此資料集學習完畢");
                    btnBack_ClickFunction();
                    return;
                }
            }

            answerId = usedCountList[nowPoint][0];
            this.label1.Text = dataList[answerId][0].ToString();


            // 選三個單字 => [答案單字, 隨機一個, 隨機一個]
            // 打亂順序選第0個

            List<int> choiceNum = Enumerable.Range(0, dataList.Count).ToList();
            choiceNum.Remove(answerId);

            var rnd = new Random();
            choiceNum = choiceNum.OrderBy(Item => rnd.Next()).ToList();

            List<int> tempChoiceNum3 = new List<int>();
            tempChoiceNum3.Add(answerId);
            if (choiceNum.Count > 0)
            {
                tempChoiceNum3.Add(choiceNum[0]);
            }
            if (choiceNum.Count > 1)
            {
                tempChoiceNum3.Add(choiceNum[1]);
            }
            tempChoiceNum3 = tempChoiceNum3.OrderBy(Item => rnd.Next()).ToList();
            
            testId = tempChoiceNum3[0];
            this.label2.Text = dataList[testId][1].ToString();
        }

        private void PairForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.mainForm.WriteToExcel(countList);
            Environment.Exit(0);
        }

        private void btnCorrectFunction()
        {
            if (answerId == testId)
            {
                countList[usedCountList[nowPoint][4]][1]++;
                countList[usedCountList[nowPoint][4]][2]++;
                MessageBox.Show("Correct!\n" +
                    dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString());
            }
            else
            {
                countList[usedCountList[nowPoint][4]][1] = 0;
                countList[usedCountList[nowPoint][4]][3]++;
                MessageBox.Show("Wrong!\n" +
                   dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString() + "\n" +
                   dataList[testId][0].ToString() + " ==> " + dataList[testId][1].ToString());
            }
            nowPoint++;
            PairForm_LabelUpdate();
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            btnCorrectFunction();
        }

        private void btnWrongFunction()
        {
            if (answerId != testId)
            {
                countList[usedCountList[nowPoint][4]][1]++;
                countList[usedCountList[nowPoint][4]][2]++;
                MessageBox.Show("Correct!\n" +
                    dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString() + "\n" +
                    dataList[testId][0].ToString() + " ==> " + dataList[testId][1].ToString());
            }
            else
            {
                countList[usedCountList[nowPoint][4]][1] = 0;
                countList[usedCountList[nowPoint][4]][3]++;
                MessageBox.Show("Wrong!\n" +
                    dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString());
            }
            nowPoint++;
            PairForm_LabelUpdate();
        }

        private void btnWrong_Click(object sender, EventArgs e)
        {
            btnWrongFunction();
        }

        private void PairForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                btnCorrectFunction();
            }else if (e.KeyCode == Keys.D)
            {
                btnWrongFunction();
            }else if (e.KeyCode == Keys.Escape)
            {
                btnBack_ClickFunction();
            }
            var tempSum = countList.Sum(x => x[1]);
        }

        private void btnBack_ClickFunction()
        {
            MainForm.mainForm.WriteToExcel(countList);
            this.Visible = false;
            MainForm.choiceDataForm.Visible = true;
            MainForm.choiceDataForm.listView1_Init();
            MainForm.choiceDataForm.listView2_update(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack_ClickFunction();
        }
    }
}
