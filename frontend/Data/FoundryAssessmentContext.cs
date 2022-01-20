#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using frontend.Models;

    public class FoundryAssessmentContext : DbContext
    {
        public FoundryAssessmentContext (DbContextOptions<FoundryAssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<frontend.Models.Employee> Employee { get; set; }

        public DbSet<frontend.Models.Client> Client { get; set; }

        public DbSet<frontend.Models.Engagement> Engagement { get; set; }
    }
