using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Categories : BaseBO
    {
        private int _CategoryID;

        private string _CategoryName;

        private string _Description;

        private byte[] _Picture;

        public Categories()
            : base()
        {
            tableProp.TableName = "Categories";
            tableProp.IdCol = "CategoryID";
        }
        public int CategoryID
        {
            set { _CategoryID = value; tableProp.Put("CategoryID", _CategoryID); }
            get { return _CategoryID; }
        }
        public string CategoryName
        {
            set { _CategoryName = value; tableProp.Put("CategoryName", _CategoryName); }
            get { return _CategoryName; }
        }
        public string Description
        {
            set { _Description = value; tableProp.Put("Description", _Description); }
            get { return _Description; }
        }
        public byte[] Picture
        {
            set { _Picture = value; tableProp.Put("Picture", _Picture); }
            get { return _Picture; }
        }

        internal int Delete()
        {
            try
            {
                using (CategoriesDL _categoriesdlDL = new CategoriesDL())
                {
                    return _categoriesdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Insert()
        {
            try
            {
                using (CategoriesDL _categoriesdlDL = new CategoriesDL())
                {
                    return _categoriesdlDL.Insert(this);
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
                using (CategoriesDL _categoriesdlDL = new CategoriesDL())
                {
                    return _categoriesdlDL.InsertAndGetId(this);
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
                using (CategoriesDL _categoriesdlDL = new CategoriesDL())
                {
                    return _categoriesdlDL.Update(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}