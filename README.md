# LibraryCatalogSystem
.NET Framework project used for managing imaginary library catalog system

<img width="1200" alt="image" src="ReadMeImg\SampleImg.png">

## Requirements
Entire project was developed using Visual Studio IDE.
Two workloads are especially needed:
* .NET desktop development
    * Components needed for developing Windows Forms applications
* Data storage and processing
    * SQL Server Data Tools

## Project Initialization
In order to compile application first database need to be initialized.

#### Database Initialization:
1. Set **LibraryCatalogSystemDatabase** project as startup project.
2. Compile solution.
3. Publish database (using **LibraryDatabase.publish.xml** from "Publish" folder)
4. Set **LibraryWinFormsApp** as startup project.
5. Initialization is done.

## Account Creation
In order to create employee account use *"EmployeeKey"* as key. \
Customer account do not need any key.

## License
This project is licensed under the [MIT License](LICENSE.txt). You are free to use, modify, and distribute the code as per the terms of the license.
