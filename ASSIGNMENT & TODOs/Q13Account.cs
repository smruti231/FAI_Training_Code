using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    abstract class Account
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public abstract void Credit(double amount);
        public abstract void Debit(double amount);
        public abstract void CalculateInterest();
        }
    class SBAccount : Account
        {
        public override void Credit(double amount)
            {
            Balance += amount;
            }
        public override void Debit(double amount)
            {
            if (Balance >= amount)
                {
                Balance -= amount;
                }
            else
                {
                Console.WriteLine("Insufficient balance.");
                }
            }
        // Implement interest calculation logic for SB Account
        public override void CalculateInterest()
            {
            double interestRate = 0.03; // Example interest rate (3%)

            double interest = Balance * interestRate;
            Balance += interest;

            Console.WriteLine($"Interest calculated for SB Account: {interest:C}");
            }
        }

    // Other subclasses (RDAccount, FDAccount) remain the same
    class RDAccount : Account
        {
        public override void Credit(double amount)
            {
            Balance += amount;
            }

        public override void Debit(double amount)
            {
            if (Balance >= amount)
                {
                Balance -= amount;
                }
            else
                {
                Console.WriteLine("Insufficient balance.");
                }
            }


        public override void CalculateInterest()
            {
            // Implement interest calculation logic for RD Account
            double interestRate = 0.04; // Example interest rate (4%)

            double interest = Balance * interestRate;
            Balance += interest;

            Console.WriteLine($"Interest calculated for RD Account: {interest:C}");
            }
        }

    class FDAccount : Account
        {
        public override void Credit(double amount)
            {
            Balance += amount;
            }

        public override void Debit(double amount)
            {
            if (Balance >= amount)
                {
                Balance -= amount;
                }
            else
                {
                Console.WriteLine("Insufficient balance.");
                }
            }


        public override void CalculateInterest()
            {
            // Implement interest calculation logic for FD Account
            double interestRate = 0.05; // Example interest rate (5%)

            double interest = Balance * interestRate;
            Balance += interest;

            Console.WriteLine($"Interest calculated for FD Account: {interest:C}");
            }
        }

    class Program
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Bank Account Management");

            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Balance Amount: ");
            int customerBalance = int.Parse(Console.ReadLine());

            Console.Write("Enter your account type (SB / RD / FD): ");
            string accountType = Console.ReadLine();

            Account customerAccount;
            if (accountType.ToLower() == "sb")
                {
                customerAccount = new SBAccount();
                }
            else if (accountType.ToLower() == "rd")
                {
                customerAccount = new RDAccount();
                }
            else if (accountType.ToLower() == "fd")
                {
                customerAccount = new FDAccount();
                }
            else
                {
                Console.WriteLine("Invalid account type.");
                return;
                }

            customerAccount.Name = customerName;
            customerAccount.Id = 101; // Set an example ID
            customerAccount.Balance = customerBalance;
            //customerAccount.Balance = 1000; // Set an example initial balance

            Console.WriteLine("Account created successfully!");

            // Demonstrate polymorphism by calling CalculateInterest
            Console.WriteLine($"Interest for {customerAccount.GetType().Name}:");
            customerAccount.CalculateInterest();
            }

        }
    }
