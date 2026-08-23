using System;

namespace Programpractise;

public class Operation
{
        int a = 10, b = 20, c = 30;

    public void Accept()
    {
        Console.WriteLine("Enter the value of a: ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the value of b: ");
        b = Convert.ToInt32(Console.ReadLine());
    }

    public void Add()
    {
        c = a + b;
        Console.WriteLine("Addition of a and b is: " + c);
        
    }

    public void Subtract()
    {
        c = a - b;
        Console.WriteLine("Subtraction of a and b is: " + c);
    }


    public void Multiply()
    {
        c = a * b;
        Console.WriteLine("Multiplication of a and b is: " + c);
    }

    public void Divide()
    {
        c = a / b;
        Console.WriteLine("Division of a and b is: " + c);
    }
}