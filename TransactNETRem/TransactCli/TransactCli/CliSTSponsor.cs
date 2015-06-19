using System;
using System.Runtime.Remoting.Lifetime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//namespace TransactCli
namespace TransactLib
{
    class CliSTSponsor : MarshalByRefObject, ISponsor
    {
        private static int mRenewCount = 0;
        // Implements ISponsor.Renewal
        public TimeSpan Renewal(ILease leaseInfo)
        {
            int gtx = leaseInfo.CurrentLeaseTime.Seconds;
            TransactWKOST transactWKOST = (TransactWKOST)Activator.GetObject(typeof(TransactWKOST), "tcp://localhost:13000/StURI.rem");
            transactWKOST.ConsoleWriteLine("SingleTon CliSTSponsor.Renewal()  mRenewCount: " +
                    mRenewCount + " gtx=" + gtx.ToString());

            if (mRenewCount < 3)
            {
                mRenewCount++;
                return TimeSpan.FromSeconds(gtx);
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
