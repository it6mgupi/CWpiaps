
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using TransactLib;
using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace TransactCli
{
    public partial class MainForm : Form
    {
        TransactCAO Transact;
        string PName;
        string Salary;
        string Age;
        string ZIP;
        string City;
        string IndPlantNum;
        IpcClientChannel channel;

        public MainForm()
        {
            InitializeComponent();
			
			// Load the .NET Remoting configuration file
			string conffile = "TransactCli.exe.config";
			RemotingConfiguration.Configure (conffile, false);

            // Registering client IPC Channel
            WellKnownClientTypeEntry typeentry =
                        new WellKnownClientTypeEntry(typeof(TransactWKOSC),
                        "ipc://ServerChannel/ScURI.rem");

            typeentry.ApplicationUrl = "ipc://ServerChannel/ScURI.rem";

            BinaryClientFormatterSinkProvider sinkprovider = new
                                BinaryClientFormatterSinkProvider();
            
            IDictionary properties = new Hashtable();
            properties["name"] = "TcpBinary";
            properties["port"] = 0;

            BinaryServerFormatterSinkProvider provider = new
                                BinaryServerFormatterSinkProvider();

            provider.TypeFilterLevel = TypeFilterLevel.Full;

            //Create an IPC client channel.
            channel = new IpcClientChannel(properties, sinkprovider);
            ChannelServices.RegisterChannel(channel, true);

            try
            { 
                Transact = new TransactCAO();

                AppConsoleTV.Text = AppConsoleTV.Text + "----Client application logging started----\n";

                // Adding new entries to log
			    AppConsoleTV.Text = AppConsoleTV.Text + "CAO called\n";
			    AppConsoleTV.Text = AppConsoleTV.Text + "Adding record\n";

                UpdateObjectsList();
            }
            // If a server is down for some reason          
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("Error: cannot connect to server: ", ex.Message);
                this.Close();
            }
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
			try
			{
                TransactWKOSC m_Accessor = new TransactWKOSC();
                m_Accessor.Commit(Transact);
				AppConsoleTV.Text = AppConsoleTV.Text + "Changes committed to persistent storage\n";
                UpdateObjectsList();
			}
            catch (RemotingException ex)
			{
				throw new RemotingException("Could not make commit\n", ex);
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
    }
}
