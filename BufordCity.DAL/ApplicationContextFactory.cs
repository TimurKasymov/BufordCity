using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BufordCity.DAL
{
    public sealed class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = "";
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=BufordCityDateBase;User Id=postgres;Password=kasymov2002")
                .Options;

            return new ApplicationContext(options);
        }
    }
}
