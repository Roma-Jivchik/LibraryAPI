# Library API

The LibraryAPI project is a .NET web application that uses a SQL Server database for managing a library system. It incorporates JWT authorization for secure authentication and authorization of users. This Readme.md file will provide instructions on how to run the project.
Modsen test task.

## Table of Contents
- [Library API](#library-api)
  - [Table of Contents](#table-of-contents)
  - [Requirements](#requirements)
  - [Setup](#setup)
      - [Database Setup](#database-setup)
      - [Create Database](#create-database)
      - [Running the Application](#running-the-application)
      - [Accessing the API](#accessing-the-api)
  - [API Endpoints](#api-endpoints)
  - [Authorization](#authorization)
      - [Login](#login)
      - [Register](#register)

## Requirements
Before running the LibraryAPI project, ensure you have the following prerequisites installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (need .NET 7)
- [SQL Server for Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (to use without Docker)

## Setup

1. Clone the project repository from GitHub.
2. Navigate to the `LibraryAPI` directory.

#### Database Setup
3. Open `appsettings.Development.json` in the `WebLibrary.API` project and update the `ConnectionString` section with your SQL Server credentials.

#### Create Database
4. Using SQL Server Management Studio, create an empty database named LibraryDatabase

#### Running the Application
To run the LibraryAPI project, follow these steps:

5. Open your terminal or command prompt.

6. Navigate to the project directory `{path to project}\LibraryAPI\WebLibrary.API`.

7. Execute the following command: `dotnet run`

Alternatively, you can use Visual Studio to run the project.

#### Accessing the API

Once the LibraryAPI is running, you can access it through the following URL:

- Swagger Documentation: http://localhost:5227/swagger

## API Endpoints
- **GET /api/book**: Get a list of all books in the library.
- **GET /api/book/{id}**: Get details of a specific book by its ID.
- **GET /api/book/byISBN/{isbn}**: Get details of a specific book by its ISBN.
- **POST /api/book**: Add a new book to the library (requires authorization).
- **PUT /api/book**: Update an existing book's details (requires authorization).
- **DELETE /api/book/{id}**: Remove a book from the library (requires authorization).

- **GET /api/user**: Get a list of all users.
- **GET /api/user/{id}**: Get details of a specific user by its ID.
- **DELETE /api/user/{id}**: Delete a user by providing the user ID (requires authorization).
- **PUT /api/user**: Update an existing user's details (requires authorization).

## Authorization
The LibraryAPI project uses JSON Web Tokens for authorization. To perform authorized actions, you must obtain an access token by following the steps below:

#### Login
To obtain an access token for an existing user, via the following endpoint:

- **POST /api/identity/login**: Provide your login and password in the request body to receive an access token.

#### Register
If you are a new user, you can register and receive an access token via the following endpoint:

- **POST /api/identity/register**: Register as a new user to obtain an access token.

With the access token obtained from either the login or register endpoint, include it in the Authorization header of subsequent requests as follows:

`Authorization: Bearer "token"`