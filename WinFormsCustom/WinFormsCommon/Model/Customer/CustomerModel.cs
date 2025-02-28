using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCommon.Model.Common;

namespace WinFormsCommon.Model.Customer
{
    public class CustomerModel: CommonModel
    {
        public List<CustomerParam>? CustomerList { get; set; }
        public CustomerParam? CustomerDetails { get; set; }
    }
    public class CustomerParam
    {
       
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdateDate { get; set; }
        public int RowId { get; set; }
    }
}
