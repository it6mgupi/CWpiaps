using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using TransactLib;


namespace TransactServer
{
    class ServerMain
    {
        public static string mod;
        static void Main(string[] args)
        {
            mod = "ServerMain";
            string fileName = "TransactServ.exe.config";
            if (File.Exists(fileName))
                try
                {
                    RemotingConfiguration.Configure(fileName, false);
                }
                catch (Exception e)
                {
                    Logger.Error( e, "Cannot read or parse remoting configuration file");
                }
            else 
            { 
                Logger.Error("Cannot find Remoting configuration file ", mod); 
            }

            Logger.Info("-----------Server logger started-----------", mod);

            // Keep the server alive until enter is pressed.
            Console.WriteLine("Server started. Press Enter to end ...");
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            Console.ReadLine();
        }

        // Console.OnClose callback
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Logger.Info("Console window closed, application terminated", mod);
            }
            return false;
        }

        // Keeps it from getting garbage collected
        static ConsoleEventDelegate handler;
   
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }
}