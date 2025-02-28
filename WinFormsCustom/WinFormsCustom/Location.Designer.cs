namespace WinFormsCustom
{
    partial class Location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Location));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            Address = new TextBox();
            label2 = new Label();
            CustomerId = new ComboBox();
            btnSubmit = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label3 = new Label();
            LocationId = new TextBox();
            LocationDataView = new DataGridView();
            AddCustomer = new LinkLabel();
            linkDashoard = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LocationDataView).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(258, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(247, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 67);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Location Name";
            // 
            // Address
            // 
            Address.Location = new Point(370, 63);
            Address.Name = "Address";
            Address.PlaceholderText = "Location Name";
            Address.Size = new Size(120, 23);
            Address.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(503, 67);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Customer";
            // 
            // CustomerId
            // 
            CustomerId.FormattingEnabled = true;
            CustomerId.Location = new Point(566, 63);
            CustomerId.Name = "CustomerId";
            CustomerId.Size = new Size(155, 23);
            CustomerId.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.ButtonHighlight;
            btnSubmit.Location = new Point(243, 120);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 33);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 128, 255);
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = SystemColors.ButtonHighlight;
            btnUpdate.Location = new Point(360, 120);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 33);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(487, 120);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 33);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 67);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 1;
            label3.Text = "Location Id";
            // 
            // LocationId
            // 
            LocationId.Location = new Point(126, 63);
            LocationId.Name = "LocationId";
            LocationId.PlaceholderText = "Location Id";
            LocationId.ReadOnly = true;
            LocationId.Size = new Size(120, 23);
            LocationId.TabIndex = 2;
            // 
            // LocationDataView
            // 
            LocationDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocationDataView.Location = new Point(127, 180);
            LocationDataView.Name = "LocationDataView";
            LocationDataView.Size = new Size(543, 238);
            LocationDataView.TabIndex = 5;
            LocationDataView.RowHeaderMouseClick += LocationDataView_RowHeaderMouseClick;
            // 
            // AddCustomer
            // 
            AddCustomer.AutoSize = true;
            AddCustomer.BackColor = Color.Lime;
            AddCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddCustomer.ForeColor = Color.Black;
            AddCustomer.Location = new Point(566, 29);
            AddCustomer.Name = "AddCustomer";
            AddCustomer.Size = new Size(86, 15);
            AddCustomer.TabIndex = 6;
            AddCustomer.TabStop = true;
            AddCustomer.Text = "Add Customer";
            AddCustomer.LinkClicked += AddCustomer_LinkClicked;
            // 
            // linkDashoard
            // 
            linkDashoard.AutoSize = true;
            linkDashoard.Location = new Point(683, 29);
            linkDashoard.Name = "linkDashoard";
            linkDashoard.Size = new Size(64, 15);
            linkDashoard.TabIndex = 7;
            linkDashoard.TabStop = true;
            linkDashoard.Text = "Dashboard";
            linkDashoard.LinkClicked += linkDashoard_LinkClicked;
            // 
            // Location
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkDashoard);
            Controls.Add(AddCustomer);
            Controls.Add(LocationDataView);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSubmit);
            Controls.Add(CustomerId);
            Controls.Add(label2);
            Controls.Add(LocationId);
            Controls.Add(label3);
            Controls.Add(Address);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Location";
            Text = "Location";
            Load += Location_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LocationDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox Address;
        private Label label2;
        private ComboBox CustomerId;
        private Button btnSubmit;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label3;
        private TextBox LocationId;
        private DataGridView LocationDataView;
        private LinkLabel AddCustomer;
        private LinkLabel linkDashoard;
    }
}