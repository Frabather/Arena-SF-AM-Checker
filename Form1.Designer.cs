
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
            buttonSettings = new Button();
            dataGridViewTwitchDrops = new DataGridView();
            lblTwitchDrops = new Label();
            buttonTwitchTV = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTwitchDrops).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 97);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(391, 965);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(399, 97);
            button1.Name = "button1";
            button1.Size = new Size(214, 77);
            button1.TabIndex = 1;
            button1.Text = "SACRIFICE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(399, 443);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(214, 77);
            button2.TabIndex = 2;
            button2.Text = "Other Tools";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(733, 1012);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 3;
            label1.Text = "@Frabather";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(113, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(427, 45);
            label2.TabIndex = 4;
            label2.Text = "Arena Manager Upgrade List";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(441, 197);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 5;
            label3.Text = "Last Sacrifice:";
            // 
            // lastSacrificeDate
            // 
            lastSacrificeDate.AutoSize = true;
            lastSacrificeDate.Location = new Point(441, 247);
            lastSacrificeDate.Margin = new Padding(4, 0, 4, 0);
            lastSacrificeDate.Name = "lastSacrificeDate";
            lastSacrificeDate.Size = new Size(136, 25);
            lastSacrificeDate.TabIndex = 6;
            lastSacrificeDate.Text = "Never sacrificed";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Location = new Point(441, 302);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(156, 25);
            label4.TabIndex = 7;
            label4.Text = "Since last sacrifice:";
            // 
            // sinceLastLabel
            // 
            sinceLastLabel.AutoSize = true;
            sinceLastLabel.Location = new Point(441, 360);
            sinceLastLabel.Margin = new Padding(4, 0, 4, 0);
            sinceLastLabel.Name = "sinceLastLabel";
            sinceLastLabel.Size = new Size(136, 25);
            sinceLastLabel.TabIndex = 8;
            sinceLastLabel.Text = "Never sacrificed";
            // 
            // buttonSettings
            // 
            buttonSettings.Location = new Point(800, 924);
            buttonSettings.Margin = new Padding(4, 5, 4, 5);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(71, 83);
            buttonSettings.TabIndex = 9;
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // dataGridViewTwitchDrops
            // 
            dataGridViewTwitchDrops.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTwitchDrops.Location = new Point(400, 600);
            dataGridViewTwitchDrops.Margin = new Padding(4, 5, 4, 5);
            dataGridViewTwitchDrops.Name = "dataGridViewTwitchDrops";
            dataGridViewTwitchDrops.RowHeadersWidth = 62;
            dataGridViewTwitchDrops.Size = new Size(357, 167);
            dataGridViewTwitchDrops.TabIndex = 10;
            // 
            // lblTwitchDrops
            // 
            lblTwitchDrops.AutoSize = true;
            lblTwitchDrops.Font = new Font("Segoe UI", 15F);
            lblTwitchDrops.Location = new Point(459, 548);
            lblTwitchDrops.Margin = new Padding(4, 0, 4, 0);
            lblTwitchDrops.Name = "lblTwitchDrops";
            lblTwitchDrops.Size = new Size(190, 41);
            lblTwitchDrops.TabIndex = 11;
            lblTwitchDrops.Text = "Twitch Drops";
            // 
            // buttonTwitchTV
            // 
            buttonTwitchTV.Location = new Point(766, 600);
            buttonTwitchTV.Margin = new Padding(4, 5, 4, 5);
            buttonTwitchTV.Name = "buttonTwitchTV";
            buttonTwitchTV.Size = new Size(99, 167);
            buttonTwitchTV.TabIndex = 12;
            buttonTwitchTV.Text = "Run all Twitch streams";
            buttonTwitchTV.UseVisualStyleBackColor = true;
            buttonTwitchTV.Click += buttonTwitchTV_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 1062);
            Controls.Add(buttonTwitchTV);
            Controls.Add(lblTwitchDrops);
            Controls.Add(dataGridViewTwitchDrops);
            Controls.Add(buttonSettings);
            Controls.Add(sinceLastLabel);
            Controls.Add(label4);
            Controls.Add(lastSacrificeDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Shakes&Fidget Checking Tools";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTwitchDrops).EndInit();
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
        private Button buttonSettings;
        private DataGridView dataGridViewTwitchDrops;
        private Label lblTwitchDrops;
        private Button buttonTwitchTV;
    }
}
