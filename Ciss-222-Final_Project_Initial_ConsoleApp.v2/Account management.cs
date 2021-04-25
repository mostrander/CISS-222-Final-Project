using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class Account_management
   {
      public Account_management()
      {
         //used solely for allowing me to access other methods to make program work.
      }

      public void AccessAccount(Bank_Account account, string response)
      {
         Console.WriteLine("\nHello " + account.GetName());

         while (response != "5")
         {
            Console.WriteLine("\nPlease select from the following options: \n" +
               "1. Deposit money \n" +
               "2. Withdraw money \n" +
               "3. Change password \n" +
               "4. Check balance \n" +
               "5. Log out.");
            response = Console.ReadLine();

            switch (response)
            {
               case "1":
                  Console.WriteLine("\nHow much money would you like to deposit?");
                  decimal.TryParse(Console.ReadLine(), out decimal amtDeposit); //Automatically verifies input, defaults to 0 if not valid
                  account.Deposit(amtDeposit);
                  break;
               case "2":
                  Console.WriteLine("\nHow much money would you like to withdraw?");
                  decimal.TryParse(Console.ReadLine(), out decimal amtWithdraw);
                  account.Withdraw(amtWithdraw);
                  break;
               case "3":
                  account.ChangePassword();
                  break;
               case "4":
                  Console.WriteLine("\nAccount balance is currently " + account.GetBalance());
                  break;
               case "5":
                  Console.WriteLine("Logging out...\n");
                  break;
               default:
                  Console.WriteLine("Invalid input. Please select only the number of the desired action and try again.");
                  break;
            }
         }
      } //End of AccessAccount method


      public void LoginAttempt(List<Bank_Account> existingAccounts)
      {
         //corresponds with the AccountLogin method in the Bank_Account class
         //Used for checking multiple accounts for a login match.

         bool accountFound = false;
         string response = null;

         try
         {

            Console.WriteLine("\nPlease provide your account number: ");
            string username = Console.ReadLine();

            Console.WriteLine("\nPlease enter the password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
               throw new Exception();
            }
            else
            {
               for (int i = 0; i < existingAccounts.Count; i++)
               {
                  //returns True is information matches login information for existing account
                  accountFound = existingAccounts[i].AccountLogin(username, password);

                  if (accountFound == true)
                  {
                     AccessAccount(existingAccounts[i], response);
                     i = 5;
                     break;
                  }
                  else
                  {
                     Console.WriteLine("Information does not match this account.\n"); // Using for testing purposes.
                  }
               }
            }

         }
         catch
         {
            Console.WriteLine("Was unable to log into your account. Please make sure you entered a value and try again.");
         }

      }



      public void CreateAccount(List<Bank_Account> establishedAccounts)
      {
         Bank_Account account;
         string firstName = null;
         string lastName = null;
         string password = null;
         string response;
         string response2;
         bool validInput = false;

         try 
         { 
            //Request first name information and verify user input a value.
            Console.WriteLine("\nWhat is your first name?");
            response = Console.ReadLine();

            //Request last name information and verify user input a value.
            Console.WriteLine("\nWhat is your last name?");
            response2 = Console.ReadLine();

            if (string.IsNullOrEmpty(response) || response.StartsWith(' ') )
            {
               Console.WriteLine("\nError: You did not provide your first name or your response starts with a space. Please do not include any spaces and try again.");
               Console.WriteLine("What is your first name?");
               response = Console.ReadLine();

               if (string.IsNullOrEmpty(response) || response.StartsWith(' '))
               {
                  throw new Exception();
               }
               else
               {
                  firstName = response;
               }
            }
            else if (string.IsNullOrEmpty(response2) || response2.StartsWith(' '))
            {
               Console.WriteLine("\nError: You did not provide your last name or your response starts with a space. Please do not include any spaces and try again.");
               Console.WriteLine("What is your last name?");
               response2 = Console.ReadLine();

               if (string.IsNullOrEmpty(response2) || response2.StartsWith(' '))
               {
                  throw new Exception();
               }
               else
               {
                  lastName = response2;
               }
            }
            else
            {
               firstName = response;
               lastName = response2;
            }

            Console.WriteLine("\nPlease create a password:\n" +
               "(Must be at least 8 characters in length)");
            response = Console.ReadLine();

            while (validInput == false)
            {
               if (string.IsNullOrEmpty(response) || response.StartsWith(' ') || !(response.Length >= 8))
               {
                  Console.WriteLine("\nError: You either did not enter a password or the password is not long enough. Please try again.");
                  Console.WriteLine("Please create a password:\n" + "(Must be at least 8 characters in length)");
                  response = Console.ReadLine();

                  //If the password provided still does not meet requirements, cancel process.
                  if(string.IsNullOrEmpty(response) || response.StartsWith(' ') || !(response.Length >= 8))
                  {
                     throw new Exception();
                  }
               }
               else
               {
                  validInput = true;
                  password = response;
                  Console.WriteLine("\nCreating your new bank account now...");
                  account = new Bank_Account(firstName, lastName, password, establishedAccounts); //Finish initializing the account

                  establishedAccounts.Add(account); //Add the new account to list of existing accounts
                  AccessAccount(account, response);
               }
            }
         } 
         catch 
         {
            Console.WriteLine("Invalid Information. We were unable to complete your request. Please try again.");
         }
      }


      public void UpdateBankAccounts(List<Bank_Account> establishedAccounts)
      {
         StreamWriter fileWriter; //Creates the StreamWriter object that allows files to be written to.

         //Saves all account information to a file so it can be used next time program is launched
         var fileOutput = new FileStream("existingAccounts.txt", FileMode.OpenOrCreate, FileAccess.Write);
         fileWriter = new StreamWriter(fileOutput);

         var sorted = from accounts in establishedAccounts
                      orderby accounts.GetAccountNumber() ascending
                      select accounts;

         foreach (var item in sorted)
         {
            fileWriter.WriteLine(item.SaveAccountInfo());
         }

         fileWriter.Close(); //Have to close file in order for information to save to it!

         Console.WriteLine("Thank you. Have a good day.");

         Environment.Exit(0); // Forces the program to close.
      }
   }
}
