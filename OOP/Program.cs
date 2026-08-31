
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
