using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace TransactLib
{
    public class XSponsor : MarshalByRefObject, ISponsor
    {
        private static int mRenewCount = 0;
        // Implements ISponsor.Renewal
        public TimeSpan Renewal(ILease leaseInfo)
        {
            int gtx = leaseInfo.CurrentLeaseTime.Seconds;
            TransactWKOST transactWKOST = (TransactWKOST)Activator.GetObject(typeof(TransactWKOST), "tcp://localhost:13000/StURI.rem");
            transactWKOST.ConsoleWriteLine("CAO XSponsor.Renewal() mRenewCount: " +
                    mRenewCount + " gtx=" + gtx.ToString());
            if (mRenewCount < 3)
            {
                mRenewCount++;
                return TimeSpan.FromSeconds(2 * gtx);
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
