﻿namespace UniversityApp.Forms.Faculties
{
    partial class AddFacultyForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.addFaculty = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nameFaculty = new System.Windows.Forms.TextBox();
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.addFaculty);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nameFaculty);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 315);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(72, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Название факультета";
            // 
            // addFaculty
            // 
            this.addFaculty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFaculty.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.addFaculty.Location = new System.Drawing.Point(109, 247);
            this.addFaculty.Name = "addFaculty";
            this.addFaculty.Size = new System.Drawing.Size(169, 40);
            this.addFaculty.TabIndex = 7;
            this.addFaculty.Text = "ДОБАВИТЬ";
            this.addFaculty.UseVisualStyleBackColor = true;
            this.addFaculty.Click += new System.EventHandler(this.addFaculty_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // nameFaculty
            // 
            this.nameFaculty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameFaculty.Location = new System.Drawing.Point(73, 151);
            this.nameFaculty.Multiline = true;
            this.nameFaculty.Name = "nameFaculty";
            this.nameFaculty.Size = new System.Drawing.Size(245, 40);
            this.nameFaculty.TabIndex = 1;
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
            this.panel2.Size = new System.Drawing.Size(403, 94);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.closeButton.Location = new System.Drawing.Point(363, 0);
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
            this.topLabelPanel.Size = new System.Drawing.Size(399, 94);
            this.topLabelPanel.TabIndex = 3;
            this.topLabelPanel.Text = "Добавление факультета";
            this.topLabelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topLabelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseDown);
            this.topLabelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseMove);
            // 
            // AddFacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 316);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddFacultyForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addFaculty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameFaculty;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label topLabelPanel;
    }
}