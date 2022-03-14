using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_OP.Interfaces.Repositories
{
    public class DapperContext : IDapperContext
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal IDisposable CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
