using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_technique.Models
{
    public class CandidatureDBContext : DbContext
    {
        public CandidatureDBContext(DbContextOptions<CandidatureDBContext> options) : base(options)
        {

        }

        public DbSet<Candidature> Candidatures { get; set; }
    }
}
