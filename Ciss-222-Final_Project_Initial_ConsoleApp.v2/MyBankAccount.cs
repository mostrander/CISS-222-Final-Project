using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class MyBankAccount
   {
      static void Main(string[] args)
      {
         StreamReader fileReader; //For reading in the information from a file

         string response = null;
         Account_management manage = new Account_management();

         List<Bank_Account> establishedAccounts =  new List<Bank_Account>(); //Will hold the account information during program.

         try
         {
            //Read account information from file and put into List.
            var fileInput = new FileStream("existingAccounts.txt", FileMode.OpenOrCreate, FileAccess.Read);
            fileReader = new StreamReader(fileInput);

            string line;

            while ((line = fileReader.ReadLine()) != null)
            {
               string[] words = line.Split(',');
               if (words.Length > 1) //Prevents program from reading empty lines unintentionally inserted into the persistent file of accounts
               {
                  establishedAccounts.Add( new Bank_Account(words[0], words[1], words[2], words[3], words[4]) );
               }
            }

            fileReader.Close();
         }
         catch
         {
            //File does not exist in directory
            //File location \Ciss-222-Final_Project_Initial_ConsoleApp.v2\bin\Debug\netcoreapp3.1
         }


         //While statement keeps the program running while the user is using it, unless specified otherwise.
         while (response != "3")
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
                  manage.CreateAccount(establishedAccounts);
                  break;

               case "3":
                  manage.UpdateBankAccounts(establishedAccounts);
                  break;

               default:
                  Console.WriteLine("Error: Input provided is not an available option. \nPlease try again " +
                     "and select one of the options provided.");
                  break;
            }
         }

         Environment.Exit(0); // Forces the program to close.
      } //End of Main Method

   }
}
