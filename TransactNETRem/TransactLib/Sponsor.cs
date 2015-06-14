using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace TransactLib
{
    public class Sponsor : ISponsor
    {
          private int mRenewCount = 0;  
           // Implements ISponsor.Renewal
           public TimeSpan Renewal(ILease leaseInfo)
            {
                int CurrSec = leaseInfo.CurrentLeaseTime.Seconds;
            Console.WriteLine("CustomerSponsor.Renewal()");
               if (mRenewCount < 3)
                {
                    mRenewCount++;
                    return TimeSpan.FromSeconds(3*CurrSec);
                }
                else
                {
                    return TimeSpan.FromSeconds(0);
                }
            }
    }
}
