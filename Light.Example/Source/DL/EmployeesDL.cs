using Light.Example.Source.BO;
using Net.Light.Framework.Logic.BaseDal;
using System;
using System.Collections.Generic;

namespace Light.Example.Source.DL
{
    internal class EmployeesDL : BaseDL
    {
        internal EmployeesDL()
            : base()
        {
        }


        public List<Employees> Employees
        {
            get
            {
                List<Employees> lst = new List<Employees>();
                try
                {
                    lst = TableRecords<Employees>();
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