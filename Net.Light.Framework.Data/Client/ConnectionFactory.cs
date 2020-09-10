using Net.Light.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Light.Framework.Data.Client
{
    /// <summary>
    /// Defines an object that which is used for creating IConnection object.
    /// </summary>
    public sealed class ConnectionFactory
    {
        private static Dictionary<ConnectionTypes, IConnection> _connTypesDict = new Dictionary<ConnectionTypes, IConnection>();

        #region [ CreateConnection Method ]

        /// <summary>
        /// Creates IConnection object with given parameters.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Returns IConnection object.</returns>
        public static IConnection CreateConnection(ConnectionTypes connType)
        {
            try
            {
                IConnection conn = null;

                conn = GetConn(connType);

                if (conn == null)
                    throw new Exception("Not Supported Connection Type");

                return conn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ GetConn method ]

        private static IConnection GetConn(ConnectionTypes connType)
        {
            IConnection conn = null;
            try
            {
                switch (connType)
                {
                    case ConnectionTypes.MariaDb:
                        conn = new ConnectionMariaDb();
                        break;

                    case ConnectionTypes.MySQL:
                        conn = new ConnectionMySQL();
                        break;

                    case ConnectionTypes.Oracle:
                        conn = new ConnectionOracle();
                        break;

                    case ConnectionTypes.Oledb:
                        conn = new ConnectionOledb();
                        break;

                    case ConnectionTypes.Odbc:
                        conn = new ConnectionOdbc();
                        break;

                    case ConnectionTypes.PostgreSQL:
                        conn = new ConnectionPostgreSQL();
                        break;

                    case ConnectionTypes.SqlServer:
                        conn = new ConnectionSqlServer();
                        break;

                    case ConnectionTypes.SqlServerCe:
                        conn = new ConnectionSqlServerCe();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return conn;
        }

        #endregion


        #region [ CreateConnection Method ]
        /// <summary>
        /// Creates IConnection object with given parameters.
        /// </summary>
        /// <param name="connType">Connection Type</param>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Returns IConnection object.</returns>
        public static IConnection CreateConnection(ConnectionTypes connType, string connectionString)
        {
            IConnection conn = null;
            try
            {
                conn = CreateConnection(connType);

                if (conn == null)
                    throw new Exception("Not Supported Connection Type");

                conn.ConnectionString = connectionString;

            }
            catch (Exception)
            {
                throw;
            }
            return conn;
        }

        #endregion

    }
}