using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace TransactLib
{
    public class XSponsor : MarshalByRefObject, ISponsor
    {

        private int mRenewCount = 0;
        // Implements ISponsor.Renewal
        public TimeSpan Renewal(ILease leaseInfo)
        {
            //leaseInfo.CurrentLeaseTime.Minutes;
            int gtx = leaseInfo.CurrentLeaseTime.Seconds;
            Console.WriteLine("XSponsor.Renewal()");
            if (mRenewCount < 3)
            {
                mRenewCount++;
                return TimeSpan.FromSeconds(2 * gtx);
            }
            else
            {
                return TimeSpan.FromSeconds(0);
            }
        }
    }
}
