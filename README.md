# Local Business Lookup
##### By Amanda Guan
###### Last Updated July 1 2023

## Description

This is an api designed to hold local businesses and their respective information. 

## Specifications:

The user will be able to call for:

  - Name 
  - Address 
  - Phone number 
  - Website

## API Endpoints
### - Businesses
- GET /api/businesses
- POST /api/businesses
- GET /api/businesses/{id}
- PUT /api/businesses/{id}
- DELETE /api/businesses/{id}

_note: to see endpoints with swagger, navagate to localhost:5000_

## Setup/Installation Requirements

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory.
3. Within the production directory, create a new file called `appsettings.json`.
4. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=l[your db];uid=[your username];pwd=[your password];"
  }
}
```

5. use postman/Swagger to interact with the api

## To create the tables: 

  - $ dotnet ef migrations add initial
  - $ dotnet ef database update


## Known Bugs

* _No known bugs at this time_

## Technologies Used:

* C#
* .NET
* ASP.NET Core
* Versioning
* Swagger UI

## License
MIT License

Copyright (c) 2023 Amanda Guan