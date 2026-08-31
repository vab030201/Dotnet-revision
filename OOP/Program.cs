
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


/*inheritance 

public abstract class Employee
{
    protected double BasicSalary;
    protected double Hra;
    protected double Da;

    protected Employee()
    {
        BasicSalary = 5000;
        Hra = 1200;
        Da = 700;
    }

    protected Employee(
        double basicSalary,
        double hra,
        double da)
    {
        BasicSalary = basicSalary;
        Hra = hra;
        Da = da;
    }

    public virtual double CalculateSalary()
    {
        return BasicSalary + Hra + Da;
    }

    public abstract double CalculateBonus();
}
Manager:

public class Manager : Employee
{
    private double incentive;

    public Manager()
        : base()
    {
        incentive = 0;
    }

    public Manager(
        double basicSalary,
        double hra,
        double da,
        double incentive)
        : base(basicSalary, hra, da)
    {
        this.incentive = incentive;
    }

    public double CalculateIncentives()
    {
        return incentive * 2;
    }

    public override double CalculateSalary()
    {
        return base.CalculateSalary()
             + CalculateIncentives();
    }

    public override double CalculateBonus()
    {
        return BasicSalary * 0.20;
    }
}
Now:

static void Main()
{
    Employee emp =
        new Manager(
            20000,
            5000,
            3000,
            4000);

    double salary =
        emp.CalculateSalary();

    double bonus =
        emp.CalculateBonus();

    Console.WriteLine(
        $"Salary = {salary}");

    Console.WriteLine(
        $"Bonus = {bonus}");
}