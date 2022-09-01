namespace LearnLanguage
{
    partial class ChoiceDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceDataForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnWordCard = new System.Windows.Forms.Button();
            this.btnPair = new System.Windows.Forms.Button();
            this.btnLearn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(30, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(390, 300);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "選擇資料集：";
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(450, 50);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(450, 300);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            // 
            // btnWordCard
            // 
            this.btnWordCard.Location = new System.Drawing.Point(930, 100);
            this.btnWordCard.Name = "btnWordCard";
            this.btnWordCard.Size = new System.Drawing.Size(75, 23);
            this.btnWordCard.TabIndex = 4;
            this.btnWordCard.Text = "字卡(Q)";
            this.btnWordCard.UseVisualStyleBackColor = true;
            this.btnWordCard.Click += new System.EventHandler(this.btnWordCard_Click);
            // 
            // btnPair
            // 
            this.btnPair.Location = new System.Drawing.Point(930, 150);
            this.btnPair.Name = "btnPair";
            this.btnPair.Size = new System.Drawing.Size(75, 23);
            this.btnPair.TabIndex = 5;
            this.btnPair.Text = "配對(E)";
            this.btnPair.UseVisualStyleBackColor = true;
            this.btnPair.Click += new System.EventHandler(this.btnPair_Click);
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(930, 200);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(75, 23);
            this.btnLearn.TabIndex = 5;
            this.btnLearn.Text = "學習(R)";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "預覽：";
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(930, 50);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 4;
            this.btnPre.Text = "上一步(Esc)";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(930, 250);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "尋找(F)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ChoiceDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnLearn);
            this.Controls.Add(this.btnPair);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnWordCard);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1057, 420);
            this.MinimumSize = new System.Drawing.Size(1057, 420);
            this.Name = "ChoiceDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選擇資料集";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiceDataForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ChoiceDataForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChoiceDataForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btnWordCard;
        private System.Windows.Forms.Button btnPair;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnSearch;
    }
}