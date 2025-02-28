using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsBusiness.Model.Location;
using WinFormsBusiness.Services.Customer;
using WinFormsBusiness.Services.Dashoard;
using WinFormsBusiness.Services.Location;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsCustom
{
    public partial class Location : Form
    {
        private readonly ICustomerServices _customerServices;
        private readonly ILocationService _locationService;
        private readonly IDashboardServices _dashboardServices;
        public Location(ICustomerServices customerServices, ILocationService locationService, IDashboardServices dashboardServices)
        {
            InitializeComponent();
            this._customerServices = customerServices;
            this._locationService = locationService;
            this._dashboardServices = dashboardServices;
            bindstaticdata();

        }

        private void AddCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Customer customershow = new Customer(_customerServices, _locationService, _dashboardServices);
            customershow.Show();

        }
        public async void bindstaticdata()
        {
            var customerList = await _customerServices.FetchAllCustomerDetails();
            var items = new BindingList<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("0", "Please select Customer"));
            if (customerList.CustomerList != null)
            {
                foreach (var item in customerList.CustomerList)
                {
                    items.Add(new KeyValuePair<string, string>(item.CustomerId.ToString(), item.FullName.ToString()));
                };

            }
            CustomerId.DataSource = items;
            CustomerId.ValueMember = "key";
            CustomerId.DisplayMember = "value";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var locationparam = new LocationParam
            {
                Address = Address.Text,
                CustomerId = Convert.ToInt32(CustomerId.SelectedValue),

            };
            var resp = await _locationService.InsertLocation(locationparam);
            MessageBox.Show(resp.Message);
            var fetchallLocationdetails = await _locationService.FetchAllLocationDetails();
            LocationDataView.DataSource = fetchallLocationdetails.LocationList;
            Clear();


        }

        private async void Clear()
        {
            Address.Text = "";
            CustomerId.Text = "";
            LocationId.Text = "";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var locationparam = new LocationParam
            {
                Address = Address.Text,
                CustomerId = Convert.ToInt32(CustomerId.SelectedValue),
                LocationId = Convert.ToInt32(LocationId.Text),

            };
            var resp = await _locationService.UpdateLocation(locationparam);
            MessageBox.Show(resp.Message);
            var fetchallLocationdetails = await _locationService.FetchAllLocationDetails();
            LocationDataView.DataSource = fetchallLocationdetails.LocationList;
            Clear();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var resp = await _locationService.DeleteLocation(Convert.ToInt32(LocationId.Text));
            MessageBox.Show(resp.Message);
            var fetchallLocationdetails = await _locationService.FetchAllLocationDetails();
            LocationDataView.DataSource = fetchallLocationdetails.LocationList;
            Clear();
        }

        private async void LocationDataView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int locationId = string.IsNullOrEmpty(LocationDataView.Rows[row].Cells[0].Value.ToString()) ? 0 : Convert.ToInt32(LocationDataView.Rows[row].Cells[0].Value);
            if (locationId <= 0)
            {
                MessageBox.Show("Cannot Find Location Details");
                return;
            }
            var getLocationDetails = await _locationService.FetchLocationDetailsById(locationId);
            var customerList = await _customerServices.FetchAllCustomerDetails();
            Address.Text = getLocationDetails.LocationDetail.Address.ToString();
            LocationId.Text = getLocationDetails.LocationDetail.LocationId.ToString();
            CustomerId.SelectedValue = getLocationDetails.LocationDetail.CustomerId.ToString();
        }

        private async void Location_Load(object sender, EventArgs e)
        {
            var fetchallLocationdetails = await _locationService.FetchAllLocationDetails();
            LocationDataView.DataSource = fetchallLocationdetails.LocationList;
        }

        private void linkDashoard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashoard dashoard = new Dashoard(_dashboardServices, _customerServices, _locationService);
            dashoard.Show();
        }
    }
}
