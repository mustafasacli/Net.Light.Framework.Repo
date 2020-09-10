using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class EmployeeTerritories : BaseBO
    {
        public EmployeeTerritories()
        {
            tableProp.TableName = "EmployeeTerritories";
            tableProp.IdCol = "";
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            set { _EmployeeID = value; tableProp.Put("EmployeeID", _EmployeeID); }
            get { return _EmployeeID; }
        }

        private string _TerritoryID;
        public string TerritoryID
        {
            set { _TerritoryID = value; tableProp.Put("TerritoryID", _TerritoryID); }
            get { return _TerritoryID; }
        }


        internal int Insert()
        {
            try
            {
                using (EmployeeTerritoriesDL _employeeterritoriesdlDL = new EmployeeTerritoriesDL())
                {
                    return _employeeterritoriesdlDL.Insert(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertAndGetId()
        {
            try
            {
                using (EmployeeTerritoriesDL _employeeterritoriesdlDL = new EmployeeTerritoriesDL())
                {
                    return _employeeterritoriesdlDL.InsertAndGetId(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Update()
        {
            try
            {
                using (EmployeeTerritoriesDL _employeeterritoriesdlDL = new EmployeeTerritoriesDL())
                {
                    return _employeeterritoriesdlDL.Update(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Delete()
        {
            try
            {
                using (EmployeeTerritoriesDL _employeeterritoriesdlDL = new EmployeeTerritoriesDL())
                {
                    return _employeeterritoriesdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}