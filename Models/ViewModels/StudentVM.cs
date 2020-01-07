using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class StudentVM
    {
        public Guid ChildId { get; set; }
        [Display(Name = "Student")]
        public string FullName { get; set; }
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DOB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EnrollmentDate { get; set; }
        public Guid ClassroomId { get; set; }
        [Display(Name = "Classroom")]
        public string Teacher { get; set; }
        public Guid PrimaryGuardianId { get; set; }
        [Display(Name = "Primary Guardian")]
        public string PrimaryGuardianName { get; set; }
        public Guid SecondaryGuardianId { get; set; }
        [Display(Name = "Secondary Guardian")]
        public string SecondaryGuardianName { get; set; }
        public Guid FamilyId { get; set; }
    }
}

