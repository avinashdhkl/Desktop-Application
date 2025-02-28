using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCommon.Model.Dashoard;

namespace WinFormsBusiness.Services.Dashoard
{
    public interface IDashboardServices
    {
        Task<CustomerModel> FetchCustomer();
        Task<CustomerLocationModel>FetchCustomerLocation(int customerId);
    }
}
