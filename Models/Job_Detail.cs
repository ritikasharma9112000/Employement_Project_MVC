using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employement_Project_MVC.Models
{
    //This class display the employer details under which it has employer id, employerdate of establishment, address of employer
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
