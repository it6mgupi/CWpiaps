
using System;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactWKOST : MarshalByRefObject
   { 
       public TransactWKOST()
	   {
           Console.WriteLine("WKO singleTon constructor called");
       }
	  // Persistent (constant) object 	
	  List<RecordDataObject> RecordsData = new List<RecordDataObject>();
	  // Creating object for CAO
	  //recDat = GetPersistentData(RecordsData);
	  
	  public List<RecordDataObject> GetPersistentData(List<RecordDataObject> xt){
			return xt;
	  }
   }
}
