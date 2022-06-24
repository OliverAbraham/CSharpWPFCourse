using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hackman3vilGuy.CodeProject.VistaSecurity.ElevateWithButton
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
                string fName = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
                    + @"\Microsoft\Windows\Start Menu\VISTA.TXT";
                if (System.IO.File.Exists(fName))
                {
                    System.IO.File.Delete(fName);
                    MessageBox.Show("VISTA.TXT deleted");
                }
                else
                {
                    System.IO.File.Create(fName).Close();
                    MessageBox.Show("VISTA.TXT created");
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