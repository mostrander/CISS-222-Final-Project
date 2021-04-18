
namespace CISS_222_Final_Project_GUI_v1
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label1 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.TestingListObject = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(20, 32);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(512, 69);
         this.label1.TabIndex = 0;
         this.label1.Text = "Welcome! What are you looking to do today? \r\nPlease select one of the following c" +
    "hoices:";
         // 
         // button1
         // 
         this.button1.AutoSize = true;
         this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.button1.Location = new System.Drawing.Point(150, 139);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(230, 39);
         this.button1.TabIndex = 1;
         this.button1.Text = "Login to an account";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.AutoSize = true;
         this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.button2.Location = new System.Drawing.Point(150, 197);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(254, 39);
         this.button2.TabIndex = 2;
         this.button2.Text = "Create a new account";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // button3
         // 
         this.button3.AutoSize = true;
         this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.button3.Location = new System.Drawing.Point(150, 256);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(159, 39);
         this.button3.TabIndex = 3;
         this.button3.Text = "Exit program";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // TestingListObject
         // 
         this.TestingListObject.FormattingEnabled = true;
         this.TestingListObject.ItemHeight = 20;
         this.TestingListObject.Location = new System.Drawing.Point(25, 327);
         this.TestingListObject.Name = "TestingListObject";
         this.TestingListObject.Size = new System.Drawing.Size(507, 284);
         this.TestingListObject.TabIndex = 4;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(557, 623);
         this.Controls.Add(this.TestingListObject);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.ListBox TestingListObject;
   }
}

