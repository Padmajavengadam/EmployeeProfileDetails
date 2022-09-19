using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFrameworkMVCProj.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Wfm_Manager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal? Experience { get; set; }
        public int? Profile_Id { get; set; }
    }
}
