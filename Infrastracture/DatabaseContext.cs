using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class DatabaseContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<TblTask> TblTasks { get; set; }
        public DbSet<TblEmploee> TblEmploes { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration _conf) : base(options)
        {
            _configuration = _conf;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<TblTask>(new TaskConfiguration());
            modelBuilder.ApplyConfiguration<TblEmploee>(new EmploeeConfiguration());
            modelBuilder.Ignore<BaseEntity>();
        }
    }
}
