using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Persistence.DAL.IDapper
{
    public interface IDapper
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }
    }
}
