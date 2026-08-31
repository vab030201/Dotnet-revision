using System;

namespace TFLDemo;

    public class Student
{
    public string Name {get; set;}
    public int Age {get; set;}

    public Student (string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new  Student("Durga", 29);


        student.Display();
    }
}




