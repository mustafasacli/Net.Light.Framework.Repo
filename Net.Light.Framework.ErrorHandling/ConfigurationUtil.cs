using System;
using System.Xml;

namespace Net.Light.Framework.ErrorHandling
{
    #region [ ConfigurationUtil class ]

    internal static class ConfigurationUtil
    {
        private static readonly String XML_FILE_PATH = @"C:\Light\config\conf.xml";
        private static readonly String SAVE_NODE = "appsettings/appconfig/log-setting";

        public static String LogType
        {
            get
            {
                string _logType = string.Empty;
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(XML_FILE_PATH);
                    XmlNodeList saveNodeList = xmlDoc.SelectNodes(SAVE_NODE);

                    foreach (XmlNode node in saveNodeList)
                    {
                        _logType = node.SelectSingleNode("log-type").InnerText;
                    }
                }
                catch (Exception)
                {
                    _logType = "file";
                }
                return _logType;
            }
        }

        public static String SaveFilePath
        {
            get
            {
                string _savePath = string.Empty;
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(XML_FILE_PATH);
                    XmlNodeList saveNodeList = xmlDoc.SelectNodes(SAVE_NODE);

                    foreach (XmlNode node in saveNodeList)
                    {
                        _savePath = node.SelectSingleNode("log-path").InnerText;
                    }
                }
                catch (Exception)
                {
                    _savePath = @"C:\\Light\log\log.txt";
                }
                return _savePath;
            }
        }



    }

    #endregion

}
