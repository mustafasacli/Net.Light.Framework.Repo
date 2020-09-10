﻿using Net.Light.Framework.Base;
using Net.Light.Framework.Entity.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Net.Light.Framework.Entity.QueryBuilding
{

    public sealed class QueryBuilder : IQueryBuilder
    {
        #region [ Private Fields ]

        private Property _property = null;
        private String _queryString = String.Empty;

        private TableObject _baseBO;
        private QueryTypes _queryType;
        private ConnectionTypes _ConnType;

        #endregion


        #region [ QueryBuilder Ctors ]

        /// <summary>
        /// Create a QueryBuilder with given object and 
        /// SqlServer ConnetionTypes and Select QueryTypes.
        /// </summary>
        /// <param name="queryObject">An object inherits BaseBO object.</param>
        public QueryBuilder(BaseBO queryObject)
            : this(ConnectionTypes.SqlServer, QueryTypes.Select, queryObject)
        { }

        /// <summary>
        /// Create a QueryBuilder with given object and 
        /// querytype and SqlServer ConnetionTypes.
        /// </summary>
        /// <param name="queryType">Query Types of Query Builder.</param>
        /// <param name="queryObject">An object inherits BaseBO object.</param>
        public QueryBuilder(QueryTypes queryType, BaseBO queryObject)
            : this(ConnectionTypes.SqlServer, queryType, queryObject)
        { }

        /// <summary>
        /// Create a QueryBuilder with given object and 
        /// querytype and connetiontypes.
        /// </summary>
        /// <param name="ConnType">Connetion Types of Query Builder.</param>
        /// <param name="queryType">Query Types of Query Builder.</param>
        /// <param name="queryObject">An object inherits IBaseBO interface.</param>
        public QueryBuilder(ConnectionTypes ConnType, QueryTypes queryType,
            BaseBO queryObject)
        {
            _baseBO = queryObject.Table;
            _queryType = queryType;
            _ConnType = ConnType;

            _queryString = GetQueryString();
            _property = GetProperties();
        }

        #endregion


        #region [ Properties Property ]

        /// <summary>
        /// Gets Query Parameters of QueryBuilder.
        /// </summary>
        public Property Properties
        {
            get { return _property; }
        }

        #endregion


        #region [ Get Properties ]

        public Property GetProperties()
        {
            try
            {
                Property prprty = Property.Instance;
                String paramPrefix = GetParameterPrefix();
                List<string> colList = new List<string>();
                if (_baseBO.GetParameters() != null)
                {
                    foreach (var item in _baseBO.GetParameters())
                    {
                        colList.Add(item.Name);
                    }
                }
                String idCol = _baseBO.IdCol;
                switch (_queryType)
                {
                    /*-- Select And SelectWithFilter Parts --*/
                    case QueryTypes.Select:
                    case QueryTypes.Identity:
                        return null;

                    /*-- Insert, InsertAnyChange and InsertAndGetId Part --*/
                    case QueryTypes.InsertAnyChange:
                    case QueryTypes.InsertAndGetId:
                    case QueryTypes.Insert:
                        {
                            if (colList.Contains(idCol) && _queryType != QueryTypes.InsertAnyChange)
                                colList.Remove(idCol);

                            if (_ConnType != ConnectionTypes.Odbc)
                            {
                                foreach (var col in colList)
                                {
                                    prprty.Put(String.Format("{0}{1}", paramPrefix, col), _baseBO.Get(col));
                                }
                            }
                            else
                            {
                                foreach (var col in colList)
                                {
                                    prprty.Put(String.Format("{0}", col), _baseBO.Get(col));
                                }
                            }
                            return prprty;
                        }
                    /*-- Update Part --*/
                    case QueryTypes.Update:
                        {
                            if (colList.Contains(idCol) == false)
                                colList.Add(idCol);

                            if (_ConnType != ConnectionTypes.Odbc)
                            {
                                foreach (var col in colList)
                                {
                                    prprty.Put(String.Format("{0}{1}", paramPrefix, col), _baseBO.Get(col));
                                }
                            }
                            else
                            {
                                foreach (var col in colList)
                                {
                                    prprty.Put(String.Format("{0}", col), _baseBO.Get(col));
                                }
                            }

                            return prprty;
                        }
                    /*-- Delete And SelectWhereId Parts --*/
                    case QueryTypes.SelectWhereId:
                    case QueryTypes.Delete:
                        {
                            if (_ConnType != ConnectionTypes.Odbc)
                            {
                                prprty.Put(String.Format("{0}{1}", paramPrefix, idCol), _baseBO.Get(idCol));
                            }
                            else
                            {
                                prprty.Put(String.Format("{0}", idCol), _baseBO.Get(idCol));
                            }
                            return prprty;

                        }
                    case QueryTypes.SelectWhereChangeColumns:
                        {
                            if (_ConnType != ConnectionTypes.Odbc)
                            {
                                foreach (String col in colList)
                                {
                                    prprty.Put(String.Format("{0}{1}", paramPrefix, col), _baseBO.Get(col));
                                }
                            }
                            else
                            {
                                foreach (String col in colList)
                                {
                                    prprty.Put(String.Format("{0}", col), _baseBO.Get(col));
                                }
                            }
                        }
                        return prprty;

                    case QueryTypes.SelectChangeColumns:
                        {
                            if (_ConnType != ConnectionTypes.Odbc)
                            {
                                foreach (String col in colList)
                                {
                                    prprty.Put(String.Format("{0}{1}", paramPrefix, col), _baseBO.Get(col));
                                }
                            }
                            else
                            {
                                foreach (String col in colList)
                                {
                                    prprty.Put(String.Format("{0}", col), _baseBO.Get(col));
                                }
                            }
                            return prprty;
                        }
                    default:
                        throw new InvalidOperationException("Invalid Query Type");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ QueryString Property ]

        /// <summary>
        /// Returns Query String of QueryBuilder.
        /// </summary>
        public String QueryString
        {
            get { return _queryString; }
        }

        #endregion


        #region [ Get Query String ]

        /// <summary>
        /// Returns Query String.
        /// </summary>
        /// <returns></returns>
        private String GetQueryString()
        {
            String _queryFormat = QueryFormat(_queryType);
            switch (_queryType)
            {
                case QueryTypes.Select:
                    return String.Format(_queryFormat, getCompleteTableName());

                case QueryTypes.Identity:
                    return GetIdentityInsert();

                case QueryTypes.InsertAnyChange:
                case QueryTypes.Insert:
                    return String.Format(_queryFormat,
                        getCompleteTableName(),
                        GetFirstPart(),
                        getSecondPart());

                case QueryTypes.Update:
                    return String.Format(_queryFormat,
                        getCompleteTableName(),
                        GetFirstPart(),
                        getSecondPart());


                case QueryTypes.Delete:
                    return String.Format(_queryFormat,
                        getCompleteTableName(),
                        getSecondPart());

                case QueryTypes.InsertAndGetId:
                    return new StringBuilder(
                        String.Format(_queryFormat,
                         getCompleteTableName(),
                         GetFirstPart(), getSecondPart()
                         )).AppendLine(";").
                         AppendLine(GetIdentityInsert()).ToString();

                case QueryTypes.SelectWhereId:
                    return String.Format(
                        _queryFormat,
                        getCompleteTableName(),
                        getSecondPart()
                        );

                case QueryTypes.SelectWhereChangeColumns:
                    return String.Format(_queryFormat, getCompleteTableName(), getSecondPart());

                case QueryTypes.SelectChangeColumns:
                    return String.Format(_queryFormat, getCompleteTableName(), getSecondPart());

                default:
                    throw new InvalidOperationException("Invalid Query Type.");
            }
        }

        #endregion


        #region [ Query Format of QueryType ]

        /// <summary>
        /// Returns Format of Query according to QueryType.
        /// </summary>
        /// <param name="queryType"></param>
        /// <returns></returns>
        private String QueryFormat(QueryTypes queryType)
        {
            switch (queryType)
            {
                case QueryTypes.Select:
                    return "SELECT * FROM {0};";

                case QueryTypes.Insert:
                    return "INSERT INTO {0}({1}) VALUES({2});";

                case QueryTypes.InsertAndGetId:
                    return "INSERT INTO {0}({1}) VALUES({2})";

                case QueryTypes.Update:
                    return "UPDATE {0} SET {1} WHERE {2};";

                case QueryTypes.Delete:
                    return "DELETE FROM {0} WHERE {1};";

                case QueryTypes.SelectWhereChangeColumns:
                case QueryTypes.SelectWhereId:
                    return "SELECT * FROM {0} WHERE {1};";

                case QueryTypes.SelectChangeColumns:
                    return "SELECT {0} FROM {0};";
                default:
                    break;
            }
            return string.Empty;
        }
        #endregion


        #region [ Get Completely Table Name ]

        /// <summary>
        /// Returns Table Name with prefix and suffix.
        /// </summary>
        /// <returns> Returns Table Name with prefix and suffix. </returns>
        private String getCompleteTableName()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_baseBO.TableName) == false)
                {
                    String prefix = GetPrefix();
                    String suffix = GetSuffix();

                    StringBuilder strBuilder = new StringBuilder();

                    strBuilder.AppendFormat("{0}{1}{2}", prefix, _baseBO.TableName, suffix);

                    return strBuilder.ToString();
                }
                else
                    throw new InvalidOperationException("Table Name can not be null or empty.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region [ Get First Part ]

        /// <summary>
        /// Returns Second Part of Query format;
        /// for Select  Or Delete --> ""
        /// for Insert --> Table({0})
        /// for Update Set Column=@Column
        /// </summary>
        /// <returns></returns>
        private String GetFirstPart()
        {
            String _firstPart = "";
            String paramPrefix = GetParameterPrefix();
            String prefix = GetPrefix();
            String suffix = GetSuffix();
            StringBuilder strBuilder;
            List<String> Cols;

            switch (_queryType)
            {
                case QueryTypes.SelectWhereId:
                case QueryTypes.SelectWhereChangeColumns:
                case QueryTypes.SelectChangeColumns:
                case QueryTypes.Select:
                case QueryTypes.Delete:
                    break;

                case QueryTypes.InsertAndGetId:
                case QueryTypes.InsertAnyChange:
                case QueryTypes.Insert:
                    {
                        Cols = new List<string>();
                        List<FreeParameter> prms = _baseBO.GetParameters();
                        foreach (var item in prms)
                        {
                            Cols.Add(item.Name);
                        }

                        if (_queryType != QueryTypes.InsertAnyChange)
                            Cols.Remove(_baseBO.IdCol);

                        if (Cols.Count == 0)
                            return "";

                        strBuilder = new StringBuilder();
                        foreach (String col in Cols)
                        {
                            strBuilder.AppendFormat("{0}{1}{2},", prefix, col, suffix);
                        }

                        _firstPart = strBuilder.ToString();

                        return _firstPart.Substring(0, _firstPart.Length - 1);
                    }

                case QueryTypes.Update:
                    {
                        strBuilder = new StringBuilder();
                        Cols = new List<string>();
                        List<FreeParameter> prms = _baseBO.GetParameters();
                        foreach (var item in prms)
                        {
                            Cols.Add(item.Name);
                        }
                        Cols.Remove(_baseBO.IdCol);

                        if (Cols.Count == 0)
                            return "";

                        if (_ConnType != ConnectionTypes.Odbc)
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0}{1}{2}={3}{1}, ",
                                    prefix, col, suffix, paramPrefix);
                            }
                        }
                        else
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0}={1}, ",
                                    col, paramPrefix);
                            }
                        }
                        _firstPart = strBuilder.ToString();
                        return _firstPart.Substring(0, _firstPart.Length - 2);
                    }

                default:
                    break;
            }

            return _firstPart;
        }

        #endregion


        #region [ Second Part ]

        /// <summary>
        /// Returns Second Part of Query format;
        /// for Select --> ""
        /// for Insert --> Values({0})
        /// for Update Or Delete Where IdColumn=@IdColumn
        /// </summary>
        /// <returns></returns>
        private String getSecondPart()
        {
            String _secondPart = "";
            String paramPrefix = GetParameterPrefix();
            String prefix = GetPrefix();
            String suffix = GetSuffix();
            StringBuilder strBuilder;
            List<String> Cols;

            switch (_queryType)
            {
                case QueryTypes.Select:
                    break;

                case QueryTypes.InsertAndGetId:
                case QueryTypes.InsertAnyChange:
                case QueryTypes.Insert:
                    {
                        Cols = new List<string>();
                        List<FreeParameter> prms = _baseBO.GetParameters();

                        foreach (var item in prms)
                        {
                            Cols.Add(item.Name);
                        }

                        if (_queryType != QueryTypes.InsertAnyChange)
                            Cols.Remove(_baseBO.IdCol);

                        if (Cols.Count == 0)
                            return "";

                        strBuilder = new StringBuilder();
                        if (_ConnType != ConnectionTypes.Odbc)
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0}{1},", paramPrefix, col);
                            }
                        }
                        else
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0},", paramPrefix);
                            }
                        }
                        _secondPart = strBuilder.ToString();
                        return _secondPart.Substring(0, _secondPart.Length - 1);
                    }

                case QueryTypes.SelectWhereId:
                case QueryTypes.Delete:
                case QueryTypes.Update:
                    {
                        if (_ConnType != ConnectionTypes.Odbc)
                        {
                            _secondPart = String.Format("{0}{1}{2}={3}{1}", prefix,
                                _baseBO.IdCol, suffix, paramPrefix);
                        }
                        else
                        {
                            _secondPart = String.Format("{0}={1}", _baseBO.IdCol, paramPrefix);
                        }
                    }
                    break;

                case QueryTypes.SelectWhereChangeColumns:
                    {
                        strBuilder = new StringBuilder();
                        Cols = new List<string>();
                        List<FreeParameter> prms = _baseBO.GetParameters();
                        foreach (var item in prms)
                        {
                            Cols.Add(item.Name);
                        }

                        if (Cols.Count == 0)
                            return "";
                        if (_ConnType != ConnectionTypes.Odbc)
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0}{1}{2}={3}{1} And ",
                                    prefix, col, suffix, paramPrefix);
                            }
                        }
                        else
                        {
                            foreach (String col in Cols)
                            {
                                strBuilder.AppendFormat("{0}={1} And ",
                                    col, paramPrefix);
                            }
                        }
                        _secondPart = strBuilder.ToString();
                        return _secondPart.Substring(0, _secondPart.Length - 5);
                    }

                default:
                    break;
            }
            return _secondPart;
        }

        #endregion


        #region [ Get Parameter Prefix ]

        /// <summary>
        /// Returns Prefix for parameters according to Connection Type.
        /// </summary>
        /// <returns> Returns Prefix for parameters according to Connection Type.</returns>
        private String GetParameterPrefix()
        {
            switch (_ConnType)
            {
                // case ConnectionTypes.DB2:
                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                //case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDb:
                case ConnectionTypes.SQLite:
                case ConnectionTypes.PostgreSQL:
                    return "@";

                case ConnectionTypes.Oracle:
                    //case ConnectionTypes.FireBird:
                    //case ConnectionTypes.SqlBase:
                    return ":";

                case ConnectionTypes.Odbc:
                    return "?";

                default:
                    //case ConnectionTypes.DB2:
                    //case ConnectionTypes.Informix:
                    //case ConnectionTypes.Ingres:
                    //case ConnectionTypes.Sybase:
                    //case ConnectionTypes.Synergy:
                    //case ConnectionTypes.U2:
                    return String.Empty;
            }
        }
        #endregion


        #region [ Get Prefix ]

        /// <summary>
        /// Returns Prefix for columns and tables according to Connection Type.
        /// </summary>
        /// <returns> Returns Prefix for columns and tables according to Connection Type.</returns>
        private String GetPrefix()
        {
            String _prefix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                //case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                    _prefix = "[";
                    break;

                case ConnectionTypes.PostgreSQL:
                    _prefix = "\"";
                    break;

                default:
                    break;
            }
            return _prefix;
        }

        #endregion


        #region [ Get Suffix ]

        /// <summary>
        /// Returns Suffix for columns and tables according to Connection Type.
        /// </summary>
        /// <returns>Returns Suffix for columns and tables according to Connection Type.</returns>
        private String GetSuffix()
        {
            String _suffix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                //case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                    _suffix = "]";
                    break;

                case ConnectionTypes.PostgreSQL:
                    _suffix = "\"";
                    break;

                default:
                    break;
            }
            return _suffix;
        }

        #endregion


        #region [ Get Identity Insert ]

        /// <summary>
        /// Returns GetIdentity query part of InsertAndGetId.
        /// </summary>
        /// <returns> Returns GetIdentity query part of InsertAndGetId. </returns>
        private String GetIdentityInsert()
        {
            switch (_ConnType)
            {
                case ConnectionTypes.Oledb:
                case ConnectionTypes.SqlServer:
                    //case ConnectionTypes.VistaDB:
                    return "SELECT SCOPE_IDENTITY();";//String.Format("SELECT IDENT_CURRENT('{0}');", _baseBO.GetTable());

                case ConnectionTypes.SqlServerCe:
                    return string.Format("SELECT MAX({0}) AS ID_COL FROM {1};", _baseBO.IdCol, _baseBO.TableName);

                case ConnectionTypes.Oracle:
                    return String.Format("Returning {0}{1}{2} As IdCol", GetPrefix(), _baseBO.IdCol, GetSuffix());

                case ConnectionTypes.SQLite:
                    return "select last_insert_rowid();";

                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDb:
                    return "SELECT LAST_INSERT_ID();";

                case ConnectionTypes.PostgreSQL:
                    return "SELECT LASTVAL();";

                default:
                    throw new NotSupportedException("Unsupported Driver Type For Identity Insert Method.");
            }
        }

        #endregion


        #region [ ToString method ]

        /// <summary>
        /// Returns Query String of QueryBuilder.
        /// </summary>
        /// <returns>Returns Query String of QueryBuilder.</returns>
        public override String ToString()
        {
            return _queryString;
        }

        #endregion

    }
}