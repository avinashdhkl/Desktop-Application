using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinFormsBusiness.Services.Customer;
using WinFormsBusiness.Services.Dashoard;
using WinFormsBusiness.Services.Location;

namespace WinFormsCustom
{
    public partial class Dashoard : Form
    {
        private readonly IDashboardServices _dashboardServices;
        private readonly ICustomerServices _customerServices;
        private readonly ILocationService _locationService;
        private System.Timers.Timer syncTimer;
        private int intervalTime = 5 * 60 * 1000; // 5 minutes
        private int delayTime = 5 * 60 * 1000; // 5 minutes
        public Dashoard(IDashboardServices dashboardServices, ICustomerServices customerServices, ILocationService locationService)
        {
            InitializeComponent();
            this._dashboardServices = dashboardServices;
            this._customerServices = customerServices;
            this._locationService = locationService;
            bindstaticdata();
            InitializeTimer();
        }
        public async void bindstaticdata(string customerID="0")
        {
            var customerList = await _dashboardServices.FetchCustomer();
            var items = new BindingList<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("0", "Please select Customer"));
            if (customerList.CustomerList != null)
            {
                foreach (var item in customerList.CustomerList)
                {
                    items.Add(new KeyValuePair<string, string>(item.CustomerId.ToString(), item.FullName.ToString()));
                };

            }
            Customer.DataSource = items;
            Customer.ValueMember = "key";
            Customer.DisplayMember = "value";
            Customer.SelectedValue = customerID;
        }
        private async void Customer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int CustomerId = Convert.ToInt32(Customer.SelectedValue);
            var customerLocation = await _dashboardServices.FetchCustomerLocation(CustomerId);
            bindstaticdata(Customer.SelectedValue.ToString());
            
            if (customerLocation.Code == "200")
            {
                dataGridCustomerLocation.DataSource = customerLocation.CustomerLocationList;
                return;
            }
            MessageBox.Show("Detail not found");
        }

        private void btnAddCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Customer customershow = new Customer(_customerServices, _locationService, _dashboardServices);
            customershow.Show();
        }

        private void btnAddLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Location location = new Location(this._customerServices, this._locationService, _dashboardServices);
            location.Show();
        }
        private async void InitializeTimer()
        {
            syncTimer = new System.Timers.Timer();
            syncTimer.Interval = intervalTime;
            syncTimer.Elapsed += InsertDataTimer_Elapsed;
            syncTimer.AutoReset = true; // Ensure it repeats
            syncTimer.Enabled = true; // Start the timer immediately
        }
        private async void InsertDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _customerServices.synch_InsertCustomer();
            //Task.Delay(delayTime).Wait();
            _locationService.synch_InsertLocation();
           
        }
    }
}
