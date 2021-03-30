﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ciss_222_Final_Project_Initial_ConsoleApp
{
   class Account_management
   {
      public Account_management()
      {
         //used solely for allowing me to access other methods to make program work.
      }

      public void AccessAccount(string response, Bank_Account account)
      {
         bool endMethod = false;

         while (endMethod == false)
         {
            string currentPassword = null;

            Console.WriteLine("Please select from the following options: \n" +
               "1. Deposit money \n" +
               "2. Withdraw money \n" +
               "3. Change password \n" +
               "4. Change security answer \n" +
               "5. Log out.");
            response = Console.ReadLine();

            switch (response)
            {
               case "1":
                  Console.WriteLine("How much money would you like to deposit?");
                  decimal.TryParse(Console.ReadLine(), out decimal amtDeposit);
                  account.Deposit(amtDeposit);
                  break;
               case "2":
                  Console.WriteLine("How much money would you like to deposit?");
                  decimal.TryParse(Console.ReadLine(), out decimal amtWithdraw);
                  account.Withdraw(amtWithdraw);
                  break;
               case "3":
                  Console.WriteLine("Please provide your current password:");
                  currentPassword = Console.ReadLine();

                  Console.WriteLine("Please provide a new password: ");
                  string newPassword = Console.ReadLine();

                  Console.WriteLine("Please verify the new password: ");
                  string newPasswordVerify = Console.ReadLine();

                  account.ChangePassword(currentPassword, newPassword, newPasswordVerify);
                  break;
               case "4":
                  Console.WriteLine("Please provide your current password:");
                  currentPassword = Console.ReadLine();
                  account.ChangeSecurityQuestionAnswer(currentPassword);
                  break;
               case "5":
                  endMethod = true;
                  Console.WriteLine("Logging out...");
                  break;
               default:
                  Console.WriteLine("Invalid input. Please select only the number of the desired action and try again.");
                  break;
            }
         }
      } //End of AccessAccount method


   }
}
