using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCommon.Model.Common;

namespace WinFormsCommon.Model.Dashoard
{
    public class CustomerModel : CommonModel
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
    public class CustomerLocationModel : CommonModel
    {
        public List<CustomerLocation>? CustomerLocationList { get; set; }
    }
    
    public class CustomerLocation
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
    
}
