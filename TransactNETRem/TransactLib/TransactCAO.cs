
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
        public int CopyListToPerStor()
        {
            try
            {
                    List<RecordDataObject> persistent = trwst.GetPersistentData();
                    Console.WriteLine("Checking persistent storage ( " + persistent.Count.ToString() + " rows) vs CAO (" +
                         CurrentRecDat.Count.ToString() + " rows)");

                    for (int i = 0; i < persistent.Count; ++i)
                    {
                        if (!persistent[i].isEqual(CurrentRecDat[i]))
                        {
                            Console.WriteLine("[" + i.ToString() + "] Object in CAO (" +
                                CurrentRecDat[i].toString() + ") != (" + persistent[i].toString() + ") object in persistent storage - ROLLBACK");

                            Logger.Info("Objects in CAO != objects in persistent storage", mod);
                            Refresh();
                            return 0;
                        }
                    }
                    Console.WriteLine("OK");

                    trwst.SetPersistentData(CurrentRecDat);
                    persistent = trwst.GetPersistentData();

                    Console.WriteLine("Checking updated persistent storage ( " + persistent.Count.ToString() + " rows) vs CAO (" +
                         CurrentRecDat.Count.ToString() + " rows)");

                    for (int i = 0; i < CurrentRecDat.Count; ++i)
                    {
                        if (!persistent[i].isEqual(CurrentRecDat[i]))
                        {
                            Console.WriteLine("[" + i.ToString() + "] Object in CAO (" +
                                CurrentRecDat[i].toString() + ") != (" + persistent[i].toString() + ") object in persistent storage - ROLLBACK");

                            Logger.Info("Error committing data to persistent storage", mod);
                            Refresh();
                            return 0;
                        }
                    }
                    Console.WriteLine("OK");

                    //trwst.SetPersistentData(CurrentRecDat);
                    //CurrentRecDat = trwst.GetPersistentData();
                    Logger.Info("All changes commited successfully", mod);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, mod);
            }
            return 1;
        }

        // Clearing objects
        public string Clear()
        {
            try
            {
                //CurrentRecDat.Clear();
                Refresh();
                RecordsDataChangeTransaction.Clear();
                Logger.Info("Objects cleared (rolled back to previous state)", mod);
                return "Objects cleared (rolled back to previous state)";
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
