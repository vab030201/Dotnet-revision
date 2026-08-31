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
