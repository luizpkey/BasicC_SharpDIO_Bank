using System;

namespace DIO.Bank
{
  class Program
  {
   static List<Account> accounts = new List<Account>();
    static void Main(string[] args)
    {
      string optionUser = GetOptionUser();

      while (optionUser != "X")
      {
        switch (optionUser)
        {
          case "1":
            AccountList();
            break;
          case "2":
            InsertAccount();
            break;
          case "3":
            Transfer();
            break;
          case "4":
            Withdraw();
            break;
          case "5":
            Deposit();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        optionUser = GetOptionUser();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.WriteLine();
    }

    private static void Withdraw()
    {
      Console.WriteLine("Digite o número/índice da conta: ");
      int accountIndex = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser sacado: ");
      double value = double.Parse(Console.ReadLine());

      accounts[accountIndex].Withdraw(value:value);
    }
    private static void Deposit()
    {
      Console.WriteLine("Digite o número/índice da conta: ");
      int accountIndex = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser depositado: ");
      double value = double.Parse(Console.ReadLine());

      accounts[accountIndex].Deposit(value: value);
    }

    private static void Transfer(){
      Console.WriteLine("Digite o número/índice da conta origem: ");
      int originAccountIndex = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o número/índice da conta destino: ");
      int destinyAccountIndex = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser transferido: ");
      double value = double.Parse(Console.ReadLine());

      accounts[originAccountIndex].Transfer(value: value, destinationAccount:accounts[destinyAccountIndex]);
    }


    private static void AccountList()
    {
      Console.WriteLine("Listar contas");

      if (accounts.Count == 0){
        Console.WriteLine("Nenhuma counta cadastrada.");
      }

      for (int i =0; i<accounts.Count; i++){
        Account account = accounts[i];
        Console.WriteLine($"{i} - {account}");
      }
    }

    private static void InsertAccount()
    {
      Console.WriteLine("Inserir nova counta");

      Console.WriteLine("Digite 1 para Conta Física ou 2 para Juridica:");
      int accountTypeIn = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Nome do cliente: ");
      string nameIn = Console.ReadLine();

      Console.WriteLine("Digite o saldo inicial: ");
      double balanceIn = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o crédito: ");
      double creditIn = double.Parse(Console.ReadLine());

      Account newAccount = new Account(accountType: (AccountType)accountTypeIn,
                                       balance: 0.0,
                                       credit: creditIn,
                                       name: nameIn );
      newAccount.Deposit(value:balanceIn);
      accounts.Add(newAccount);

    }

    private static string GetOptionUser()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank a seu dispor!!!");
      Console.WriteLine("");

      Console.WriteLine("1- Listar Contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string? optionUser = Console.ReadLine();
      if (optionUser == null)
        optionUser = "";
      return optionUser.ToUpper();
    }
  }
}


