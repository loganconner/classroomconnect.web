using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class GuardianVM
    {
        private string _guardianName = null;

        public Guid GuardianId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Guardian")]
        public string GuardianName
        {
            get
            {
                if (string.IsNullOrEmpty(_guardianName) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName))
                    return this.FirstName + " " + this.LastName;
                else
                    return this._guardianName?.Trim();
            }
            set
            {
                _guardianName = value;
            }
        }
        [Display(Name = "DOB")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Primary Guardian")]
        public bool IsPrimaryGuardian { get; set; }
        public Guid FamilyId { get; set; }
        public Guid? HomeAddressId { get; set; }
        public AddressVM HomeAddress { get; set; }
        public Guid? MobilePhoneId { get; set; }
        public PhoneVM MobilePhone { get; set; }
        public Guid? WorkAddressId { get; set; }
        public AddressVM WorkAddress { get; set; }
        public Guid? WorkPhoneId { get; set; }
        public PhoneVM WorkPhone { get; set; }

        public GuardianVM()
        {
            HomeAddress = new AddressVM();
            WorkAddress = new AddressVM();
            MobilePhone = new PhoneVM();
            WorkPhone = new PhoneVM();
        }
    }
}
