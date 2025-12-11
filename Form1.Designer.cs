namespace USB1208_Controller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnA0 = new Button();
            btnA1 = new Button();
            btnA2 = new Button();
            btnA3 = new Button();
            btnExit = new Button();
            lblA0 = new Label();
            lblA3 = new Label();
            lblA2 = new Label();
            lblA1 = new Label();
            SuspendLayout();
            // 
            // btnA0
            // 
            btnA0.Location = new Point(32, 42);
            btnA0.Name = "btnA0";
            btnA0.Size = new Size(75, 23);
            btnA0.TabIndex = 0;
            btnA0.Text = "Toggle A0";
            btnA0.UseVisualStyleBackColor = true;
            btnA0.Click += btnA0_Click;
            // 
            // btnA1
            // 
            btnA1.Location = new Point(32, 71);
            btnA1.Name = "btnA1";
            btnA1.Size = new Size(75, 23);
            btnA1.TabIndex = 1;
            btnA1.Text = "Toggle A1";
            btnA1.UseVisualStyleBackColor = true;
            btnA1.Click += btnA1_Click;
            // 
            // btnA2
            // 
            btnA2.Location = new Point(32, 100);
            btnA2.Name = "btnA2";
            btnA2.Size = new Size(75, 23);
            btnA2.TabIndex = 2;
            btnA2.Text = "Toggle A2";
            btnA2.UseVisualStyleBackColor = true;
            btnA2.Click += btnA2_Click;
            // 
            // btnA3
            // 
            btnA3.Location = new Point(32, 129);
            btnA3.Name = "btnA3";
            btnA3.Size = new Size(75, 23);
            btnA3.TabIndex = 3;
            btnA3.Text = "Toggle A3";
            btnA3.UseVisualStyleBackColor = true;
            btnA3.Click += btnA3_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(86, 180);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 4;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblA0
            // 
            lblA0.AutoSize = true;
            lblA0.Location = new Point(159, 46);
            lblA0.Name = "lblA0";
            lblA0.Size = new Size(48, 15);
            lblA0.TabIndex = 5;
            lblA0.Text = "A0: OFF";
            // 
            // lblA3
            // 
            lblA3.AutoSize = true;
            lblA3.Location = new Point(159, 133);
            lblA3.Name = "lblA3";
            lblA3.Size = new Size(48, 15);
            lblA3.TabIndex = 6;
            lblA3.Text = "A3: OFF";
            // 
            // lblA2
            // 
            lblA2.AutoSize = true;
            lblA2.Location = new Point(159, 104);
            lblA2.Name = "lblA2";
            lblA2.Size = new Size(48, 15);
            lblA2.TabIndex = 7;
            lblA2.Text = "A2: OFF";
            // 
            // lblA1
            // 
            lblA1.AutoSize = true;
            lblA1.Location = new Point(159, 75);
            lblA1.Name = "lblA1";
            lblA1.Size = new Size(48, 15);
            lblA1.TabIndex = 8;
            lblA1.Text = "A1: OFF";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 254);
            Controls.Add(lblA1);
            Controls.Add(lblA2);
            Controls.Add(lblA3);
            Controls.Add(lblA0);
            Controls.Add(btnExit);
            Controls.Add(btnA3);
            Controls.Add(btnA2);
            Controls.Add(btnA1);
            Controls.Add(btnA0);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnA0;
        private Button btnA1;
        private Button btnA2;
        private Button btnA3;
        private Button btnExit;
        private Label lblA0;
        private Label lblA3;
        private Label lblA2;
        private Label lblA1;
    }
}
