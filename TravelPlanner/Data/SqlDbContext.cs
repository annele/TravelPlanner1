using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options): base(options)
        {

        }
        public DbSet<CityResult> CityResults
        {
            get; set;
        }

        public DbSet<WeatherResult> WeatherResults
        {
            get; set;
        }

        public DbSet<CafeResult> CafeResults
        {
            get; set;
        }

        public DbSet<LocationInformation> LocationInformations
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://docs.microsoft.com/en-gb/ef/ef6/modeling/code-first/fluent/relationships?redirectedfrom=MSDN

            modelBuilder.Entity<LocationInformation>().HasMany(i => i.CafeResults);
            modelBuilder.Entity<LocationInformation>().HasMany(i => i.WeatherResults);
         

        }
    }
}
