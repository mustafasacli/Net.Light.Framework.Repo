using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class SuppliersDL : BaseDL
    {
        internal SuppliersDL()
            : base()
        {
        }

        public List<Suppliers> Suppliers
        {
            get
            {
                List<Suppliers> lst = new List<Suppliers>();
                try
                {
                    lst = TableRecords<Suppliers>();
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