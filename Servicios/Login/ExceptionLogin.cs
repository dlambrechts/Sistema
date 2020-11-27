using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ExceptionLogin : Exception
    {
        public ResultadoLogin Result;

        public ExceptionLogin(ResultadoLogin result)
        {
            Result = result;
        }

    }
}
