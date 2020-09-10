using Net.Light.Framework.Base;
using Net.Light.Framework.ConnectionStringBuilding.Encryption;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Net.Light.Framework.ConnectionStringBuilding.PropertyBuilding
{
    internal class PropertyBuilder
    {
        private static List<string> paramHashList = new List<string>()
       {
       "uid",
       "userid",
       "logonid",
       "user",
       "username",
       "pwd",
       "password"
       };

        #region [ Build method ]

        public static string Build(ConnectionTypes connType, string propertyName, string strProperty)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strProperty) == true)
                    throw new Exception("StrProperty is null or empty.");

                string strConnType = GetConnectionType(connType);

                string[] crypted = strProperty.Split(';', '=');

                for (int i = 0; i < crypted.Length; i++)
                {
                    crypted[i] = Encryptor.EncodeString(crypted[i]);
                }
                XmlDocument xmlDoc = new XmlDocument();

                XmlNode mainNode = CreateNode(xmlDoc, "properties", "name", "driver-type", "conn-str");
                mainNode.Attributes["name"].InnerText = propertyName;
                mainNode.Attributes["driver-type"].InnerText = strConnType;
                mainNode.Attributes["conn-str"].InnerText = strProperty;

                XmlNode childNode = null;
                for (int cryptedCounter = 0; cryptedCounter < crypted.Length - 1; cryptedCounter += 2)
                {
                    childNode = CreateNode(xmlDoc, "property", "key", "value");
                    childNode.Attributes["key"].InnerText = crypted[cryptedCounter];
                    childNode.Attributes["value"].InnerText = crypted[cryptedCounter + 1];
                    mainNode.AppendChild(childNode);
                }
                childNode = null;
                xmlDoc.AppendChild(mainNode);
                return xmlDoc.OuterXml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ BuildNew method ]

        public static string BuildNew(ConnectionTypes connType, string propertyName, string strProperty)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strProperty) == true)
                    throw new Exception("StrProperty is null or empty.");

                string strConnType = GetConnectionType(connType);

                string[] crypted = strProperty.Split(';', '=');

                Property p = Property.CreateFromStringSplit(strProperty, ';', '=');
                List<FreeParameter> parameters = p.GetParameters();
                string str;
                List<string> paramHashList = new List<string>()
                {
                    "uid",
                "userid",
                "logonid",
                "user",
                "username",
                "pwd",
                "password"
                };
                string strPrm;
                p = null;
                p = Property.Instance;
                foreach (FreeParameter prm in parameters)
                {
                    str = string.Format("{0}", prm.Value);
                    strPrm = prm.Name.ToLower().Replace('ı', 'i');
                    strPrm = strPrm.Replace(" ", "");

                    if (paramHashList.Contains(strPrm))
                    {
                        str = Encryptor.EncodeString(str);
                    }
                    p.Put(prm.Name.TrimStart().TrimEnd(), str);
                }

                XmlDocument xmlDoc = new XmlDocument();

                XmlNode mainNode = CreateNode(xmlDoc, "properties", "name", "driver-type", "conn-str");
                mainNode.Attributes["name"].InnerText = propertyName;
                mainNode.Attributes["driver-type"].InnerText = strConnType;
                mainNode.Attributes["conn-str"].InnerText = strProperty;

                XmlNode childNode = null;
                parameters = new List<FreeParameter>();
                parameters = p.GetParameters();
                for (int cryptedCounter = 0; cryptedCounter < parameters.Count; cryptedCounter++)
                {
                    childNode = CreateNode(xmlDoc, "property", "key", "value");
                    childNode.Attributes["key"].InnerText = parameters[cryptedCounter].Name;
                    childNode.Attributes["value"].InnerText = string.Format("{0}", parameters[cryptedCounter].Value);
                    mainNode.AppendChild(childNode);
                }
                childNode = null;
                xmlDoc.AppendChild(mainNode);
                xmlDoc.Normalize();
                return xmlDoc.OuterXml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ BuildNew-2 method ]

        public static string BuildNew(ConnectionTypes connType, string propertyName, string strProperty, bool hasContainsConnStr)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strProperty) == true)
                    throw new Exception("StrProperty is null or empty.");

                string strConnType = GetConnectionType(connType);

                string[] crypted = strProperty.Split(';', '=');

                Property p = Property.CreateFromStringSplit(strProperty, ';', '=');
                List<FreeParameter> parameters = p.GetParameters();
                string str;
                string strPrm;
                p = null;
                p = Property.Instance;
                foreach (FreeParameter prm in parameters)
                {
                    str = string.Format("{0}", prm.Value);
                    strPrm = prm.Name.ToLower().Replace('ı', 'i');
                    strPrm = strPrm.Replace(" ", "");

                    if (paramHashList.Contains(strPrm))
                    {
                        str = Encryptor.EncodeString(str);
                    }
                    p.Put(prm.Name.TrimStart().TrimEnd(), str);
                }

                XmlDocument xmlDoc = new XmlDocument();

                XmlNode mainNode = CreateNode(xmlDoc, "properties", "name", "driver-type", "conn-str");
                mainNode.Attributes["name"].InnerText = propertyName;
                mainNode.Attributes["driver-type"].InnerText = strConnType;
                if (hasContainsConnStr)
                {
                    mainNode.Attributes["conn-str"].InnerText = strProperty;
                }
                XmlNode childNode = null;
                parameters = new List<FreeParameter>();
                parameters = p.GetParameters();
                for (int cryptedCounter = 0; cryptedCounter < parameters.Count; cryptedCounter++)
                {
                    childNode = CreateNode(xmlDoc, "property", "key", "value");
                    childNode.Attributes["key"].InnerText = parameters[cryptedCounter].Name;
                    childNode.Attributes["value"].InnerText = string.Format("{0}", parameters[cryptedCounter].Value);
                    mainNode.AppendChild(childNode);
                }
                childNode = null;
                xmlDoc.AppendChild(mainNode);
                xmlDoc.Normalize();
                return xmlDoc.OuterXml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ CreateNode method ]

        internal static XmlNode CreateNode(XmlDocument xml_doc, string nodeName, params object[] attrs)
        {
            try
            {
                XmlNode node = xml_doc.CreateElement(nodeName);

                XmlAttribute attr;
                foreach (object obj in attrs)
                {
                    if (String.Format("{0}", obj).Length > 0)
                    {
                        attr = xml_doc.CreateAttribute(obj.ToString());
                        node.Attributes.Append(attr);
                    }
                }

                return node;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ GetConnectionType method ]

        internal static string GetConnectionType(ConnectionTypes connType)
        {
            switch (connType)
            {
                default:
                    return string.Empty;

                case ConnectionTypes.SqlServer:
                    return "sqlserver";

                case ConnectionTypes.PostgreSQL:
                    return "postgresql";

                case ConnectionTypes.Oracle:
                    return "oracle";

                case ConnectionTypes.MySQL:
                    return "mysql";

                case ConnectionTypes.MariaDb:
                    return "mariadb";

                case ConnectionTypes.Oledb:
                    return "oledb";

                case ConnectionTypes.SQLite:
                    return "sqlite";

                case ConnectionTypes.SqlServerCe:
                    return "sqlserverce";

                /*
                case ConnectionTypes.DB2:
                    return "db2";

                case ConnectionTypes.OracleManaged:
                    return "oracle-managed";

                case ConnectionTypes.VistaDB:
                    return "vistadb";

                case ConnectionTypes.Sybase:
                    return "sybase";

                case ConnectionTypes.Informix:
                    return "informix";

                case ConnectionTypes.FireBird:
                    return "firebird";

                case ConnectionTypes.U2:
                    return "u2";

                case ConnectionTypes.Synergy:
                    return "synergy";

                case ConnectionTypes.Ingres:
                    return "ingres";
               

                case ConnectionTypes.SqlBase:
                    return "sqlbase";
                */
                case ConnectionTypes.Odbc:
                    return "odbc";
            }
        }

        #endregion
    }
}