using System;
using System.Runtime.Remoting.Lifetime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactCli
{
    class CliSTSponsor : MarshalByRefObject, ISponsor
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
                return TimeSpan.FromSeconds(gtx);
            }
            else
            {
                return TimeSpan.FromSeconds(0);
            }
        }
    }
}
