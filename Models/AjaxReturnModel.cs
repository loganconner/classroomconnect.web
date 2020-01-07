using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models
{
    [Serializable]
    public class AjaxReturnModel
    {
        public Object ReturnObject { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
