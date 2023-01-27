namespace UniversityApp.Forms.FacyltiesGroups_form
{
    partial class FacyltiesGroupsRemovalConfirmationForm
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
            this.noDelete = new System.Windows.Forms.Button();
            this.yesDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.noDelete);
            this.panel1.Controls.Add(this.yesDelete);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 179);
            this.panel1.TabIndex = 8;
            // 
            // noDelete
            // 
            this.noDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.noDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.noDelete.Location = new System.Drawing.Point(270, 105);
            this.noDelete.Name = "noDelete";
            this.noDelete.Size = new System.Drawing.Size(169, 40);
            this.noDelete.TabIndex = 8;
            this.noDelete.Text = "НЕТ";
            this.noDelete.UseVisualStyleBackColor = true;
            this.noDelete.Click += new System.EventHandler(this.noDelete_Click);
            // 
            // yesDelete
            // 
            this.yesDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yesDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.yesDelete.Location = new System.Drawing.Point(71, 105);
            this.yesDelete.Name = "yesDelete";
            this.yesDelete.Size = new System.Drawing.Size(169, 40);
            this.yesDelete.TabIndex = 7;
            this.yesDelete.Text = "ДА";
            this.yesDelete.UseVisualStyleBackColor = true;
            this.yesDelete.Click += new System.EventHandler(this.yesDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
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
            this.panel2.Size = new System.Drawing.Size(516, 74);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(136)))), ((int)(((byte)(210)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.closeButton.Location = new System.Drawing.Point(476, 0);
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
            this.topLabelPanel.Size = new System.Drawing.Size(512, 68);
            this.topLabelPanel.TabIndex = 3;
            this.topLabelPanel.Text = "Подтверждаете удаление связи?";
            this.topLabelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topLabelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseDown);
            this.topLabelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLabelPanel_MouseMove);
            // 
            // FacyltiesGroupsRemovalConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 179);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FacyltiesGroupsRemovalConfirmationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FacyltiesGroupsRemovalConfirmationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button noDelete;
        private System.Windows.Forms.Button yesDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label topLabelPanel;
    }
}