namespace WinFormsCustom
{
    partial class Dashoard
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
            dataGridCustomerLocation = new DataGridView();
            Customer = new ComboBox();
            label1 = new Label();
            btnAddCustomer = new LinkLabel();
            btnAddLocation = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridCustomerLocation).BeginInit();
            SuspendLayout();
            // 
            // dataGridCustomerLocation
            // 
            dataGridCustomerLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCustomerLocation.Location = new Point(196, 189);
            dataGridCustomerLocation.Name = "dataGridCustomerLocation";
            dataGridCustomerLocation.Size = new Size(425, 197);
            dataGridCustomerLocation.TabIndex = 0;
            // 
            // Customer
            // 
            Customer.FormattingEnabled = true;
            Customer.Location = new Point(301, 127);
            Customer.Name = "Customer";
            Customer.Size = new Size(214, 23);
            Customer.TabIndex = 1;
            Customer.SelectionChangeCommitted += Customer_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(196, 135);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Customers";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.AutoSize = true;
            btnAddCustomer.BackColor = SystemColors.AppWorkspace;
            btnAddCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCustomer.LinkColor = Color.Red;
            btnAddCustomer.Location = new Point(532, 39);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(83, 15);
            btnAddCustomer.TabIndex = 3;
            btnAddCustomer.TabStop = true;
            btnAddCustomer.Text = "AddCustomer";
            btnAddCustomer.LinkClicked += btnAddCustomer_LinkClicked;
            // 
            // btnAddLocation
            // 
            btnAddLocation.AutoSize = true;
            btnAddLocation.BackColor = SystemColors.ButtonShadow;
            btnAddLocation.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddLocation.LinkColor = Color.Lime;
            btnAddLocation.Location = new Point(646, 39);
            btnAddLocation.Name = "btnAddLocation";
            btnAddLocation.Size = new Size(86, 17);
            btnAddLocation.TabIndex = 3;
            btnAddLocation.TabStop = true;
            btnAddLocation.Text = "AddLocation";
            btnAddLocation.LinkClicked += btnAddLocation_LinkClicked;
            // 
            // Dashoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddLocation);
            Controls.Add(btnAddCustomer);
            Controls.Add(label1);
            Controls.Add(Customer);
            Controls.Add(dataGridCustomerLocation);
            Name = "Dashoard";
            Text = "Dashoard";
            ((System.ComponentModel.ISupportInitialize)dataGridCustomerLocation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridCustomerLocation;
        private ComboBox Customer;
        private Label label1;
        private LinkLabel btnAddCustomer;
        private LinkLabel btnAddLocation;
    }
}