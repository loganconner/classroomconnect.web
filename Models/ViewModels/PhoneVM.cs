using ClassroomConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class PhoneVM
    {
        public Guid PhoneId { get; set; }
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Type")]
        public PhoneType PhoneType { get; set; }
    }

    public enum PhoneType
    {
        Mobile = 1,
        Home = 2,
        Work = 3
    }
}
