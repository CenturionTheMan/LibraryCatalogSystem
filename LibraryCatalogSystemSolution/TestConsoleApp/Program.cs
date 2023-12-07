using LibraryDataBaseAPI;


//LibraryApi.PostLibraryUser("Tomasz", "Kowalski", "das", "123", "Client");


var users = LibraryApi.GetLibraryUsers();
var borrowRequests = LibraryApi.GetBorrowRequests();
var resourceCopies = LibraryApi.GetResourceCopies();
var libraryResources = LibraryApi.GetLibraryResources();

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