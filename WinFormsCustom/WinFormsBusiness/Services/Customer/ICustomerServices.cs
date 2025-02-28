using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCommon.Model.Common;
using WinFormsCommon.Model.Customer;


namespace WinFormsBusiness.Services.Customer
{
    public interface ICustomerServices
    {
        Task<CommonModel> InsertCustomer(CustomerParam customerparam);
        Task<CommonModel> UpdateCustomer(CustomerParam customerparam);
        Task<CustomerModel> FetchAllCustomerDetails();
        Task<CustomerModel> FetchCustomerDetailsById(int customerId);
        Task<CommonModel> DeleteCustomer(int customerId);
        void synch_InsertCustomer();

    }
}
