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
      private string securityAnswer; //Must be correct in order to change password or reset password
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
         int accountNumberAuto = randomNum.Next(3);

         bool accountNumFound = true;

         while (accountNumFound == true)
         {
            IEnumerable<Bank_Account> findAccount = from accounts in existingAccounts
                              where accounts.GetAccountNumber() == accountNumberAuto
                              select accounts;

            if (findAccount.Count() == 0)
            {
               accountNumFound = false;
            }
            else
            {
               accountNumberAuto = randomNum.Next(3);
            }
         }


         //for (int i = 0; i < existingAccounts.Count; i++)
         //{
         //   if (accountNumberAuto.ToString() == existingAccounts[i].accountNumber.ToString())
         //   {
         //      accountNumberAuto = randomNum.Next(3);
         //      i = 0;
         //   }
         //}

         accountNumber = accountNumberAuto;

         Console.WriteLine("Please enter an answer for the following security question:");
         Console.WriteLine("What city were you born in?");
         securityAnswer = Console.ReadLine();

         Console.WriteLine($"Your account has been created. Your account number is: {accountNumber.ToString()}");
      }


      //Will be used for recreating EXISTING bank accounts from text file
      public Bank_Account (string account_Number, string first_Name, string last_Name, string Password, string answer, string accountBalance)
      {
         accountNumber = int.Parse(account_Number);
         firstName = first_Name;
         lastName = last_Name;
         password = Password;
         securityAnswer = answer;
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
            Console.WriteLine($"Account balance is now {balance}.");
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
            Console.WriteLine($"Current account balance is {balance}.\n" +
               $"If you withdraw {amount}, your account will be overdrawn!\n" +
               $"Would you like to proceed with withdrawing {amount}?\n" +
               $"Type Y for yes, N for no.");
            string answer = Console.ReadLine();

            switch(answer)
            {
               case "Y":
               case "y":
                  balance -= amount;
                  Console.WriteLine($"Account balance is now {balance}.");
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
            Console.WriteLine($"Account balance is now {balance}.");
         }
      }


      public void ChangePassword (string oldPassword, string newPassword, string newPassword2)
      {

         if (oldPassword != password)
         {
            Console.WriteLine("You entered the incorrect account password.\n" +
               "Cannot successfully change password. Please try again.");
         }
         else if (!(newPassword.Length >= 8))
         {
            Console.WriteLine("New password must be at least 8 characters long. Please try again.");
         }
         else if (newPassword != newPassword2)
         {
            Console.WriteLine("The new password you entered does not match the verification field.\n" +
               "Cannot successfully change password. Please verify you are typing the new password correctly " +
               "and try again.");
         }
         else 
         {
            password = newPassword;
            Console.WriteLine("Password has been successfully changed.");
         }

      }


      //Will be used to change the answer to the account security question.
      public void ChangeSecurityQuestionAnswer (string Password)
      {
         Console.WriteLine("Please enter an answer for the following security question:");
         Console.WriteLine("What city were you born in?");
         Console.WriteLine("Your current answer: ");
         string answer = Console.ReadLine();

         Console.WriteLine("Please provide a new answer: ");
         string newAnswer = Console.ReadLine();

         if (string.IsNullOrEmpty(newAnswer))
         {
            Console.WriteLine("Error: You did not enter a new answer to the security question!\n" +
               "Unable to update your answer to the security question. Please try again.");
         }

         else if (Password != password)
         {
            Console.WriteLine("The account password you entered is incorrect. " +
               "Please try again.");
         }

         else if (answer != securityAnswer )
         {
            Console.WriteLine("Error: Your current answer to the security question is incorrect.\n" +
               "Please try again.");
         }

         else
         {
            securityAnswer = newAnswer;
            Console.WriteLine("Your answer to the security question has been successfully updated. " +
               "Thank you.");
         }
      }


      public string GetName()
      {
         return firstName + lastName;
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
         if( username != accountNumber.ToString() )
         {
            return false;
         }
         else if (username == accountNumber.ToString() && passwordInput != password)
         {
            Console.WriteLine("Unable to log into the account due to invalid password.");
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
         return $"{accountNumber},{firstName},{lastName},{password},{securityAnswer},{balance} ";
      }

   }
}
