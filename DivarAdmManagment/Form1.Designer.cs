﻿namespace DivarAdManagment
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripSplitButton();
            this.progressPrecent = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbdeleteTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.rdoApprove = new System.Windows.Forms.RadioButton();
            this.chkDeleteRegister = new System.Windows.Forms.CheckBox();
            this.chkDeleteQueue = new System.Windows.Forms.CheckBox();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTokens = new System.Windows.Forms.DataGridView();
            this.clmNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.Info;
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(60, 36);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "انتخاب فایل";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.statusStrip1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.progressPrecent});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(464, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.statusText.Name = "statusText";
            this.statusText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusText.Size = new System.Drawing.Size(177, 23);
            this.statusText.Text = "Please Select Your Excel File";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressPrecent
            // 
            this.progressPrecent.AutoSize = false;
            this.progressPrecent.Margin = new System.Windows.Forms.Padding(1, 3, 170, 3);
            this.progressPrecent.Name = "progressPrecent";
            this.progressPrecent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressPrecent.Size = new System.Drawing.Size(100, 16);
            this.progressPrecent.Step = 1;
            this.progressPrecent.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeleteAll);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbdeleteTime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbPeriod);
            this.groupBox2.Controls.Add(this.rdoApprove);
            this.groupBox2.Controls.Add(this.chkDeleteRegister);
            this.groupBox2.Controls.Add(this.chkDeleteQueue);
            this.groupBox2.Controls.Add(this.rdoDelete);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(10, 387);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 127);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // chkDeleteAll
            // 
            this.chkDeleteAll.AutoSize = true;
            this.chkDeleteAll.Enabled = false;
            this.chkDeleteAll.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold);
            this.chkDeleteAll.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.chkDeleteAll.Location = new System.Drawing.Point(116, 49);
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeleteAll.Size = new System.Drawing.Size(90, 23);
            this.chkDeleteAll.TabIndex = 24;
            this.chkDeleteAll.Text = "همه آگهی ها";
            this.chkDeleteAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            this.chkDeleteAll.CheckedChanged += new System.EventHandler(this.chkDeleteAll_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnApply.Enabled = false;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.Window;
            this.btnApply.Location = new System.Drawing.Point(12, 8);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(82, 119);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "ارسال";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(277, 20);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "از زمان:";
            // 
            // cmbdeleteTime
            // 
            this.cmbdeleteTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdeleteTime.Enabled = false;
            this.cmbdeleteTime.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbdeleteTime.FormattingEnabled = true;
            this.cmbdeleteTime.Location = new System.Drawing.Point(116, 18);
            this.cmbdeleteTime.Name = "cmbdeleteTime";
            this.cmbdeleteTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbdeleteTime.Size = new System.Drawing.Size(141, 27);
            this.cmbdeleteTime.TabIndex = 20;
            this.cmbdeleteTime.SelectedIndexChanged += new System.EventHandler(this.cmbdeleteTime_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(285, 89);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "تناوب";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Location = new System.Drawing.Point(116, 87);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPeriod.Size = new System.Drawing.Size(141, 27);
            this.cmbPeriod.TabIndex = 18;
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);
            // 
            // rdoApprove
            // 
            this.rdoApprove.AutoSize = true;
            this.rdoApprove.Checked = true;
            this.rdoApprove.Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Bold);
            this.rdoApprove.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.rdoApprove.Location = new System.Drawing.Point(337, 84);
            this.rdoApprove.Name = "rdoApprove";
            this.rdoApprove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoApprove.Size = new System.Drawing.Size(106, 26);
            this.rdoApprove.TabIndex = 17;
            this.rdoApprove.TabStop = true;
            this.rdoApprove.Text = "تایید آگهی ها";
            this.rdoApprove.UseVisualStyleBackColor = true;
            this.rdoApprove.CheckedChanged += new System.EventHandler(this.rdoApprove_CheckedChanged);
            // 
            // chkDeleteRegister
            // 
            this.chkDeleteRegister.AutoSize = true;
            this.chkDeleteRegister.Checked = true;
            this.chkDeleteRegister.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteRegister.Enabled = false;
            this.chkDeleteRegister.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold);
            this.chkDeleteRegister.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.chkDeleteRegister.Location = new System.Drawing.Point(342, 49);
            this.chkDeleteRegister.Name = "chkDeleteRegister";
            this.chkDeleteRegister.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeleteRegister.Size = new System.Drawing.Size(81, 23);
            this.chkDeleteRegister.TabIndex = 16;
            this.chkDeleteRegister.Text = "منتشر شده";
            this.chkDeleteRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeleteRegister.UseVisualStyleBackColor = true;
            this.chkDeleteRegister.CheckedChanged += new System.EventHandler(this.chkDeleteRegister_CheckedChanged);
            // 
            // chkDeleteQueue
            // 
            this.chkDeleteQueue.AutoSize = true;
            this.chkDeleteQueue.Enabled = false;
            this.chkDeleteQueue.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold);
            this.chkDeleteQueue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.chkDeleteQueue.Location = new System.Drawing.Point(216, 49);
            this.chkDeleteQueue.Name = "chkDeleteQueue";
            this.chkDeleteQueue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDeleteQueue.Size = new System.Drawing.Size(96, 23);
            this.chkDeleteQueue.TabIndex = 15;
            this.chkDeleteQueue.Text = "در صف انتشار";
            this.chkDeleteQueue.UseVisualStyleBackColor = true;
            this.chkDeleteQueue.CheckedChanged += new System.EventHandler(this.chkDeleteQueue_CheckedChanged);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Bold);
            this.rdoDelete.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.rdoDelete.Location = new System.Drawing.Point(336, 16);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoDelete.Size = new System.Drawing.Size(106, 26);
            this.rdoDelete.TabIndex = 13;
            this.rdoDelete.Text = "حذف اگهی ها";
            this.rdoDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.CheckedChanged += new System.EventHandler(this.rdoDelete_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewTokens);
            this.groupBox3.Location = new System.Drawing.Point(12, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 342);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.AllowUserToDeleteRows = false;
            this.dataGridViewTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTokens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTokens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNumber,
            this.clmToken});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTokens.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTokens.Location = new System.Drawing.Point(2, 10);
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTokens.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridViewTokens.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTokens.Size = new System.Drawing.Size(444, 328);
            this.dataGridViewTokens.TabIndex = 4;
            this.dataGridViewTokens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTokens_CellContentClick);
            // 
            // clmNumber
            // 
            this.clmNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmNumber.Frozen = true;
            this.clmNumber.HeaderText = "ردیف1";
            this.clmNumber.MaxInputLength = 100;
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 50;
            // 
            // clmToken
            // 
            this.clmToken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmToken.HeaderText = "ردیف2";
            this.clmToken.Name = "clmToken";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(464, 544);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DivarAdManagment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressPrecent;
        private System.Windows.Forms.ToolStripSplitButton statusText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDeleteRegister;
        private System.Windows.Forms.CheckBox chkDeleteQueue;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.RadioButton rdoApprove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbdeleteTime;
        private System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.DataGridView dataGridViewTokens;
        private System.Windows.Forms.CheckBox chkDeleteAll;
    }
}

