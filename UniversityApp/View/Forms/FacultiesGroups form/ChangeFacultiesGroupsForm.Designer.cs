namespace UniversityApp.Forms.FacultiesGroups_form
{
    partial class ChangeFacultiesGroupsForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.changeFacultiesGroups = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupCombo = new System.Windows.Forms.ComboBox();
            this.facultyCombo = new System.Windows.Forms.ComboBox();
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
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.changeFacultiesGroups);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupCombo);
            this.panel1.Controls.Add(this.facultyCombo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 374);
            this.panel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(54, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Группы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(54, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Факультеты";
            // 
            // changeFacultiesGroups
            // 
            this.changeFacultiesGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeFacultiesGroups.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.changeFacultiesGroups.Location = new System.Drawing.Point(149, 302);
            this.changeFacultiesGroups.Name = "changeFacultiesGroups";
            this.changeFacultiesGroups.Size = new System.Drawing.Size(169, 40);
            this.changeFacultiesGroups.TabIndex = 7;
            this.changeFacultiesGroups.Text = "ИЗМЕНИТЬ";
            this.changeFacultiesGroups.UseVisualStyleBackColor = true;
            this.changeFacultiesGroups.Click += new System.EventHandler(this.changeFacultiesGroups_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // groupCombo
            // 
            this.groupCombo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupCombo.FormattingEnabled = true;
            this.groupCombo.Location = new System.Drawing.Point(55, 233);
            this.groupCombo.Name = "groupCombo";
            this.groupCombo.Size = new System.Drawing.Size(370, 27);
            this.groupCombo.TabIndex = 4;
            // 
            // facultyCombo
            // 
            this.facultyCombo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyCombo.FormattingEnabled = true;
            this.facultyCombo.Location = new System.Drawing.Point(55, 160);
            this.facultyCombo.Name = "facultyCombo";
            this.facultyCombo.Size = new System.Drawing.Size(370, 27);
            this.facultyCombo.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.topLabelPanel);
            this.panel2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(483, 94);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.closeButton.Location = new System.Drawing.Point(444, 0);
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
            this.topLabelPanel.Size = new System.Drawing.Size(480, 94);
            this.topLabelPanel.TabIndex = 3;
            this.topLabelPanel.Text = "Изменение факультетов и групп";
            this.topLabelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topLabelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseDown);
            this.topLabelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseMove);
            // 
            // ChangeFacultiesGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 374);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeFacultiesGroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeFacultiesGroupsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button changeFacultiesGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox groupCombo;
        private System.Windows.Forms.ComboBox facultyCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label topLabelPanel;
    }
}