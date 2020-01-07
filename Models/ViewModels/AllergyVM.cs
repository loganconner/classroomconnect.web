using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class AllergyVM
    {
        public int AllergyId { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
