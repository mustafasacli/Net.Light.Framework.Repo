using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class ShippersDL : BaseDL
    {
        internal ShippersDL()
            : base()
        {
        }


        public List<Shippers> Shippers
        {
            get
            {
                List<Shippers> lst = new List<Shippers>();
                try
                {
                    lst = TableRecords<Shippers>();
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