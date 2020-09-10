using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Shippers : BaseBO
    {
        public Shippers()
        {
            tableProp.TableName = "Shippers";
            tableProp.IdCol = "ShipperID";
        }

        private int _ShipperID;
        public int ShipperID
        {
            set { _ShipperID = value; tableProp.Put("ShipperID", _ShipperID); }
            get { return _ShipperID; }
        }

        private string _CompanyName;
        public string CompanyName
        {
            set { _CompanyName = value; tableProp.Put("CompanyName", _CompanyName); }
            get { return _CompanyName; }
        }

        private string _Phone;
        public string Phone
        {
            set { _Phone = value; tableProp.Put("Phone", _Phone); }
            get { return _Phone; }
        }


        internal int Insert()
        {
            try
            {
                using (ShippersDL _shippersdlDL = new ShippersDL())
                {
                    return _shippersdlDL.Insert(this);
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
                using (ShippersDL _shippersdlDL = new ShippersDL())
                {
                    return _shippersdlDL.InsertAndGetId(this);
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
                using (ShippersDL _shippersdlDL = new ShippersDL())
                {
                    return _shippersdlDL.Update(this);
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
                using (ShippersDL _shippersdlDL = new ShippersDL())
                {
                    return _shippersdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}