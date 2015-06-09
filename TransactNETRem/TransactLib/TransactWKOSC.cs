
using System;
using System.Collections;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactWKOSC : MarshalByRefObject
   {
        string mod;
        public TransactWKOSC()
	    {
            mod = "WKOSingleCall";
            Logger.Info("WKO SingleCall constructor called ",mod);
        }

        #region Functional module
        public void Commit(TransactCAO CAO, TransactWKOST WKOST){
			try {
                TransactWKOST PerStor = new TransactWKOST();
				//if(CAO.SourceRecDat = Perstor){  }
			}
			catch(Exception ex){
                Logger.Error(ex, mod);
			}
		}

		public void Rollback(TransactCAO CAO){
			try {
				CAO.Clear();
			}
			catch(Exception ex){
                Logger.Error(ex, mod);
			}
        }
       #endregion
   }
}
