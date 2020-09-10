using System;
using Net.Light.Framework.Base;
using Net.Light.Framework.Logic.BaseDal;
using System.Collections.Generic;
using Light.Example.Source.BO;

namespace Light.Example.Source.DL
{
    internal class CustomersDL : BaseDL
    {
        internal CustomersDL()
            : base()
        {
        }


        public List<Customers> Customers
        {
            get
            {
                List<Customers> lst = new List<Customers>();
                try
                {
                    lst = TableRecords<Customers>();
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