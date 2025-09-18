using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDemo
{
    abstract class Account
    {
        static int _accountNoSeed = 1000;
        public int AccountNo { get; private set; } //property
        public string AccountHolder { get; set; }
        public Account() //constructor
        {
            AccountNo = ++_accountNoSeed;
        }
        public double Balance { get; private set; }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance is {Balance}.");
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount}. New balance is {Balance}.");
        }
        public abstract void CalculateInterest();
    }
    class SavingsAccount : Account // inherit
    {
        public double InterestRate { get; set; } = .025;
        public SavingsAccount(string accountHolder)
        {
            AccountHolder = accountHolder;
        }
        public override void CalculateInterest()
        {
            double interest = Balance * InterestRate / 100;
            Deposit(interest); // Adding interest to the balance
            Console.WriteLine($"Interest earned on Savings Account: {interest}");
        }
    }

    class RecurringDepositAccount : Account
    {
        public double InterestRate { get; set; } = 0.05;
        public double MonthlyDeposit { get; set; }
        public int Months { get; set; }
        public RecurringDepositAccount(string accountHolder, double monthlyDeposit, int months)
        {
            AccountHolder = accountHolder;
            MonthlyDeposit = monthlyDeposit;
            Months = months;
        }
        public override void CalculateInterest()
        {
            // Formula for Recurring Deposit Interest:
            // Interest = P * n(n+1) * r / (2*12*100)
            // P = MonthlyDeposit, n = Months, r = annual interest rate (assume 5%)
            double r = 5.0;
            double interest = (MonthlyDeposit * Months * (Months + 1) * r) / (2 * 12 * 100);
            Deposit(interest); // Adding interest to the balance
            Console.WriteLine($"Interest earned on Recurring Deposit Account: {interest}");
        }
    }
    class FixedDepositAccount : Account
    {
        public double InterestRate { get; set; } = 0.03;
        public double MonthlyDeposit { get; set; }
        public int Months { get; set; }
        public FixedDepositAccount(string accountHolder, double monthlyDeposit, int months)
        {
            AccountHolder = accountHolder;
            MonthlyDeposit = monthlyDeposit;
            Months = months;
        }
        public override void CalculateInterest()
        {
            // Formula for Recurring Deposit Interest:
            // Interest = P * n(n+1) * r / (2*12*100)
            // P = MonthlyDeposit, n = Months, r = annual interest rate (assume 5%)
            double r = 3.0;
            double interest = (MonthlyDeposit * Months * (Months + 1) * r) / (2 * 12 * 100);
            Deposit(interest); // Adding interest to the balance
            Console.WriteLine($"Interest earned on Recurring Deposit Account: {interest}");
        }
    }


}
namespace SampleConApp
{
    using BankingDemo; //To use the class of another namespace...


    internal class AbstractExample
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter account holder name :");
            string accholdername = Console.ReadLine();
            //Account acc = new SavingsAccount("John Doe");
            Console.WriteLine("Enter deposit value :");
            double deposit_amt = double.Parse(Console.ReadLine());
            //Account acc = new SavingsAccount(accholdername);
            Console.WriteLine("Enter amount to be withdraw :");
            double withdraw_amt = double.Parse(Console.ReadLine());
            //acc.Deposit(1000);
            //acc.Deposit(deposit_amt);
            //acc.Withdraw(withdraw_amt);
            //acc.CalculateInterest();
            //Console.WriteLine("The current Balance : " + acc.Balance);
            Account acc = new FixedDepositAccount("John Doe",500,6);
            acc.Deposit(1000);
            acc.Deposit(deposit_amt);
            acc.Withdraw(withdraw_amt);
            acc.CalculateInterest();
            Console.WriteLine("The current Balance : " + acc.Balance);
        }
    }
}
// enter choice saving rd fd .

