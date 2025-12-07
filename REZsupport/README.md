## REZsupport Microservice

A complete .NET Core 8 microservice built with Clean Architecture principles.

### Architecture

- **Product.API**: API layer with REST endpoints, middleware, and Swagger
- **Product.Application**: Application layer with CQRS, MediatR, DTOs, and FluentValidation
- **Product.Core**: Domain layer with entities, interfaces, and exceptions
- **Product.Infrastructure**: Infrastructure layer with EF Core, Repository pattern, and Unit of Work

### Features

- ✅ Clean Architecture
- ✅ CQRS with MediatR
- ✅ Repository Pattern & Unit of Work
- ✅ EF Core with Azure SQL integration
- ✅ FluentValidation
- ✅ Global Exception Handling Middleware
- ✅ Serilog Logging (Console & File)
- ✅ Polly Retry Policies for Database Resilience
- ✅ Swagger/OpenAPI Documentation
- ✅ Docker & Docker Compose Support
- ✅ Azure SQL Edge for local development

### Prerequisites

- .NET 8.0 SDK
- Docker Desktop
- Visual Studio 2022 or VS Code

### Getting Started

#### Run with Docker Compose

```bash
docker-compose up -d
```

The API will be available at: http://localhost:5000/swagger

#### Run Locally

1. Start SQL Server (or use Docker):

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
```

2. Update connection string in `appsettings.json`

3. Run the API:

```bash
cd REZsupport/Services/Product.API
dotnet run
```

### API Endpoints

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

### Database Migrations

Migrations are automatically applied on startup. To create new migrations:

```bash
cd REZsupport/Services/Product.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../Product.API
```

### Project Structure

```
REZsupport/
├── Services/
│   ├── Product.API/
│   │   ├── Controllers/
│   │   ├── Middleware/
│   │   ├── Program.cs
│   │   └── Dockerfile
│   ├── Product.Application/
│   │   ├── Features/
│   │   │   └── Products/
│   │   │       ├── Commands/
│   │   │       └── Queries/
│   │   ├── DTOs/
│   │   ├── Behaviors/
│   │   └── Mappings/
│   ├── Product.Core/
│   │   ├── Entities/
│   │   ├── Interfaces/
│   │   └── Exceptions/
│   └── Product.Infrastructure/
│       ├── Persistence/
│       └── Repositories/
└── docker-compose.yml
```

### Technologies Used

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core 8.0
- MediatR
- FluentValidation
- AutoMapper
- Serilog
- Polly
- Swashbuckle (Swagger)
- Azure SQL Edge (Docker)

### License

MIT
