# Safebet .NET Solution
Safebet .NET Web API Solution

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

## Endpoints
- GET /api/matches/date/2018-11-03
- GET /api/matches/date/2018-11-03?gemstones=grandidierite,diamond,ruby
- GET /api/matches/view/1
- GET /api/matches/view/1/snapshot/14:50:00
- GET /api/gemstones/today
- GET /api/gemstones/upcoming
- GET /api/bettingHistory/2017-01-01/2018-12-31
- GET /api/bettingHistory/2017-01-01/2018-12-31?gemstones=grandidierite,diamond,ruby