using PatientBook.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Persistence.DAL.Common
{
    public static class Command
    {
        public static IDbCommand CreateCommand()
        {
            IDbCommand command = null;
            switch (SessionObj.AppSettings.DbProvider)
            {
                case PatientBook.Core.Enum.ProviderType.SqlClient:
                    command = new SqlCommand() { CommandTimeout = SessionObj.AppSettings.CommandTimeout };
                    break;
                case PatientBook.Core.Enum.ProviderType.MySql:

                    break;
                case PatientBook.Core.Enum.ProviderType.OracleClient:

                    break;

            }
            return command;
        }
    }
}
