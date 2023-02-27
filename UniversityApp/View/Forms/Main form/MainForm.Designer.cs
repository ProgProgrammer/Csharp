namespace UniversityApp.Forms.Main_form
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.facultiesButton = new System.Windows.Forms.Button();
            this.facyltiesGroupsButton = new System.Windows.Forms.Button();
            this.studentsButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.groupsButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.topLabelPanel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(156)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.facultiesButton);
            this.panel1.Controls.Add(this.facyltiesGroupsButton);
            this.panel1.Controls.Add(this.studentsButton);
            this.panel1.Controls.Add(this.usersButton);
            this.panel1.Controls.Add(this.groupsButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 500);
            this.panel1.TabIndex = 4;
            // 
            // facultiesButton
            // 
            this.facultiesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facultiesButton.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.facultiesButton.Location = new System.Drawing.Point(143, 346);
            this.facultiesButton.Name = "facultiesButton";
            this.facultiesButton.Size = new System.Drawing.Size(361, 40);
            this.facultiesButton.TabIndex = 11;
            this.facultiesButton.Text = "ФАКУЛЬТЕТЫ";
            this.facultiesButton.UseVisualStyleBackColor = true;
            this.facultiesButton.Click += new System.EventHandler(this.facultiesButton_Click);
            // 
            // facyltiesGroupsButton
            // 
            this.facyltiesGroupsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facyltiesGroupsButton.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.facyltiesGroupsButton.Location = new System.Drawing.Point(143, 276);
            this.facyltiesGroupsButton.Name = "facyltiesGroupsButton";
            this.facyltiesGroupsButton.Size = new System.Drawing.Size(361, 40);
            this.facyltiesGroupsButton.TabIndex = 10;
            this.facyltiesGroupsButton.Text = "ФАКУЛЬТЕТЫ И ГРУППЫ";
            this.facyltiesGroupsButton.UseVisualStyleBackColor = true;
            this.facyltiesGroupsButton.Click += new System.EventHandler(this.facyltiesGroupsButton_Click);
            // 
            // studentsButton
            // 
            this.studentsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentsButton.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.studentsButton.Location = new System.Drawing.Point(143, 136);
            this.studentsButton.Name = "studentsButton";
            this.studentsButton.Size = new System.Drawing.Size(361, 40);
            this.studentsButton.TabIndex = 9;
            this.studentsButton.Text = "СТУДЕНТЫ";
            this.studentsButton.UseVisualStyleBackColor = true;
            this.studentsButton.Click += new System.EventHandler(this.studentsButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usersButton.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.usersButton.Location = new System.Drawing.Point(143, 207);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(361, 40);
            this.usersButton.TabIndex = 8;
            this.usersButton.Text = "ПОЛЬЗОВАТЕЛИ";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // groupsButton
            // 
            this.groupsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupsButton.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupsButton.Location = new System.Drawing.Point(143, 415);
            this.groupsButton.Name = "groupsButton";
            this.groupsButton.Size = new System.Drawing.Size(361, 40);
            this.groupsButton.TabIndex = 7;
            this.groupsButton.Text = "ГРУППЫ";
            this.groupsButton.UseVisualStyleBackColor = true;
            this.groupsButton.Click += new System.EventHandler(this.groupsButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.topLabelPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(646, 94);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.closeButton.Location = new System.Drawing.Point(607, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(39, 37);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseDown);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            // 
            // topLabelPanel
            // 
            this.topLabelPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.topLabelPanel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topLabelPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.topLabelPanel.Location = new System.Drawing.Point(3, 0);
            this.topLabelPanel.Name = "topLabelPanel";
            this.topLabelPanel.Size = new System.Drawing.Size(643, 94);
            this.topLabelPanel.TabIndex = 3;
            this.topLabelPanel.Text = "Выбор таблицы";
            this.topLabelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topLabelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseDown);
            this.topLabelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button groupsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label topLabelPanel;
        private System.Windows.Forms.Button facultiesButton;
        private System.Windows.Forms.Button facyltiesGroupsButton;
        private System.Windows.Forms.Button studentsButton;
        private System.Windows.Forms.Button usersButton;
    }
}