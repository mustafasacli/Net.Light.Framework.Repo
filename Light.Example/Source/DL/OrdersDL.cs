using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class OrdersDL : BaseDL
    {
        internal OrdersDL()
            : base()
        {
        }

        public List<Orders> Orders
        {
            get
            {
                List<Orders> lst = new List<Orders>();
                try
                {
                    lst = TableRecords<Orders>();
                }
                catch (Exception)
                {
                    throw;
                }
                return lst;
            }
        }
    }
}