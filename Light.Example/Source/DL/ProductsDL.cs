using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class ProductsDL : BaseDL
    {
        internal ProductsDL()
            : base()
        {
        }


        public List<Products> Products
        {
            get
            {
                List<Products> lst = new List<Products>();
                try
                {
                    lst = TableRecords<Products>();
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