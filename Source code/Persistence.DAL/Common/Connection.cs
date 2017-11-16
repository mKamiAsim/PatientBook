using PatientBook.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Persistence.DAL.Common
{
    public static class Connection
    {
        public static IDbConnection CreateConnection()
        {
            IDbConnection connection = null;
            switch (SessionObj.AppSettings.DbProvider)
            {
                case PatientBook.Core.Enum.ProviderType.SqlClient:
                    connection = new SqlConnection(SessionObj.AppSettings.ConnectionString);
                    break;
                case PatientBook.Core.Enum.ProviderType.MySql:

                    break;
                case PatientBook.Core.Enum.ProviderType.OracleClient:

                    break;

            }
            return connection;
        }
    }
}
