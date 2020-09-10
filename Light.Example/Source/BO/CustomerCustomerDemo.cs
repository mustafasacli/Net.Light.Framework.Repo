using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class CustomerCustomerDemo : BaseBO
    {
        public CustomerCustomerDemo()
        {
            tableProp.TableName = "CustomerCustomerDemo";
            tableProp.IdCol = "";
        }

        private char _CustomerID;
        public char CustomerID
        {
            set { _CustomerID = value; tableProp.Put("CustomerID", _CustomerID); }
            get { return _CustomerID; }
        }

        private char _CustomerTypeID;
        public char CustomerTypeID
        {
            set { _CustomerTypeID = value; tableProp.Put("CustomerTypeID", _CustomerTypeID); }
            get { return _CustomerTypeID; }
        }


        internal int Insert()
        {
            try
            {
                using (CustomerCustomerDemoDL _customercustomerdemodlDL = new CustomerCustomerDemoDL())
                {
                    return _customercustomerdemodlDL.Insert(this);
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
                using (CustomerCustomerDemoDL _customercustomerdemodlDL = new CustomerCustomerDemoDL())
                {
                    return _customercustomerdemodlDL.InsertAndGetId(this);
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
                using (CustomerCustomerDemoDL _customercustomerdemodlDL = new CustomerCustomerDemoDL())
                {
                    return _customercustomerdemodlDL.Update(this);
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
                using (CustomerCustomerDemoDL _customercustomerdemodlDL = new CustomerCustomerDemoDL())
                {
                    return _customercustomerdemodlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}