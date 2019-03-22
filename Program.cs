using System;
using System.Net;
using System.Net.NetworkInformation;

namespace ConsolePinger1
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = "Console Pinger";
            string appVersion = "0.0.1";
            while (true)
            {
                Console.Clear();          
                Console.Write("Enter the IP Address on the location you’d like to ping \n> ");
                string userIP = Console.ReadLine();
                using (var ping = new Ping())
                    try
                    {
                        var reply = ping.Send(userIP);
                        if (reply.Status == IPStatus.Success)
                        {
                            Console.Clear();
                            Console.WriteLine("{0} Version: {1}", appName, appVersion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Status: " + reply.Status + "\nUser Input: {0}", userIP + "\nIP Address: " + reply.Address + " Time: " + reply.RoundtripTime.ToString() + "ms");
                            Console.ResetColor();
                            Console.WriteLine("Press any key to enter another IP");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("{0} Version: {1}", appName, appVersion);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Status: Failed\nUser Input: {0}", userIP);
                            Console.ResetColor();
                            Console.WriteLine("Press any key to enter another IP");
                            Console.ReadKey(true);
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("{0} Version: {1}", appName, appVersion);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Status: ERROR\nUser Input: {0}\nCheck Input and try again.", userIP);
                        Console.ResetColor();
                        Console.WriteLine("Press any key to enter another IP");
                        Console.ReadKey(true);
                    }
                }
        }
    }
}

