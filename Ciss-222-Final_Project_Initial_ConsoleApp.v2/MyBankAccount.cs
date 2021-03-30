using System;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class MyBankAccount
   {
      static void Main(string[] args)
      {
         bool endLoop = false;
         string response = null;
         Bank_Account account;
         Account_management manage = new Account_management();

         Bank_Account account1 = new Bank_Account(1245, "Rob", "Fiddle", "puddingPop", "New York", 4536.25m);
         Bank_Account account2 = new Bank_Account(12485, "Sam", "Fiddle", "MagicalSong", "New York", 0.25m);
         Bank_Account account3 = new Bank_Account(1635, "Tom", "Fiddle", "Tingaling", "New York", 47415.63m);
         Bank_Account account4 = new Bank_Account(245, "Kim", "Fiddle", "puddingPop2", "New York", 16.87m);
         Bank_Account account5 = new Bank_Account(24577, "Kimmy", "Biddle", "puddingPop2", "New York", 120.87m);

         Bank_Account[] establishedAccounts =  new Bank_Account [5];

         establishedAccounts[0] = account1;
         establishedAccounts[1] = account2;
         establishedAccounts[2] = account3;
         establishedAccounts[3] = account4;
         establishedAccounts[4] = account5;

         //Need to make sure that the array actually holds the desired data
         foreach(var item in establishedAccounts)
         {
            item.TestingData();
         } //Discovered everything but the account number is correct.
         //Found the issue. I had accountnumber in the bank_account object set to static. I thought that it would apply ONLY to the specific 
         //object, but it actually stayed across all of them!



         //While statement keeps the program running while the user is using it, unless specified otherwise.
         while (endLoop == false)
         {
            try
            {
               Console.WriteLine("Welcome! What are you looking to do today? Please select the number of your choice:\n" +
                  "1. Login to an account\n" +
                  "2. Create a new account\n" +
                  "3. Exit program");
               response = Console.ReadLine();

               switch (response)
               {
                  case "1":
                     Console.WriteLine("Not implemented yet.");
                     manage.LoginAttempt(establishedAccounts);
                     break;
                  case "2":
                     string firstName = null;
                     string lastName = null;
                     string password = null;

                     //Request first name information and verify user input a value.
                     Console.WriteLine("What is your first name?");
                     response = Console.ReadLine();

                     if (string.IsNullOrEmpty(response))
                     {
                        throw new Exception();
                     }
                     else
                     {
                        firstName = response;
                     }
                     
                     //Request last name information and verify user input a value.
                     Console.WriteLine("What is your last name?");
                     response = Console.ReadLine();

                     if (string.IsNullOrEmpty(response))
                     {
                        throw new Exception();
                     }
                     else
                     {
                        lastName = response;
                     }
                     

                     Console.WriteLine("Please create a password:\n" +
                        "(Must be at least 8 characters in length)");
                     response = Console.ReadLine();

                     if (!(response.Length >= 8) || string.IsNullOrEmpty(response))
                     {
                        throw new Exception();
                     }
                     else
                     {
                        password = response;
                        Console.WriteLine("Creating your new bank account now...");
                        account = new Bank_Account(firstName, lastName, password); //Finish initializing the account
                        manage.AccessAccount(account);
                     }

                     endLoop = true; //forces this loop to discontinue running, continue with rest of program.
                     break;

                  case "3":
                     Console.WriteLine("Thank you. Have a good day.");
                     Environment.Exit(0); // Forces the program to close.
                     break;
                  default:
                     Console.WriteLine("Error: Input provided is not an available option. Please try again " +
                        "and select one of the options provided.");
                     break;
               }


            }
            catch
            {
               if (string.IsNullOrEmpty(response))
               {
                  Console.WriteLine("Error: You did not enter a value. Please try again.");
               }
               else if (!(response.Length >= 8))
               {
                  Console.WriteLine("Error: Could not create account because password provided was not at least " +
                     "8 characters long.\n" +
                     "Please try again.");
               }
            }

         }

         Environment.Exit(0); // Forces the program to close.
      }

   }
}
