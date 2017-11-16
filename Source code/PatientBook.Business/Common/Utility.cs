using Microsoft.EntityFrameworkCore;
using PatientBook.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBook.Business.Common
{
    public class Utility
    {

        public static void ManageDbConnection(DbContextOptionsBuilder options)
        {
            switch (SessionObj.AppSettings.DbProvider)
            {
                case Core.Enum.ProviderType.SqlClient:
                    options.UseSqlServer(SessionObj.AppSettings.ConnectionString);
                    break;
            }
        }
    }
}
