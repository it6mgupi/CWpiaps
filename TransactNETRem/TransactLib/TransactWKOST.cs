
using System;
using System.Collections.Generic;

namespace TransactLib
{
    public class TransactWKOST : MarshalByRefObject
    {
        string mod;
        public List<RecordDataObject> RecordsData;

        public TransactWKOST()
        {
            mod = "WKOSingleton";
            Logger.Info("WKO Singleton constructor called", mod);

            //Creating persistent (constant) object 
            RecordsData = new List<RecordDataObject>();
        }

        public List<RecordDataObject> GetPersistentData()
        {
            return RecordsData;
        }

        public void SetPersistentData(List<RecordDataObject> NewList)
        {
            RecordsData = NewList;
        }
    }
}
