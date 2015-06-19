
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using TransactLib;

namespace TransactCli
{
    public partial class MainForm : Form
    {
        TransactCAO Transact;
        TransactWKOST SingleTon1;
        ISponsor m_CAOSponsor;
        ISponsor m_STSponsor;

        string PName;
        string Salary;
        string Age;
        string ZIP;
        string City;
        string IndPlantNum;

        public MainForm()
        {
            InitializeComponent();
			
			// Load the .NET Remoting configuration file
			string conffile = "TransactCli.exe.config";
			RemotingConfiguration.Configure (conffile, false);

            try
            { 
                
                m_CAOSponsor = new XSponsor();
                m_STSponsor = new CliSTSponsor();

                using (Transact = new TransactCAO())
                {

                    ILease lease = (ILease)RemotingServices.GetLifetimeService(Transact);
                    lease.Register(m_CAOSponsor);


                    // Register the client side sponsor
                    //ILease lease = (ILease)Transact.InitializeLifetimeService();
                    //lease.Register(m_CAOSponsor);

                    SingleTon1 = (TransactWKOST)Activator.GetObject(typeof(TransactWKOST), "tcp://localhost:13000/StURI.rem");
                    if (SingleTon1 == null)
                    {
                        MessageBox.Show("SingleTon1 == null");
                    }
                    ILease leaseInfo1 = (ILease)SingleTon1.InitializeLifetimeService();
                    //ILease leaseInfo1 = (ILease)SingleTon1.GetLifetimeService();
                    leaseInfo1.Register(m_STSponsor);

                    SingleTon1.SponsorsList.Add(m_CAOSponsor);
                    SingleTon1.SponsorsList.Add(m_STSponsor);


                    AppConsoleTV.Text = AppConsoleTV.Text + "----Client application logging started----\n";

                    // Adding new entries to log
                    AppConsoleTV.Text = AppConsoleTV.Text + "CAO called\n";

                    UpdateObjectsList();
                }
            }
            // If a server is down for some reason          
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error: cannot connect to server: ");
                this.Close();
            }
        }

        void OnClosed(object sender, EventArgs e)
        {
            //Unegister the sponsor
            ILease lease = (ILease)RemotingServices.GetLifetimeService(Transact);
            lease.Unregister(m_CAOSponsor);
        }

        // Acquiring input from textBoxes in client
        public void getInput()
        {
            PName = NameInput.Text;
            Salary = SalaryInput.Text;
            Age = AgeInput.Text;
            ZIP = zipInput.Text;
            City = CityInput.Text;
            IndPlantNum = ipnInput.Text;
        }

        // Cleaning client input fields
        public void CleanInputFields() 
        {
            NameInput.Text = "";
            SalaryInput.Text = "";
            AgeInput.Text = "";
            zipInput.Text = "";
            CityInput.Text = "";
            ipnInput.Text = "";
        }

        // Updating list of objects shown at client ListBox
        public void UpdateObjectsList()
        {
            CleanInputFields();
            ObjectList.Items.Clear();
            try
            {
                foreach (RecordDataObject element in Transact.CurrentRecDat)
                {
                    ObjectList.Items.Add(element.getName());
                }
            }
            catch(Exception ex) 
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "Could not get current object\n";
                throw new RemotingException("Could not make commit\n", ex);
            }
        }

        // Saving current changes
        private void SaveChBtn_Click(object sender, EventArgs e)
        {
            int result = 0;
			try
			{
                TransactWKOSC m_Accessor = new TransactWKOSC();
                result = m_Accessor.Commit(Transact);	
			}
            catch (RemotingException ex)
			{
				throw new RemotingException("Could not make commit\n", ex);
			}
            if (result == 1)
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "Changes committed to persistent storage\n";
                UpdateObjectsList();
            }
            else
            {
                AppConsoleTV.Text = AppConsoleTV.Text + "Error when commiting. Rolled back \n";
                UpdateObjectsList();
            }
        }

        // Rolling changes back
        private void CancelChBtn_Click(object sender, EventArgs e)
        {
			try
		    {
                TransactWKOSC m_Accessor = new TransactWKOSC();
                m_Accessor.Rollback(Transact);

			    AppConsoleTV.Text = AppConsoleTV.Text + "Changes rolled back\n";
                UpdateObjectsList();
		    }
		    catch(RemotingException ex)
		    {
			    throw new RemotingException("Error when rolling back\n"+ ex.Message, ex);
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
                UpdateObjectsList();
            }
        }

        // Modify existing record
        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            if (ObjectList.SelectedIndex != -1)
            {
                getInput();
                int result;
                AppConsoleTV.Text = AppConsoleTV.Text + "Modifying record...\n";
                result = Transact.UpdateRecord(ObjectList.SelectedIndex, PName, Salary, ZIP, City, Age, IndPlantNum);
                if (result == 1)
                {
                    AppConsoleTV.Text = AppConsoleTV.Text + "Record successfully modified\n";
                    UpdateObjectsList();
                }
            }
            else
            {
                MessageBox.Show("Please select an Item first!");
            }
        }

        // Delete existing record
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ObjectList.SelectedIndex != -1)
            {
                int result;
                AppConsoleTV.Text = AppConsoleTV.Text + "Deleting record...\n";
                result = Transact.DeleteRecord(ObjectList.SelectedIndex);
                if (result == 1)
                {
                    AppConsoleTV.Text = AppConsoleTV.Text + "Record successfully deleted\n";
                    UpdateObjectsList();
                }
            }
            else
            {
                MessageBox.Show("Please select an Item first!");
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

        // On each ListBoxIndex change, getting info on remote object
        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedIndex != -1)
            {
                NameInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getName();
                SalaryInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getSalary();
                AgeInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getAge();
                zipInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getZIP();
                CityInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getCity();
                ipnInput.Text = Transact.CurrentRecDat[ObjectList.SelectedIndex].getPlantNum();
            }
            else
            {
                MessageBox.Show("Please select an Item first!");
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            Transact.Refresh();
            UpdateObjectsList();
        }
    }
}
