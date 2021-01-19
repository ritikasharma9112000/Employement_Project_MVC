using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employement_Project_MVC.Models;

namespace Employement_Project_MVC.Data
{
    public class Employement_Project_MVCContext : DbContext
    {
        public Employement_Project_MVCContext (DbContextOptions<Employement_Project_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Employement_Project_MVC.Models.Candidate_Detail> Candidate_Detail { get; set; }

        public DbSet<Employement_Project_MVC.Models.Employer_Detail> Employer_Detail { get; set; }

        public DbSet<Employement_Project_MVC.Models.Apply_Job_Detail> Apply_Job_Detail { get; set; }

        public DbSet<Employement_Project_MVC.Models.Job_Detail> Job_Detail { get; set; }
    }
}
