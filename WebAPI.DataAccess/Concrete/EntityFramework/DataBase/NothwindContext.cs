using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Entities.Concrete;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Concrete.EntityFramework.DataBase
{
    public class NothwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-G2VNR8H\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
