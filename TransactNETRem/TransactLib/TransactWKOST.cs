
using System;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactWKOST : MarshalByRefObject
   {
       string mod;
       List<RecordDataObject> RecordsData;

       public TransactWKOST()
	   {
           mod = "WKOSingleton";
           Logger.Info("WKO Singleton constructor called", mod);

           //Creating persistent (constant) object 
           RecordsData = new List<RecordDataObject>();
       }
	  
	  public List<RecordDataObject> GetPersistentData(){
			return RecordsData;
	  }
   }
}
