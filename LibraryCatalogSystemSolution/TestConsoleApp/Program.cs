using LibraryDatabaseAPI;
using System.Collections;


namespace TestConesoleApp;

public class Program
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";


    public static void Main()
    {

        var api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

        //LibraryApi.PostUsers("Tomasz", "Kowalski", "das", "123", "Client");


        var users = api.GetUsers();
        var borrowRequests = api.GetBorrowRequests();
        var resourceCopies = api.GetResourceCopies();
        var Resourcess = api.GetResources();

        //foreach (var user in users)
        //{
        //    Console.WriteLine(user);
        //}

        //foreach (var item in borrowRequests)
        //{
        //    Console.WriteLine(item);
        //}

        //foreach (var item in resourceCopies)
        //{
        //    Console.WriteLine(item);
        //}

        //foreach (var item in Resourcess)
        //{
        //    Console.WriteLine(item);
        //}


        PrintInConsole(users);
        PrintInConsole(borrowRequests);
        PrintInConsole(resourceCopies);
        PrintInConsole(Resourcess);
    }


    public static void PrintInConsole(object? obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Result is NULL => ERROR");
            return;
        }

        if (obj is IList)
        {
            IList list = (IList)obj;

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"||> Count: {list.Count}");
        }
        else
        {
            Console.WriteLine(obj.ToString());
        }
    }
}

