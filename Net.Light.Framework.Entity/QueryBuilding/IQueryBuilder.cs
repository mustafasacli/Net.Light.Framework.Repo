using Net.Light.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Light.Framework.Entity.QueryBuilding
{

    internal interface IQueryBuilder
    {
        /// <summary>
        /// Gets Property contains parameter(s).
        /// </summary>
        Property Properties { get; }

        /// <summary>
        /// Gets Sql Query.
        /// </summary>
        String QueryString { get; }

    }
}