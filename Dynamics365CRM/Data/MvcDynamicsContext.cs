using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Models;

namespace Dynamics365CRM.Data
{
    public class MvcDynamicsContext : DbContext
    {  
        
        public MvcDynamicsContext(DbContextOptions<MvcDynamicsContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Kontakt> Kontakts { get; set; }
        public DbSet<Firmenwagen> Firmenwagens { get; set; }
    }
}
