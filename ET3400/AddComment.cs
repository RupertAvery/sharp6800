﻿using System;
using System.Windows.Forms;
using ET3400.Debugger;

namespace ET3400
{
    public partial class AddComment : Form
    {
        public int StartAddress { get; set; }
        public RangeType RangeType { get; set; }
        public string Description { get; set; }

        public AddComment(int startAddress)
        {
            StartAddress = startAddress;
            InitializeComponent();
            startTextBox.Text = "$" + startAddress.ToString("X4");
            RangeType = RangeType.Comment;
        }

        public AddComment()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (startTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter an address", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (startTextBox.Text.StartsWith("$"))
                {
                    StartAddress = Convert.ToInt32(startTextBox.Text.Trim().Substring(1), 16);
                }
                else if (startTextBox.Text.Trim().ToLower().StartsWith("0x"))
                {
                    StartAddress = Convert.ToInt32(startTextBox.Text.Trim().Substring(2), 16);
                }
                else
                {
                    StartAddress = Convert.ToInt32(startTextBox.Text.Trim());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a valid address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (descriptionTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter a description", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (StartAddress < 0)
            {
                MessageBox.Show("The start address must be greater than $0000", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (StartAddress > 0xFFFF)
            {
                MessageBox.Show("The start address must be less than $FFFF", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Description = descriptionTextBox.Text.Trim();

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
