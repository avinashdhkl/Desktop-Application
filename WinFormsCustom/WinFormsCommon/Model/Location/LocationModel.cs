using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCommon.Model.Common;


namespace WinFormsBusiness.Model.Location
{
    public class LocationModel:CommonModel
    {
        public List<LocationParam>? LocationList { get; set; }
        public LocationParam? LocationDetail { get; set; }
        public List<ListTextModel>? CustomerList { get; set; }
    }
    public class LocationParam
    {
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public string? Address { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdateDate { get; set; }
    }
}
