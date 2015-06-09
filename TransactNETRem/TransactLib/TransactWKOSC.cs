
using System;
using System.Collections;
using System.Collections.Generic;

namespace TransactLib
{
   public class TransactWKOSC : MarshalByRefObject
   {
        public TransactWKOSC()
	    {
           Console.WriteLine("WKO SingleCall constructor called");
        }
		public int Commit(TransactCAO trans){
			try {
                TransactWKOST PerStor = new TransactWKOST();
				//if(trans.)
				return 1;
			}
			catch(InvalidCastException ex){
				return 0;
			}
		}

		public int Rollback(TransactCAO trans){
			try {
				trans.Clear();
				return 1;
			}
			catch(Exception ex){
				return 0;
			}
		}
   }
}
