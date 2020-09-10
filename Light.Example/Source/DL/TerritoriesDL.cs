using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class TerritoriesDL : BaseDL
    {
        internal TerritoriesDL()
            : base()
        {
        }

        public List<Territories> Territories
        {
            get
            {
                List<Territories> lst = new List<Territories>();
                try
                {
                    lst = TableRecords<Territories>();
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