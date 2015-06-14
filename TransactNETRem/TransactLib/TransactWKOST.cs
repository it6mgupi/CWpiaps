
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Collections.Generic;

namespace TransactLib
{
    public class TransactWKOST : MarshalByRefObject, IDisposable
    {
        string mod;
        public List<RecordDataObject> RecordsData;
        public List<ISponsor> LeaseCashe;

        public override object InitializeLifetimeService()
        {
            // Call base class version
            ILease leaseInfo = (ILease)base.InitializeLifetimeService();

            // Register a CustomerSponsor object as a sponsor.
            leaseInfo.Register(new Sponsor());

            /*while(LeaseCashe.Count > 0){
            for (int i = 0; i <= LeaseCashe.Count; i++)
            {
                try
                {
                    LeaseCashe[i].Renewal(leaseInfo);
                }
                catch (Exception ex)
                {
                    LeaseCashe.RemoveAt(i);
                }
            }
            }*/

            return leaseInfo;
        }

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

        public void Dispose() {
           // Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
