using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

//Transaction types and categories
enum TransactionType
{
    Income,Expense
}

enum Category
{
    Salary,Freelance, Investment, Food, Transport, Enjoyment, Utilities, HealthCare, Shopping, Other
}

//Base clase for all transactions
abstract class Transaction
{
    private static int _idCounter = 1;

    public int Id { get; private set;}
    public decimal Amount {get; set;}
    public string Description {get; set;}
    public DateTime Date {get; set;}

    public Category Category {get; set;}
    public TransactionType Type {get; protected set;}

    protected Transaction(decimal amount, string descrption, Category category)
    {
        if (amount <= 0)
        throw new ArgumentException("Amount must be positive");

        Id = _idCounter++;
        Amount = amount;
        Description = descrption;
        Category = category;
        Date = DateTime.Today;
    }

    public abstract void Display();

    public override string ToString()
    {
        return $"[ID: {Id}] {Date: dd/MM/yyyy} - {Category} - ${Amount:F2}";
    }
}
