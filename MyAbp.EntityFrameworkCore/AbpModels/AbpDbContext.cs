using Abp.Domian.UserInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MyAbp.EntityFrameworkCore.AbpModels
{
    [ConnectionStringName("Defualt")]
    public class AbpDbContext : AbpDbContext<AbpDbContext>
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public AbpDbContext(DbContextOptions<AbpDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
