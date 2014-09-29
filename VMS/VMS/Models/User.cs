using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string OfficialId { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}