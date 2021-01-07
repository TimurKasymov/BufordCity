using System;
using System.Collections.Generic;
using System.Text;
using BufordCity.DAL.Entities;

namespace BufordCity.DAL.Repositories
{
    public sealed class StreetRepository : DbRepository<StreetEntity, int>
    {
        public StreetRepository(ApplicationContext context) : base(context)
        {

        }   
    }
}
