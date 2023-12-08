using LibraryDatabaseAPI;



const string PROVIDER = ".NET Framework Data Provider for SQL Server";
const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";


var api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

//LibraryApi.PostLibraryUser("Tomasz", "Kowalski", "das", "123", "Client");


var users = api.GetLibraryUsers();
var borrowRequests = api.GetBorrowRequests();
var resourceCopies = api.GetResourceCopies();
var libraryResources = api.GetLibraryResources();

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

foreach (var item in libraryResources)
{
    Console.WriteLine(item);
}