# se-dotnet-webapi

### Prerequesites

- .NET Core 3.1 SDK
- Visual Studio Code
- Visual Studio Code C# Package

### Create and run webapi project

1. mkdir se-dotnet-webapi; cd se-dotnet-webapi; dotnet new webapi -lang C#
1. dotnet new webapi -o se-dotnet-webapi -lang C#; cd se-dotnet-webapi
2. code .
3. add model class
4. add database context
5. register database context in Startup.cs
6. add controller 
7. dotnet run

### Install EntityFrameworkCore

1. ´dotnet add package Microsoft.EntityFrameworkCore.SqlServer´
2. ´dotnet add package Microsoft.EntityFrameworkCore.InMemory´

### Generate Controller via CLI

- Model: TodoItem
- Controller: TodoItemsController
- DataContext: TodoContext

1. ´dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design´
2. ´dotnet add package Microsoft.EntityFrameworkCore.Design´
3. ´dotnet tool install --global dotnet-aspnet-codegenerator´
4. ´dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers´
