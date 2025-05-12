namespace WindowsFormsApp1
{
    partial class signup
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
            this.button1 = new System.Windows.Forms.Button();
            this.lable1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            // 
            // lable1
            // 
            this.lable1.Location = new System.Drawing.Point(0, 0);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(100, 23);
            this.lable1.TabIndex = 0;
            // 
            // signup
            // 
            this.ClientSize = new System.Drawing.Size(1466, 681);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.button1);
            this.Name = "signup";
            this.Load += new System.EventHandler(this.signup_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.TextBox surnametextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox addresstextBox;
        private System.Windows.Forms.TextBox emailtextBox;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.TextBox confirmpasswordtextBox;
        private System.Windows.Forms.ComboBox gendercomboBox;
        private System.Windows.Forms.NumericUpDown agenumericUpDown1;
        private System.Windows.Forms.Button signupbutton;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lable1;
    }
}