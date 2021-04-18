
namespace CISS_222_Final_Project_GUI_v1
{
   partial class Form2
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
         this.accountNumberInput = new System.Windows.Forms.TextBox();
         this.passwordInput = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // accountNumberInput
         // 
         this.accountNumberInput.Location = new System.Drawing.Point(167, 84);
         this.accountNumberInput.Name = "accountNumberInput";
         this.accountNumberInput.Size = new System.Drawing.Size(100, 26);
         this.accountNumberInput.TabIndex = 0;
         // 
         // passwordInput
         // 
         this.passwordInput.Location = new System.Drawing.Point(167, 121);
         this.passwordInput.Name = "passwordInput";
         this.passwordInput.Size = new System.Drawing.Size(100, 26);
         this.passwordInput.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(31, 87);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(130, 20);
         this.label1.TabIndex = 2;
         this.label1.Text = "Account number:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(83, 127);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(78, 20);
         this.label2.TabIndex = 3;
         this.label2.Text = "Password";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(31, 40);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(252, 20);
         this.label3.TabIndex = 4;
         this.label3.Text = "Please enter your login information";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(129, 169);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(76, 34);
         this.button1.TabIndex = 5;
         this.button1.Text = "Login";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form2
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(326, 250);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.passwordInput);
         this.Controls.Add(this.accountNumberInput);
         this.Name = "Form2";
         this.Text = "Form2";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.TextBox passwordInput;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button button1;
      public System.Windows.Forms.TextBox accountNumberInput;
   }
}