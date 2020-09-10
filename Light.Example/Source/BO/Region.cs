using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Region : BaseBO
    {
        public Region()
        {
            tableProp.TableName = "Region";
            tableProp.IdCol = "";
        }

        private int _RegionID;
        public int RegionID
        {
            set { _RegionID = value; tableProp.Put("RegionID", _RegionID); }
            get { return _RegionID; }
        }

        private char _RegionDescription;
        public char RegionDescription
        {
            set { _RegionDescription = value; tableProp.Put("RegionDescription", _RegionDescription); }
            get { return _RegionDescription; }
        }


        internal int Insert()
        {
            try
            {
                using (RegionDL _regiondlDL = new RegionDL())
                {
                    return _regiondlDL.Insert(this);
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
                using (RegionDL _regiondlDL = new RegionDL())
                {
                    return _regiondlDL.InsertAndGetId(this);
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
                using (RegionDL _regiondlDL = new RegionDL())
                {
                    return _regiondlDL.Update(this);
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
                using (RegionDL _regiondlDL = new RegionDL())
                {
                    return _regiondlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}