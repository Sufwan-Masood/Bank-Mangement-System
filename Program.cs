using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Transactions;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace myNamespace
{
    class program
    {   /// <summary>
    /// this class contains all the messages that are often repeated in the sytem
    /// </summary>
        public static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(0);
            Bank bank = new Bank();
            loading();
            Console.WriteLine("\t\tWELCOME TO BANK MANAGEMEN SYSTEM\n");
            bank.run();
        }


        public static void loading()
        {   
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(Messages.Executing);


            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(500); // Simulate some work being done

            }

            Console.SetCursorPosition(0, 1); // Move cursor to the beginning of the next line
            Console.WriteLine(Messages.Executed);
            Console.ResetColor();
        }
        
    }
}