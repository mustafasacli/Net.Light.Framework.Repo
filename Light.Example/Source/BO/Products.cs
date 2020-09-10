using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Products : BaseBO
    {
        public Products()
        {
            tableProp.TableName = "Products";
            tableProp.IdCol = "ProductID";
        }

        private int _ProductID;
        public int ProductID
        {
            set { _ProductID = value; tableProp.Put("ProductID", _ProductID); }
            get { return _ProductID; }
        }

        private string _ProductName;
        public string ProductName
        {
            set { _ProductName = value; tableProp.Put("ProductName", _ProductName); }
            get { return _ProductName; }
        }

        private int _SupplierID;
        public int SupplierID
        {
            set { _SupplierID = value; tableProp.Put("SupplierID", _SupplierID); }
            get { return _SupplierID; }
        }

        private int _CategoryID;
        public int CategoryID
        {
            set { _CategoryID = value; tableProp.Put("CategoryID", _CategoryID); }
            get { return _CategoryID; }
        }

        private string _QuantityPerUnit;
        public string QuantityPerUnit
        {
            set { _QuantityPerUnit = value; tableProp.Put("QuantityPerUnit", _QuantityPerUnit); }
            get { return _QuantityPerUnit; }
        }

        private decimal _UnitPrice;
        public decimal UnitPrice
        {
            set { _UnitPrice = value; tableProp.Put("UnitPrice", _UnitPrice); }
            get { return _UnitPrice; }
        }

        private Int16 _UnitsInStock;
        public Int16 UnitsInStock
        {
            set { _UnitsInStock = value; tableProp.Put("UnitsInStock", _UnitsInStock); }
            get { return _UnitsInStock; }
        }

        private Int16 _UnitsOnOrder;
        public Int16 UnitsOnOrder
        {
            set { _UnitsOnOrder = value; tableProp.Put("UnitsOnOrder", _UnitsOnOrder); }
            get { return _UnitsOnOrder; }
        }

        private Int16 _ReorderLevel;
        public Int16 ReorderLevel
        {
            set { _ReorderLevel = value; tableProp.Put("ReorderLevel", _ReorderLevel); }
            get { return _ReorderLevel; }
        }

        private bool _Discontinued;
        public bool Discontinued
        {
            set { _Discontinued = value; tableProp.Put("Discontinued", _Discontinued); }
            get { return _Discontinued; }
        }


        internal int Insert()
        {
            try
            {
                using (ProductsDL _productsdlDL = new ProductsDL())
                {
                    return _productsdlDL.Insert(this);
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
                using (ProductsDL _productsdlDL = new ProductsDL())
                {
                    return _productsdlDL.InsertAndGetId(this);
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
                using (ProductsDL _productsdlDL = new ProductsDL())
                {
                    return _productsdlDL.Update(this);
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
                using (ProductsDL _productsdlDL = new ProductsDL())
                {
                    return _productsdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}