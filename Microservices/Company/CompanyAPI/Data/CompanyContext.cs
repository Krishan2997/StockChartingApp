using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyAPI.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        public DbSet<Companies> Companies { get; set; }
        public DbSet<IPOs> IPOs { get; set; }
        public DbSet<StockExchanges> StockExchanges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IPOs>().Property(i => i.OpenDate).HasDefaultValueSql("getDate()");
        }
    }
}