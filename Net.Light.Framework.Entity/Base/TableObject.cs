using Net.Light.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Light.Framework.Entity.Base
{
    public class TableObject
    {
        private List<FreeParameter> _Parameters = null;

        public TableObject()
        {
            _Parameters = new List<FreeParameter>();
        }

        private string _tableName = string.Empty;
        /// <summary>
        /// Gets, Sets Table Name.
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        private string _IdCol = string.Empty;
        /// <summary>
        /// Gets, Sets IdColumn Nameç
        /// </summary>
        public string IdCol
        {
            get { return _IdCol; }
            set { _IdCol = value; }
        }


        public Int32 Puts(params FreeParameter[] parameters)
        {
            if (parameters == null)
            {
                return -1;
            }
            else
            {
                Int32 intRet = 0;
                FreeParameter frPrm;
                foreach (FreeParameter prm in parameters)
                {
                    if (_Parameters.Contains(prm) == true)
                    {
                        frPrm = _Parameters[_Parameters.IndexOf(prm)];
                        frPrm.Value = prm.Value;
                        _Parameters[_Parameters.IndexOf(prm)] = frPrm;
                    }
                    else
                    {
                        _Parameters.Add(prm);
                        intRet++;
                    }
                }
                return intRet;
            }
        }

        public Boolean Put(FreeParameter freeParam)
        {
            Int32 index = _Parameters.IndexOf(freeParam);
            if (index == -1)
            {
                _Parameters.Add(freeParam);
                return true;
            }
            else
            {
                FreeParameter frmPrm = _Parameters[index];
                frmPrm.Value = freeParam.Value;
                _Parameters[index] = frmPrm;
                return false;
            }
        }

        public Boolean Put(String name, Object value)
        {
            return Put(new FreeParameter() { Name = name, Value = value });
        }

        public Boolean Remove(String name)
        {
            return Remove(new FreeParameter() { Name = name });
        }

        public Boolean Remove(FreeParameter freeParam)
        {
            Int32 index = _Parameters.IndexOf(freeParam);
            if (index == -1)
            {
                return false;
            }
            else
            {
                return _Parameters.Remove(freeParam);
            }
        }

        public List<FreeParameter> GetParameters()
        {
            return _Parameters;
        }

        public int ChangeCount
        {
            get
            {
                return _Parameters.Count;
            }
        }

        public bool Contains(string parameterName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(parameterName) == true)
                    return false;

                string prm = string.Format("{0}", parameterName);
                bool isContain = false;

                foreach (var item in _Parameters)
                {
                    if (prm.Equals(item.Name))
                    {
                        isContain = true;
                        break;
                    }
                }

                return isContain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object Get(string key)
        {
            object result = null;
            try
            {
                string ky = string.Format("{0}", key);
                foreach (var item in _Parameters)
                {
                    if (ky.Equals(item.Name) == true)
                    {
                        result = item.Value;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

    }
}
