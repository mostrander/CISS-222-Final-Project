using System;
using System.Collections.Generic;
using System.IO;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class MyBankAccount
   {
      
      static void Main(string[] args)
      {
         StreamWriter fileWriter; //Creates the StreamWriter object that allows files to be written to.
         StreamReader fileReader; //For reading in the information from a file

         string response = null;
         Bank_Account account;
         Account_management manage = new Account_management();

         List<Bank_Account> establishedAccounts =  new List<Bank_Account>(); //Will hold the account information during program.

         //Read account information from file and put into List.
         var fileInput = new FileStream("existingAccounts.txt", FileMode.OpenOrCreate, FileAccess.Read);
         fileReader = new StreamReader(fileInput);

         string line;

         while ((line = fileReader.ReadLine()) != null)
         {
            string[] words = line.Split(',');
            //if(words.Length > 0)
            //{
               establishedAccounts.Add( new Bank_Account(words[0], words[1], words[2], words[3], words[4], words[5]) );
            //}
         }

         fileReader.Close();


         //List implementation - original
         //Bank_Account account1 = new Bank_Account("1245", "Rob", "Fiddle", "puddingPop", "New York", 4536.25m);
         //Bank_Account account2 = new Bank_Account("12485", "Sam", "Fiddle", "MagicalSong", "New York", 0.25m);
         //Bank_Account account3 = new Bank_Account("1635", "Tom", "Fiddle", "Tingaling", "New York", 47415.63m);
         //Bank_Account account4 = new Bank_Account("245", "Kim", "Fiddle", "puddingPop2", "New York", 16.87m);
         //Bank_Account account5 = new Bank_Account("24577", "Kimmy", "Biddle", "puddingPop2", "New York", 120.87m);

         //Original array implementation for individual accounts already existing
         //establishedAccounts[0] = account1;
         //establishedAccounts[1] = account2;
         //establishedAccounts[2] = account3;
         //establishedAccounts[3] = account4;
         //establishedAccounts[4] = account5;

         //establishedAccounts.Add(account1);
         //establishedAccounts.Add(account2);
         //establishedAccounts.Add(account3);
         //establishedAccounts.Add(account4);
         //establishedAccounts.Add(account5);



         //Need to make sure that the array actually holds the desired data
         foreach (var item in establishedAccounts)
         {
            item.TestingData();
         } //Discovered everything but the account number is correct.
         //Found the issue. I had accountnumber in the bank_account object set to static. I thought that it would apply ONLY to the specific 
         //object, but it actually stayed across all of them!



         //While statement keeps the program running while the user is using it, unless specified otherwise.
         while (response != "3")
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
                        account = new Bank_Account(firstName, lastName, password, establishedAccounts); //Finish initializing the account

                        establishedAccounts.Add(account); //Add the new account to list of existing accounts
                        manage.AccessAccount(account);
                     }

                     break;

                  case "3":
                     Console.WriteLine("Thank you. Have a good day.");

                     //Saves all account information to a file so it can be used next time program is launched
                     Console.WriteLine("Testing the SaveAccountInformation method...");

                     for (int i = 0; i < establishedAccounts.Count; i++)
                     {
                        Console.WriteLine(establishedAccounts[i].SaveAccountInfo());
                     }


                     //Print information to a text document so it persists
                     var fileOutput = new FileStream("existingAccounts.txt", FileMode.OpenOrCreate, FileAccess.Write);
                     fileWriter = new StreamWriter(fileOutput);

                     foreach(var item in establishedAccounts)
                     {
                        fileWriter.WriteLine(item.SaveAccountInfo());
                     }

                     fileWriter.Close(); //Have to close file in order for information to save to it!
                     //It works!!


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
