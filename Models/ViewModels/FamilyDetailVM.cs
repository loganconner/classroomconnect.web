using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class FamilyDetailVM
    {
        public Guid FamilyId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<GuardianVM> Guardians { get; set; }
        public IEnumerable<ChildVM> Children { get; set; }
        public IEnumerable<ContactVM> Contacts { get; set; }
    }
}
