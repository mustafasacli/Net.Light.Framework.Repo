using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class CustomerDemographics : BaseBO
    {
        public CustomerDemographics()
        {
            tableProp.TableName = "CustomerDemographics";
            tableProp.IdCol = "";
        }

        private char _CustomerTypeID;
        public char CustomerTypeID
        {
            set { _CustomerTypeID = value; tableProp.Put("CustomerTypeID", _CustomerTypeID); }
            get { return _CustomerTypeID; }
        }

        private string _CustomerDesc;
        public string CustomerDesc
        {
            set { _CustomerDesc = value; tableProp.Put("CustomerDesc", _CustomerDesc); }
            get { return _CustomerDesc; }
        }


        internal int Insert()
        {
            try
            {
                using (CustomerDemographicsDL _customerdemographicsdlDL = new CustomerDemographicsDL())
                {
                    return _customerdemographicsdlDL.Insert(this);
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
                using (CustomerDemographicsDL _customerdemographicsdlDL = new CustomerDemographicsDL())
                {
                    return _customerdemographicsdlDL.InsertAndGetId(this);
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
                using (CustomerDemographicsDL _customerdemographicsdlDL = new CustomerDemographicsDL())
                {
                    return _customerdemographicsdlDL.Update(this);
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
                using (CustomerDemographicsDL _customerdemographicsdlDL = new CustomerDemographicsDL())
                {
                    return _customerdemographicsdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}