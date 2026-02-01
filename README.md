# DynamicSignalFormsAngularDotnet

An Angular 21 application (with [Angular CLI](https://github.com/angular/angular-cli) version 21.1.2) that demonstrates the new Signal Forms in a dynamic way.  
It uses a .NET/C# WebAPI as Backend and a PostgreSQL database.  
The .NET/C# WebAPI has CRUD (Create Update and Delete) functionality to store all data of the forms in the PostgreSQL database.

The Angular application:

*   Shows an overview of the available forms.
*   Can create new Dynamic Signal Forms.
*   Shows the Dynamic Signal Forms.
*   2 components are responsible for the generation of the Dynamic Signal Forms:

1.  DynamicSignalFormComponent
2.  DynamicSignalFormArrayComponent

*   There is support for Form Arrays. And Form Arrays can be used within other Forms.

See the images in the root of this project for examples.

### **PostgreSQL database:**

Requirement: _Docker Desktop_

See the folder: _Docker\_PostgreSQL_ with the docker-compose file.

Command to add the _docker container_:

**docker-compose up --build -d**

### **Add database migrations**

Install the **dotnet ef-tool** - version: 8.0.11 or above

When the tool is installed, run the command for a _database migration:_

**dotnet ef database update**

For more information see the link below:

[https://learn.microsoft.com/en-us/ef/core/cli/dotnet](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### **Angular application installation**

**Angular 21** needs a **Node.js** version of at least _20.19.0_

**Command to install**

_npm install_  
or shorter:

_npm i_

**Command to run the application:**

_ng serve --open_

or shorter:

_ng s --o_

### **Changelog:**

_February 2026_

\- First commit. Basic validation of the data.