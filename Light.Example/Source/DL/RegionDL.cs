using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class RegionDL : BaseDL
    {
        internal RegionDL()
            : base()
        {
        }


        public List<Region> Regions
        {
            get
            {
                List<Region> lst = new List<Region>();
                try
                {
                    lst = TableRecords<Region>();
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