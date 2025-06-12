
namespace Arena_SF_AM_Checker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lastSacrificeDate = new Label();
            label4 = new Label();
            sinceLastLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 58);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(274, 579);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(279, 58);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 1;
            button1.Text = "SACRIFICE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(279, 266);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 2;
            button2.Text = "Other Tools";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(337, 607);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 3;
            label1.Text = "@Frabather";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(79, 9);
            label2.Name = "label2";
            label2.Size = new Size(291, 30);
            label2.TabIndex = 4;
            label2.Text = "Arena Manager Upgrade List";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(309, 118);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 5;
            label3.Text = "Last Sacrifice:";
            // 
            // lastSacrificeDate
            // 
            lastSacrificeDate.AutoSize = true;
            lastSacrificeDate.Location = new Point(309, 148);
            lastSacrificeDate.Name = "lastSacrificeDate";
            lastSacrificeDate.Size = new Size(91, 15);
            lastSacrificeDate.TabIndex = 6;
            lastSacrificeDate.Text = "Never sacrificed";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Location = new Point(309, 181);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 7;
            label4.Text = "Since last sacrifice:";
            // 
            // sinceLastLabel
            // 
            sinceLastLabel.AutoSize = true;
            sinceLastLabel.Location = new Point(309, 216);
            sinceLastLabel.Name = "sinceLastLabel";
            sinceLastLabel.Size = new Size(91, 15);
            sinceLastLabel.TabIndex = 8;
            sinceLastLabel.Text = "Never sacrificed";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 637);
            Controls.Add(sinceLastLabel);
            Controls.Add(label4);
            Controls.Add(lastSacrificeDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Shakes&Fidget Checking Tools";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lastSacrificeDate;
        private Label label4;
        private Label sinceLastLabel;
    }
}
