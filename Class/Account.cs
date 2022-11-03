using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Bank
{
  public class Account
  {
    private AccountType AccountType;
    private double Balance;

    private double Credit;
    private string Name;

    public Account(AccountType accountType, double balance, double credit, string name)
    {
      this.AccountType = accountType;
      this.Balance = balance;
      this.Credit = credit;
      this.Name = name;
    }
    public Account(AccountType accountType, string name)
    {
      this.AccountType = accountType;
      this.Balance = 0;
      this.Credit = 0;
      this.Name = name;
    }

    public bool Withdraw(double value)
    {
      if (this.Balance + this.Credit - value < 0)
      {
        Console.WriteLine("Saldo insulficiente");
        return false;
      }

      if (this.Balance - value > 0)
      {
        this.Balance -= value;
        Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}");
      }else if (this.Balance + this.Credit - value > 0)
      {
        this.Balance -= value;
        Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}, para esta operação você está utilizando seu limite");
      }
      return true;
    }
    public void Deposit(double value){
        this.Balance+=value;
    }

    public void Transfer(double value, Account destinationAccount){
        if (this.Withdraw(value)){
            destinationAccount.Deposit(value);
        }
    }
    public override string ToString()
    {
        string whoMe = "";
        whoMe += "AccountType " +this.AccountType + " | ";
        whoMe += "Name " +this.Name + " | ";
        whoMe += "Balance " +this.Balance + " | ";
        whoMe += "Credit " +this.Credit;
      return whoMe;
    }
  }
}