# Safebet .NET Solution
Football matches Web API project with ASP.NET Core

## Installation
1. Navigate to the Web API project
    ```console
    cd Safebet.WebAPI
    ```
2. Build the project and all of its dependencies
    ```console
    dotnet build
    ```
3. Run the migrations
    ```console
    dotnet ef database update
    ```
4. Run the application
    ```console
    dotnet run
    ```

## Environment variables
- ConnectionStrings__DefaultConnection

## .NET Entity Framework migrations
Generate the SQL script based on the entire migration script to update the production database
```console
dotnet ef migrations script --output dump.sql
```