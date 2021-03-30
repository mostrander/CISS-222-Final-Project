using System;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class Program
   {
      static void Main(string[] args)
      {
         bool endLoop = false;
         string response = null;
         Bank_Account account;
         Account_management manage = new Account_management();

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
                        manage.AccessAccount(response, account);
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
