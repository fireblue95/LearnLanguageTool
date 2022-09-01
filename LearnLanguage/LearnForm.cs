using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnLanguage
{
    public partial class LearnForm : Form
    {

        List<List<object>> dataList = null;
        List<List<int>> countList = null;
        List<List<int>> usedCountList = null;

        int nowPoint = 0;
        int answerId = -1;

        //wrongToRevise == true ==> 答錯, 需要修改
        //wrongToRevise == false ==> 沒答錯, 正常答題
        bool wrongToRevise = false;
        bool showOverViewForm = false;

        Stopwatch perStopWatch = new Stopwatch();


        // countList = [Id, 連續答對次數, 總答對次數, 總答錯次數, countList的ID, 單場答對次數, 單場答錯次數, 最快答對時間]
        // usedList = [Id, 連續答對次數, 總答對次數, 總答錯次數, countList的ID]

        public LearnForm()
        {
            InitializeComponent();
           // Console.WriteLine();
        }

        public void LearnFormInit(List<List<object>> data)
        {
            this.tbResponse.Focus();
            Console.WriteLine("time start+++");
            MainForm.mainForm.stopWatch.Start();
            

            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = data.Count * 3;

            //progressCount = 0;
            //progressNum = new bool[data.Count];

            dataList = data;
            nowPoint = 0;

            countList = new List<List<int>>();

            for (int i = 0; i < data.Count; i++)
            {
                List<int> tempList = new List<int>();


                // 0 id
                tempList.Add(i);

                // 1 連續答對次數
                tempList.Add(0);

                // 2 總答對次數
                if (data[i][2].ToString().Trim() == "" || !char.IsDigit(data[i][2].ToString().Trim(), 0))
                {
                    tempList.Add(0);
                }
                else
                {
                    tempList.Add(int.Parse(data[i][2].ToString()));
                }

                // 3 總答錯次數
                if (data[i][3].ToString().Trim() == "" || !char.IsDigit(data[i][3].ToString().Trim(), 0))
                {
                    tempList.Add(0);
                }
                else
                {
                    tempList.Add(int.Parse(data[i][3].ToString()));
                }
                
                tempList.Add(0); // 4 countList的ID
                tempList.Add(0); // 5 單場答對次數
                tempList.Add(0); // 6 單場答錯次數
                tempList.Add(Convert.ToInt32(TimeSpan.Parse(data[i][4].ToString()).TotalMilliseconds)); // 7 最快答對時間
                countList.Add(tempList);
            }


            var rnd = new Random();
            countList = countList.OrderBy(Item => rnd.Next()).ToList();
            //num = 0;
            //Label1Update();
            for (int i = 0; i < countList.Count; i++)
            {
                countList[i][4] = i;
            }

            usedCountList = countList.Where(x => x[1] == 0).ToList();


            LearnForm_LabelUpdate();
        }

        private void LearnForm_LabelUpdate()
        {
            perStopWatch.Reset();
            perStopWatch.Start();


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
                    MainForm.mainForm.stopWatch.Stop();
                    MainForm.choiceDataForm.writeToTxt(false, true);
                    btnBack_ClickFunction();
                    return;
                }
            }

            answerId = usedCountList[nowPoint][0];
            this.label1.Text = dataList[answerId][0].ToString();

            this.tbResponse.Focus();

        }

        private void btnBack_ClickFunction()
        {
            wrongToRevise = false;
            perStopWatch.Stop();
            perStopWatch.Reset();

            if (showOverViewForm)
            {
                btOverView_ClickFunction();
            }
            MainForm.mainForm.WriteToExcel(countList, true);

            MainForm.mainForm.stopWatch.Stop();
            //MainForm.choiceDataForm.writeToTxt(false, true);
            MainForm.mainForm.stopWatch.Reset();

            this.Visible = false;
            this.tbResponse.Text = "";
            MainForm.choiceDataForm.Visible = true;
            MainForm.choiceDataForm.listView1_Init();
            MainForm.choiceDataForm.listView2_update(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack_ClickFunction();
        }

        private void LearnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.mainForm.WriteToExcel(countList, true);
            Environment.Exit(0);
        }

        private void LearnForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnBack_ClickFunction();
            }else if(e.KeyCode == Keys.Enter)
            {
                btnNext_ClickFunction();
            }else if(e.KeyCode == Keys.ControlKey)
            {
                btOverView_ClickFunction();
            }
        }

        private void btnNext_ClickFunction()
        {

            //split(", ")
            //split("，")
            //split("(...)")
            //[\(].*?[\)]
            //Console.WriteLine("QQ:==>" + Regex.Replace(dataList[answerId][1].ToString(), "[(].*?[)]", ""));

            string correctAnswer = dataList[answerId][1].ToString().Replace("…", "...").Trim();
            bool isCorrect = false;

            if (this.ckboxMultiAns.Checked) // 允許多個答案
            {
                string[] tempStrArray = new Regex("[(].*?[)]|，|,| |:|;|；|、|/").Split(correctAnswer);

                foreach (string xx in tempStrArray)
                {
                    if (xx.Trim() == "")
                    {
                        continue;
                    }

                    if (this.tbResponse.Text.Trim() == xx.Trim())
                    {
                        isCorrect = true;
                        break;
                    }
                }
            }
            else // 允許單一答案
            {
                if (this.tbResponse.Text.Trim() == correctAnswer)
                {
                    isCorrect = true;
                }
            }

            

            if(isCorrect)
            {
                if (wrongToRevise)//答錯, 修改答案
                {
                    perStopWatch.Stop();
                    wrongToRevise = false;
                }
                else//正常答題
                {
                    perStopWatch.Stop();
                    TimeSpan ts = perStopWatch.Elapsed;

                    TimeSpan oldTs = TimeSpan.FromMilliseconds(countList[usedCountList[nowPoint][4]][7]);
                    //Console.WriteLine("ts:" + ts.ToString("hh':'mm':'ss'.'ff"));
                    //Console.WriteLine("oldTs:" + oldTs.ToString("hh':'mm':'ss'.'ff"));
                    //Console.WriteLine(oldTs.TotalMilliseconds == 0);
                    //Environment.Exit(0);

                    countList[usedCountList[nowPoint][4]][1]++; // 連續答對次數++
                    countList[usedCountList[nowPoint][4]][2]++; // 總答對次數++
                    countList[usedCountList[nowPoint][4]][5]++; // 單場答對次數++
                    countList[usedCountList[nowPoint][4]][7] = (oldTs <= ts && oldTs.TotalMilliseconds != 0) ? Convert.ToInt32(oldTs.TotalMilliseconds) : Convert.ToInt32(ts.TotalMilliseconds);
                }

                MessageBox.Show("Correct!\n" +
                    dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString());
                this.tbResponse.Text = "";
                nowPoint++;
                LearnForm_LabelUpdate();
            }
            else
            {
                if (!wrongToRevise)//沒答錯過, 歸零
                {
                    countList[usedCountList[nowPoint][4]][1] = 0; // 連續答對次數 = 0
                    countList[usedCountList[nowPoint][4]][3]++; // 總答錯次數++
                    countList[usedCountList[nowPoint][4]][6]++; // 單場答錯次數++

                    wrongToRevise = true;
                }
                MessageBox.Show("Wrong!\n" +
                   dataList[answerId][0].ToString() + " ==> " + dataList[answerId][1].ToString());
            }
            if (showOverViewForm)
            {
                MainForm.overViewForm.listView1_update(dataList, countList, usedCountList[nowPoint][4]);
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext_ClickFunction();
        }

        public void btOverView_ClickFunction()
        {
            //Console.WriteLine("point:" + this.nowPoint);
            //Console.WriteLine("Location:" + this.Location);
            //Console.WriteLine("w" + this.Width);
            //Console.WriteLine("h" + this.Height);

            if (MainForm.overViewForm == null)
            {
                MainForm.overViewForm = new OverViewForm();
            }

            if (showOverViewForm)//已經顯示, 按下後要關閉
            {
                showOverViewForm = false;
                MainForm.overViewForm.Visible = false;
            }
            else//未顯示, 按下後顯示
            {
                showOverViewForm = true;
                MainForm.overViewForm.Visible = true;
                MainForm.overViewForm.Location = new Point(
                    this.Location.X + this.Width - 15, this.Location.Y);
                MainForm.overViewForm.listView1_update(dataList, countList, usedCountList[nowPoint][4]);
            }

            this.Focus();
            this.tbResponse.Focus();

        }

        private void btOverView_Click(object sender, EventArgs e)
        {
            btOverView_ClickFunction();
        }

        private void LearnForm_LocationChanged(object sender, EventArgs e)
        {
            if (showOverViewForm)
            {
                MainForm.overViewForm.Location = new Point(
                    this.Location.X + this.Width - 15, this.Location.Y);
            }
        }
    }
}
