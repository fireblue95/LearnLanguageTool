using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LearnLanguage
{
    public partial class MainForm : Form
    {
        List<string> files = new List<string>();
        public static string currentFilePath = null;


        public static ChoiceDataForm choiceDataForm = null;
        public static MainForm mainForm = null;
        public static WordCardForm wordCardForm = null;
        public static PairForm pairForm = null;
        public static AddDataForm addDataForm = null;
        public static LearnForm learnForm = null;
        public static OverViewForm overViewForm = null;
        public static WordCardSearchForm wordCardSearchForm = null;
        public static SearchForm searchForm = null;


        public Stopwatch stopWatch = new Stopwatch();


        /*
            -- 字卡 --
            1. 1. 儲存所有資料到List
                類型:
                    [英文, 中文]
            2. 打亂List順序
            3. 逐個顯示資料

            -- 配對 學習 --
            1. 儲存所有資料到ListArr
                類型:
                    [英文, 中文, 顯示次數]
            2. x打亂List資料順序
                
                設List<int>儲存[ID, 答對次數], 打亂new List
                依照new List打亂後的順序進行讀取List Arr
                若無連續答對三次則歸0重新計算, 使用where(x=>...)取得資料
                一次全部從頭到尾, 第二次先取得答對次數最少的, 之後random new List, 

            3. 設置x儲存min顯示次數
            4. 把[顯示次數==x]的資料取出
            5. 一個一個顯示出來
            6. 答對後顯示次數+1
            7. 取出的資料顯示完後
        */


        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
            this.listView1.FullRowSelect = true;

            
        }

        public string getWatchTime()
        {
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);
            stopWatch.Reset();
            return elapsedTime;
        }

        private void listView1_update()
        {
            listView1.Clear();

            listView1.View = View.Details;
            listView1.Columns.Add("File Name", 370, System.Windows.Forms.HorizontalAlignment.Left);

            foreach (string x in files)
            {
                //Console.WriteLine(x);
                ListViewItem lvi = new ListViewItem(x);
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void btnAdd_ClickFunction()
        {
            //Console.WriteLine("test");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "選擇學習資料";
            dialog.Filter = "xlsx(*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var temp_files = files.ToArray();
                foreach (string x in dialog.FileNames)
                {
                    if (Array.IndexOf(temp_files, x) == -1)
                    {
                        files.Add(x);
                    }
                }

                listView1_update();

            }

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd_ClickFunction();
        }

        private void btnRemove_ClickFunction()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var temp_files = files.ToArray();
                temp_files = temp_files.Where(x => x != listView1.SelectedItems[0].Text).ToArray();
                files = temp_files.ToList();
                listView1_update();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            btnRemove_ClickFunction();
        }


        private void btnNext_ClickFunction()
        {
            if (files.Count > 0)
            {
                this.Visible = false;
                if (choiceDataForm == null)
                    choiceDataForm = new ChoiceDataForm();
                choiceDataForm.updateFiles(this.files);
                choiceDataForm.Visible = true;

                //choiceDataForm.files = ;
                choiceDataForm.listView1_Init();
            }
            else
            {
                MessageBox.Show("至少選擇一個資料集");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext_ClickFunction();
        }


        private void btnRemoveAll_ClickFunction()
        {
            files = new List<string>();
            listView1_update();
        }


        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            btnRemoveAll_ClickFunction();
        }


        public void WriteToExcel(List<List<int>> _countList, bool writeTime=false)
        {
            //string exportExcelPath = "D:\\Users\\Chen\\Desktop\\export.xlsx";
            IWorkbook workbook = WorkbookFactory.Create(currentFilePath);
            ISheet sheet = workbook.GetSheetAt(0);

            foreach (List<int> x in _countList)
            {
                IRow row = (IRow)sheet.GetRow(x[0]);
                //Console.WriteLine(sheet.GetRow(0).Cells.Count);
                //Console.WriteLine(sheet.GetRow(0).GetCell(1));
                row.CreateCell(2).SetCellValue(x[2]); // 總答對題數
                row.CreateCell(3).SetCellValue(x[3]); // 總答錯題數

                if (writeTime)
                    row.CreateCell(4).SetCellValue(TimeSpan.FromMilliseconds(x[7]).ToString("hh':'mm':'ss'.'ff")); // 最快答對時間

            }

            FileStream fs = new FileStream(currentFilePath, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                btnAdd_ClickFunction();
            }
            else if (e.KeyCode == Keys.E)
            {
                btnRemove_ClickFunction();
            }
            else if (e.KeyCode == Keys.C)
            {
                btnRemoveAll_ClickFunction();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnNext_ClickFunction();
            }
            else if (e.KeyCode == Keys.W)
            {
                if (this.listView1.SelectedIndices.Count > 0)
                {
                    int nextNum = (listView1.SelectedIndices[0] - 1 + listView1.Items.Count) % listView1.Items.Count;
                    listView1.Items[listView1.SelectedIndices[0]].Selected = false;
                    listView1.Items[nextNum].Selected = true;
                }
                else
                {
                    listView1.Items[0].Selected = true;
                }

            }
            else if (e.KeyCode == Keys.S)
            {
                if (this.listView1.SelectedIndices.Count > 0)
                {
                    int nextNum = (listView1.SelectedIndices[0] + 1) % listView1.Items.Count;
                    listView1.Items[listView1.SelectedIndices[0]].Selected = false;
                    listView1.Items[nextNum].Selected = true;
                }
                else
                {
                    listView1.Items[0].Selected = true;
                }

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }

        
    }
}
