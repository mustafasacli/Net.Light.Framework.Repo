using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Orders : BaseBO
    {
        public Orders()
        {
            tableProp.TableName = "Orders";
            tableProp.IdCol = "OrderID";
        }

        private int _OrderID;
        public int OrderID
        {
            set { _OrderID = value; tableProp.Put("OrderID", _OrderID); }
            get { return _OrderID; }
        }

        private char _CustomerID;
        public char CustomerID
        {
            set { _CustomerID = value; tableProp.Put("CustomerID", _CustomerID); }
            get { return _CustomerID; }
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            set { _EmployeeID = value; tableProp.Put("EmployeeID", _EmployeeID); }
            get { return _EmployeeID; }
        }

        private DateTime _OrderDate;
        public DateTime OrderDate
        {
            set { _OrderDate = value; tableProp.Put("OrderDate", _OrderDate); }
            get { return _OrderDate; }
        }

        private DateTime _RequiredDate;
        public DateTime RequiredDate
        {
            set { _RequiredDate = value; tableProp.Put("RequiredDate", _RequiredDate); }
            get { return _RequiredDate; }
        }

        private DateTime _ShippedDate;
        public DateTime ShippedDate
        {
            set { _ShippedDate = value; tableProp.Put("ShippedDate", _ShippedDate); }
            get { return _ShippedDate; }
        }

        private int _ShipVia;
        public int ShipVia
        {
            set { _ShipVia = value; tableProp.Put("ShipVia", _ShipVia); }
            get { return _ShipVia; }
        }

        private decimal _Freight;
        public decimal Freight
        {
            set { _Freight = value; tableProp.Put("Freight", _Freight); }
            get { return _Freight; }
        }

        private string _ShipName;
        public string ShipName
        {
            set { _ShipName = value; tableProp.Put("ShipName", _ShipName); }
            get { return _ShipName; }
        }

        private string _ShipAddress;
        public string ShipAddress
        {
            set { _ShipAddress = value; tableProp.Put("ShipAddress", _ShipAddress); }
            get { return _ShipAddress; }
        }

        private string _ShipCity;
        public string ShipCity
        {
            set { _ShipCity = value; tableProp.Put("ShipCity", _ShipCity); }
            get { return _ShipCity; }
        }

        private string _ShipRegion;
        public string ShipRegion
        {
            set { _ShipRegion = value; tableProp.Put("ShipRegion", _ShipRegion); }
            get { return _ShipRegion; }
        }

        private string _ShipPostalCode;
        public string ShipPostalCode
        {
            set { _ShipPostalCode = value; tableProp.Put("ShipPostalCode", _ShipPostalCode); }
            get { return _ShipPostalCode; }
        }

        private string _ShipCountry;
        public string ShipCountry
        {
            set { _ShipCountry = value; tableProp.Put("ShipCountry", _ShipCountry); }
            get { return _ShipCountry; }
        }


        internal int Insert()
        {
            try
            {
                using (OrdersDL _ordersdlDL = new OrdersDL())
                {
                    return _ordersdlDL.Insert(this);
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
                using (OrdersDL _ordersdlDL = new OrdersDL())
                {
                    return _ordersdlDL.InsertAndGetId(this);
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
                using (OrdersDL _ordersdlDL = new OrdersDL())
                {
                    return _ordersdlDL.Update(this);
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
                using (OrdersDL _ordersdlDL = new OrdersDL())
                {
                    return _ordersdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}