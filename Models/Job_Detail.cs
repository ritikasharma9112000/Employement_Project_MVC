using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employement_Project_MVC.Models
{
    public class Job_Detail
    {
        public int Id { get; set; }
        public string Job_role { get; set; }
        public string Job_type { get; set; }
        public decimal Job_salary { get; set; }
        public string Job_description { get; set; }
        public int Employer_DetailId { get; set; }
        public Employer_Detail Employer_Detail { get; set; }
    }
}
