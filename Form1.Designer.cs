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
            btnGetVoltage = new Button();
            btnGetBits = new Button();
            btnSetBits = new Button();
            btnGetIOID = new Button();
            btnExit = new Button();
            lblA0 = new Label();
            lblA3 = new Label();
            lblA2 = new Label();
            lblA1 = new Label();
            txtOutput = new TextBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnGetVoltage
            // 
            btnGetVoltage.Location = new Point(32, 42);
            btnGetVoltage.Name = "btnGetVoltage";
            btnGetVoltage.Size = new Size(75, 23);
            btnGetVoltage.TabIndex = 0;
            btnGetVoltage.Text = "Get Voltage";
            btnGetVoltage.UseVisualStyleBackColor = true;
            btnGetVoltage.Click += btnGetVoltage_Click;
            // 
            // btnGetBits
            // 
            btnGetBits.Location = new Point(32, 71);
            btnGetBits.Name = "btnGetBits";
            btnGetBits.Size = new Size(75, 23);
            btnGetBits.TabIndex = 1;
            btnGetBits.Text = "Get Bits";
            btnGetBits.UseVisualStyleBackColor = true;
            btnGetBits.Click += btnGetBits_Click;
            // 
            // btnSetBits
            // 
            btnSetBits.Location = new Point(32, 100);
            btnSetBits.Name = "btnSetBits";
            btnSetBits.Size = new Size(75, 23);
            btnSetBits.TabIndex = 2;
            btnSetBits.Text = "Set Bits";
            btnSetBits.UseVisualStyleBackColor = true;
            btnSetBits.Click += btnSetBits_Click;
            // 
            // btnGetIOID
            // 
            btnGetIOID.Location = new Point(32, 129);
            btnGetIOID.Name = "btnGetIOID";
            btnGetIOID.Size = new Size(75, 23);
            btnGetIOID.TabIndex = 3;
            btnGetIOID.Text = "Get IO ID";
            btnGetIOID.UseVisualStyleBackColor = true;
            btnGetIOID.Click += btnGetIOID_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(145, 277);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 4;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblA0
            // 
            lblA0.AutoSize = true;
            lblA0.Location = new Point(113, 46);
            lblA0.Name = "lblA0";
            lblA0.Size = new Size(48, 15);
            lblA0.TabIndex = 5;
            lblA0.Text = "A0: OFF";
            // 
            // lblA3
            // 
            lblA3.AutoSize = true;
            lblA3.Location = new Point(113, 133);
            lblA3.Name = "lblA3";
            lblA3.Size = new Size(48, 15);
            lblA3.TabIndex = 6;
            lblA3.Text = "A3: OFF";
            // 
            // lblA2
            // 
            lblA2.AutoSize = true;
            lblA2.Location = new Point(113, 104);
            lblA2.Name = "lblA2";
            lblA2.Size = new Size(48, 15);
            lblA2.TabIndex = 7;
            lblA2.Text = "A2: OFF";
            // 
            // lblA1
            // 
            lblA1.AutoSize = true;
            lblA1.Location = new Point(113, 75);
            lblA1.Name = "lblA1";
            lblA1.Size = new Size(48, 15);
            lblA1.TabIndex = 8;
            lblA1.Text = "A1: OFF";
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(30, 173);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(188, 23);
            txtOutput.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 281);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(77, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status: Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 312);
            Controls.Add(lblStatus);
            Controls.Add(txtOutput);
            Controls.Add(lblA1);
            Controls.Add(lblA2);
            Controls.Add(lblA3);
            Controls.Add(lblA0);
            Controls.Add(btnExit);
            Controls.Add(btnGetIOID);
            Controls.Add(btnSetBits);
            Controls.Add(btnGetBits);
            Controls.Add(btnGetVoltage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetVoltage;
        private Button btnGetBits;
        private Button btnSetBits;
        private Button btnGetIOID;
        private Button btnExit;
        private Label lblA0;
        private Label lblA3;
        private Label lblA2;
        private Label lblA1;
        private TextBox txtOutput;
        private Label lblStatus;
    }
}
