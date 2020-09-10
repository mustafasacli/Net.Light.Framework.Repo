using Net.Light.Framework.Entity.Base;
using System;

namespace Net.Light.Framework.ErrorHandling
{
    internal class Log : BaseBO
    {
        private Int32 _OBJID;
        private String _Message;
        private String _StackTrace;
        private String _Title;
        private String _LogCode;
        private Int32 _UserId;
        private Int32 _LogType;
        private DateTime _LogTime;

        public Log(Int32 userId)
        {
            UserId = userId;
            LogTime = DateTime.Now;
            tableProp.IdCol = "OBJID";
            tableProp.TableName = "FreeLogEntry";
            tableProp.Put("MachineName", this.MachineName);
        }

        public Log()
        {
            LogTime = DateTime.Now;
            tableProp.IdCol = "OBJID";
            tableProp.TableName = "FreeLogEntry";
            tableProp.Put("MachineName", this.MachineName);
        }


        public Int32 OBJID
        {
            set { _OBJID = value; tableProp.Put("OBJID", _OBJID); }
            get { return _OBJID; }
        }

        public String Message
        {
            set { _Message = value; tableProp.Put("Message", _Message); }
            get { return _Message; }
        }
        public String StackTrace
        {
            set { _StackTrace = value; tableProp.Put("StackTrace", _StackTrace); }
            get { return _StackTrace; }
        }
        public String Title
        {
            set { _Title = value; tableProp.Put("Title", _Title); }
            get { return _Title; }
        }
        public String LogCode
        {
            set { _LogCode = value; tableProp.Put("LogCode", _LogCode); }
            get { return _LogCode; }
        }
        public Int32 UserId
        {
            set { _UserId = value; tableProp.Put("UserId", _UserId); }
            get { return _UserId; }
        }
        public DateTime LogTime
        {
            set { _LogTime = value; tableProp.Put("LogTime", _LogTime); }
            get { return _LogTime; }
        }
        public Int32 LogType
        {
            set { _LogType = value; tableProp.Put("LogType", _LogType); }
            get { return _LogType; }
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

    }
}