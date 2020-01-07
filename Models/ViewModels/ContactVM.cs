using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class ContactVM
    {
        private string _contactName = null;

        public Guid ContactId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Contact")]
        public string ContactName
        {
            get
            {
                if (string.IsNullOrEmpty(_contactName) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName))
                    return this.FirstName + " " + this.LastName;
                else
                    return this._contactName?.Trim();
            }
            set
            {
                _contactName = value;
            }
        }
        [Display(Name = "Approved For Pickup")]
        public bool ApprovedPickup { get; set; }
        public ContactType ContactType { get; set; }
        [Display(Name = "Approved By Guardians")]
        public bool ApprovedByGuardians { get; set; }
        public Guid FamilyId { get; set; }
        public Guid? AddressId { get; set; }
        public AddressVM Address { get; set; }
        public Guid? PhoneId { get; set; }
        public PhoneVM Phone { get; set; }

        public ContactVM()
        {
            Address = new AddressVM();
            Phone = new PhoneVM();
        }
    }

    public enum ContactType
    {
        Emergency = 1,
        ApprovedRelease = 2
    }
}
