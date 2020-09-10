using Net.Light.Framework.Base;
using Npgsql;
using System;
using System.Data;
using System.Data.Common;

namespace Net.Light.Framework.Data.Client
{
    sealed class ConnectionPostgreSQL : IConnection
    {
        NpgsqlConnection Conn = null;
        NpgsqlTransaction Trans = null;

        internal ConnectionPostgreSQL()
        {
            Conn = new NpgsqlConnection();
        }

        internal ConnectionPostgreSQL(string connectionString)
        {
            Conn = new NpgsqlConnection(connectionString);
        }


        public String ConnectionString
        {
            get { return Conn.ConnectionString; }
            set { Conn.ConnectionString = value; }
        }

        public DbConnectionStringBuilder ConnectionStringBuilder
        {
            get { return new NpgsqlConnectionStringBuilder(); }
        }

        public ConnectionTypes ConnectionType
        {
            get { return ConnectionTypes.PostgreSQL; }
        }

        public void Open()
        {
            try
            {
                Conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            try
            {
                Conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ConnectionState ConnectionState
        {
            get { return Conn.State; }
        }

        public DbTransaction Transaction
        {
            get { return Trans; }
        }

        public void CreateTransaction()
        {
            try
            {
                Trans = Conn.BeginTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateTransaction(IsolationLevel isolationLevel)
        {
            try
            {
                Trans = Conn.BeginTransaction(isolationLevel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                Trans.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                Trans.Rollback();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DbDataAdapter CreateAdapter()
        {
            try
            {
                DbDataAdapter dtAdapter = null;
                dtAdapter = new NpgsqlDataAdapter();
                return dtAdapter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DbCommand CreateCommand()
        {
            try
            {
                DbCommand cmd = null;
                cmd = Conn.CreateCommand();
                return cmd;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (Trans != null)
                {
                    Trans.Dispose();
                }
                if (Conn != null)
                {
                    if (Conn.State == System.Data.ConnectionState.Open)
                    {
                        Conn.Close();
                    }

                    Conn.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public String Database
        {
            get
            {
                try
                {
                    return Conn.Database;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}