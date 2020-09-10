using Net.Light.Framework.Logic.BaseDal;
using System;

namespace Net.Light.Framework.ErrorHandling
{
    internal class LogDL : BaseDL
    {
        public LogDL()
            : base()
        { }

        public LogDL(String logName)
            : base(logName)
        {
        }
    }
}