﻿using myNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNamespace
{
    class Customer : Person
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
                Console.WriteLine($"\t\t\tWELCOME TO CUSTOMER SECTION {firstName} {lastName}");
                Thread.Sleep(300);
                Console.WriteLine("         1.DIPLSAY CURRENT BALANCE");
                Thread.Sleep(300);
                Console.WriteLine("         2.ADD BALANCE");
                Thread.Sleep(300);
                Console.WriteLine("         3.WITHDRAW BALANCE");
                Thread.Sleep(300);
                Console.WriteLine("         4.CHANGE CREDENTIALS (PASSWORD)");
                Thread.Sleep(300);
                Console.WriteLine("         5.DISPLAY ALL INFORMATION");
                Thread.Sleep(300);
                Console.WriteLine("         6.TERMS AND CONDTIONS");
                Thread.Sleep(300);
                Console.WriteLine("         7.Calculate taxes (filer and non filer)");
                Thread.Sleep(300);
                Console.WriteLine("Press ' 8 ' to exit.");
                Thread.Sleep(300);
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
                        Console.WriteLine("\n-----------------");
                        display();
                        break;

                    case 6:
                        Console.WriteLine(Messages.Terms);
                        terms();
                        break;
                    case 7:
                        Console.WriteLine("Press 1 if you are filer , 2 if you are non-filer");
                        Console.ForegroundColor= ConsoleColor.Red;
                        Thread.Sleep(500);
                        Console.WriteLine("             The tax deduction for a filer person is 0.15% ");
                        Thread.Sleep(500);
                        Console.WriteLine("             The tax deduction for a non-filer person is 0.75%, VAT also applies ");
                        Console.ResetColor();
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                calculateTax();     //function overloading having different arguments
                                break;
                            case 2:
                                Console.WriteLine("Enter the number of days since the last payout: ");
                                calculateTax(Convert.ToInt32(Console.ReadLine()));      //function overloading
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }
                        break;
                    case 8:
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
        public void calculateTax()
        {   Console.WriteLine("     Calculating Tax...");
            Console.WriteLine($"{firstName} {lastName} is a regular Tax Payer.");
            Console.WriteLine($"Annual Tax is: ${(balance * 0.15) / 100}. ");
        }
        public void calculateTax(int days)
        {
            Console.WriteLine("     Calculating Tax...");
            Console.WriteLine($"{firstName} {lastName} is a Non Filer (VAT fee also applies).");
            Console.WriteLine($"Annual Tax is: {(balance * 0.75) / 100}(tax) + {0.25*days}(VAT markup) = ${((balance * 0.75) / 100)+(0.25 * days)} ");
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

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public override void display()
        {
            Console.WriteLine($"    Showing Information of {firstName}-{LastName} [customer]");
            Console.WriteLine($"    Password: {Password}");
            Console.WriteLine($"    Balance: {Balance}");
        }
    }
}
