using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class CategoriesDL : BaseDL
    {
        internal CategoriesDL()
            : base()
        {
        }

        public List<Categories> Categories
        {
            get
            {
                List<Categories> lst = new List<Categories>();
                try
                {
                    lst = TableRecords<Categories>();
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