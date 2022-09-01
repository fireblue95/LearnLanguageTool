//using ExcelDataReader;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LearnLanguage
{
    public partial class ChoiceDataForm : Form
    {

        public List<string> files = new List<string>();
        private List<List<object>> data = null;
        private List<List<string>> recordList = null;
        private List<List<string>> listView1DataList = null;

        private string txtPath = "./LearnLanguageRecord.txt";

        // [英文, 中文, 總答對次數, 總答錯次數, 總答題次數, 最快答對時間]
        private List<List<string>> listView2DataList = null;

        private bool[] listView1ColReversed = { false, false, false, false };
        private bool listView1HaveReversed = false;

        private bool[] listView2ColReversed = { false, false, false, false, false, false, false };
        private bool listView2HaveReversed = false;


        public ChoiceDataForm()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            this.listView2.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView2.FullRowSelect = true;
        }

        public void updateFiles(List<string> _files)
        {
            this.files = _files;
        }

        public void listView1_Init()
        {
            
            readFromTxt();
            listView1_update();
            this.listView2.Clear();
        }

        private void listView1_update()
        {
            this.listView1.Clear();
            //this.listView1.CheckBoxes = true;
            this.listView1.Columns.Add("名稱", 100, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView1.Columns.Add("學習次數", 60, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView1.Columns.Add("最快學習時間", 85, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView1.Columns.Add("上次學習時間", 120, System.Windows.Forms.HorizontalAlignment.Left);

            for (int i=0; i < listView1DataList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(listView1DataList[i][0]);
                lvi.SubItems.Add(listView1DataList[i][1]);
                lvi.SubItems.Add(listView1DataList[i][2]);
                lvi.SubItems.Add(listView1DataList[i][3]);
                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();

        }

        public void listView2_update(bool useSorted)
        {
            this.listView2.Clear();

            this.listView2.Columns.Add("ID", 30, System.Windows.Forms.HorizontalAlignment.Center);
            this.listView2.Columns.Add("英文", 100, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView2.Columns.Add("中文", 100, System.Windows.Forms.HorizontalAlignment.Left);
            this.listView2.Columns.Add("O", 30, System.Windows.Forms.HorizontalAlignment.Center);
            this.listView2.Columns.Add("X", 30, System.Windows.Forms.HorizontalAlignment.Center);
            this.listView2.Columns.Add("All", 50, System.Windows.Forms.HorizontalAlignment.Center);
            this.listView2.Columns.Add("最快答對時間", 85, System.Windows.Forms.HorizontalAlignment.Center);

            if (!useSorted)
                listView2DataList = new List<List<string>>();

            if(data != null)
            {
                if (data.Count != 0)
                {
                    if (!useSorted)
                    {
                        // Rows
                        for (int i = 0; i < data.Count; i++)
                        {
                            ListViewItem lvi = new ListViewItem((i + 1).ToString());
                            int allCount = 0;

                            List<string> tempList = new List<string>();
                            tempList.Add((i + 1).ToString());
                            // Columns
                            for (int k = 0; k < data[0].Count; k++)
                            {
                                if (k <= 1)
                                {
                                    // k == 0 英文
                                    // k == 1 中文
                                    lvi.SubItems.Add(data[i][k].ToString().Trim());
                                    tempList.Add(data[i][k].ToString().Trim());
                                }
                                else if (k > 1 && k < 4 && data[i][k].ToString().Trim() != "" && char.IsDigit(data[i][k].ToString().Trim(), 0))
                                {
                                    // k == 2 總答對次數
                                    // k == 3 總答錯次數
                                    allCount += Int32.Parse(data[i][k].ToString().Trim());
                                    lvi.SubItems.Add(data[i][k].ToString().Trim());
                                    tempList.Add(data[i][k].ToString().Trim());
                                }else if (k == 4)
                                {
                                    // 4 總答題次數
                                    lvi.SubItems.Add(allCount.ToString());
                                    tempList.Add(allCount.ToString());

                                    // 5 最快答對時間
                                    lvi.SubItems.Add(data[i][k].ToString().Trim());
                                    tempList.Add(data[i][k].ToString().Trim());
                                }
                                else
                                {
                                    lvi.SubItems.Add("0");
                                    tempList.Add("0");
                                }
                            }
                            


                            this.listView2.Items.Add(lvi);
                            listView2DataList.Add(tempList);
                        }
                    }else if (useSorted)
                    {
                        // Rows
                        for (int i = 0; i < listView2DataList.Count; i++)
                        {
                            ListViewItem lvi = new ListViewItem(listView2DataList[i][0]);

                            // Columns
                            for (int k = 1; k < listView2DataList[0].Count; k++)
                            {
                                lvi.SubItems.Add(listView2DataList[i][k]);
                            }
                            this.listView2.Items.Add(lvi);
                        }
                    }
                    
                }
            }
            this.listView2.EndUpdate();
        }

        private void ChoiceDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void initListView1ColReversed(int _id = -1)
        {
            for (int i = 0; i < listView1ColReversed.Length; i++)
            {
                listView1ColReversed[i] = false;
            }
            if (_id >= 0)
            {
                listView1ColReversed[_id] = true;
                listView1HaveReversed = true;
            }
        }

        private void initListView2ColReversed(int _id=-1)
        {
            for (int i = 0; i < listView2ColReversed.Length; i++)
            {
                listView2ColReversed[i] = false;
            }
            if (_id >= 0)
            {
                listView2ColReversed[_id] = true;
                listView2HaveReversed = true;
            }
        }


        private void ListViewLoadFile_Update()
        {
            data = new List<List<object>>();

            if (this.listView1.SelectedIndices.Count > 0)
            {
                //Console.WriteLine("selected~~~:" + files[this.listView1.SelectedIndices[0]]);

                MainForm.currentFilePath = files[this.listView1.SelectedIndices[0]];

                try
                {
                    IWorkbook workbook = WorkbookFactory.Create(files[this.listView1.SelectedIndices[0]]);
                    ISheet sheet = workbook.GetSheetAt(0);
                    /*
                    FileStream fStream = File.Open(files[this.listView1.SelectedIndices[0]], FileMode.Open, FileAccess.Read);

                    IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
                    DataSet resultDataSet = excelDataReader.AsDataSet();
                    */

                    //Console.WriteLine("Columns:----" + resultDataSet.Tables[0].Columns.Count);
                    //Console.WriteLine("Rows:----" + resultDataSet.Tables[0].Rows.Count);
                    //Console.WriteLine("sd:----" + resultDataSet.Tables[0].Rows[0].ItemArray[0].ToString());

                    //Console.WriteLine("LastRownum" + sheet.LastRowNum);
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    //for (int i = 0; i < resultDataSet.Tables[0].Rows.Count; i++)
                    {
                        List<object> temp = new List<object>();

                        IRow row = (IRow)sheet.GetRow(i);
                        //Console.WriteLine("i:" + i);

                        if (row == null)
                        {
                            MessageBox.Show("此檔案是空的, 請選擇其他資料集");
                            break;
                        }


                        /*for (int k = 0; k < row.Cells.Count; k++) // Col
                        {
                            //Console.WriteLine("k:" + k);

                            if (k > 1 && row.GetCell(k) == null)
                            {
                                temp.Add(0);
                            }
                            else
                            {
                                temp.Add(row.GetCell(k).ToString());
                                //temp.Add(resultDataSet.Tables[0].Rows[i][k]);
                            }
                        }
                        //for (int j=resultDataSet.Tables[0].Columns.Count; j < 4; j++)
                        for (int j = sheet.GetRow(i).Cells.Count; j < 4; j++)
                        {
                            temp.Add(0);
                        }


                        */
                        //Console.WriteLine("temp");

                        for (int k = 0; k < 5; k++) // Col
                        {
                            //Console.WriteLine("k:" + k);
                            if (k >= row.Cells.Count) // 沒寫過
                            {
                                if (k > 1 && k < 4) // 答對和答錯
                                {
                                    temp.Add(0); 
                                }else if (k == 4) // 最快答對時間
                                {
                                    temp.Add("00:00:00.00");
                                }
                            }else
                            {
                                if (row.GetCell(k).ToString().Trim() == "")
                                {
                                    if (k > 1 && k < 4)
                                    {
                                        temp.Add(0);
                                    }else if (k == 4)
                                    {
                                        temp.Add("00:00:00.00");
                                    }
                                }
                                else
                                {
                                    temp.Add(row.GetCell(k).ToString());
                                }
                            }
                        }
                        data.Add(temp);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("此檔案正在其他程式使用中, 請先關閉此檔案後再選取此資料集");
                }


            //excelDataReader.Close();
            //if (this.listView1.SelectedIndices.Count > 0)
            //Console.WriteLine("selected----:" + this.listView1.SelectedIndices[0]);
        }
            listView2_update(false);
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            initListView2ColReversed();
            ListViewLoadFile_Update();
            
        }

        private void btnWordCard_ClickFunction()
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                writeToTxt(false);
                closeThisForm();
                if (MainForm.wordCardForm == null)
                    MainForm.wordCardForm = new WordCardForm();

                MainForm.wordCardForm.Text = "字卡：" + this.listView1.SelectedItems[0].Text;
                MainForm.wordCardForm.Visible = true;
                MainForm.wordCardForm.WordCardFormInit(data);
            }
            else
                MessageBox.Show("至少選擇一個資料集");
        }

        private void btnWordCard_Click(object sender, EventArgs e)
        {
            btnWordCard_ClickFunction();
        }

        private void btnPre_ClickFunction()
        {
            closeThisForm();

            MainForm.mainForm.Visible = true;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            btnPre_ClickFunction();
        }

        private void btnPair_ClickFunction()
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                writeToTxt(false);
                closeThisForm();
                if (MainForm.pairForm == null)
                    MainForm.pairForm = new PairForm();

                MainForm.pairForm.Text = "配對：" + this.listView1.SelectedItems[0].Text;
                MainForm.pairForm.Visible = true;
                MainForm.pairForm.PairFormInit(data);
            }
            else
                MessageBox.Show("至少選擇一個資料集");
        }

        private void btnPair_Click(object sender, EventArgs e)
        {
            btnPair_ClickFunction();
        }

        private void btnLearn_ClickFunction()
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                writeToTxt(false);
                closeThisForm();
                if (MainForm.learnForm == null)
                    MainForm.learnForm = new LearnForm();

                MainForm.learnForm.Text = "學習：" + this.listView1.SelectedItems[0].Text;
                MainForm.learnForm.Visible = true;
                MainForm.learnForm.LearnFormInit(data);
            }
            else
                MessageBox.Show("至少選擇一個資料集");
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            btnLearn_ClickFunction();
        }

        private void ChoiceDataForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                ListViewLoadFile_Update();
            }
        }

        private void ChoiceDataForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnPre_ClickFunction();
            } else if (e.KeyCode == Keys.Q)
            {
                btnWordCard_ClickFunction();
            } else if (e.KeyCode == Keys.E)
            {
                btnPair_ClickFunction();
            } else if (e.KeyCode == Keys.R)
            {
                btnLearn_ClickFunction();
            } else if (e.KeyCode == Keys.F) 
            {
                btnSearch_ClickFunction();
            } else if (e.KeyCode == Keys.W)
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
        }

        /*
         * if(file not exists){
         *      => create listView1DataList
         *      => write empty file
         *      
         * }else{ // file exists
         *      => create listView1DataList
         *      => read from txt
         * }
         * 
         * => from {wordCardForm, pairForm, learnForm} back to this Form
         * => write new file
         * 
         * 
         */

        public void writeToTxt(bool _empty=false, bool writeTime=false)
        {
            List<List<string>> tempRecordList = new List<List<string>>(recordList);


            tempRecordList.Sort((x, y) => StringToTypeCompare(x[0], y[0], 0));
            //showListView1DataList();


            using (StreamWriter file = new StreamWriter(txtPath, append: false))
            {
                //var newLine = String.Format("{0}, {1}, {2}", this.listView1.SelectedItems[0].Text,
                //                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //                "0");
                foreach (List<string> _temp in tempRecordList)
                {
                    //Console.WriteLine(String.Format("temp[0]:{0}, temp[1]:{1}, temp[2]:{2}", _temp[0], _temp[1], _temp[2]));

                    string newLine = "";
                    int nowCount = int.Parse(_temp[1]);

                    string dTime = _temp[2] == "" ? "00:00:00.00" : _temp[2];

                    //Console.WriteLine("oldTime:" + dTime);

                    if (_empty || _temp[0] != this.listView1.SelectedItems[0].Text)
                    {
                        //if(this.listView1.SelectedItems.Count > 0)
                        //Console.WriteLine("!=" + _temp[0] + "--" + this.listView1.SelectedItems[0].Text);
                        newLine = String.Format("{0},{1},{2},{3}", _temp[0],
                                nowCount,
                                dTime,
                                _temp[3]);
                    }
                    else if (_temp[0] == this.listView1.SelectedItems[0].Text)
                    {
                        //if (this.listView1.SelectedItems.Count > 0)
                        // Console.WriteLine("==" + _temp[0] + "--" + this.listView1.SelectedItems[0].Text);

                        if (writeTime)
                        {
                            string newTime = MainForm.mainForm.getWatchTime();
                            //Console.WriteLine("newTime:" + newTime);

                            dTime = (TimeSpan.Parse(dTime) <= TimeSpan.Parse(newTime)) && (TimeSpan.Parse(dTime) != TimeSpan.Parse("00:00:00.00")) ? dTime : newTime;
                        }
                        newLine = String.Format("{0},{1},{2},{3}", _temp[0],
                                ++nowCount,
                                dTime,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    file.WriteLine(newLine);
                }
                file.Close();
            }
            
            
        }

        private void filesToListView1DataList(bool writeToRecordList=false)
        {
            recordList = new List<List<string>>();
            listView1DataList = new List<List<string>>();
            for (int i=0; i < files.Count; i++)
            {
                if (writeToRecordList)
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(Path.GetFileName(files[i]));
                    tempList.Add("0"); 
                    tempList.Add("00:00:00.00");
                    tempList.Add("");

                    recordList.Add(tempList);
                }

                List<string> tempList2 = new List<string>();
                tempList2.Add(Path.GetFileName(files[i]));
                tempList2.Add("0");
                tempList2.Add("00:00:00.00");
                tempList2.Add("");
                // recordId
                if (writeToRecordList)
                {
                    tempList2.Add(i.ToString());
                }
                else
                {
                    tempList2.Add("");
                }
                
                listView1DataList.Add(tempList2);
                //Console.WriteLine("record count:" + recordList[0].Count);
                //Console.WriteLine("listView1DataList count:" + listView1DataList[0].Count);
            }

            //showListView1DataList();
            //Console.WriteLine("showShow");
        }

        /*
         * files = [1.xlsx, 2.xlsx...]
         * 
         * 只存files的list record
         * listview1datalist = {{filename, lasttime, count, shortpass, allRecordListid},
         *                      ...
         *                      }
         *                      
         * 存所有 list record
         * allRecordList = {{filename, lasttime, count, shorpass}
         *                  }
         * 
         * 
         * 
         * if (file not exists)
         *      ==> allRecordList = listiew1datalist = files
         *      ==> allRecordList ==> to txt
         * else
         *      ==> readalltxt to allRecordList
         *      ==> if (data = files[i])
         *              ==> to listview1datalist
         *          if (files[i] not in allRecordList)
         *              ==> allRecordList.add(files[i])
         * 
         */

        private void readFromTxtToRecordList()
        {
            string[] txtLines = File.ReadAllLines(txtPath);

            int i = 0;
            for (; i < txtLines.Length; i++)//Txt data
            {
                string[] _line = txtLines[i].Split(','); // [A, B, C]
                List<string> tempList = new List<string>(_line);
                recordList.Add(tempList);

                for (int j = 0; j < listView1DataList.Count; j++)
                {
                    if (listView1DataList[j][4] != "")
                    {
                        continue;
                    }
                    var tempFileName = listView1DataList[j][0];
                    //Console.WriteLine("tempFileName:" + tempFileName);

                    //ori: [filename, lasttime, learncount, fasttime]
                    //ori: [0, 1, 2, 3]

                    //new: [filename, learncount, fasttime, lasttime]
                    //new: [0, 2, 3, 1]

                    if (tempFileName == _line[0])
                    {
                        listView1DataList[j][1] = _line[1];
                        //if (_line.Length > 3)
                        //{
                        //    listView1DataList[j][2] = _line[2];
                        //}
                        //else
                        //{
                        //    listView1DataList[j][2] = "";
                        //}
                        listView1DataList[j][2] = _line[2];
                        listView1DataList[j][3] = _line[3];

                        listView1DataList[j][4] = i.ToString();
                        break;
                    }
                }
            }

            for (int j = 0; j < listView1DataList.Count; j++)
            {
                if (listView1DataList[j][4] != "")
                {
                    continue;
                }
                else
                {
                    listView1DataList[j][4] = (i++).ToString();

                    List<string> tempList = new List<string>();
                    tempList.Add(listView1DataList[j][0]);
                    tempList.Add(listView1DataList[j][1]);
                    tempList.Add(listView1DataList[j][2]);
                    tempList.Add(listView1DataList[j][3]);
                    recordList.Add(tempList);
                }
            }
        }

        private void readFromTxt()
        {
            if (File.Exists(txtPath))
            {
                filesToListView1DataList();
                readFromTxtToRecordList();
            }
            else
            {
                filesToListView1DataList(true);
                writeToTxt(true);
            }


            /*
            filesToListView1DataList();
            if (File.Exists(txtPath))
            {
                string[] txtLines = File.ReadAllLines(txtPath);
                for (int i=0; i < txtLines.Length; i++)//Txt data
                {
                    string[] _line = txtLines[i].Split(','); // [A, B, C]
                    List<string> tempList = new List<string>(_line);
                    recordList.Add(tempList);
                    for (int j=0; j < files.Count; j++)
                    {
                        var tempFileName = Path.GetFileName(files[j]);
                        //Console.WriteLine("tempFileName:" + tempFileName);

                        if (tempFileName == _line[0])
                        {
                            listView1DataList[j][1] = _line[1];
                            listView1DataList[j][2] = _line[2];
                            if (_line.Length > 3)
                            {
                                listView1DataList[j][3] = _line[3];
                            }
                            else
                            {
                                listView1DataList[j][3] = "";
                            }
                            listView1DataList[j][4] = i.ToString();
                            break;
                        }
                    }

                }

            }
            else
            {
                writeToTxt(true);
            }*/

        }

        private void showListView1DataList()
        {
            Console.WriteLine("filescount:" + files.Count);
            Console.WriteLine("listview1DataList:");
            foreach (List<string> temp in listView1DataList)
            {
                foreach(string tt in temp)
                {
                    Console.Write(tt + " ");
                }
                Console.WriteLine();
            }
        }

        private int StringToIntCompare(string x, string y)
        {
            const int XGreaterThenY = 1;
            const int YGreaterThenX = -1;


            int numX = x.Trim() != "" ? Int32.Parse(x) : 0;
            int numY = y.Trim() != "" ? Int32.Parse(y) : 0;

            if (numX >= numY)
            {
                return XGreaterThenY;
            }
            else
            {
                return YGreaterThenX;
            }
        }

        private int StringToTimeSpanCompare(string x, string y)
        {
            const int XGreaterThenY = 1;
            const int YGreaterThenX = -1;

            return TimeSpan.Parse(x.Trim()) >= TimeSpan.Parse(y.Trim()) ? XGreaterThenY : YGreaterThenX;
        }

        private int StringToTypeCompare(string x, string y, int _type)
        {
            const int XGreaterThenY = 1;
            const int YGreaterThenX = -1;

            switch (_type)
            {
                case 0:
                    Regex reg = new Regex(@"[^0-9]+");

                    var matchX = reg.Match(x);
                    var matchY = reg.Match(y);

                    Regex regNum = new Regex(@"[0-9]+");

                    var matchNumX = regNum.Match(x);
                    var matchNumY = regNum.Match(y);

                    if (matchX.Success && matchY.Success)
                    {
                        if (matchX.Value == matchY.Value && matchNumX.Success && matchNumY.Success)
                        {
                            return Int32.Parse(matchNumX.Value).CompareTo(Int32.Parse(matchNumY.Value));
                        }
                        else
                        {
                            x.CompareTo(y);
                        }
                    }
                    return x.CompareTo(y);
                    break;
                case 1:
                    return Int32.Parse(x) >= Int32.Parse(y) ? XGreaterThenY : YGreaterThenX;
                    break;
                case 2:
                    return TimeSpan.Parse(x.Trim()) >= TimeSpan.Parse(y.Trim()) ? XGreaterThenY : YGreaterThenX;
                    break;
                case 3:
                    if (x.Trim() == "" && y.Trim() == "")
                        return 0;
                    else if (x.Trim() != "" && y.Trim() == "")
                        return XGreaterThenY;
                    else if (x.Trim() == "" && y.Trim() != "")
                        return YGreaterThenX;
                    return DateTime.Parse(x.Trim()) >= DateTime.Parse(y.Trim()) ? XGreaterThenY : YGreaterThenX;
                    break;
            }
            return 0;
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Console.WriteLine("e:" + e.Column);
            /*
             * 按排序3
             * 
             * // 按下第二次且為true => 要reverse
             * if (listView2HaveReversed && reversedNum == 3) ==> listView2ColReversed == [F, F, F, T, F, F, F];
             *   ==> 要反向排序
             *   ==> listView2HaveReversed = false;
             *   ==> initListView2ColReversed();
             * else if ((listView2HaveReversed && reversedNum != 3) || !listView2HaveReversed) ==> listView2ColReversed == [F, T, F, F, F, F, F];
             *   ==> 要正向排序
             *   ==> listView2HaveReversed = true;
             *   ==> initListView2ColReversed(3);
             */



            switch (e.Column)
            {
                case 0:
                case 3:
                case 4:
                case 5:
                    if (listView2HaveReversed && listView2ColReversed[e.Column]) // 按下第二次且為true => 要reverse
                    {
                        listView2DataList.Sort((x, y) => StringToIntCompare(y[e.Column], x[e.Column]));
                        initListView2ColReversed();
                    }else if ((listView2HaveReversed && !listView2ColReversed[e.Column]) || !listView2HaveReversed)
                    {
                        listView2DataList.Sort((x, y) => StringToIntCompare(x[e.Column], y[e.Column]));
                        initListView2ColReversed(e.Column);
                    }
                    listView2_update(true);
                    break;
                case 1:
                    if (listView2HaveReversed && listView2ColReversed[e.Column])
                    {
                        listView2DataList.Sort((x, y) => string.Compare(y[e.Column], x[e.Column]));
                        initListView2ColReversed();
                    }else if ((listView2HaveReversed && !listView2ColReversed[e.Column]) || !listView2HaveReversed)
                    {
                        listView2DataList.Sort((x, y) => string.Compare(x[e.Column], y[e.Column]));
                        initListView2ColReversed(e.Column);
                    }
                    listView2_update(true);
                    break;
                case 6:
                    if (listView2HaveReversed && listView2ColReversed[e.Column]) // 按下第二次且為true => 要reverse
                    {
                        listView2DataList.Sort((x, y) => StringToTimeSpanCompare(y[e.Column], x[e.Column]));
                        initListView2ColReversed();
                    }
                    else if ((listView2HaveReversed && !listView2ColReversed[e.Column]) || !listView2HaveReversed)
                    {
                        listView2DataList.Sort((x, y) => StringToTimeSpanCompare(x[e.Column], y[e.Column]));
                        initListView2ColReversed(e.Column);
                    }
                    listView2_update(true);
                    break;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            

            switch (e.Column)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    if (listView1HaveReversed && listView1ColReversed[e.Column]) // 按下第二次且為true => 要reverse
                    {
                        switch (e.Column)
                        {
                            case 0:
                                //listView1DataList.Sort((x, y) => String.Compare(y[e.Column], x[e.Column]));
                                //break;
                            case 1:
                            case 2:
                            case 3:
                                listView1DataList.Sort((x, y) => StringToTypeCompare(y[e.Column], x[e.Column], e.Column));
                                break;
                        }
                        
                        initListView1ColReversed();
                        
                    }
                    else if ((listView1HaveReversed && !listView1ColReversed[e.Column]) || !listView1HaveReversed)
                    {
                        switch (e.Column)
                        {
                            case 0:
                               // listView1DataList.Sort((x, y) => String.Compare(x[e.Column], y[e.Column]));
                               // break;
                            case 1:
                            case 2:
                            case 3:
                                listView1DataList.Sort((x, y) => StringToTypeCompare(x[e.Column], y[e.Column], e.Column));
                                break;
                        }

                        
                        initListView1ColReversed(e.Column);
                    }
                    listView1_update();
                    break;
            }
        }

        private void btnSearch_ClickFunction()
        {
            if (MainForm.searchForm == null)
            {
                MainForm.searchForm = new SearchForm();
            }

            MainForm.searchForm.SearchForm_Init(this.files);

            if (!MainForm.searchForm.Visible)
            {
                MainForm.searchForm.Visible = true;
                MainForm.searchForm.textBox1_Focus();
            }
            else
            {
                MainForm.searchForm.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch_ClickFunction();
        }

        public void listView1_selectedFromFiles(string _fileName)
        {
            for (int i=0; i < this.listView1DataList.Count; i++)
            {
                if (this.listView1DataList[i][0] == _fileName)
                {
                    if (this.listView1.SelectedIndices.Count > 0)
                    {
                        this.listView1.Items[this.listView1.SelectedIndices[0]].Selected = false;
                    }
                    this.listView1.Items[i].Selected = true;
                    this.listView1.EnsureVisible(i);

                    break;
                }
            }
        }

        public void listView2_selectedFromFiles(string _fileName)
        {
            for (int i = 0; i < this.listView2DataList.Count; i++)
            {
                if (this.listView2DataList[i][1] == _fileName)
                {
                    if (this.listView2.SelectedIndices.Count > 0)
                    {
                        this.listView2.Items[this.listView2.SelectedIndices[0]].Selected = false;
                    }
                    this.listView2.Items[i].Selected = true;
                    this.listView2.EnsureVisible(i);

                    break;
                }
            }
        }

        private void closeThisForm()
        {
            this.Visible = false;
            if (MainForm.searchForm != null && MainForm.searchForm.Visible)
            {
                MainForm.searchForm.Visible = false;
            }
        }
    }
}
