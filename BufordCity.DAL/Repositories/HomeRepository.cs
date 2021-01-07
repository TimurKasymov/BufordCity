using System;
using System.Collections.Generic;
using System.Text;
using BufordCity.DAL.Entities;

namespace BufordCity.DAL.Repositories
{
    public sealed class HomeRepository : DbRepository<HomeEntity, int>
    {
        public HomeRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
