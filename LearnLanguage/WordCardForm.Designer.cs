namespace LearnLanguage
{
    partial class WordCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordCardForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btnWordCardSearch = new System.Windows.Forms.Button();
            this.btnCheckTans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(2, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(153, 188);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 1;
            this.btnPre.Text = "上一個(A)";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(268, 188);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一個(D)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(141, 226);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "回到資料集(Esc)";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("新細明體", 14F);
            this.lbProgress.Location = new System.Drawing.Point(421, 32);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(51, 19);
            this.lbProgress.TabIndex = 3;
            this.lbProgress.Text = "100%";
            // 
            // btnWordCardSearch
            // 
            this.btnWordCardSearch.Location = new System.Drawing.Point(268, 226);
            this.btnWordCardSearch.Name = "btnWordCardSearch";
            this.btnWordCardSearch.Size = new System.Drawing.Size(75, 23);
            this.btnWordCardSearch.TabIndex = 4;
            this.btnWordCardSearch.Text = "概覽(Ctrl)";
            this.btnWordCardSearch.UseVisualStyleBackColor = true;
            this.btnWordCardSearch.Click += new System.EventHandler(this.btnWordCardSearch_Click);
            // 
            // btnCheckTans
            // 
            this.btnCheckTans.Location = new System.Drawing.Point(372, 188);
            this.btnCheckTans.Name = "btnCheckTans";
            this.btnCheckTans.Size = new System.Drawing.Size(75, 23);
            this.btnCheckTans.TabIndex = 6;
            this.btnCheckTans.Text = "查看翻譯(S)";
            this.btnCheckTans.UseVisualStyleBackColor = true;
            this.btnCheckTans.Click += new System.EventHandler(this.btnCheckTans_Click);
            // 
            // WordCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btnCheckTans);
            this.Controls.Add(this.btnWordCardSearch);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "WordCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字卡";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WordCardForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.WordCardForm_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WordCardForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Button btnWordCardSearch;
        private System.Windows.Forms.Button btnCheckTans;
    }
}