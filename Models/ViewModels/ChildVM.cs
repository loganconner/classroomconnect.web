using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class ChildVM
    {
        private string _fullName = null;

        [Key]
        public Guid ChildId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName))
                    return string.IsNullOrEmpty(this.MiddleName) ? this.FirstName + " " + this.LastName : this.FirstName + " " + this.MiddleName + " " + this.LastName;
                else
                    return this._fullName?.Trim();
            }
            set
            {
                _fullName = value;
            }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DOB { get; set; }
        public Guid FamilyId { get; set; }
        public Guid ClassroomId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int IsDeleted { get; set; }

        public string ImageUrl { get; set; }

        public IList<AllergyVM> Allergies { get; set; }

    }
}
