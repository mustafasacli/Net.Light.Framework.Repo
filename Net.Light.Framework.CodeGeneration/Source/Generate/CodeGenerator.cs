using Net.Light.Framework.Base;
using Net.Light.Framework.CodeGeneration.Source.BLH;
using Net.Light.Framework.CodeGeneration.Source.BO;
using Net.Light.Framework.CodeGeneration.Source.QO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Net.Light.Framework.CodeGeneration.Source.Generate
{
    internal class CodeGenerator
    {
        public static string ConnStr = string.Empty;
        public static int Index = -1;

        private string _ConnectionString = string.Empty;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private ConnectionTypes _ConnType = ConnectionTypes.SqlServer;

        internal ConnectionTypes ConnType
        {
            get { return _ConnType; }
            set { _ConnType = value; }
        }


        public List<Table> GetTablesAndColumns(ConnectionTypes connectionType, string connStr)
        {
            try
            {
                GeneratorLH genLH = new GeneratorLH();
                return genLH.GetTablesAndColumns(connectionType, connStr);
            }
            catch (Exception)
            {
                throw;
            }
        }             

    }
}