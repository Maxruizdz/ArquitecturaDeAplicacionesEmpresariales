using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pacagroup.Ecommerce.Transversal.Common
{
    public interface IConnectionsFactory
    {

        IDbConnection GetConnection { get; }
    }
}
