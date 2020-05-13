﻿namespace Timer
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.labTimer = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtKeypress1 = new System.Windows.Forms.TextBox();
            this.txtKeypress2 = new System.Windows.Forms.TextBox();
            this.txtKeypress3 = new System.Windows.Forms.TextBox();
            this.txtKeypress4 = new System.Windows.Forms.TextBox();
            this.txtKPTime1 = new System.Windows.Forms.TextBox();
            this.txtKPTime2 = new System.Windows.Forms.TextBox();
            this.txtKPTime3 = new System.Windows.Forms.TextBox();
            this.txtKPTime4 = new System.Windows.Forms.TextBox();
            this.btnKeyPressStart = new System.Windows.Forms.Button();
            this.txtHotKey = new System.Windows.Forms.TextBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labNowTime = new System.Windows.Forms.Label();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUserInput = new System.Windows.Forms.ToolStripTextBox();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRBC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuRBC.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTimer
            // 
            this.labTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labTimer.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimer.ForeColor = System.Drawing.Color.Black;
            this.labTimer.Location = new System.Drawing.Point(9, 49);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(184, 38);
            this.labTimer.TabIndex = 0;
            this.labTimer.Text = "00:00:00.0";
            this.labTimer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labTime_MouseDoubleClick);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Violet;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(152, 93);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(40, 17);
            this.btnReset.TabIndex = 2;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Reset";
            this.btnReset.UseMnemonic = false;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtKeypress1
            // 
            this.txtKeypress1.Location = new System.Drawing.Point(5, 102);
            this.txtKeypress1.Name = "txtKeypress1";
            this.txtKeypress1.ReadOnly = true;
            this.txtKeypress1.Size = new System.Drawing.Size(82, 21);
            this.txtKeypress1.TabIndex = 4;
            this.txtKeypress1.Text = "49";
            this.txtKeypress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeypress1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeypress1_KeyDown);
            // 
            // txtKeypress2
            // 
            this.txtKeypress2.Location = new System.Drawing.Point(5, 129);
            this.txtKeypress2.Name = "txtKeypress2";
            this.txtKeypress2.ReadOnly = true;
            this.txtKeypress2.Size = new System.Drawing.Size(82, 21);
            this.txtKeypress2.TabIndex = 5;
            this.txtKeypress2.Text = "27";
            this.txtKeypress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeypress2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeypress2_KeyDown);
            // 
            // txtKeypress3
            // 
            this.txtKeypress3.Location = new System.Drawing.Point(5, 156);
            this.txtKeypress3.Name = "txtKeypress3";
            this.txtKeypress3.ReadOnly = true;
            this.txtKeypress3.Size = new System.Drawing.Size(82, 21);
            this.txtKeypress3.TabIndex = 6;
            this.txtKeypress3.Text = "27";
            this.txtKeypress3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeypress3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeypress3_KeyDown);
            // 
            // txtKeypress4
            // 
            this.txtKeypress4.Location = new System.Drawing.Point(5, 183);
            this.txtKeypress4.Name = "txtKeypress4";
            this.txtKeypress4.ReadOnly = true;
            this.txtKeypress4.Size = new System.Drawing.Size(82, 21);
            this.txtKeypress4.TabIndex = 7;
            this.txtKeypress4.Text = "27";
            this.txtKeypress4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeypress4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeypress4_KeyDown);
            // 
            // txtKPTime1
            // 
            this.txtKPTime1.Location = new System.Drawing.Point(93, 102);
            this.txtKPTime1.Name = "txtKPTime1";
            this.txtKPTime1.Size = new System.Drawing.Size(51, 21);
            this.txtKPTime1.TabIndex = 8;
            this.txtKPTime1.Text = "30";
            this.txtKPTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKPTime1.TextChanged += new System.EventHandler(this.TXTKPTime1_TextChanged);
            this.txtKPTime1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTKPTime1_KeyPress);
            // 
            // txtKPTime2
            // 
            this.txtKPTime2.Location = new System.Drawing.Point(93, 129);
            this.txtKPTime2.Name = "txtKPTime2";
            this.txtKPTime2.Size = new System.Drawing.Size(51, 21);
            this.txtKPTime2.TabIndex = 9;
            this.txtKPTime2.Text = "70";
            this.txtKPTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKPTime2.TextChanged += new System.EventHandler(this.TXTKPTime1_TextChanged);
            this.txtKPTime2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTKPTime1_KeyPress);
            // 
            // txtKPTime3
            // 
            this.txtKPTime3.Location = new System.Drawing.Point(93, 156);
            this.txtKPTime3.Name = "txtKPTime3";
            this.txtKPTime3.Size = new System.Drawing.Size(51, 21);
            this.txtKPTime3.TabIndex = 10;
            this.txtKPTime3.Text = "100";
            this.txtKPTime3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKPTime3.TextChanged += new System.EventHandler(this.TXTKPTime1_TextChanged);
            this.txtKPTime3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTKPTime1_KeyPress);
            // 
            // txtKPTime4
            // 
            this.txtKPTime4.Location = new System.Drawing.Point(93, 183);
            this.txtKPTime4.Name = "txtKPTime4";
            this.txtKPTime4.Size = new System.Drawing.Size(51, 21);
            this.txtKPTime4.TabIndex = 11;
            this.txtKPTime4.Text = "500";
            this.txtKPTime4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKPTime4.TextChanged += new System.EventHandler(this.TXTKPTime1_TextChanged);
            this.txtKPTime4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTKPTime1_KeyPress);
            // 
            // btnKeyPressStart
            // 
            this.btnKeyPressStart.Enabled = false;
            this.btnKeyPressStart.Location = new System.Drawing.Point(150, 152);
            this.btnKeyPressStart.Name = "btnKeyPressStart";
            this.btnKeyPressStart.Size = new System.Drawing.Size(43, 35);
            this.btnKeyPressStart.TabIndex = 13;
            this.btnKeyPressStart.Text = "Start";
            this.btnKeyPressStart.UseVisualStyleBackColor = true;
            this.btnKeyPressStart.Click += new System.EventHandler(this.BTNKeyPressStart_Click);
            // 
            // txtHotKey
            // 
            this.txtHotKey.Location = new System.Drawing.Point(154, 128);
            this.txtHotKey.Name = "txtHotKey";
            this.txtHotKey.ReadOnly = true;
            this.txtHotKey.Size = new System.Drawing.Size(34, 21);
            this.txtHotKey.TabIndex = 19;
            this.txtHotKey.Text = "F11";
            this.txtHotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotKey_KeyDown);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(150, 189);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(43, 19);
            this.btnSaveSetting.TabIndex = 20;
            this.btnSaveSetting.Text = "Save";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hotkey:";
            // 
            // labNowTime
            // 
            this.labNowTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labNowTime.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNowTime.ForeColor = System.Drawing.Color.Black;
            this.labNowTime.Location = new System.Drawing.Point(8, 7);
            this.labNowTime.Name = "labNowTime";
            this.labNowTime.Size = new System.Drawing.Size(155, 38);
            this.labNowTime.TabIndex = 22;
            this.labNowTime.Text = "00:00:00";
            this.labNowTime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labNowTime_MouseDoubleClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.CheckOnClick = true;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.topToolStripMenuItem.Text = "Stay Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // txtUserInput
            // 
            this.txtUserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserInput.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserInput.MaxLength = 20;
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(100, 23);
            this.txtUserInput.Text = "备注";
            this.txtUserInput.ToolTipText = "回车确认，回车或双击解锁";
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Enabled = false;
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.timeToolStripMenuItem.Text = "time";
            this.timeToolStripMenuItem.Visible = false;
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Visible = false;
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // MnuRBC
            // 
            this.MnuRBC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.topToolStripMenuItem,
            this.txtUserInput,
            this.timeToolStripMenuItem,
            this.transparentToolStripMenuItem});
            this.MnuRBC.Name = "MnuRBC";
            this.MnuRBC.Size = new System.Drawing.Size(161, 117);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(200, 220);
            this.ContextMenuStrip = this.MnuRBC;
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.txtHotKey);
            this.Controls.Add(this.btnKeyPressStart);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.labNowTime);
            this.Controls.Add(this.txtKPTime4);
            this.Controls.Add(this.txtKPTime3);
            this.Controls.Add(this.txtKPTime2);
            this.Controls.Add(this.txtKPTime1);
            this.Controls.Add(this.txtKeypress4);
            this.Controls.Add(this.txtKeypress3);
            this.Controls.Add(this.txtKeypress2);
            this.Controls.Add(this.txtKeypress1);
            this.Controls.Add(this.labTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ffrmmousedown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ffrmmousemove);
            this.MnuRBC.ResumeLayout(false);
            this.MnuRBC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtKeypress1;
        private System.Windows.Forms.TextBox txtKeypress2;
        private System.Windows.Forms.TextBox txtKeypress3;
        private System.Windows.Forms.TextBox txtKeypress4;
        private System.Windows.Forms.TextBox txtKPTime1;
        private System.Windows.Forms.TextBox txtKPTime2;
        private System.Windows.Forms.TextBox txtKPTime3;
        private System.Windows.Forms.TextBox txtKPTime4;
        private System.Windows.Forms.Button btnKeyPressStart;
        private System.Windows.Forms.TextBox txtHotKey;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labNowTime;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtUserInput;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MnuRBC;
    }
}

