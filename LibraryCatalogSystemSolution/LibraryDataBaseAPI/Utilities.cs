using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataBaseAPI;

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

}
