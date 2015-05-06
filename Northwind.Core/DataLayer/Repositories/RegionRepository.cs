﻿using System.Data.Entity;
using Northwind.Core.DataLayer.Operations;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
