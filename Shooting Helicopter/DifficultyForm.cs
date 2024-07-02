using System;
using System.Windows.Forms;

namespace Shooting_Helicopter
{
    public partial class DifficultyForm : Form
    {
        public string SelectedDifficulty { get; private set; }

        public DifficultyForm()
        {
            InitializeComponent();
            this.FormClosing += DifficultyForm_FormClosing;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // No action needed here
        }

        private void DifficultyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                SelectedDifficulty = "Easy"; // Default to Easy if closed without selecting
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (easyRadioButton.Checked)
            {
                SelectedDifficulty = "Easy";
            }
            else if (mediumRadioButton.Checked)
            {
                SelectedDifficulty = "Medium";
            }
            else if (hardRadioButton.Checked)
            {
                SelectedDifficulty = "Hard";
            }
            else
            {
                SelectedDifficulty = "Default"; // Handle default case if needed
            }

            this.DialogResult = DialogResult.OK;
        }

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
