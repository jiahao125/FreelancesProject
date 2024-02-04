using System;
using System.Collections.Generic;

namespace FreelancesProject.Models
{
    public partial class Freelancer
    {
        public Guid RowId { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNum { get; set; }
        public string? SkillSet { get; set; }
        public string? Hobby { get; set; }
    }
}
