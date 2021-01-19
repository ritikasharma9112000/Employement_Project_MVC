using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employement_Project_MVC.Models
{
    public class Candidate_Detail
    {
        public int Id { get; set; }
        [Required]
        public string Name_of_candidate { get; set; }
        public DateTime DOB_of_candidate { get; set; }
        [Required]
        public string Mobile_no_of_candidate { get; set; }
        public string Email_address_of_candidate { get; set; }
    }
}
