using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class OrderDetails : BaseBO
    {
        public OrderDetails()
        {
            tableProp.TableName = "Order Details";
            tableProp.IdCol = "";
        }

        private int _OrderID;
        public int OrderID
        {
            set { _OrderID = value; tableProp.Put("OrderID", _OrderID); }
            get { return _OrderID; }
        }

        private int _ProductID;
        public int ProductID
        {
            set { _ProductID = value; tableProp.Put("ProductID", _ProductID); }
            get { return _ProductID; }
        }

        private decimal _UnitPrice;
        public decimal UnitPrice
        {
            set { _UnitPrice = value; tableProp.Put("UnitPrice", _UnitPrice); }
            get { return _UnitPrice; }
        }

        private Int16 _Quantity;
        public Int16 Quantity
        {
            set { _Quantity = value; tableProp.Put("Quantity", _Quantity); }
            get { return _Quantity; }
        }

        private float _Discount;
        public float Discount
        {
            set { _Discount = value; tableProp.Put("Discount", _Discount); }
            get { return _Discount; }
        }


        internal int Insert()
        {
            try
            {
                using (OrderDetailsDL _orderdetailsdlDL = new OrderDetailsDL())
                {
                    return _orderdetailsdlDL.Insert(this);
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
                using (OrderDetailsDL _orderdetailsdlDL = new OrderDetailsDL())
                {
                    return _orderdetailsdlDL.InsertAndGetId(this);
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
                using (OrderDetailsDL _orderdetailsdlDL = new OrderDetailsDL())
                {
                    return _orderdetailsdlDL.Update(this);
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
                using (OrderDetailsDL _orderdetailsdlDL = new OrderDetailsDL())
                {
                    return _orderdetailsdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}