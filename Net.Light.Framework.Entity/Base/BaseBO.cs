using System;

namespace Net.Light.Framework.Entity.Base
{
    public abstract class BaseBO
    {
        protected TableObject tableProp = null;

        #region [ BaseBO Ctor ]

        /// <summary>
        /// BaseBO Ctor.
        /// </summary>
        protected BaseBO()
        {
            tableProp = new TableObject();
        }

        #endregion

        #region [ Table Property ]

        /// <summary>
        /// Gets Table Object
        /// </summary>
        public TableObject Table { get { return tableProp; } }

        #endregion

        #region [ ChangeSetCount Property ]

        /// <summary>
        /// Gets Count of Changed Property.
        /// </summary>
        public int ChangeSetCount
        {
            get
            {
                return Table.ChangeCount;
            }
        }

        #endregion

        #region [ IsPropertyChanged method ]

        /// <summary>
        /// Returns true if Value of Property with given name changes, return true; else returns false.
        /// </summary>
        /// <param name="propName">Property Name</param>
        /// <returns>Returns bool object.</returns>
        public bool IsPropertyChanged(string propName)
        {
            try
            {
                bool iscontain = false;
                iscontain = tableProp.Contains(propName);
                return iscontain;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}