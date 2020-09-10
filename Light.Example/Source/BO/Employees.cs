using Light.Example.Source.DL;
using Net.Light.Framework.Entity.Base;
using System;

namespace Light.Example.Source.BO
{
    public class Employees : BaseBO
    {
        public Employees()
        {
            tableProp.TableName = "Employees";
            tableProp.IdCol = "EmployeeID";
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            set { _EmployeeID = value; tableProp.Put("EmployeeID", _EmployeeID); }
            get { return _EmployeeID; }
        }

        private string _LastName;
        public string LastName
        {
            set { _LastName = value; tableProp.Put("LastName", _LastName); }
            get { return _LastName; }
        }

        private string _FirstName;
        public string FirstName
        {
            set { _FirstName = value; tableProp.Put("FirstName", _FirstName); }
            get { return _FirstName; }
        }

        private string _Title;
        public string Title
        {
            set { _Title = value; tableProp.Put("Title", _Title); }
            get { return _Title; }
        }

        private string _TitleOfCourtesy;
        public string TitleOfCourtesy
        {
            set { _TitleOfCourtesy = value; tableProp.Put("TitleOfCourtesy", _TitleOfCourtesy); }
            get { return _TitleOfCourtesy; }
        }

        private DateTime _BirthDate;
        public DateTime BirthDate
        {
            set { _BirthDate = value; tableProp.Put("BirthDate", _BirthDate); }
            get { return _BirthDate; }
        }

        private DateTime _HireDate;
        public DateTime HireDate
        {
            set { _HireDate = value; tableProp.Put("HireDate", _HireDate); }
            get { return _HireDate; }
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

        private string _HomePhone;
        public string HomePhone
        {
            set { _HomePhone = value; tableProp.Put("HomePhone", _HomePhone); }
            get { return _HomePhone; }
        }

        private string _Extension;
        public string Extension
        {
            set { _Extension = value; tableProp.Put("Extension", _Extension); }
            get { return _Extension; }
        }

        private byte[] _Photo;
        public byte[] Photo
        {
            set { _Photo = value; tableProp.Put("Photo", _Photo); }
            get { return _Photo; }
        }

        private string _Notes;
        public string Notes
        {
            set { _Notes = value; tableProp.Put("Notes", _Notes); }
            get { return _Notes; }
        }

        private int _ReportsTo;
        public int ReportsTo
        {
            set { _ReportsTo = value; tableProp.Put("ReportsTo", _ReportsTo); }
            get { return _ReportsTo; }
        }

        private string _PhotoPath;
        public string PhotoPath
        {
            set { _PhotoPath = value; tableProp.Put("PhotoPath", _PhotoPath); }
            get { return _PhotoPath; }
        }


        internal int Insert()
        {
            try
            {
                using (EmployeesDL _employeesdlDL = new EmployeesDL())
                {
                    return _employeesdlDL.Insert(this);
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
                using (EmployeesDL _employeesdlDL = new EmployeesDL())
                {
                    return _employeesdlDL.InsertAndGetId(this);
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
                using (EmployeesDL _employeesdlDL = new EmployeesDL())
                {
                    return _employeesdlDL.Update(this);
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
                using (EmployeesDL _employeesdlDL = new EmployeesDL())
                {
                    return _employeesdlDL.Delete(this);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}