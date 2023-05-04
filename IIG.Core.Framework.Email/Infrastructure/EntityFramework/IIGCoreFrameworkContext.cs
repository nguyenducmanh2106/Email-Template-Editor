using IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Infrastructure.EntityFramework
{
    public class IIGCoreFrameworkContext : DbContext
    {
        public DbSet<SysHistory> Histories { get; set; }
        public DbSet<SysApplication> Applications { get; set; }
        public DbSet<SysEmail> Emails { get; set; }
        public DbSet<SysEmailTemplate> EmailTemplates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = IIG.Core.Framework.Email.Infrastructure.Utils.Utils.GetConfig("ConnectionStrings:IIG.Core.Framework");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
