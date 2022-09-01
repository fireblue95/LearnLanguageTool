namespace LearnLanguage
{
    partial class LearnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LearnForm));
            this.lbProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.btOverView = new System.Windows.Forms.Button();
            this.ckboxMultiAns = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("新細明體", 14F);
            this.lbProgress.Location = new System.Drawing.Point(425, 31);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(51, 19);
            this.lbProgress.TabIndex = 9;
            this.lbProgress.Text = "100%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(30, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(406, 171);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一個(Enter)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(148, 218);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "回到資料集(Esc)";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 54);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbResponse
            // 
            this.tbResponse.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbResponse.Location = new System.Drawing.Point(31, 167);
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(359, 31);
            this.tbResponse.TabIndex = 10;
            // 
            // btOverView
            // 
            this.btOverView.Location = new System.Drawing.Point(265, 218);
            this.btOverView.Name = "btOverView";
            this.btOverView.Size = new System.Drawing.Size(75, 23);
            this.btOverView.TabIndex = 11;
            this.btOverView.Text = "概覽(Ctrl)";
            this.btOverView.UseVisualStyleBackColor = true;
            this.btOverView.Click += new System.EventHandler(this.btOverView_Click);
            // 
            // ckboxMultiAns
            // 
            this.ckboxMultiAns.AutoSize = true;
            this.ckboxMultiAns.Checked = true;
            this.ckboxMultiAns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckboxMultiAns.Location = new System.Drawing.Point(396, 222);
            this.ckboxMultiAns.Name = "ckboxMultiAns";
            this.ckboxMultiAns.Size = new System.Drawing.Size(96, 16);
            this.ckboxMultiAns.TabIndex = 12;
            this.ckboxMultiAns.Text = "允許多個答案";
            this.ckboxMultiAns.UseVisualStyleBackColor = true;
            // 
            // LearnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 261);
            this.Controls.Add(this.ckboxMultiAns);
            this.Controls.Add(this.btOverView);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 300);
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "LearnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "學習";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LearnForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.LearnForm_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LearnForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Button btOverView;
        private System.Windows.Forms.CheckBox ckboxMultiAns;
    }
}