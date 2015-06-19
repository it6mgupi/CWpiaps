
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

        public int Commit(TransactCAO CAO){
            int result = 0;
			try 
            {
                result = CAO.CopyListToPerStor();
			}
			catch(Exception ex){
                Logger.Error(ex, mod);
			}
            return result;
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
