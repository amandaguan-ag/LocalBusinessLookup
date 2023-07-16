# Local Business Lookup API
##### Developed by Amanda Guan
###### Last Updated: July 1, 2023

## Introduction

Welcome to the Local Business Lookup API, a highly scalable, easy-to-use and robust RESTful service designed to store and provide critical information about local businesses. Whether you need to find the address, phone number, or website of a business, this API has got you covered.

## Features

Using this API, you can:

- Retrieve a comprehensive list of local businesses
- Add a new business to the database
- Access detailed information about a specific business
- Update information of a particular business
- Delete a business from the database

## API Endpoints
- `GET /api/businesses` - fetch all businesses
- `POST /api/businesses` - add a new business
- `GET /api/businesses/{id}` - retrieve a specific business
- `PUT /api/businesses/{id}` - update a specific business
- `DELETE /api/businesses/{id}` - delete a specific business

> To explore these endpoints interactively, navigate to `localhost:5000` after starting the service to access Swagger UI.

## Getting Started

Follow these steps to get the API up and running:

1. Clone this repository.
2. Navigate to the root directory in your terminal.
3. Create a new file called `appsettings.json` in the root directory.
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
    "DefaultConnection": "Server=localhost;Port=3306;database=l[your-db];uid=[your-username];pwd=[your-password];"
  }
}
```
4. Add your MySQL `uid` and `pwd` in the `appsettings.json` file.
5. Use Postman or Swagger to interact with the API.

## Database Setup: 

To create the necessary tables in your database, run the following commands:

  - $ dotnet ef migrations add initial
  - $ dotnet ef database update

## Known Issues

As of the latest update, there are no known issues or bugs.

## Tech Stack:

This API is built with:

- C#
- .NET
- ASP.NET Core
- Versioning
- Swagger UI

## License
Distributed under the MIT License. See `LICENSE` for more information.

## Connect with me

I'm Amanda Guan, a passionate software engineer who loves solving problems and creating innovative solutions. Feel free to connect with me on [LinkedIn](https://www.linkedin.com/in/amandaguan1/).

Copyright (c) 2023 Amanda Guan
