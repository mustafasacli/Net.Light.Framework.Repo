using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class EmployeeTerritoriesDL : BaseDL
    {
        internal EmployeeTerritoriesDL()
            : base()
        {
        }


        public List<EmployeeTerritories> EmployeeTerritories
        {
            get
            {
                List<EmployeeTerritories> lst = new List<EmployeeTerritories>();
                try
                {
                    lst = TableRecords<EmployeeTerritories>();
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