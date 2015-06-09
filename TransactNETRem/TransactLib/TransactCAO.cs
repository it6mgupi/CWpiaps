
using System;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactCAO : MarshalByRefObject
   {
	   
	   	// Initializing global components
		List<string> RecordsDataChangeTransaction;
        TransactWKOST trwst;
        List<RecordDataObject> recDat;


        #region Creating temp objects to work with
        public TransactCAO()
		{ 
			// constructor implementation
			Console.WriteLine("Constructor called");
            RecordsDataChangeTransaction = new List<string>();
            trwst = new TransactWKOST();
            recDat = new List<RecordDataObject>(); 
            recDat = trwst.GetPersistentData(recDat);
        }
        #endregion

        #region Essential methods
        public int CreateRecord(String rec){
			try
			{
                int EntriesCount;
                EntriesCount = recDat.Count;
              //  recDat[EntriesCount].NewRec(rec);
				int RDCTSize;
				RDCTSize = RecordsDataChangeTransaction.Count;
				RecordsDataChangeTransaction [RDCTSize] = rec; 
				Console.WriteLine("Record " + RecordsDataChangeTransaction [RDCTSize] + " created");
				return 1;
			}
			catch(Exception ex){
				return 0;
			}
		}

		public int UpdateRecord(String rec, int pos){
			try
			{
				//recDat[pos].UpdRec(rec,pos);
				RecordsDataChangeTransaction.Add("Record at position updated");
				Console.WriteLine("Record updated");
				return 1;
			}
			catch(Exception ex){
				return 0;
			}
		}

		public int DeleteRecord(int pos){
			try
			{
                string position;
                //position = pos.ToString;
                recDat[pos].DelRec(pos);
				RecordsDataChangeTransaction.Add("Deleted object at position ");
				Console.WriteLine("Record deleted");
				return 1;
			}
			catch(Exception ex){
				return 0;
			}
		}

        // Requesting CRUD cashe
		public String RequestCacheRecords(){
			try
			{
                String RetStrg = "Transactional cashe";
                int i;
                Console.WriteLine("Cashe requested");
                Console.WriteLine("Current contains:");
                for (i = 0; i<= RecordsDataChangeTransaction.Count; i++)
                {
                    RetStrg = RetStrg + RecordsDataChangeTransaction[i];
                    Console.WriteLine(RecordsDataChangeTransaction[i]);
                }
				
				return RetStrg;
			}
			catch(Exception ex){
				throw new Exception("Cannot request transactional cashe",ex);
			}
		}
		
        // Clearing objects
		public int Clear(){
			try
			{
				recDat.Clear();
				RecordsDataChangeTransaction.Add("Objects cleared ( transaction rolled back)");
				Console.WriteLine("Objects cleared ( previoustransaction rolled back)");
				return 1;
			}
			catch(Exception ex){
				return 0;
			}
		}
		#endregion
   }
}
