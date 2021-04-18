using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CISS_222_Final_Project_GUI_v1
{
   public partial class Form1 : Form
   {
      public Account_management manageAccounts = new Account_management();

      public Form1()
      {
         InitializeComponent();
      }


      //Log into an account button
      private void button1_Click(object sender, EventArgs e)
      {
         List<Bank_Account> existingAccounts = new List<Bank_Account>();

         Bank_Account account1 = new Bank_Account("1245", "Rob", "Fiddle", "puddingPop", "New York", 4536.25m);
         Bank_Account account2 = new Bank_Account("12485", "Sam", "Fiddle", "MagicalSong", "New York", 0.25m);
         Bank_Account account3 = new Bank_Account("1635", "Tom", "Fiddle", "Tingaling", "New York", 47415.63m);
         Bank_Account account4 = new Bank_Account("245", "Kim", "Fiddle", "puddingPop2", "New York", 16.87m);
         Bank_Account account5 = new Bank_Account("24577", "Kimmy", "Biddle", "puddingPop2", "New York", 120.87m);

         existingAccounts.Add(account1);
         existingAccounts.Add(account2);
         existingAccounts.Add(account3);
         existingAccounts.Add(account4);
         existingAccounts.Add(account5);

         //Quick test of using existingAccounts list object
         //Items are in list properly.
         foreach (var item in existingAccounts)
         {
            TestingListObject.Items.Add(item.SaveAccountInfo());
         }

         //Copy original code from console app version of project
         (new Form2()).Show();
         //this.Hide(); //This will hide form 1 on screen

         manageAccounts.LoginAttempt(existingAccounts);
      }

      //Create an account button
      private void button2_Click(object sender, EventArgs e)
      {

      }

      //Exit program button
      //Works
      private void button3_Click(object sender, EventArgs e)
      {
         Environment.Exit(0);
      }
   }
}
