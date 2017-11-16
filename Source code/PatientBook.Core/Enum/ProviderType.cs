using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBook.Core.Enum
{
    public enum ProviderType
    {
        None = -1,
        OleDb = 0,
        SqlClient = 1,
        OracleClient = 2,
        MySql = 3
    }
}
