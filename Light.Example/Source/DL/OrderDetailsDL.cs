using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class OrderDetailsDL : BaseDL
    {
        internal OrderDetailsDL()
            : base()
        {
        }


        public List<OrderDetails> OrderDetails
        {
            get
            {
                List<OrderDetails> lst = new List<OrderDetails>();
                try
                {
                    lst = TableRecords<OrderDetails>();
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