
using System;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactCAO : MarshalByRefObject
   {
        #region Initializing global components
        List<string> RecordsDataChangeTransaction;
        public List<RecordDataObject> SourceRecDat;
        public List<RecordDataObject> CurrentRecDat;
        TransactWKOST trwst;
        string mod;
        #endregion

        #region Constructor, initializing objects
        public TransactCAO()
		{
            mod = "CAO";
			// constructor implementation
			Logger.Info("Constructor called ", mod);
            RecordsDataChangeTransaction = new List<string>();
            trwst = new TransactWKOST();
            SourceRecDat = trwst.GetPersistentData();
            CurrentRecDat = trwst.GetPersistentData();
        }
        #endregion

        #region Essential methods
        public int CreateRecord(string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum)
        {
			try
			{
                int EntriesCount;
                EntriesCount = CurrentRecDat.Count;

                string strOut = "Record " + pName + " " + pSalary + " " + pCity + " " + pZIP + " " + pAge + " " + 
                    pPlantNum + " created";

                Logger.Info(strOut, mod);

                CurrentRecDat.Add(new RecordDataObject());
                CurrentRecDat[EntriesCount].SetRec(pName,pSalary,pCity,pZIP,pAge,pPlantNum);
				RecordsDataChangeTransaction.Add(strOut);
                return 1;
			}
			catch(Exception ex){
                Logger.Error(ex,mod);
                return 0;
			}
		}

        public int UpdateRecord(int pos, string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum)
        {
			try
			{
                CurrentRecDat[pos].SetRec(pName, pSalary, pCity, pZIP, pAge, pPlantNum);

                RecordsDataChangeTransaction.Add("Record at position " + pos + " updated with " + pName + " " + pSalary + 
                    " " + pCity + " " + pZIP + " " + pAge + " " + pPlantNum);

                Console.WriteLine("Record at position updated with " + pName + pSalary + pCity + pZIP + pAge + pPlantNum);
                Logger.Info("Record updated ", mod);
				return 1;
			}
			catch(Exception ex){
                Logger.Error(ex, mod);
				return 0;
			}
		}

		public int DeleteRecord(int pos){
			try
			{
                CurrentRecDat.RemoveAt(pos);
				RecordsDataChangeTransaction.Add("Deleted record at position " + pos.ToString());
                Logger.Info("Deleted record at position " + pos.ToString(), mod);
				return 1;
			}
			catch(Exception ex){
                Logger.Error(ex, mod);
				return 0;
			}
		}

        // Requesting CRUD cashe
		public String RequestCacheRecords(){
            String RetStrg = "Transactional cache ";
            int i;
            Logger.Info("Cache requested ",mod);
            Logger.Info("Current contains: ",mod);
            try
            {
                for (i = 0; i<= RecordsDataChangeTransaction.Count-1; i++)
                {
                    RetStrg = RetStrg + RecordsDataChangeTransaction[i] + "\n";
                    Logger.Info(RecordsDataChangeTransaction[i], mod);
                }
				return RetStrg;
			}
			catch(Exception ex){
                Logger.Error(ex, "Cannot request CRUD cache ");
                return "Error when requesting CRUD cache \n";
			}
		}
		
        // Clearing objects
		public String Clear(){
			try
			{
                CurrentRecDat.Clear();
				CurrentRecDat = SourceRecDat;
                RecordsDataChangeTransaction.Clear();
                Logger.Info("Objects cleared ( previous transaction rolled back)",mod);
                return "Objects cleared ( previous transaction rolled back)";
			}
			catch(Exception ex){
                Logger.Error(ex, "Cannot clear objects");
                return "Error when clearing objects\n";
			}
		}
		#endregion
   }
}
