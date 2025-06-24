namespace Arena_SF_AM_Checker
{
    partial class AppConfigurationForm
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
            label1 = new Label();
            twichDropNotificationToggle = new CheckBox();
            button1 = new Button();
            label2 = new Label();
            undergroundResetBtn = new Button();
            BtnToBeLine = new Button();
            BtnToBeLine2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 0;
            label1.Text = "Twitch Drop Notification";
            // 
            // twichDropNotificationToggle
            // 
            twichDropNotificationToggle.AutoSize = true;
            twichDropNotificationToggle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            twichDropNotificationToggle.Location = new Point(249, 12);
            twichDropNotificationToggle.Name = "twichDropNotificationToggle";
            twichDropNotificationToggle.Size = new Size(15, 14);
            twichDropNotificationToggle.TabIndex = 1;
            twichDropNotificationToggle.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(326, 10);
            button1.Name = "button1";
            button1.Size = new Size(51, 40);
            button1.TabIndex = 2;
            button1.Text = "RESET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(202, 25);
            label2.TabIndex = 3;
            label2.Text = "Reset All Underground";
            // 
            // undergroundResetBtn
            // 
            undergroundResetBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            undergroundResetBtn.ForeColor = Color.Red;
            undergroundResetBtn.Location = new Point(326, 74);
            undergroundResetBtn.Name = "undergroundResetBtn";
            undergroundResetBtn.Size = new Size(51, 40);
            undergroundResetBtn.TabIndex = 4;
            undergroundResetBtn.Text = "RESET";
            undergroundResetBtn.UseVisualStyleBackColor = true;
            undergroundResetBtn.Click += undergroundResetBtn_Click;
            // 
            // BtnToBeLine
            // 
            BtnToBeLine.Location = new Point(2, 58);
            BtnToBeLine.Name = "BtnToBeLine";
            BtnToBeLine.Size = new Size(385, 10);
            BtnToBeLine.TabIndex = 5;
            BtnToBeLine.UseVisualStyleBackColor = true;
            // 
            // BtnToBeLine2
            // 
            BtnToBeLine2.Location = new Point(2, 120);
            BtnToBeLine2.Name = "BtnToBeLine2";
            BtnToBeLine2.Size = new Size(385, 10);
            BtnToBeLine2.TabIndex = 6;
            BtnToBeLine2.UseVisualStyleBackColor = true;
            // 
            // AppConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 500);
            Controls.Add(BtnToBeLine2);
            Controls.Add(BtnToBeLine);
            Controls.Add(undergroundResetBtn);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(twichDropNotificationToggle);
            Controls.Add(label1);
            Name = "AppConfigurationForm";
            Text = "App Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox twichDropNotificationToggle;
        private Button button1;
        private Label label2;
        private Button undergroundResetBtn;
        private Button BtnToBeLine;
        private Button BtnToBeLine2;
    }
}