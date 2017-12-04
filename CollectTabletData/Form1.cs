using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CollectTabletData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectDataFolder_Click(object sender, EventArgs e)
        {
            string dataFolder = "";
            FolderBrowserDialog dlgDataFolder = new FolderBrowserDialog();
            if (dlgDataFolder.ShowDialog() == DialogResult.OK)
            {
                dataFolder = dlgDataFolder.SelectedPath;
                lblDataFileBase.Visible = true;
                lblDataFolder.Visible = true;
                lblDataFolder.Text = dataFolder;
                btnDataFileBaseDone.Enabled = true;
                btnDataFileBaseDone.Visible = true;
                txtDataSetName.Visible = true;
                txtDataSetName.Enabled = true;
            }
        }

        private void btnDataFileBaseDone_Click(object sender, EventArgs e)
        {
            // check whether data files with this basename already exist
            string[] fileList = Directory.GetFiles(lblDataFolder.Text, txtDataSetName.Text + "*.*", SearchOption.TopDirectoryOnly);
            string dirQuery = Path.Combine(lblDataFolder.Text, txtDataSetName.Text);
            btnRunTrials.Visible = true;
            btnRunTrials.Enabled = true;
        }

        private void txtDataSetName_TextChanged(object sender, EventArgs e)
        {
            
            

        }

        private void btnRunTrials_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            RunTrials frm = new RunTrials(lblDataFolder.Text, txtDataSetName.Text);
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
