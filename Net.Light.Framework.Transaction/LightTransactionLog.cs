namespace Net.Light.Framework.Transaction
{
    using Net.Light.Framework.Entity.Base;
    using System;
    using System.Xml;

    public sealed class LightTransactionLog : BaseBO, IDisposable
    {
        private Int32 _UserId;
        private String _TransactionType;
        private Int32 _LogObject;
        private DateTime _LogTime;
        private String _ControlTag;
        private String _ControlName;
        private String _FormName;
        private Int32 _OBJID;

        public LightTransactionLog(Int32 userId)
        {
            UserId = userId;
            LogTime = DateTime.Now;
            tableProp.IdCol = "OBJID";
            tableProp.TableName = "TransactionLog";
            tableProp.Put("MachineName", this.MachineName);
        }

        public Int32 OBJID
        {
            set { _OBJID = value; tableProp.Put("OBJID", _OBJID); }
            get { return _OBJID; }
        }
        public String FormName
        {
            set { _FormName = value; tableProp.Put("FormName", _FormName); }
            get { return _FormName; }
        }
        public String ControlName
        {
            set { _ControlName = value; tableProp.Put("ControlName", _ControlName); }
            get { return _ControlName; }
        }
        public String ControlTag
        {
            set { _ControlTag = value; tableProp.Put("ControlTag", _ControlTag); }
            get { return _ControlTag; }
        }
        public DateTime LogTime
        {
            private set { _LogTime = value; tableProp.Put("LogTime", _LogTime); }
            get { return _LogTime; }
        }
        public Int32 LogObject
        {
            set { _LogObject = value; tableProp.Put("LogObject", _LogObject); }
            get { return _LogObject; }
        }
        public String TransactionType
        {
            set { _TransactionType = value; tableProp.Put("TransactionType", _TransactionType); }
            get { return _TransactionType; }
        }
        public Int32 UserId
        {
            set { _UserId = value; tableProp.Put("UserId", _UserId); }
            get { return _UserId; }
        }

        public String MachineName
        {
            get
            {
                string _machineName = string.Empty;
                try
                {
                    _machineName = Environment.MachineName;
                }
                catch (Exception)
                {
                    _machineName = String.Empty;
                }
                return _machineName;
            }
        }

        public Int32 Insert()
        {
            try
            {
                switch (SaveType)
                {
                    case SaveTypes.File:
                    case SaveTypes.Database:
                        using (TransactionLogDL transDL = new TransactionLogDL())
                        {
                            return transDL.Insert(this);
                        }

                    case SaveTypes.Cloud:
                        using (TransactionLogDL transDL = new TransactionLogDL("ext"))
                        {
                            return transDL.Insert(this);
                        }

                    default:
                        return -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private SaveTypes SaveType
        {
            get
            {
                String saveType = ConfigurationUtil.SaveType;
                saveType = saveType.TrimStart().TrimEnd().ToLower();
                switch (saveType)
                {
                    case "db":
                    case "dbase":
                    case "database":
                    default:
                        return SaveTypes.Database;

                    case "cloud":
                    case "cld":
                        return SaveTypes.Cloud;
                }
            }

        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

    }

    internal static class ConfigurationUtil
    {

        private static readonly String XML_FILE_PATH = @"C:\Ligth\config\conf.xml";
        private static readonly String SAVE_NODE = "appsettings/appconfig/log-setting";


        static ConfigurationUtil()
        {
            try
            {
                PrepareConf();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string _saveType = string.Empty;
        public static String SaveType
        {
            get { return _saveType; }
        }


        private static void PrepareConf()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XML_FILE_PATH);
                XmlNodeList saveNodeList = xmlDoc.SelectNodes(SAVE_NODE);

                foreach (XmlNode node in saveNodeList)
                {
                    try
                    {
                        _saveType = node.SelectSingleNode("save-type").InnerText;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}