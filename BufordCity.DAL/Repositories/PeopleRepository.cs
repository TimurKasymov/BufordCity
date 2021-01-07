using System;
using System.Collections.Generic;
using System.Text;
using BufordCity.DAL.Entities;

namespace BufordCity.DAL.Repositories
{
    public sealed class PeopleRepository : DbRepository<PeopleEntity, int> 
    {
        public PeopleRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
