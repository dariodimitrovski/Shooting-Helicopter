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
           
        }

        private void DifficultyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                SelectedDifficulty = "Easy"; 
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
                SelectedDifficulty = "Default";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
