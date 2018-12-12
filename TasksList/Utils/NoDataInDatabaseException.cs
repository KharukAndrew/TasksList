using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksList.Utils
{
    public class NoDataInDatabaseException : Exception
    {
        public NoDataInDatabaseException()
            : base("No data in the Database.") {}
    }
}