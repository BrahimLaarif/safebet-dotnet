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
- GET /api/matches
- GET /api/matches?date=2018-11-07
- GET /api/matches/1
- GET /api/matches/today
- GET /api/matches/today?date=2018-11-07
- GET /api/matches/today/gemstone
- GET /api/matches/today/gemstone?date=2018-11-07
- GET /api/matches/today/gemstone/grandidierite
- GET /api/matches/today/gemstone/grandidierite,diamond,ruby
- GET /api/matches/today/gemstone/grandidierite,diamond,ruby?date=2018-11-07
- GET /api/gemstones/statistics
- GET /api/gemstones/statistics/grandidierite
- GET /api/gemstones/statistics/grandidierite,diamond,ruby