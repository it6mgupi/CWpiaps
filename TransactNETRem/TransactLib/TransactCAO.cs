
using System;
using System.Collections.Generic;

namespace TransactLib
{
    public class TransactCAO : MarshalByRefObject
    {
        #region Initializing global components
        List<string> RecordsDataChangeTransaction;
        public List<RecordDataObject> CurrentRecDat;
        TransactWKOST trwst;
        string mod;
        #endregion

        public void Refresh() 
        {
            trwst = (TransactWKOST)Activator.GetObject(typeof(TransactWKOST), "http://localhost:13000/StURI.rem");
            CurrentRecDat = trwst.GetPersistentData();
        }

        #region Constructor, initializing objects
        public TransactCAO()
        {
            mod = "CAO";
            // constructor implementation
            Logger.Info("Constructor called ", mod);
            RecordsDataChangeTransaction = new List<string>();
            try
            {
                //TransactWKOST trwst = new TransactWKOST(); 
                Refresh();
            }
            catch(Exception ex) 
            { 
                //TransactWKOST trwst = new TransactWKOST(); //CurrentRecDat = trwst.GetPersistentData();
            }
        }
        #endregion

        #region Commit and rollback source methods
        // Copy objects to persistent storage
        public void CopyListToPerStor()
        {
            try
            {
                trwst.SetPersistentData(CurrentRecDat);
                CurrentRecDat = trwst.GetPersistentData();
                Logger.Info("All changes commited successfully", mod);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, mod);
            }
        }

        // Clearing objects
        public string Clear()
        {
            try
            {
                //CurrentRecDat.Clear();
                Refresh();
                RecordsDataChangeTransaction.Clear();
                Logger.Info("Objects cleared ( previous transaction rolled back)", mod);
                return "Objects cleared ( previous transaction rolled back)";
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot clear objects");
                return "Error when clearing objects\n";
            }
        }
        #endregion

        #region Methods to work with List
        public int CreateRecord(string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum)
        {
            try
            {
                int EntriesCount;
                EntriesCount = CurrentRecDat.Count;
                Logger.Info("Record " + pName + pSalary + pCity + pZIP + pAge + pPlantNum + " created", mod);
                CurrentRecDat.Add(new RecordDataObject());
                CurrentRecDat[EntriesCount].SetRec(pName, pSalary, pCity, pZIP, pAge, pPlantNum);
                RecordsDataChangeTransaction.Add("Record " + pName + pSalary + pCity + pZIP + pAge + pPlantNum + " created");
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, mod);
                return 0;
            }
        }

        public int UpdateRecord(int pos, string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum)
        {
            try
            {
                CurrentRecDat[pos].SetRec(pName, pSalary, pCity, pZIP, pAge, pPlantNum);
                RecordsDataChangeTransaction.Add("Record at position " + pos + " updated with " + pName + pSalary + pCity + pZIP + pAge + pPlantNum);
                Console.WriteLine("Record at position updated with " + pName + pSalary + pCity + pZIP + pAge + pPlantNum);
                Logger.Info("Record updated", mod);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, mod);
                return 0;
            }
        }

        public int DeleteRecord(int pos)
        {
            try
            {
                CurrentRecDat.RemoveAt(pos);
                RecordsDataChangeTransaction.Add("Deleted record at position " + pos.ToString());
                Logger.Info("Deleted record at position " + pos.ToString(), mod);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, mod);
                return 0;
            }
        }

        // Requesting CRUD cashe
        public String RequestCacheRecords()
        {
            String RetStrg = "---------Transactional cashe---------\n";
            int i;
            Logger.Info("Cashe requested", mod);
            Logger.Info("Current contains:", mod);
            try
            {
                for (i = 0; i <= RecordsDataChangeTransaction.Count - 1; i++)
                {
                    RetStrg = RetStrg + RecordsDataChangeTransaction[i] + "\n";
                    Logger.Info(RecordsDataChangeTransaction[i], mod);
                }
                RetStrg = RetStrg + "------------------------------------\n";
                return RetStrg;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cannot request CRUD cashe");
                return "Error when requesting CRUD cashe\n";
            }
        }
        #endregion
    }
}
