using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Entry point for the application
        Console.WriteLine("Expense Management Application started.");
        // You can add further logic here as needed.
    }
//Transaction types and categories
enum TransactionType
{
    Income,Expense
}

enum Category
{
    Salary,Freelance, Investment, Food, Transport, Enjoyment, Utilities, HealthCare, Shopping, Other
}

//Base class for all transactions
abstract class Transaction
{
    private static int _idCounter = 1;

    public int Id { get; private set;}
    public decimal Amount {get; set;}
    public string Description {get; set;}
    public DateTime Date {get; set;}

    public Category Category {get; set;}
    public TransactionType Type {get; protected set;}

    protected Transaction(decimal amount, string description, Category category)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        Id = _idCounter++;
        Amount = amount;
        Description = description;
        Category = category;
        Date = DateTime.Today;
    }

    public abstract void Display();

    public override string ToString()
    {
        return $"[ID: {Id}] {Date:dd/MM/yyyy} - {Category} - ${Amount:F2}";
    }
}
//Income class
class Income : Transaction
{
    public Income(decimal amount, string description, Category category) : base(amount, description, category){
        Type = TransactionType.Income;
    }
    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"+ INCOME: {ToString()} - {Description}");
        Console.ResetColor();
    }
}

//Expense class
class Expense : Transaction
{
    public Expense(decimal amount, string description, Category category) : base(amount, description, category)
    {
        Type = TransactionType.Expense;
    }
    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"- EXPENSE: {ToString()} - {Description}");
        Console.ResetColor();
    }
}
    
//Savings goal class
class SavingsGoal
{
    public string GoalName {get;set;}
    public decimal TargetAmount{get; set;}
    public DateTime CreatedDate{get;set;}

    public SavingsGoal(string name, decimal target)
    {
        if(target <= 0)
        throw new ArgumentException("Target amount must be positive!");

        GoalName = name;
        TargetAmount = target;
        CreatedDate = DateTime.Now;
    }

    public double CalculateProgress(decimal currentSavings)
    {
        return (double) (currentSavings / TargetAmount * 100);
    }

    public void DisplayProgress(decimal currentSavings)
    {
        double progress = CalculateProgress(currentSavings);
        Console.WriteLine($"\n Goal: {GoalName}");
        Console.WriteLine($"Target: ${TargetAmount:F2}");
        Console.WriteLine($"Current Savings: ${currentSavings:F2}");
        Console.WriteLine($"Progress: {progress:F2}%");

        if(progress >= 100)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Goal Achieved!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Remaining: ${TargetAmount - currentSavings:F2}");
        }
    }
}
}