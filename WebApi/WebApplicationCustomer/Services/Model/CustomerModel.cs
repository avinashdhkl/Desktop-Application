using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class CustomerModel: CommomModel
    {
        public List<CustomerDetails>? CustomerList { get; set; }
    }
    public class CustomerDetails
    {
        public string? CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
    public class CustomerLocationModel : CommomModel
    {
        public List<CustomerLocation>? CustomerLocationList { get; set; }
    }
    public class CustomerParam
    {
        public string? Flag { get; set; }
        public string? CustomerId { get; set; }
    }
    public class CustomerLocation
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
    public class CommomModel
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}
