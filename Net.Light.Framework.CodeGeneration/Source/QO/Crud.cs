using Net.Light.Framework.Base;

namespace Net.Light.Framework.CodeGeneration.Source.QO
{
    internal class Crud
    {

        #region [ GetTablesAndColumns method ]

        public static string GetTablesAndColumns(ConnectionTypes connType)
        {
            switch (connType)
            {               
                case ConnectionTypes.PostgreSQL:
                    return "select column_name, udt_name, table_name, column_default from information_schema.columns where table_schema='public';";

                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDb:
                    return "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, COLUMN_KEY, EXTRA  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='{0}' Order By TABLE_NAME;";

                case ConnectionTypes.Oracle:
                    return "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE FROM COLS ORDER BY TABLE_NAME, COLUMN_ID;";

                case ConnectionTypes.SQLite:
                    break;

                case ConnectionTypes.Oledb:
                case ConnectionTypes.Odbc:
                    break;

                case ConnectionTypes.SqlServerCe:
                    return @"SELECT ISC.COLUMN_NAME, ISC.TABLE_NAME, ISC.DATA_TYPE, ISC.AUTOINC_INCREMENT AS IdentityState
                            FROM INFORMATION_SCHEMA.COLUMNS AS ISC INNER JOIN
                            INFORMATION_SCHEMA.TABLES AS IST ON ISC.TABLE_NAME = IST.TABLE_NAME";

                case ConnectionTypes.SqlServer:
                    return @"SELECT ISC.COLUMN_NAME, ISC.TABLE_NAME, ISC.DATA_TYPE,
                            COLUMNPROPERTY(OBJECT_ID(ISC.TABLE_NAME), ISC.COLUMN_NAME, 'IsIdentity') AS IdentityState
                            FROM INFORMATION_SCHEMA.COLUMNS ISC INNER JOIN INFORMATION_SCHEMA.TABLES IST
							ON ISC.TABLE_NAME=IST.TABLE_NAME
							WHERE IST.TABLE_TYPE='BASE TABLE' AND ISC.TABLE_NAME<>'sysdiagrams';";
                
                default:
                    break;
            }
            return string.Empty;
        }

        #endregion


        #region [ GetTablesQuery method ]

        public static string GetTablesQuery(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {
                case ConnectionTypes.PostgreSQL:
                    return "select table_name from information_schema.tables where table_schema='public'";

                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDb:
                    return "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, COLUMN_KEY, EXTRA FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='{0}'";

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    return "SELECT tbl_name FROM sqlite_master WHERE type='table' ORDER BY name;";

                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                    return "select name from sys.objects where type='u' order by name;";

                default:
                    break;
            }
            return string.Empty;
        }

        #endregion


        #region [ GetColumnsOfTablesQuery method ]

        public static string GetColumnsOfTablesQuery(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {
                case ConnectionTypes.PostgreSQL:
                    return "select column_name,udt_name,table_name from information_schema.columns where table_schema='public' and table_name='{0}';";

                case ConnectionTypes.MySQL:
                    break;

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    return "PRAGMA table_info('{0}');";

                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                    return @"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'";
                default:
                    break;
            }
            return string.Empty;
        }

        #endregion


        #region [ GetIdColumnOfTable method ]

        public static string GetIdColumnOfTable(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {

                case ConnectionTypes.PostgreSQL:
                    break;
                    
                case ConnectionTypes.MySQL:
                    break;

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    break;

                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                    return @"select COLUMN_NAME
from INFORMATION_SCHEMA.COLUMNS
where COLUMNPROPERTY(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 And
TABLE_NAME='{0}'";

                default:
                    break;
            }
            return string.Empty;
        }

        #endregion

    }
}