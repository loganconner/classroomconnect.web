using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassroomConnect.Core.Models;
using ClassroomConnect.Web.Models.ViewModels;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class EnrollmentRecordVM
    {
        public ChildVM Child { get; set; } = new ChildVM();
        //public ClassroomVM Classroom { get; set; }
        public GuardianVM PrimaryGuardian { get; set; } = new GuardianVM();
        public GuardianVM SecondaryGuardian { get; set; } = new GuardianVM();
        public List<ContactVM> ContactList { get; set; } = new List<ContactVM>();

        public EnrollmentRecordVM()
        {
            Child = new ChildVM();
            PrimaryGuardian = new GuardianVM();
            SecondaryGuardian = new GuardianVM();
            //Classroom = new ClassroomVM();
            ContactList = new List<ContactVM>();
        }

    }

}
