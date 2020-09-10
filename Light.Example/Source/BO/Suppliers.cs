using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Suppliers : BaseBO
    {
        public Suppliers()
        {
            tableProp.TableName = "Suppliers";
            tableProp.IdCol = "SupplierID";
        }

        private int _SupplierID;
        public int SupplierID
        {
            set { _SupplierID = value; tableProp.Put("SupplierID", _SupplierID); }
            get { return _SupplierID; }
        }

        private string _CompanyName;
        public string CompanyName
        {
            set { _CompanyName = value; tableProp.Put("CompanyName", _CompanyName); }
            get { return _CompanyName; }
        }

        private string _ContactName;
        public string ContactName
        {
            set { _ContactName = value; tableProp.Put("ContactName", _ContactName); }
            get { return _ContactName; }
        }

        private string _ContactTitle;
        public string ContactTitle
        {
            set { _ContactTitle = value; tableProp.Put("ContactTitle", _ContactTitle); }
            get { return _ContactTitle; }
        }

        private string _Address;
        public string Address
        {
            set { _Address = value; tableProp.Put("Address", _Address); }
            get { return _Address; }
        }

        private string _City;
        public string City
        {
            set { _City = value; tableProp.Put("City", _City); }
            get { return _City; }
        }

        private string _Region;
        public string Region
        {
            set { _Region = value; tableProp.Put("Region", _Region); }
            get { return _Region; }
        }

        private string _PostalCode;
        public string PostalCode
        {
            set { _PostalCode = value; tableProp.Put("PostalCode", _PostalCode); }
            get { return _PostalCode; }
        }

        private string _Country;
        public string Country
        {
            set { _Country = value; tableProp.Put("Country", _Country); }
            get { return _Country; }
        }

        private string _Phone;
        public string Phone
        {
            set { _Phone = value; tableProp.Put("Phone", _Phone); }
            get { return _Phone; }
        }

        private string _Fax;
        public string Fax
        {
            set { _Fax = value; tableProp.Put("Fax", _Fax); }
            get { return _Fax; }
        }

        private string _HomePage;
        public string HomePage
        {
            set { _HomePage = value; tableProp.Put("HomePage", _HomePage); }
            get { return _HomePage; }
        }


        internal int Insert()
        {
            try
            {
                using (SuppliersDL _suppliersdlDL = new SuppliersDL())
                {
                    return _suppliersdlDL.Insert(this);
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
                using (SuppliersDL _suppliersdlDL = new SuppliersDL())
                {
                    return _suppliersdlDL.InsertAndGetId(this);
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
                using (SuppliersDL _suppliersdlDL = new SuppliersDL())
                {
                    return _suppliersdlDL.Update(this);
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
                using (SuppliersDL _suppliersdlDL = new SuppliersDL())
                {
                    return _suppliersdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}