using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseAPI;

public enum UserType
{
    Client,
    Employee
}

public enum Status
{
    Pending, 
    Approved,
    Returned,
}

public enum ResourceType
{
    Book, 
    Magazine,
}
