
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
        TransactWKOST WKOST;
        string PName;
        string Salary;
        string Age;
        string ZIP;
        string City;
        string IndPlantNum;

        public void getInput() {
            PName = NameInput.Text;
            Salary = SalaryInput.Text;
            Age = AgeInput.Text;
            ZIP = zipInput.Text;
            City = CityInput.Text;
            IndPlantNum = ipnInput.Text;
        }

        class MyRecord
        {
            public string UserName { get; set; }
            public string UserId { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();
			
			// Load the .NET Remoting configuration file
			string conffile = "TransactCli.exe.config";
			RemotingConfiguration.Configure (conffile, false);

            try
            {
                Transact = new TransactCAO();
                WKOST = new TransactWKOST();

                int result;

                AppConsoleTV.Text = AppConsoleTV.Text + "----Client application logging started----\n";

                // Adding new entries to log
                AppConsoleTV.Text = AppConsoleTV.Text + "CAO called\n";
                AppConsoleTV.Text = AppConsoleTV.Text + "Adding record\n";

                result = Transact.CreateRecord("Testrec", "Testrec", "Testrec", "Testrec", "Testrec", "Testrec");
                if (result == 1)
                {
                    AppConsoleTV.Text = AppConsoleTV.Text + "New record created\n";
                }

                ObjectList.DisplayMember = "UserName";
                ObjectList.ValueMember = "UserId";

                //foreach (RecordDataObject element in Transact.CurrentRecDat) {
                ObjectList.Items.Add(new MyRecord
                {
                    UserName = "FooName",
                    UserId = "FooId"
                });
                // }

            }
            // если сервер не запущен           
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("ОШИБКА: сервер не запущен", ex.Message);
                Close();
            }
            
			
        }

        // Saving current changes
        private void SaveChBtn_Click(object sender, EventArgs e)
        {
			try
			{
				TransactWKOSC trWKO = new TransactWKOSC();
				trWKO.Commit(Transact, WKOST);
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

        // Request transactional cashe
        private void ReqCashBtn_Click(object sender, EventArgs e)
        {
            string Answer;

            AppConsoleTV.Text = AppConsoleTV.Text + "Getting current cache\n";
            Answer = Transact.RequestCacheRecords();
            AppConsoleTV.Text = AppConsoleTV.Text + Answer;
        }

        // Create new record
        private void AddBtn_Click(object sender, EventArgs e)
        {
            getInput();
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Creating new record...\n";
            result = Transact.CreateRecord(PName, Salary, ZIP, City, Age, IndPlantNum);
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "New record created\n";
            }
        }

        // Modify existing record
        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Updating record...\n";
            result = Transact.UpdateRecord(1, PName, Salary, ZIP, City, Age, IndPlantNum);
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "Record successfully modified\n";
            }
        }

        // Delete existing record
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            int result;
            AppConsoleTV.Text = AppConsoleTV.Text + "Deleting record...\n";
            result = Transact.DeleteRecord(1);
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "Record successfully deleted\n";
            }
        }

        // Export log to text file
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
