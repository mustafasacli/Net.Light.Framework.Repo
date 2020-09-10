using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class CustomerCustomerDemoDL : BaseDL
    {
        internal CustomerCustomerDemoDL()
            : base()
        {
        }


        public List<CustomerCustomerDemo> CustomerCustomerDemos
        {
            get
            {
                List<CustomerCustomerDemo> lst = new List<CustomerCustomerDemo>();
                try
                {
                    lst = TableRecords<CustomerCustomerDemo>();
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