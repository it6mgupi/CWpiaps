
using System;
using System.Collections;
using System.Collections.Generic;

namespace TransactLib
{
   [Serializable]
   public class RecordDataObject
   {
		string Name{ get; set; }
        string Salary { get; set; }
        string City { get; set; }
        string ZIP { get; set; }
        string Age { get; set; }
        string IndPlantNumber { get; set; }

        #region Setter function
        public void SetRec(string pName, string pSalary, string pCity, string pZIP, string pAge, string pPlantNum ){
            Name = pName;
            Salary = pSalary;
            City = pCity;
            ZIP = pZIP;
            Age = pAge;
            IndPlantNumber = pPlantNum;
		}
        #endregion

        #region A bunch of getter functions
        public string getName() { return Name; }
        public string getSalary() { return Salary; }
        public string getCity() { return City; }
        public string getZIP() { return ZIP; }
        public string getAge() { return Age; }
        public string getPlantNum() { return IndPlantNumber; }
        #endregion
   }
}
