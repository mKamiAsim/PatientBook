using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Persistence.DAL.Common
{
    public class BaseDapper : IDisposable
    {
        private IDbConnection connection = null;
        private IDbCommand command = null;
        public IDbTransaction Transaction { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    Connection = Common.Connection.CreateConnection();
                }
                return connection;
            }
            set => connection = value;
        }

        public IDbCommand Command
        {
            get
            {
                if (command == null)
                {
                    command = Common.Command.CreateCommand();
                }
                command.Connection = Connection;
                return command;

            }
            set => command = value;
        }

        public void BeginTransaction()
        {
            OpenConnection();
            Transaction = Connection.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            Transaction?.Rollback();
            Transaction?.Dispose();
        }
        public void CommitTransaction()
        {
            Transaction?.Commit();
            Transaction?.Dispose();
        }

        public void OpenConnection()
        {
            if (Connection?.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection?.State != ConnectionState.Closed)
            {
                Connection?.Close();
            }
            Connection = null;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Command?.Dispose();
                    Connection?.Dispose();
                    Command = null;
                    Connection = null;


                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~BaseDapper()
        {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
