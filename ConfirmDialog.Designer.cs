namespace Arena_SF_AM_Checker
{
    partial class ConfirmDialog
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
            lblMessage = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(12, 18);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(24, 28);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "#";
            // 
            // buttonYes
            // 
            buttonYes.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonYes.ForeColor = Color.Red;
            buttonYes.Location = new Point(12, 72);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(158, 53);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "YES";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += btnYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonNo.Location = new Point(348, 72);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(158, 53);
            buttonNo.TabIndex = 2;
            buttonNo.Text = "NO";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += btnNo_Click;
            // 
            // ConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 150);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(lblMessage);
            Name = "ConfirmDialog";
            Text = "ConfirmDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private Button buttonYes;
        private Button buttonNo;
    }
}