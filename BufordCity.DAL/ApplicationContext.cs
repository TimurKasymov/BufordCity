using System;
using System.Collections.Generic;
using System.Text;
using BufordCity.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BufordCity.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<HomeEntity> Home { get; set; }
        public DbSet<PeopleEntity> People { get; set; }
        public DbSet<StreetEntity> Street { get; set; }
        public ApplicationContext() { }
        public  ApplicationContext(DbContextOptions options) : base(options) { }
    }
}
