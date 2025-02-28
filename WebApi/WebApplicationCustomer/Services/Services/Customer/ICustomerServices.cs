using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Customer
{
    public interface ICustomerServices
    {
        Task<CustomerModel> FetchAllCustomer(string Flag= "GetAllCustomer"); 
        Task<CustomerLocationModel> FetchCustomerLocation(CustomerParam customerparam); 
    }
}
