using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Transversal.Common
{
    public interface IAppLogger<T>
    {

        void LogginInformation(string Message, params object[] args);
        void LogginWarning(string Message, params object[] args);

        void LogginError(string Message, params object[] args);

    }
}
