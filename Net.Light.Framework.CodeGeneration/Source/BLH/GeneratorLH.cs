using Net.Light.Framework.Base;
using Net.Light.Framework.CodeGeneration.Source.BO;
using Net.Light.Framework.CodeGeneration.Source.DL;
using Net.Light.Framework.CodeGeneration.Source.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Net.Light.Framework.CodeGeneration.Source.BLH
{
    internal class GeneratorLH
    {
        private GeneratorDL generatorDL;

        #region [ GeneratorLH Ctor ]

        public GeneratorLH()
        {
            generatorDL = new GeneratorDL();
        }

        #endregion

        #region [ GetTablesAndColumns method ]

        public List<Table> GetTablesAndColumns(ConnectionTypes connectionType, string connectionString)
        {
            List<Table> tables = new List<Table>();

            try
            {
                switch (connectionType)
                {
                    default:
                        break;

                    case ConnectionTypes.SqlServerCe:
                        tables = GetSqlServerCeTables(connectionString);
                        break;

                    case ConnectionTypes.SqlServer:
                        tables = GetSqlServerTables(connectionString);
                        break;

                    case ConnectionTypes.PostgreSQL:
                        tables = GetPostgreSQLTables(connectionString);
                        break;

                    case ConnectionTypes.Oracle:
                        tables = GetOracleTables(connectionString);
                        break;
                        
                    case ConnectionTypes.MySQL:
                    case ConnectionTypes.MariaDb:
                        tables = GetMySQLAndMariaDbTables(connectionString);
                        break;

                    case ConnectionTypes.Oledb:
                        tables = GetOledbTable(connectionString);
                        break;

                    case ConnectionTypes.SQLite:
                        tables = GetSqliteTables(connectionString);
                        break;

                    case ConnectionTypes.Odbc:
                        tables = GetOdbcTable(connectionString);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tables;
        }

        #endregion

        #region [ GetSqlServerCeTables method ]

        private List<Table> GetSqlServerCeTables(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataTable dt = new DataTable();
                dt = generatorDL.GetSqlServerCeTables(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "TABLE_NAME");
                DataRow[] rows;
                List<Column> columns;
                Table tbl;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = dt.Select(string.Format("TABLE_NAME='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["COLUMN_NAME"].ToString(), rw["DATA_TYPE"].ToString()));
                    }

                    tbl.TableColumns = columns;

                    rows = null;
                    rows = dt.Select(string.Format("TABLE_NAME='{0}' AND IdentityState=1", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["COLUMN_NAME"].ToString();
                        break;
                    }

                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetSqlServerTables method ]

        private List<Table> GetSqlServerTables(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataTable dt = new DataTable();
                dt = generatorDL.GetSqlServerTables(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "TABLE_NAME");
                DataRow[] rows;
                List<Column> columns;
                Table tbl;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = dt.Select(string.Format("TABLE_NAME='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["COLUMN_NAME"].ToString(), rw["DATA_TYPE"].ToString()));
                    }

                    tbl.TableColumns = columns;

                    rows = null;
                    rows = dt.Select(string.Format("TABLE_NAME='{0}' AND IdentityState=1", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["COLUMN_NAME"].ToString();
                        break;
                    }

                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetPostgreSQLTables method ]

        private List<Table> GetPostgreSQLTables(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataTable dt = new DataTable();
                dt = generatorDL.GetPostgreSQL(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "table_name");
                DataRow[] rows;
                List<Column> columns;
                Table tbl;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = dt.Select(string.Format("table_name='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["column_name"].ToString(), rw["udt_name"].ToString()));
                    }

                    tbl.TableColumns = columns;
                    /*
                     * Identity Column bulunacak.
                    */
                    rows = null;
                    rows = dt.Select(string.Format("table_name='{0}' AND udt_name LIKE '%int%' AND column_default LIKE '%nextval%'", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["column_name"].ToString();
                        break;
                    }
                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetMySQLAndMariaDbTables method ]

        private List<Table> GetMySQLAndMariaDbTables(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataTable dt = new DataTable();
                dt = generatorDL.GetMySQLAndMariaDbTables(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "TABLE_NAME");
                DataRow[] rows;
                List<Column> columns;
                Table tbl;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = dt.Select(string.Format("TABLE_NAME='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["COLUMN_NAME"].ToString(), rw["DATA_TYPE"].ToString()));
                    }

                    tbl.TableColumns = columns;

                    rows = null;
                    rows = dt.Select(string.Format("TABLE_NAME='{0}' AND EXTRA='auto_increment'", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["COLUMN_NAME"].ToString();
                        break;
                    }

                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetOracleTables method ]

        private List<Table> GetOracleTables(string connectionString)
        {
            List<Table> _tables = new List<Table>();
            try
            {
                DataTable dt = generatorDL.GetOracleTables(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "TABLE_NAME");
                Table _table;
                DataRow[] rows;
                List<Column> cols;
                foreach (string tbl in tables)
                {
                    _table = new Table()
                    {
                        TableName = tbl
                    };
                    cols = new List<Column>();
                    rows = dt.Select(string.Format("TABLE_NAME='{0}'", tbl));
                    foreach (DataRow row in rows)
                    {
                        cols.Add(new Column(string.Format("{0}", row["COLUMN_NAME"]), string.Format("{0}", row["DATA_TYPE"])));
                    }
                    _table.TableColumns = cols;
                    /*
                    rows = null;
                    rows = dt.Select(string.Format("table_name='{0}' AND coltype IN(6, 18, 53)", tbl));

                    foreach (DataRow row in rows)
                    {
                        _table.IdColumn = string.Format("{0}", row["colname"]);
                        break;
                    }

                    _tables.Add(_table);
                    rows = null;
                     */
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _tables;
        }

        #endregion

        #region [ GetOledbTable method ]

        private List<Table> GetOledbTable(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataSet ds = new DataSet();
                DataRow[] rows;
                List<string> tables = new List<string>();
                ds = generatorDL.GetOledbSet(connectionString);
                rows = ds.Tables[0].Select("TABLE_TYPE='TABLE'");
                string str_tbl;
                foreach (DataRow rw in rows)
                {
                    str_tbl = string.Format("{0}", rw["TABLE_NAME"]);

                    if (tables.Contains(str_tbl) == false)
                        tables.Add(str_tbl);
                }

                List<Column> columns;
                Table tbl;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = ds.Tables[1].Select(string.Format("TABLE_NAME='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["COLUMN_NAME"].ToString(), OleDbUtil.GetIntFrom(ConvertUtil.ToInt(rw["DATA_TYPE"].ToString()))));
                    }

                    tbl.TableColumns = columns;
                    /*
                     * Identity Column bulunacak.
                    */
                    rows = null;
                    rows = ds.Tables[1].Select(string.Format("TABLE_NAME='{0}' AND DATA_TYPE=3", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["COLUMN_NAME"].ToString();
                        break;
                    }
                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetOdbcTable method ]

        private List<Table> GetOdbcTable(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = generatorDL.GetOdbcTable(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(ds.Tables[0], "TABLE_NAME");
                DataRow[] rows;
                List<Column> columns;
                Table tbl;
                dt = ds.Tables[1];
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    rows = dt.Select(string.Format("TABLE_NAME='{0}'", strTable));
                    foreach (DataRow rw in rows)
                    {
                        columns.Add(new Column(rw["COLUMN_NAME"].ToString(), rw["TYPE_NAME"].ToString()));
                    }

                    tbl.TableColumns = columns;
                    /*
                     * Identity Column bulunacak.
                    */
                    rows = null;
                    rows = dt.Select(string.Format("TABLE_NAME='{0}' AND TYPE_NAME='int identity'", strTable));

                    foreach (DataRow rw2 in rows)
                    {
                        tbl.IdColumn = rw2["COLUMN_NAME"].ToString();
                    }
                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

        #region [ GetSqliteTables method ]

        private List<Table> GetSqliteTables(string connectionString)
        {
            List<Table> tableList = new List<Table>();
            try
            {
                DataTable dt = generatorDL.GetSqliteTables(connectionString);
                List<string> tables = DbDataUtil.GetColumnAsUniqueList(dt, "tbl_name");
                List<Column> columns;
                Table tbl;
                DataTable dtColumns;
                foreach (string strTable in tables)
                {
                    tbl = new Table()
                    {
                        TableName = strTable
                    };
                    columns = new List<Column>();
                    dtColumns = generatorDL.GetSqliteColumns(connectionString, strTable);

                    foreach (DataRow row in dtColumns.Rows)
                    {
                        columns.Add(new Column(row["name"].ToString(), row["type"].ToString()));
                        if (ConvertUtil.ToInt(string.Format("{0}", row["pk"])) == 1)
                        {
                            tbl.IdColumn = row["name"].ToString();
                        }
                    }
                    tbl.TableColumns = columns;
                    tableList.Add(tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tableList;
        }

        #endregion

    }
}