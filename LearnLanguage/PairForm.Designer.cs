namespace LearnLanguage
{
    partial class PairForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PairForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.btnWrong = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(2, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCorrect
            // 
            this.btnCorrect.Location = new System.Drawing.Point(153, 238);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(75, 23);
            this.btnCorrect.TabIndex = 1;
            this.btnCorrect.Text = "O(A)";
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // btnWrong
            // 
            this.btnWrong.Location = new System.Drawing.Point(268, 238);
            this.btnWrong.Name = "btnWrong";
            this.btnWrong.Size = new System.Drawing.Size(75, 23);
            this.btnWrong.TabIndex = 1;
            this.btnWrong.Text = "X(D)";
            this.btnWrong.UseVisualStyleBackColor = true;
            this.btnWrong.Click += new System.EventHandler(this.btnWrong_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(2, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "label1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(196, 276);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "回到資料集(Esc)";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("新細明體", 14F);
            this.lbProgress.Location = new System.Drawing.Point(420, 27);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(51, 19);
            this.lbProgress.TabIndex = 5;
            this.lbProgress.Text = "100%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // PairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnWrong);
            this.Controls.Add(this.btnCorrect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "PairForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配對";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PairForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PairForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCorrect;
        private System.Windows.Forms.Button btnWrong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}