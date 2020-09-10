using System;

namespace Net.Light.Framework.Base
{
    public enum ConnectionTypes : byte
    {
        MariaDb,
        MySQL,
        Odbc,
        Oledb,
        Oracle,
        PostgreSQL,
        SQLite,
        SqlServer,
        SqlServerCe
    };

    #region [ ConnectionTypeBuilder class ]

    public static class ConnectionTypeBuilder
    {
        public static ConnectionTypes GetConnectionType(String driverTypeName)
        {
            ConnectionTypes _connType;
            try
            {
                driverTypeName = string.Format("{0}", driverTypeName).TrimEnd().TrimStart().ToLower().Replace("ı", "i");

                switch (driverTypeName)
                {
                    case "mariadb":
                        _connType = ConnectionTypes.MariaDb;
                        break;

                    case "mysql":
                        _connType = ConnectionTypes.MySQL;
                        break;

                    case "odbc":
                        _connType = ConnectionTypes.Odbc;
                        break;

                    case "oledb":
                        _connType = ConnectionTypes.Oledb;
                        break;

                    case "oracle":
                        _connType = ConnectionTypes.Oracle;
                        break;

                    case "postgresql":
                        _connType = ConnectionTypes.PostgreSQL;
                        break;

                    case "sqlexpress":
                    case "sqlserver":
                    case "mssql":
                    case "ms-sql":
                    default:
                        _connType = ConnectionTypes.SqlServer;
                        break;

                    case "sqlserverce":
                        _connType = ConnectionTypes.SqlServerCe;
                        break;
                }

            }
            catch (Exception)
            {
                _connType = ConnectionTypes.SqlServer;
            }
            return _connType;
        }
    }

    #endregion
}