
using System;
using System.Collections;
using System.Collections.Generic;

namespace TransactLib
{
   [Serializable]
   public class RecordDataObject
   {
	    int ID;
		string Name;
		string Salary;
		string City;
		string ZIP;
		string Age;
		string IndPlantNumber;

		public void NewRec(string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum ){
            Name = pName;
            Salary = pSalary;
            City = pCity;
            ZIP = pZIP;
            Age = pAge;
            IndPlantNumber = pPlantNum;
		}

		public void UpdRec(int ID, string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum)
        {
            Name = pName;
            Salary = pSalary;
            City = pCity;
            ZIP = pZIP;
            Age = pAge;
            IndPlantNumber = pPlantNum;
		}
		
		public void DelRec(int ID){
         
        }
   }
}
