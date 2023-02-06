using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bankAccountsArgs = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            var bankAccounts = new Dictionary<int, double>();

            foreach (var item in bankAccountsArgs)
            {
                string[] info = item
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                int accNum = int.Parse(info[0]);
                double accValue = double.Parse(info[1]);

                bankAccounts[accNum] = accValue;
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmdArgs = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = cmdArgs[0];

                    if (command == "Deposit")
                    {
                        int accNum = int.Parse(cmdArgs[1]);
                        double valueToAdd = double.Parse(cmdArgs[2]);

                        if (!bankAccounts.Any(x => x.Key == accNum))
                        {
                            throw new ArgumentException();
                        }

                        bankAccounts[accNum] += valueToAdd;

                        Console.WriteLine($"Account {accNum} " +
                            $"has new balance: {bankAccounts[accNum]:F2}");
                    }
                    else if (command == "Withdraw")
                    {
                        int accNum = int.Parse (cmdArgs[1]);
                        double valueToWithdraw = double.Parse(cmdArgs[2]);

                        if (!bankAccounts.Any(x => x.Key == accNum))
                        {
                            throw new ArgumentException();
                        }

                        if (bankAccounts[accNum] < valueToWithdraw)
                        {
                            throw new Exception();
                        }

                        bankAccounts[accNum] -= valueToWithdraw;

                        Console.WriteLine($"Account {accNum} " +
                            $"has new balance: {bankAccounts[accNum]:F2}");
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }

        }
    }
}