using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Model;
using Services.Services.Customer;

namespace WebApplicationCustomer.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CuustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CuustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]      
        public async Task<object> FetchAllCustomer()
        {
            return await _customerServices.FetchAllCustomer();
        }

        [HttpGet("{customerId}/locations")]        
        public async Task<object> FetchCustomerLocation(int customerId)
        {
            var CustomerParam = new CustomerParam
            {
                CustomerId = customerId.ToString()
            };
            return await _customerServices.FetchCustomerLocation(CustomerParam);
        }
    }
}
