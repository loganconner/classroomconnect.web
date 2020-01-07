using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class AddressVM
    {
        public Guid AddressId { get; set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int PostalCode { get; set; }
        [Display(Name = "Type")]
        public AddressType AddressType { get; set; }
    }

    public enum AddressType
    {
        Home = 1,
        Work = 2,
        Alternate = 3
    }
}
