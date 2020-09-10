using Net.Light.Framework.Base;
using Net.Light.Framework.CodeGeneration.Source.QO;
using Net.Light.Framework.Data.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;

namespace Net.Light.Framework.CodeGeneration.Source.DL
{
    internal class GeneratorDL
    {

        #region [ GetSqlServerCeTables method ]

        public DataTable GetSqlServerCeTables(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.SqlServerCe, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = Crud.GetTablesAndColumns(ConnectionTypes.SqlServerCe);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetSqlServerTables method ]

        public DataTable GetSqlServerTables(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.SqlServer, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = Crud.GetTablesAndColumns(ConnectionTypes.SqlServer);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetMySQLAndMariaDbTables method ]

        public DataTable GetMySQLAndMariaDbTables(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.MySQL, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = string.Format(Crud.GetTablesAndColumns(ConnectionTypes.MySQL), freeConn.Database);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetPostgreSQL method ]

        public DataTable GetPostgreSQL(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.PostgreSQL, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = Crud.GetTablesAndColumns(ConnectionTypes.PostgreSQL);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetOracleTables method ]

        public DataTable GetOracleTables(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.Oracle, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = Crud.GetTablesAndColumns(ConnectionTypes.Oracle);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        #endregion


        #region [ GetOledbSet method ]

        public DataSet GetOledbSet(string connectionString)
        {
            DataSet ds = new DataSet();
            try
            {
                using (OleDbConnection oledbConn = new OleDbConnection(connectionString))
                {
                    oledbConn.Open();

                    DataTable dt = oledbConn.GetSchema("TABLES");
                    DataView dV = dt.DefaultView;
                    dV.Sort = "TABLE_NAME Asc";
                    dt = dV.ToTable();

                    ds.Tables.Add(dt);

                    dt = new DataTable();
                    dt = oledbConn.GetSchema("COLUMNS");
                    dV = dt.DefaultView;
                    dV.Sort = "TABLE_NAME Asc, ORDINAL_POSITION Asc";
                    dt = dV.ToTable();
                    ds.Tables.Add(dt);

                    oledbConn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        #endregion


        #region [ GetOdbcTable method ]

        public DataSet GetOdbcTable(string connectionString)
        {
            DataSet ds = new DataSet();
            try
            {
                using (OdbcConnection odbcConn = new OdbcConnection(connectionString))
                {
                    odbcConn.Open();
                    DataTable dt = odbcConn.GetSchema("TABLES");
                    DataView dV = dt.DefaultView;
                    dV.Sort = "TABLE_NAME Asc";
                    dt = dV.ToTable();

                    ds.Tables.Add(dt);

                    dt = new DataTable();
                    dt = odbcConn.GetSchema("COLUMNS");
                    dV = dt.DefaultView;
                    dV.Sort = "TABLE_NAME Asc, ORDINAL_POSITION Asc";
                    dt = dV.ToTable();
                    ds.Tables.Add(dt);

                    odbcConn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        #endregion


        #region [ SQLite Methods ]

        #region [ GetSqliteTables method ]

        public DataTable GetSqliteTables(string connectionString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.SQLite, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = Crud.GetTablesQuery(ConnectionTypes.SQLite);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        #endregion

        #region [ GetSqliteColumns method ]

        public DataTable GetSqliteColumns(string connectionString, string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IConnection freeConn = ConnectionFactory.CreateConnection(ConnectionTypes.SQLite, connectionString))
                {
                    using (DbCommand dbCmd = freeConn.CreateCommand())
                    {
                        dbCmd.CommandText = string.Format(Crud.GetColumnsOfTablesQuery(ConnectionTypes.SQLite), tableName);
                        dbCmd.CommandType = CommandType.Text;
                        using (DbDataAdapter adapter = freeConn.CreateAdapter())
                        {
                            freeConn.Open();
                            adapter.SelectCommand = dbCmd;
                            adapter.Fill(dt);
                            freeConn.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        #endregion

        #endregion



    }
}