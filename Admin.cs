using myNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace myNamespace
{
    class Admin : Person
    {
        private string firstName;
        private string lastName;
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
        public override void display()
        {
            Console.WriteLine(" DISPLAYING ADMIN INFORMATION ");
            Console.WriteLine($"    First Name: {firstName}");
            Console.WriteLine($"    Last Name: {lastName}");
            Console.WriteLine($"    Password: {password}");

        }
        public Admin()
        {
            firstName = "Sufwan";
            lastName = "Masood";
            password = "1234";
        }
        public void adminMenu(List<Customer> customers)
        {
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            bool flag = false;
            double totalFunds = 0;
            while (!flag)
            {
                int choice = 0;
                Console.WriteLine($"Welcome to Admin Site  {firstName} {lastName}");
                Console.WriteLine("                  1   --->    Display information of all Customers");
                Console.WriteLine("                  2   --->    Add a Customer");
                Console.WriteLine("                  3   --->    Remove a Customer");
                Console.WriteLine("                  4   --->    Total Funds at Bank");
                Console.WriteLine("                  5   --->    Net Revenue Generated");
                Console.WriteLine("                  6   --->    Change Credentials");
                Console.WriteLine("                  7   --->    Check information of a Specific Customer ");
                Console.WriteLine("                  8   --->    Verify Admin Information");
                Console.WriteLine("                 10   --->    Exit   ");
                Console.WriteLine("       Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(Messages.Customer_info);
                        foreach (var c in customers)
                        {
                            Console.WriteLine("\n\n----------------------------------------------------");
                            c.displayCustInfo();
                        }
                        break;
                    case 2:
                        string firstName;
                        string lastName;
                        string password;
                        float balance;
                        Console.WriteLine(Messages.Add_customer);
                        Console.WriteLine("Enter first name: ");
                        firstName = Console.ReadLine();

                        Console.WriteLine("Enter last name: ");
                        lastName = Console.ReadLine(); ;

                        Console.WriteLine("Enter password: ");
                        password = Console.ReadLine();

                        Console.WriteLine($"Enter initial balance of Customer ({firstName} {lastName}): ");
                        balance = Convert.ToInt32(Console.ReadLine());
                        customers.Add(new Customer(firstName, lastName, password, balance));
                        string JsonString = JsonSerializer.Serialize(customers);
                        File.WriteAllText(@"C:\Users\GOLDEN\source\repos\BANKING SYSTEM\customers.json", JsonString);
                        break;

                    case 3:
                        Console.WriteLine("Enter Id of the customer to remove: ");
                        int removeInd = Convert.ToInt32(Console.ReadLine());
                        if (removeInd <= customers.Count - 1)
                        {
                            customers[removeInd].displayCustInfo();
                            customers.RemoveAt(removeInd);

                            Console.WriteLine(Messages.Remove_customer);
                        }
                        else
                            Console.WriteLine($"Customer having id: {removeInd} doesn't exist ! ");
                        break;
                    case 4:

                        foreach (var c in customers)
                        {
                            totalFunds += c.Balance;
                        }
                        Console.WriteLine($"The total funds of the bank are: ${totalFunds} ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Messages.Funds);
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.WriteLine($"The net revenue generated in this month is: ${totalFunds * 3.5 / 100}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Messages.Net_revenue);
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.WriteLine("Enter the current password: ");
                        if (Console.ReadLine() == Password)
                        {
                            Console.WriteLine("Enter The New Password:");
                            password = Console.ReadLine();
                            Console.WriteLine($"Your Password has successfully been changed to {password} .");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter ID to check the information of specific customer: ");
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        customers[Convert.ToInt32(Console.ReadLine())].displayCustInfo();
                        Console.ResetColor();
                        break;
                    case 8:
                        display();
                        break;
                    case 10:
                        Console.WriteLine(Messages.Admin_exit);
                        flag = true;
                        break;

                    default:
                        break;
                }
            }
            Console.ResetColor();
        }
    }
}
