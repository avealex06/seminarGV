using System;
namespace classes
{
	public class BankAccount
	{
		public int accountNumber, balance;
		public string holderName, currency;

		public int Deposit(int amount)
		{
			balance += amount;
			return balance;
		}
		public int Withdraw(int amount)
		{
			if (amount <= balance)
			{
				balance -= amount;
				return balance;
			}
			else
			{
				return 0;
			}
		}
		public void Transfer(int amount, BankAccount otherAcc)
		{
            if (amount <= balance)
            {
                balance -= amount;
				otherAcc.balance += amount;

            }
            else
            {
				Console.Write("you broke");
            }
        }

		public BankAccount(string holder, string curr)
		{
			holderName = holder;
			currency = curr;
			Random rand = new Random();
            accountNumber = rand.Next(100000000, (int)Convert.ToInt64(10000000001));
			balance = 0;
		}
	}
}

