# Inventory Management API

RESTful Inventory Management API built with ASP.NET Core.

This project is intended as a backend-focused learning project to deepen my experience
with C#, ASP.NET Core, Entity Framework Core, and relational databases, while following
clean architecture and API design principles.

## Tech Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite (development)
- Swagger / OpenAPI

## Features (MVP)

- Create, read, update, and delete inventory items
- Input validation and appropriate HTTP responses
- Persistent storage using Entity Framework Core
- Clean separation of concerns (Domain / Application / Infrastructure / API)

## Getting Started

### Prerequisites
- .NET SDK (7 or later)
- Visual Studio 2022 (recommended)

### Running the API

1. Clone the repository
2. Restore dependencies
3. Run database migrations
4. Start the API

```bash
dotnet ef database update
dotnet run --project Inventory.Api
