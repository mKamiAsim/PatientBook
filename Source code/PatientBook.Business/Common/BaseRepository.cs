using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PatientBook.Business.Common
{
    internal class BaseRepository
    {
        IDbConnection connection = null;

        public IDbConnection Connection { get => connection; protected set => connection = value; }
        public IDbTransaction Transaction { get; set; }

        public void BeginTransaction()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();

            Transaction = Connection.BeginTransaction();
        }
    }
}
