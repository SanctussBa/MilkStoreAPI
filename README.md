# MilkStoreAPI

## What is this project about?

* This is a `back-end` part of Full-Stack Milk Store application. 
* This API is build using `Asp.Net Web API` with initial command of `dotnet new webapi`.
* On model creation database is seeded with initial data. Data sample:
```json
[
    {
        "name": "Dillion's unequaled cashew milk",
        "type": "Cashew milk",
        "storage": 99,
        "id": "301d5dcf-a2a8-4a34-b26b-efcaa103963c"
    },
    {
        "name": "Monet's powerful cashew milk",
        "type": "Cashew milk",
        "storage": 27,
        "id": "1277e861-b33b-485d-b86f-400769d25a82"
    }
]
```

* All basic `CRUD`  operations are implemented in API controller.
* `Front-end` part you can find in this repository: https://github.com/SanctussBa/MilkStoreReact

## How you can clone and run this project?

From your command line, first clone this repo:

```
# Clone this repo
>>> git clone git@github.com:SanctussBa/MilkStoreAPI.git

# Go into the repository
>>> cd .\MilkStoreAPI\

# Remove current origin repository
>>> git remote remove origin

```

## Configure .NET Web API:

1. If you don't have it yet. Download [Microsoft SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms)

2. Set up your SQL Server and Create new database.

3. Open MilkStoreAPI folder with your IDE

4. Go into appsettings.json file and change `ConnectionString` fill your database name and password. (User Id by default should be "sa", please change if in your case is custum Id)
```json
"DataContext": "Server=localhost;Database=[your DB name];User Id=sa;Password=[your password];TrustServerCertificate=True"

```

5. Open new terminal in your IDE and run:
```
>>> dotnet build
```

6. Create your first migration
```
>>> dotnet ef migrations add InitialCreate
```

7. Create your database and schema. It will also seed database with data.
```
>>> dotnet ef database update
```

8. Run API
```
>>> dotnet watch run
```

It should open Swagger UI and you can interact with API. 

### Next step: Set up Front-End here -->  https://github.com/SanctussBa/MilkStoreReact
