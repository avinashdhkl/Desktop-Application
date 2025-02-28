using DataAccess.Generic;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Customer
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IGeneric _generic;
        private const string storeProducerName = "Customer.Proc_Customer";
        private const string successCode = "200";
        private const string errorCode = "101";

        public CustomerServices(IGeneric generic)
        {
            _generic = generic;
        }

        public async Task<CustomerModel> FetchAllCustomer(string Flag= "GetAllCustomer")
        {
            try
            {              
                var param = new
                {
                    Flag = Flag
                };               
                var resp = await _generic.ManageWithList<CustomerDetails>(storeProducerName, param);
                return new CustomerModel
                {
                    Code = successCode,
                    Message = "Success",
                    CustomerList = resp
                };
            }
            catch (Exception ex)
            {

                return new CustomerModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }

        public async Task<CustomerLocationModel> FetchCustomerLocation(CustomerParam customerparam)
        {
            try
            {
                customerparam.Flag = "CustomerLocation";
                var param = new
                {
                    Flag = customerparam.Flag,
                    CustomerId = customerparam.CustomerId,
                };
                var resp = await _generic.ManageWithList<CustomerLocation>(storeProducerName, param);
                if (resp.Count()>0)
                {
                    return new CustomerLocationModel
                    {
                        Code = successCode,
                        Message = "Success",
                        CustomerLocationList = resp
                    };
                }
                return new CustomerLocationModel
                {
                    Code = errorCode,
                    Message = "Details does not found"                    
                };
            }
            catch (Exception ex)
            {

                return new CustomerLocationModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
    }
}
