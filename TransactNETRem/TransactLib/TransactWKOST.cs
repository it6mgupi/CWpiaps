
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
        public List<ISponsor> SponsorsList;

        public override object InitializeLifetimeService()
        {
            ISponsor s = new Sponsor();
            // Call base class version
            ILease leaseInfo = (ILease)base.InitializeLifetimeService();
            Console.WriteLine("singletone lifetime: " + leaseInfo.SponsorshipTimeout);
            // Регистрируем спонсора
            leaseInfo.Register(s);

            while(SponsorsList.Count > 0){
            for (int i = 0; i < SponsorsList.Count; i++)
            {
                try
                {
                    SponsorsList[i].Renewal(leaseInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    SponsorsList.RemoveAt(i);
                }
            }
            }

            return leaseInfo;
        }

        public TransactWKOST()
        {
            SponsorsList = new List<ISponsor>();
            Console.WriteLine("WKO Singleton constructor called");

            mod = "WKOSingleton";
            Logger.Info("WKO Singleton constructor called", mod);

            //Creating persistent (constant) object 
            RecordsData = new List<RecordDataObject>();
        }

        public void Dispose()
        {
            // Dispose(true);
            Console.WriteLine("CAO Dispose called");
            GC.SuppressFinalize(this);
        }

        ~TransactWKOST()
        {
            Dispose();
            Console.WriteLine("WKO Singleton destructor called");
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
