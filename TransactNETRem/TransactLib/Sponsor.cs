using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace TransactLib
{
    public class Sponsor : MarshalByRefObject, ISponsor
    {
          private static int mRenewCount = 0;  
           // Implements ISponsor.Renewal
           public TimeSpan Renewal(ILease leaseInfo)
            {
                int CurrSec = leaseInfo.CurrentLeaseTime.Seconds;
                Console.WriteLine("Sponsor.Renewal() mRenewCount: " + 
                    mRenewCount + " currSec: " + CurrSec.ToString());
            
               if (mRenewCount < 3)
                {
                    mRenewCount++;
                    return TimeSpan.FromSeconds(3*CurrSec);
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
    }
}
