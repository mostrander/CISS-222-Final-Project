using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class Bank_Account
   {

      private int accountNumber;
      private readonly string firstName;
      private readonly string lastName;
      private string password;
      private decimal balance;


      //Will be used for the creation of NEW bank accounts. Default starting balance is $0;
      public Bank_Account (string first_Name, string last_Name, string passwordGiven, List<Bank_Account> existingAccounts)
      {
         firstName = first_Name;
         lastName = last_Name;
         password = passwordGiven;
         balance = 0;

         //Randomly generates an account number automatically and assigns it to account.
         //NOTE: Need to add verification that number does not already exist, otherwise reroll!
         Random randomNum = new Random();
         int accountNumberAuto = randomNum.Next();

         bool accountNumFound = true;
         IEnumerable<Bank_Account> findAccount;

         //Prevents an account from being created with an existing account number
         while (accountNumFound == true)
         {
            findAccount = from accounts in existingAccounts
                              where accounts.GetAccountNumber() == accountNumberAuto
                              select accounts;

            if (findAccount.Count() == 0)
            {
               accountNumFound = false;
            }
            else
            {
               accountNumberAuto = randomNum.Next();
            }
         }

         accountNumber = accountNumberAuto;

         Console.WriteLine("Your account has been created. Your account number is: " + GetAccountNumber().ToString());
      }


      //Will be used for recreating EXISTING bank accounts from text file
      public Bank_Account (string account_Number, string first_Name, string last_Name, string Password, string accountBalance)
      {
         accountNumber = int.Parse(account_Number);
         firstName = first_Name;
         lastName = last_Name;
         password = Password;
         balance = decimal.Parse(accountBalance);
      }

      public void Deposit (decimal amount)
      {
         if(amount < 0)
         {
            Console.WriteLine("Error: Cannot deposit a negative amount.");
         }
         else
         {
            balance += amount;
            Console.WriteLine($"Account balance is now {balance:C}.");
         }
      }


      public void Withdraw (decimal amount)
      {
         if (amount < 0)
         {
            Console.WriteLine("Error: Cannot withdraw a negative amount.");
         }

         else if ((balance - amount) < 0)
         {
            Console.WriteLine($"\nCurrent account balance is {balance:C}.\n" +
               $"If you withdraw {amount:C}, your account will be overdrawn!\n" +
               $"Would you like to proceed with withdrawing {amount:C}?\n" +
               $"Type Y for yes, N for no.");
            string answer = Console.ReadLine();

            switch(answer)
            {
               case "Y":
               case "y":
                  balance -= amount;
                  Console.WriteLine($"Account balance is now {balance:C}.");
                  break;

               case "N":
               case "n":
                  break;

               default:
                  Console.WriteLine("Invalid response entered. Aborting withdraw request.");
                  break;
            }

         }

         else
         {
            balance -= amount;
            Console.WriteLine($"Account balance is now {balance:C}.");
         }
      }


      public void ChangePassword ()
      {
         Console.WriteLine("Please provide your current password:");
         string oldPassword = Console.ReadLine();

         Console.WriteLine("Please provide a new password: ");
         string newPassword = Console.ReadLine();

         Console.WriteLine("Please verify the new password: ");
         string newPasswordVerify = Console.ReadLine();

         if (oldPassword != password)
         {
            Console.WriteLine("You entered the incorrect account password.\n" +
               "Cannot successfully change password. Please try again.");
         }
         //Verifies password is at least 8 characters long and user input actually contains a value (not blank)
         else if (!(newPassword.Length >= 8) || string.IsNullOrWhiteSpace(newPassword))
         {
            Console.WriteLine("New password must be at least 8 characters long. Please try again.");
         }
         else if (newPassword != newPasswordVerify || string.IsNullOrWhiteSpace(newPasswordVerify))
         {
            Console.WriteLine("You did not type the new password correctly the second time. " +
               "Cannot successfully change password. \nPlease verify you are typing the new password correctly " +
               "and try again.");
         }
         else 
         {
            password = newPassword;
            Console.WriteLine("Password has been successfully changed.");
         }

      }


      public string GetName()
      {
         return firstName + " " + lastName;
      }

      public string GetBalance()
      {
         return balance.ToString("C");
      }

      public int GetAccountNumber()
      {
         return accountNumber;
      }

      public bool AccountLogin(string username, string passwordInput)
      {
         //Used to verify that the user is indeed the account owner before allowing user to modify information
         if( username != GetAccountNumber().ToString() )
         {
            return false;
         }
         else if (username == GetAccountNumber().ToString() && passwordInput != password)
         {
            Console.WriteLine("\nUnable to log into the account due to invalid password.");
            return false;
         }
         else 
         {
            return true;
         }
      }


      //Method for saving information to a file, need to find a better way to implement this due to security issues
      public string SaveAccountInfo()
      {
         return $"{accountNumber},{firstName},{lastName},{password},{balance}";
      }

   }
}
