public class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int d, int m, int y)
    {
        this.day = d;
        this.month = m;
        this.year = y;
    }

    public void Show()
    {
        Console.WriteLine(
            this.day + "/" +
            this.month + "/" +
            this.year);
    }

    public static void Main(string[] args)
    {
        Date today = new Date(12, 10, 2025);

        today.Show();
    }
}


//Override 

/*public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Bark");
    }
}

class Program
{
    static void Main()
    {
        Animal a = new Dog();
        a.Speak(); // Output: Bark
    }
}


// overloading

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(2, 3));       // 5
        Console.WriteLine(calc.Add(2.5, 3.5));   // 6.0
        Console.WriteLine(calc.Add(1, 2, 3));    // 6
    }
}*/
