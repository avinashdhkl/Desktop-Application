namespace WinFormsCustom
{
    partial class Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            FullName = new TextBox();
            emailLabel = new Label();
            Email = new TextBox();
            label2 = new Label();
            PhoneNo = new TextBox();
            btnSubmitCustomer = new Button();
            CustomerDataGridList = new DataGridView();
            label3 = new Label();
            CustomerId = new TextBox();
            label4 = new Label();
            Updatebutton_Customer = new Button();
            button1 = new Button();
            AddLocationBtn = new LinkLabel();
            linkDashboard = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridList).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(830, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 197);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 1;
            label1.Text = "Full Name";
            // 
            // FullName
            // 
            FullName.Location = new Point(92, 199);
            FullName.Name = "FullName";
            FullName.PlaceholderText = "Full Name";
            FullName.Size = new Size(205, 23);
            FullName.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(12, 226);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(48, 21);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email";
            // 
            // Email
            // 
            Email.Location = new Point(91, 228);
            Email.Name = "Email";
            Email.PlaceholderText = "Email";
            Email.Size = new Size(205, 23);
            Email.TabIndex = 2;
            Email.Text = "\r\n\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 257);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 1;
            label2.Text = "Phone No";
            // 
            // PhoneNo
            // 
            PhoneNo.Location = new Point(91, 257);
            PhoneNo.Name = "PhoneNo";
            PhoneNo.PlaceholderText = "Phone No";
            PhoneNo.Size = new Size(206, 23);
            PhoneNo.TabIndex = 2;
            // 
            // btnSubmitCustomer
            // 
            btnSubmitCustomer.BackColor = SystemColors.HotTrack;
            btnSubmitCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmitCustomer.ForeColor = SystemColors.ButtonHighlight;
            btnSubmitCustomer.Location = new Point(2, 302);
            btnSubmitCustomer.Name = "btnSubmitCustomer";
            btnSubmitCustomer.Size = new Size(111, 41);
            btnSubmitCustomer.TabIndex = 3;
            btnSubmitCustomer.Text = "Submit";
            btnSubmitCustomer.UseVisualStyleBackColor = false;
            btnSubmitCustomer.Click += btnSubmitCustomer_Click;
            // 
            // CustomerDataGridList
            // 
            CustomerDataGridList.BackgroundColor = SystemColors.ControlLight;
            CustomerDataGridList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataGridList.Location = new Point(358, 125);
            CustomerDataGridList.Name = "CustomerDataGridList";
            CustomerDataGridList.Size = new Size(484, 311);
            CustomerDataGridList.TabIndex = 4;
            CustomerDataGridList.RowHeaderMouseClick += CustomerDataGridList_RowHeaderMouseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(76, 117);
            label3.Name = "label3";
            label3.Size = new Size(123, 30);
            label3.TabIndex = 8;
            label3.Text = "Registration";
            // 
            // CustomerId
            // 
            CustomerId.Location = new Point(92, 170);
            CustomerId.Name = "CustomerId";
            CustomerId.ReadOnly = true;
            CustomerId.Size = new Size(205, 23);
            CustomerId.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(2, 170);
            label4.Name = "label4";
            label4.Size = new Size(95, 21);
            label4.TabIndex = 1;
            label4.Text = "Customer Id";
            // 
            // Updatebutton_Customer
            // 
            Updatebutton_Customer.BackColor = Color.FromArgb(128, 128, 255);
            Updatebutton_Customer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Updatebutton_Customer.ForeColor = SystemColors.ButtonHighlight;
            Updatebutton_Customer.Location = new Point(131, 302);
            Updatebutton_Customer.Name = "Updatebutton_Customer";
            Updatebutton_Customer.Size = new Size(111, 41);
            Updatebutton_Customer.TabIndex = 3;
            Updatebutton_Customer.Text = "Update";
            Updatebutton_Customer.UseVisualStyleBackColor = false;
            Updatebutton_Customer.Click += Updatebutton_Customer_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(248, 302);
            button1.Name = "button1";
            button1.Size = new Size(111, 41);
            button1.TabIndex = 3;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Deletebutton_Customer_Click;
            // 
            // AddLocationBtn
            // 
            AddLocationBtn.ActiveLinkColor = Color.Blue;
            AddLocationBtn.AutoSize = true;
            AddLocationBtn.BackColor = Color.Lime;
            AddLocationBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddLocationBtn.ForeColor = Color.DarkSlateGray;
            AddLocationBtn.Location = new Point(731, 98);
            AddLocationBtn.Name = "AddLocationBtn";
            AddLocationBtn.Size = new Size(111, 21);
            AddLocationBtn.TabIndex = 10;
            AddLocationBtn.TabStop = true;
            AddLocationBtn.Text = "Add Location";
            AddLocationBtn.LinkClicked += AddLocationBtn_LinkClicked;
            // 
            // linkDashboard
            // 
            linkDashboard.AutoSize = true;
            linkDashboard.BackColor = Color.Gray;
            linkDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkDashboard.ForeColor = Color.Black;
            linkDashboard.LinkColor = Color.FromArgb(255, 128, 128);
            linkDashboard.Location = new Point(558, 100);
            linkDashboard.Name = "linkDashboard";
            linkDashboard.Size = new Size(75, 17);
            linkDashboard.TabIndex = 11;
            linkDashboard.TabStop = true;
            linkDashboard.Text = "Dashboard";
            linkDashboard.LinkClicked += linkDashboard_LinkClicked;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 450);
            Controls.Add(linkDashboard);
            Controls.Add(AddLocationBtn);
            Controls.Add(label3);
            Controls.Add(CustomerDataGridList);
            Controls.Add(button1);
            Controls.Add(Updatebutton_Customer);
            Controls.Add(btnSubmitCustomer);
            Controls.Add(PhoneNo);
            Controls.Add(Email);
            Controls.Add(CustomerId);
            Controls.Add(FullName);
            Controls.Add(label2);
            Controls.Add(emailLabel);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Customer";
            Text = "Customer";
            Load += Customer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox FullName;
        private Label emailLabel;
        private TextBox Email;
        private Label label2;
        private TextBox PhoneNo;
        private Button btnSubmitCustomer;
        private DataGridView CustomerDataGridList;
        private Label label3;
        private TextBox CustomerId;
        private Label label4;
        private Button Updatebutton_Customer;
        private Button button1;
        private LinkLabel AddLocationBtn;
        private LinkLabel linkDashboard;
    }
}
