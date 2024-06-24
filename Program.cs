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
        public static class Messages {
            public static string Executing = "\t\t\tExecuting Bank System";
            public static string Executed = "\t\t\tExecuted Successfully!";
            public static string Wrong_password = "\t\t\tWrong Password";
            public static string Wrong_credentials = "\t\t\tWrong Credentials, Please try again";
            public static string Invalid_choice = "\t\t\tInvalid choice, Please try again";
            public static string Customer_info = "\t\t\tDisplaying information of all the customers";
            public static string Add_customer = "\t\t\tAdding customer...";
            public static string Remove_customer = "\t\t\tThe Above Customer has successfully been removed from our system";
            public static string Funds = "\t\t\tThe total funds are the balance of all customers and other assets of the bank as well";
            public static string Net_revenue = "\t\t\tThe net revenue is the approximate % value of total funds at the bank (i.e. 3.5%)";
            public static string Admin_exit = "\t\t\tExiting from Admin Site...";
            public static string Display_balance = "\t\t\tDisplaying current balance";
            public static string Failed_transaction = "\t\t\tTransaction failed\nInsufficient balance";
            public static string Operation_performed = "\t\t\tOperation performed successfully  !";
            public static string Terms = "\t\t\tFollowing are the terms and conditions";



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

        class Admin
        {
            private string firstName;
            private string lastName;
            private string password;
            public string Password
            {
                get { return password; }
                set { password = value; }

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

        class Customer
        {
            private string firstName;
            private string lastName;
            private string password;
            private float balance;
            public Customer()
            {
                firstName = "random";
                lastName = "random";
                password = "customer";
                balance = 0f;
            }
            public Customer(string fn, string ln, string p, float b)
            {
                firstName = fn;
                lastName = ln;
                password = p;
                balance = b;
            }
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            public float Balance
            {
                get { return balance; }
                set { balance = value; }
            }
            public void customerMenu()
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                bool flag = false;
                int choice = 0;
                while (!flag)
                {
                    Console.WriteLine($"WELCOME TO CUSTOMER SECTION {firstName} {lastName}");
                    Console.WriteLine("         1.DIPLSAY CURRENT BALANCE");
                    Console.WriteLine("         2.ADD BALANCE");
                    Console.WriteLine("         3.WITHDRAW BALANCE");
                    Console.WriteLine("         4.CHANGE CREDENTIALS (PASSWORD)");
                    Console.WriteLine("         5.DISPLAY ALL INFORMATION");
                    Console.WriteLine("         6.TERMS AND CONDTIONS");
                    Console.WriteLine("Press ' 7 ' to exit.");
                    Console.WriteLine(" ENTER YOUR CHOICE: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(Messages.Display_balance);
                            Console.WriteLine($"Your current balance is: $ {balance}");

                            break;
                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("ENTER AMMOUNT TO ADD: ");
                            float amount = Convert.ToInt32(Console.ReadLine());
                            balance += amount;
                            Console.WriteLine($"{amount} $ AMMOUNT ADDED SUCCESSFULLY");

                            break;
                        case 3:
                            Console.WriteLine("ENTER AMOUNT TO WITHDRAW: ");
                            amount = (float)Convert.ToDouble(Console.ReadLine());
                            if (amount > balance)
                            {
                                Console.WriteLine(Messages.Failed_transaction);
                            }
                            else
                            {
                                Console.WriteLine($"Withdrwaing Amount $ {amount}");
                                balance -= amount;
                                Console.WriteLine(Messages.Operation_performed);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Current Password to change the password: ");
                            if (Console.ReadLine() == password)
                            {
                                Console.WriteLine("Enter New Password: ");
                                password = Console.ReadLine();
                                Console.WriteLine("Password has been changed");
                            }
                            else
                                Console.WriteLine(Messages.Wrong_credentials);
                            break;
                        case 5:
                            Console.WriteLine("DISPLAYING ALL INFO...");
                            displayCustInfo();
                            break;

                        case 6:
                            Console.WriteLine(Messages.Terms);
                            terms();
                            break;
                        case 7:
                            flag = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine(Messages.Invalid_choice);
                            break;

                    }
                }
                Console.ResetColor();
            }
            public void displayCustInfo()
            {
                Console.WriteLine("\n----------------------------");
                Console.WriteLine($"First Name: {firstName}");
                Console.WriteLine($"Last Name: {lastName}");
                Console.WriteLine($"Credentials: {password}");
                Console.WriteLine($"Current Balance: {balance}");
                Console.WriteLine("----------------------------\n");
            }
            //            public void terms()
            //            {
            //                Console.WriteLine(@"
            //BANK TERMS AND CONDITIONS

            //1. Introduction
            //These Terms and Conditions govern the use of our banking services. By opening an account or using any of our services, you agree to be bound by these terms.

            //2. Account Opening
            //- To open an account, you must provide accurate and complete information.
            //- You must be at least 18 years old to open an account.

            //3. Account Usage
            //- You are responsible for all transactions conducted through your account.
            //- Keep your account information and passwords secure.

            //4. Deposits and Withdrawals
            //- Deposits can be made through various channels such as cash, check, or electronic transfer.
            //- Withdrawals are subject to the availability of funds in your account.

            //5. Fees and Charges
            //- Various fees may apply to your account, including but not limited to maintenance fees, overdraft fees, and transfer fees. A full schedule of fees is available upon request.

            //6. Interest
            //- Interest rates on savings accounts and other deposit accounts are subject to change at any time. The current rates are available at our branches and on our website.

            //7. Confidentiality
            //- We are committed to maintaining the confidentiality of your personal and financial information. However, we may disclose information as required by law or regulation.

            //8. Liability
            //- The bank is not liable for any loss or damage arising from your use of our services, except as required by law.

            //9. Termination
            //- We reserve the right to terminate your account at any time with or without notice if you violate any of these terms.

            //10. Amendments
            //- We may amend these Terms and Conditions at any time. Notice of amendments will be provided through our branches, website, or by mail.

            //11. Governing Law
            //- These Terms and Conditions are governed by the laws of the country in which the bank operates.

            //12. Contact Information
            //- For any questions or concerns regarding these Terms and Conditions, please contact our customer service department.

            //Thank you for choosing our bank. We look forward to serving you.
            //            ");
            //            }
            public void terms()
            {
                string path = @"C:\Users\GOLDEN\source\repos\BANKING SYSTEM\terms.txt";
                //string terms = File.ReadAllText(path);
                //Console.WriteLine(terms);

                //              both are the same methods of reading data from a file

                using (StreamReader sr = new StreamReader(path)) {
                    string line;
                    while ((line=sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
            }    }
        }
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            loading();
            Console.WriteLine("\t\tWELCOME TO BANK MANAGEMEN SYSTEM\n");
            bank.run();
        }



    }
}