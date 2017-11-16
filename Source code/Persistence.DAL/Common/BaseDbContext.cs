using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL.Common
{
  public  class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
