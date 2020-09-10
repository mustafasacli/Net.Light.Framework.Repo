using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Territories : BaseBO
    {
        public Territories()
        {
            tableProp.TableName = "Territories";
            tableProp.IdCol = "";
        }

        private string _TerritoryID;

        public string TerritoryID
        {
            set { _TerritoryID = value; tableProp.Put("TerritoryID", _TerritoryID); }
            get { return _TerritoryID; }
        }

        private char _TerritoryDescription;

        public char TerritoryDescription
        {
            set { _TerritoryDescription = value; tableProp.Put("TerritoryDescription", _TerritoryDescription); }
            get { return _TerritoryDescription; }
        }

        private int _RegionID;

        public int RegionID
        {
            set { _RegionID = value; tableProp.Put("RegionID", _RegionID); }
            get { return _RegionID; }
        }

        internal int Insert()
        {
            try
            {
                using (TerritoriesDL _territoriesdlDL = new TerritoriesDL())
                {
                    return _territoriesdlDL.Insert(this);
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
                using (TerritoriesDL _territoriesdlDL = new TerritoriesDL())
                {
                    return _territoriesdlDL.InsertAndGetId(this);
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
                using (TerritoriesDL _territoriesdlDL = new TerritoriesDL())
                {
                    return _territoriesdlDL.Update(this);
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
                using (TerritoriesDL _territoriesdlDL = new TerritoriesDL())
                {
                    return _territoriesdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}