namespace LearnLanguage
{
    partial class SearchForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ckBoxEn = new System.Windows.Forms.CheckBox();
            this.ckBoxCn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(325, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜尋(Enter)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(390, 236);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // ckBoxEn
            // 
            this.ckBoxEn.AutoSize = true;
            this.ckBoxEn.Checked = true;
            this.ckBoxEn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBoxEn.Location = new System.Drawing.Point(12, 13);
            this.ckBoxEn.Name = "ckBoxEn";
            this.ckBoxEn.Size = new System.Drawing.Size(48, 16);
            this.ckBoxEn.TabIndex = 5;
            this.ckBoxEn.Text = "英文";
            this.ckBoxEn.UseVisualStyleBackColor = true;
            this.ckBoxEn.CheckedChanged += new System.EventHandler(this.ckBoxEn_CheckedChanged);
            // 
            // ckBoxCn
            // 
            this.ckBoxCn.AutoSize = true;
            this.ckBoxCn.Location = new System.Drawing.Point(66, 12);
            this.ckBoxCn.Name = "ckBoxCn";
            this.ckBoxCn.Size = new System.Drawing.Size(48, 16);
            this.ckBoxCn.TabIndex = 5;
            this.ckBoxCn.Text = "中文";
            this.ckBoxCn.UseVisualStyleBackColor = true;
            this.ckBoxCn.CheckedChanged += new System.EventHandler(this.ckBoxCn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "(Ctrl 切換)";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(325, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "關閉(Esc)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 311);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckBoxCn);
            this.Controls.Add(this.ckBoxEn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(430, 350);
            this.MinimumSize = new System.Drawing.Size(430, 350);
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜尋";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox ckBoxEn;
        private System.Windows.Forms.CheckBox ckBoxCn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}