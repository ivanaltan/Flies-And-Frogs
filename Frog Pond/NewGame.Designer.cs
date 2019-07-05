namespace Frogs
{
    partial class NewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radio1P = new System.Windows.Forms.RadioButton();
            this.radio2P = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio3P = new System.Windows.Forms.RadioButton();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(12, 226);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time Limit (seconds):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Game Options:";
            // 
            // radio1P
            // 
            this.radio1P.AutoSize = true;
            this.radio1P.Checked = true;
            this.radio1P.Location = new System.Drawing.Point(7, 15);
            this.radio1P.Name = "radio1P";
            this.radio1P.Size = new System.Drawing.Size(109, 17);
            this.radio1P.TabIndex = 12;
            this.radio1P.TabStop = true;
            this.radio1P.Text = "1 player (time trial)";
            this.radio1P.UseVisualStyleBackColor = true;
            this.radio1P.CheckedChanged += new System.EventHandler(this.radio1P_CheckedChanged);
            // 
            // radio2P
            // 
            this.radio2P.AutoSize = true;
            this.radio2P.Location = new System.Drawing.Point(7, 40);
            this.radio2P.Name = "radio2P";
            this.radio2P.Size = new System.Drawing.Size(102, 17);
            this.radio2P.TabIndex = 13;
            this.radio2P.Text = "2 players (battle)";
            this.radio2P.UseVisualStyleBackColor = true;
            this.radio2P.CheckedChanged += new System.EventHandler(this.radio2P_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(133, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio3P);
            this.panel1.Controls.Add(this.radio2P);
            this.panel1.Controls.Add(this.radio1P);
            this.panel1.Location = new System.Drawing.Point(67, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 103);
            this.panel1.TabIndex = 15;
            // 
            // radio3P
            // 
            this.radio3P.AutoSize = true;
            this.radio3P.Location = new System.Drawing.Point(7, 65);
            this.radio3P.Name = "radio3P";
            this.radio3P.Size = new System.Drawing.Size(102, 17);
            this.radio3P.TabIndex = 14;
            this.radio3P.Text = "3 players (battle)";
            this.radio3P.UseVisualStyleBackColor = true;
            this.radio3P.CheckedChanged += new System.EventHandler(this.radio3P_CheckedChanged);
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(133, 175);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(106, 20);
            this.tbTime.TabIndex = 16;
            this.tbTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTime_KeyPress);
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 271);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Game";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio1P;
        private System.Windows.Forms.RadioButton radio2P;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.RadioButton radio3P;
    }
}