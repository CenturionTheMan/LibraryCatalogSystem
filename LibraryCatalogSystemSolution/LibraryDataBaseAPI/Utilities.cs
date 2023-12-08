using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseAPI;

public static class Utilities
{
    public static UserType ParseToUserType(this string str)
    {
        str = str.ToUpper();

        return str switch
        {
            "CLIENT" => UserType.Client,
            "EMPLOYEE" => UserType.Employee,
            _ => throw new ArgumentException(),
        };
    }

    public static Status ParseToStatus(this string str) 
    {
        return str switch
        {
            "Pending" => Status.Pending,
            "Approved" => Status.Approved,
            "Returned" => Status.Returned,
            _ => throw new ArgumentException(),
        };
    }

    public static ResourceType ParseToResourceType(this string str)
    {
        return str switch
        {
            "Book" => ResourceType.Book,
            "Magazine" => ResourceType.Magazine,
            _ => throw new ArgumentException(),
        };
    }
    
}
