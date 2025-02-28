using Microsoft.IdentityModel.Tokens;
using System.Timers;
using WinFormsBusiness.Services.Customer;
using WinFormsBusiness.Services.Dashoard;
using WinFormsBusiness.Services.Location;
using WinFormsCommon.Model.Customer;

namespace WinFormsCustom
{
    public partial class Customer : Form
    {
        private readonly ICustomerServices _customerServices;
        private readonly ILocationService _locationService;
        private readonly IDashboardServices _dashboardServices;
        
        public Customer(ICustomerServices customerServices, ILocationService locationService, IDashboardServices dashboardServices)
        {
            InitializeComponent();

            _customerServices = customerServices;
            _locationService = locationService;
            _dashboardServices = dashboardServices;
           
        }

        private async void btnSubmitCustomer_Click(object sender, EventArgs e)
        {
            var customerparam = new CustomerParam
            {
                FullName = FullName.Text,
                Email = Email.Text,
                PhoneNo = PhoneNo.Text,
            };
            var resp = await _customerServices.InsertCustomer(customerparam);
            MessageBox.Show(resp.Message);
            var fetchallcustomerdetails = await _customerServices.FetchAllCustomerDetails();
            CustomerDataGridList.DataSource = fetchallcustomerdetails.CustomerList;
            Clear();
        }

        private async void Customer_Load(object sender, EventArgs e)
        {
            var fetchallcustomerdetails = await _customerServices.FetchAllCustomerDetails();
            CustomerDataGridList.DataSource = fetchallcustomerdetails.CustomerList;
        }

        private async void CustomerDataGridList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int custerId = string.IsNullOrEmpty(CustomerDataGridList.Rows[row].Cells[0].Value.ToString()) ? 0 : Convert.ToInt32(CustomerDataGridList.Rows[row].Cells[0].Value);
            if (custerId <= 0)
            {
                MessageBox.Show("Cannot Find Customer Details");
                return;
            }
            var getCustomerDetails = await _customerServices.FetchCustomerDetailsById(custerId);
            FullName.Text = getCustomerDetails.CustomerDetails.FullName;
            Email.Text = getCustomerDetails.CustomerDetails.Email;
            PhoneNo.Text = getCustomerDetails.CustomerDetails.PhoneNo;
            CustomerId.Text = getCustomerDetails.CustomerDetails.CustomerId.ToString();
        }

        private async void Updatebutton_Customer_Click(object sender, EventArgs e)
        {
            var customerparam = new CustomerParam
            {
                FullName = FullName.Text,
                Email = Email.Text,
                PhoneNo = PhoneNo.Text,
                CustomerId = Convert.ToInt32(CustomerId.Text),
            };
            var resp = await _customerServices.UpdateCustomer(customerparam);
            MessageBox.Show(resp.Message);
            var fetchallcustomerdetails = await _customerServices.FetchAllCustomerDetails();
            CustomerDataGridList.DataSource = fetchallcustomerdetails.CustomerList;
            Clear();
        }

        private async void Deletebutton_Customer_Click(object sender, EventArgs e)
        {
            var resp = await _customerServices.DeleteCustomer(Convert.ToInt32(CustomerId.Text));
            MessageBox.Show(resp.Message);
            var fetchallcustomerdetails = await _customerServices.FetchAllCustomerDetails();
            CustomerDataGridList.DataSource = fetchallcustomerdetails.CustomerList;
            Clear();
        }
        private async void Clear()
        {
            FullName.Text = "";
            Email.Text = "";
            PhoneNo.Text = "";
            CustomerId.Text = "";
        }

        private void AddLocationBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Location location = new Location(this._customerServices, this._locationService, _dashboardServices);
            location.Show();
        }

        

        private void linkDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashoard dashoard = new Dashoard(_dashboardServices,_customerServices, _locationService);
            dashoard.Show();
        }
    }
}
