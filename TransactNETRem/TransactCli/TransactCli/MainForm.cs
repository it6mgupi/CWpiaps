
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using TransactLib;

namespace TransactCli
{
    public partial class MainForm : Form
    {
        TransactCAO Transact;
        string Name;
        string Salary;
        string Age;
        string ZIP;
        string City;
        string IndPlantNum;

        public void getInput() {
            Name = NameInput.Text;
            Salary = SalaryInput.Text;
            Age = AgeInput.Text;
            ZIP = zipInput.Text;
            City = CityInput.Text;
            IndPlantNum = ipnInput.Text;
        }

        public MainForm()
        {
            InitializeComponent();
			
			// Load the .NET Remoting configuration file
			string conffile = "TransactCli.exe.config";
			RemotingConfiguration.Configure (conffile, false);


            Transact = new TransactCAO();

			int result;

            // Adding new entries to log
			AppConsoleTV.Text = AppConsoleTV.Text + "CAO called\n";
			AppConsoleTV.Text = AppConsoleTV.Text + "Adding record\n";
			result = Transact.CreateRecord("Testrec");
			result = Transact.CreateRecord("testrecord2");
			if (result == 1) {
				AppConsoleTV.Text = AppConsoleTV.Text + "New record created\n";
			}
           // foreach () in Transact
        }

        // Saving current changes
        private void SaveChBtn_Click(object sender, EventArgs e)
        {
			try
			{
				TransactWKOSC trWKO = new TransactWKOSC();
				trWKO.Rollback(Transact);
				AppConsoleTV.Text = AppConsoleTV.Text + "Changes saved\n";
			}
			catch
			{
				throw new Exception("Could not make commit\n");
			}
        }

        // Rolling changes back
        private void CancelChBtn_Click(object sender, EventArgs e)
        {
			try
		    {
			    TransactWKOSC trWKO = new TransactWKOSC();
		        trWKO.Rollback(Transact);
			    AppConsoleTV.Text = AppConsoleTV.Text + "Changes rolled back\n";
		    }
		    catch
		    {
			    throw new Exception("Error when rolling back");
		    }
        }

        // Requesting transactional cashe
        private void ReqCashBtn_Click(object sender, EventArgs e)
        {
            string Answer;

            AppConsoleTV.Text = AppConsoleTV.Text + "Getting current cache\n";
            Answer = Transact.RequestCacheRecords();
            AppConsoleTV.Text = AppConsoleTV.Text + Answer;
        }

        // Creating new record
        private void AddBtn_Click(object sender, EventArgs e)
        {
            getInput();
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Creating new record...\n";
            result = Transact.CreateRecord("1");
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "DELOK\n";
            }
        }

        // Modifying existing record
        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Updating record...\n";
            result = Transact.UpdateRecord("Supertest", 1);
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "UPDOK\n";
            }
        }

        // Deleting existing record
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Deleting record...\n";
            result = Transact.DeleteRecord(1);
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "DELOK\n";
            }
        }

        private void ExportLogBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.ExecutablePath;
            saveFileDialog.Filter = String.Format("Log files|*{0}", ".log");
            saveFileDialog.DefaultExt = ".log";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Writing textview1 text to log file
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(AppConsoleTV.Text);
                sw.Close();
            }
        }
    }
}
