using Net.Light.Framework.Base;
using Net.Light.Framework.Data.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Light.Framework.ConnectionStringBuilding.Test
{

    internal class ConnectionTester
    {
        public static bool TestConnection(ConnectionTypes connType, string connectionString)
        {
            bool retBool = false;
            try
            {
                using (IConnection conn = ConnectionFactory.CreateConnection(connType, connectionString))
                {
                    conn.Open();
                    retBool = true;
                    conn.Close();
                }
                FrmSecureHash.Error = retBool == true ? "Valid Connection" : "Unknown Error.";
            }
            catch (Exception exc)
            {
                FrmSecureHash.Error = exc.Message;
                retBool = false;
            }
            return retBool;
        }
    }
}