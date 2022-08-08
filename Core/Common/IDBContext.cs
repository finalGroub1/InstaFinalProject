using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Core.Common
{
    public interface IDBContext
    {
        public DbConnection Connection { get; }
    }
}
