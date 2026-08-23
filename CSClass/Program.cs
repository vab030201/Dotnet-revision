
class Account
{
    // Data members
    private string accountHolderName;
    private string accountNumber;
    private double balance;
}


Account a1 = new Account();
Account a2 = new Account();
Account a3 = new Account();


public string AccountHolderName
{
    get { return accountHolderName; }
    set { accountHolderName = value; }
}

public void Deposit(double amount)
{
    balance += amount;
}

public void Withdraw(double amount)
{
    if(amount <= balance)
        balance -= amount;
    else
        Console.WriteLine("Insufficient balance!");
}

public void Display()
{
    Console.WriteLine($"Name: {accountHolderName}, Balance: {balance}");
} 

// Constructor
public Account(string name, string accNo)
{
    accountHolderName = name;
    accountNumber = accNo;
    balance = 0;
}

public class Account
{
    string accountHolderName;
    string accountNumber;
    double balance;

    //Default constructor
    public Account()
    {
        accountHolderName = "Unknown";
        accountNumber = "0000";
        balance = 0.0;
    }

    // Parameterized constructor
    public Account(string name, string accNo)
    {
        accountHolderName = name;
        accountNumber = accNo;
        balance = 0.0;
    }

    //Another overload with initial balance
    public Account(string name, string accNo, double initialBalance)
    {
        accountHolderName = name;
        accountNumber = accNo;
        balance = initialBalance;
    }

}

//Destructor
public class Account : IDisposable
{
    private bool disposed = false;

    public void Dispose()
    {
        if (!disposed)
        {
            // Cleanup code here
            disposed = true;
        }
        GC.SuppressFinalize(this); // prevents destructor call
    }

    ~Account()
    {
        // Fallback cleanup if Dispose wasn't called
        Dispose();
    }
}
  

class Program
{
    public static void Main(string[] args)
    {
        Account a1 = new Account("Vibha","500000000");

        a1.Deposit(1000);
        a1.Withdraw(500);


        a1.Display();   
    }
}