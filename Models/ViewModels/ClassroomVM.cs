using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models.ViewModels
{
    public class ClassroomVM
    {
        public Guid ClassroomId { get; set; }

        public Guid TeacherId { get; set; }
        [Display(Name = "Classroom")]
        public string TeacherName { get; set; }

        public DateTime ClassDate { get; set; }
        [ForeignKey("ClassroomId")]
        public IEnumerable<StudentVM> Students { get; set; }
    }
}
