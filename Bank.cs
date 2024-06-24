using myNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace myNamespace
{
    class Bank
    {
        private List<Customer> Customers = new List<Customer>();
        private Admin admin = new Admin();
        public void run()
        {   /// here are some predefined customers, already enrolled int the bank.
            //Customers.Add(new Customer("Ali", "Khan", "password1", 1000.0f));
            //Customers.Add(new Customer("Ahmed", "Siddiqui", "password2", 1500.0f));
            //Customers.Add(new Customer("Sara", "Malik", "password3", 2000.0f));
            //Customers.Add(new Customer("Zara", "Shaikh", "password4", 2500.0f));
            //Customers.Add(new Customer("Hassan", "Javed", "password5", 3000.0f));
            //Customers.Add(new Customer("Aisha", "Iqbal", "password6", 3500.0f));
            //Customers.Add(new Customer("Usman", "Hussain", "password7", 4000.0f));
            //Customers.Add(new Customer("Rabia", "Butt", "password8", 450000.0f));
            //Customers.Add(new Customer("Bilal", "Qureshi", "password9", 5000.0f));
            //Customers.Add(new Customer("Fatima", "Chaudhry", "password10", 5500.0f));
            string JsonString = File.ReadAllText(@"C:\Users\GOLDEN\source\repos\BANKING SYSTEM\customers.json");
            Customers = JsonSerializer.Deserialize<List<Customer>>(JsonString);

            bool flag = false;
            do
            {
                int choice;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("         1--> Admin");
                Console.WriteLine("         2--> Customer");
                Console.WriteLine("         3--> Press 3 to exit: ");
                Console.ResetColor();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Admin Password to proceed: ");
                        if (Console.ReadLine() == admin.Password)
                        {
                            Console.WriteLine("Shifting to Admin site...");
                            admin.adminMenu(Customers);
                        }
                        else
                            Console.WriteLine("Wrong Credentials, please try again.");
                        break;
                    case 2:
                        Console.WriteLine("Enter Customer Credentials to proceed: ");
                        Console.WriteLine("Enter ID: ");
                        int ind = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter Password:");
                        string p = Console.ReadLine();
                        if (ind <= Customers.Count - 1)
                        {
                            if (p == Customers[ind].Password)
                            {
                                Console.WriteLine("Shifting to Customer site...");
                                Customers[ind].customerMenu();
                            }
                            else Console.WriteLine(Messages.Wrong_password);
                        }

                        else
                            Console.WriteLine(Messages.Wrong_credentials);
                        break;
                    case 3:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine(Messages.Invalid_choice);
                        break;

                }

            } while (!flag);
        }

    }
}
