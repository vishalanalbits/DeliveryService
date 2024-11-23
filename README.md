# Delivery.Service
# API Development with .NET, Entity Framework, and PostgreSQL

This project is a demonstration of building an API using **.NET 6**, **Entity Framework**, and **PostgreSQL 16**.

---

## Features
- **Entity Framework Core** for database interaction
- PostgreSQL 16 as the database
- Password hashing with **BCrypt.Net-Next**
- Request validation using **FluentValidation**
- Object mapping using **AutoMapper**
- RESTful API design
- Scalable and modular architecture(N-tier)

---

## Prerequisites
Before you begin, ensure you have the following installed:
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [PostgreSQL 16](https://www.postgresql.org/download/)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

---

## Setting Up the Environment

### 1. Install PostgreSQL 16
1. Download and install PostgreSQL 16.


### 2. Clone the Repository
    ``bash
    git clone <repository-url>
    cd <project-folder>


### 3. Update the Connection String
Modify the `appsettings.json` file with your PostgreSQL connection details:

    {
      "ConnectionStrings": {
        "FoodDeliveryDbConnectionString": "Host=localhost;Port=5432;Database=your_database;Username=your_user;Password=your_password"
      }
    }


### 4. Apply Database Migrations
This project uses `Entity Framework Core` for data access. Follow the steps below to add migrations or update the database schema.

#### 1. Add Migrations
    ``bash
    dotnet ef migrations add <MigrationName>

#### 2. Update Database
    ``bash
    dotnet ef database update


### 5. Run the Application
Launch the application:
    ``bash
    dotnet run


### Notes
- Replace <repository-url> and <project-folder> with actual repository details.
- Adjust `appsettings.json` for database.
- Ensure validators and mappings are updated whenever new models or DTOs are added.
- Use hashed passwords for all user accounts.
- Consider adding a LICENSE file to complement the license section.