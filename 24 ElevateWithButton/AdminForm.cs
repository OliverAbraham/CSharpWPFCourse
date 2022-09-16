using System;
using System.Windows.Forms;

namespace ElevateWithButton
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            if (!VistaSecurity.IsAdmin())
            {
                this.Text += " (Standard)";
                VistaSecurity.AddShieldToButton(buttonGetElevation);
            }
            else
                this.Text += " (Elevated)";
        }

        private void buttonGetElevation_Click(object sender, EventArgs e)
        {
            if (VistaSecurity.IsAdmin())
            {
                DoAdminTask();
            }
            else
            {
                VistaSecurity.RestartElevated();
            }
        }

        private void DoAdminTask()
        {
            try
            {
                string filename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\NEW FILE.TXT";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                    MessageBox.Show("NEW FILE deleted");
                }
                else
                {
                    System.IO.File.Create(filename).Close();
                    MessageBox.Show("NEW FILE created");
                }
            }
            catch (UnauthorizedAccessException uacEx)
            {
                MessageBox.Show(uacEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

        }

        private void buttonNoElevation_Click(object sender, EventArgs e)
        {
            DoAdminTask();
        }
    }
}