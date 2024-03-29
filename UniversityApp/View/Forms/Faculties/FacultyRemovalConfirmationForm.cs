﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniversityApp.Forms.Faculties
{
    public partial class FacultyRemovalConfirmationForm : Form
    {
        public bool result = false;  // инфорамция о том, было ли подтверждение удаления или нет

        public FacultyRemovalConfirmationForm()
        {
            InitializeComponent();
        }
        private void yesDelete_Click(object sender, EventArgs e)
        {
            result = true;
            this.Close();
        }

        private void noDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Cyan;
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(243, 0, 33);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.FromArgb(239, 239, 239);
        }

        Point lastPoint;

        private void topLabelPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topLabelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
