
using System;

namespace OOP
{
    // Abstract base class
    abstract class Payment
    {
        public abstract void Pay(decimal amount);
    }

    // Derived class 1
    class CreditCardPayment : Payment
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card.");
        }
    }

    // Derived class 2
    class PayPalPayment : Payment
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal.");
        }
    }

    class Program
    {
        static void Main()
        {
            Payment payment1 = new CreditCardPayment();
            payment1.Pay(100);   // Output: Paid ₹100.00 using Credit Card.

            Payment payment2 = new PayPalPayment();
            payment2.Pay(200);   // Output: Paid ₹200.00 using PayPal.

            // Reuse same objects
            payment1.Pay(150);   // Output: Paid ₹150.00 using Credit Card.
            payment2.Pay(250);   // Output: Paid ₹250.00 using PayPal.
        }
    }
}


// Encapsulation 
class BankAccount
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }
}

/* Inheritance
class Account
{
    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
    }
}

class SavingAccount : Account
{
    public decimal InterestRate { get; set; } = 0.05m;

    public void ApplyInterest()
    {
        Balance += Balance * InterestRate;
    }
}

class CurrentAccount : Account
{
    public decimal OverdraftLimit { get; set; }
}

//polymorphism

class Account
{
    public decimal Balance { get; set; }

    public virtual void ProcessTransaction(decimal amount)
    {
        Balance += amount;

        Console.WriteLine(
            $"Generic Account: {Balance}"
        );
    }
}
Now SavingAccount:

class SavingAccount : Account
{
    public decimal InterestRate { get; set; } = 0.05m;

    public override void ProcessTransaction(decimal amount)
    {
        Balance += amount;

        Balance += Balance * InterestRate;

        Console.WriteLine(
            $"Saving Account: {Balance}"
        );
    }
}
And CurrentAccount:

class CurrentAccount : Account
{
    public override void ProcessTransaction(decimal amount)
    {
        Balance += amount;

        Console.WriteLine(
            $"Current Account: {Balance}"
        );
    }
}
Now:

Account acc1 = new SavingAccount();
Account acc2 = new CurrentAccount();

acc1.ProcessTransaction(1000);
acc2.ProcessTransaction(1000);