using System;
using System.Runtime.Remoting;

namespace TransactServer
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            string fileName = "TransactServ.exe.config";
            try
            {
                RemotingConfiguration.Configure(fileName, false);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot read or parse Remoting configuration file", e);
            }
            // Keep the server alive until enter is pressed.
            Console.WriteLine("Server started. Press Enter to end ...");
            Console.ReadLine();
        }
    }
}