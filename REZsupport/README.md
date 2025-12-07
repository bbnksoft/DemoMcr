## REZsupport Microservices

A complete .NET Core 8+ microservices solution built with Clean Architecture principles, featuring two independent services: **Product** and **Inventory**.

### Architecture

This solution follows Clean Architecture with CQRS pattern, implementing a 4-layer structure for each microservice:

#### Product Microservice

- **Product.API**: API layer with REST endpoints, middleware, and Swagger
- **Product.Application**: Application layer with CQRS, MediatR, DTOs, and FluentValidation
- **Product.Core**: Domain layer with entities, interfaces, and exceptions
- **Product.Infrastructure**: Infrastructure layer with EF Core, Repository pattern, and Unit of Work

#### Inventory Microservice

- **Inventory.API**: API layer with Venues, Sections, and Products controllers
- **Inventory.Application**: Application layer with CQRS operations for hierarchical data management
- **Inventory.Core**: Domain layer with Venue, Section, and Product entities
- **Inventory.Infrastructure**: Infrastructure layer with EF Core relationships and repositories

### Features

- ✅ Clean Architecture with 4-layer separation
- ✅ CQRS with MediatR (15+ operations)
- ✅ Repository Pattern & Unit of Work
- ✅ EF Core 8.0 with SQL Server integration
- ✅ FluentValidation for command validation
- ✅ Global Exception Handling Middleware
- ✅ Serilog Logging (Console & File with daily rolling)
- ✅ Polly Retry Policies for Database Resilience
- ✅ Swagger/OpenAPI Documentation at root URL
- ✅ Docker & Docker Compose Support
- ✅ Seed Data with EF Core Migrations
- ✅ Graceful database connection error handling
- ✅ AutoMapper for DTO transformations
- ✅ Hierarchical data relationships (Venue → Section → Product)
- ✅ Two independent microservices with separate databases

### Prerequisites

- .NET 8.0 SDK
- Docker Desktop
- Visual Studio 2022 or VS Code

### Getting Started

#### Run with Docker Compose

```bash
cd REZsupport
docker-compose up -d
```

The Product API will be available at: http://localhost:5000

#### Run Locally

1. Start SQL Server (using Docker):

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=admin1234" -e "MSSQL_USER=admin" -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
```

2. Connection strings are configured in `appsettings.json`:

   - Server: `localhost`
   - Database: `RezDemoDB`
   - User: `admin`
   - Password: `admin1234`

3. Run Product API:

```bash
cd REZsupport/Services/Product/Product.API
dotnet run --urls "http://localhost:5000"
```

4. Run Inventory API:

```bash
cd REZsupport/Services/Inventory/Inventory.API
dotnet run --urls "http://localhost:5001"
```

**Note:** The applications handle database connection failures gracefully. If the database is unavailable, the APIs will start without database connectivity and log appropriate warnings.

### API Endpoints

#### Product API (http://localhost:5000)

**Swagger UI:** http://localhost:5000

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product (soft delete)

**Seeded Data:** 5 products (Wireless Mouse, Mechanical Keyboard, USB-C Hub, Laptop Stand, Webcam HD)

#### Inventory API (http://localhost:5001)

**Swagger UI:** http://localhost:5001

**Venues:**

- `GET /api/venues` - Get all venues
- `GET /api/venues/{id}` - Get venue by ID
- `POST /api/venues` - Create a new venue
- `PUT /api/venues/{id}` - Update a venue
- `DELETE /api/venues/{id}` - Delete a venue (soft delete)

**Sections:**

- `GET /api/sections` - Get all sections
- `GET /api/sections/{id}` - Get section by ID
- `POST /api/sections` - Create a new section
- `PUT /api/sections/{id}` - Update a section
- `DELETE /api/sections/{id}` - Delete a section (soft delete)

**Products:**

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product (soft delete)

**Seeded Data:**

- 2 Venues: Madison Square Garden, Staples Center
- 4 Sections: Floor Section, Lower Bowl, Court Side, Upper Deck
- 5 Products: Various tickets and VIP packages ($75 - $1,200)

### Database Migrations

Migrations are automatically applied on startup with seed data. To create new migrations:

**Product Service:**

```bash
cd REZsupport/Services/Product/Product.Infrastructure
dotnet ef migrations add MigrationName --startup-project ../Product.API/Product.API.csproj
```

**Inventory Service:**

```bash
cd REZsupport/Services/Inventory/Inventory.Infrastructure
dotnet ef migrations add MigrationName --startup-project ../Inventory.API/Inventory.API.csproj
```

**Apply Migrations Manually:**

```bash
dotnet ef database update --startup-project ../[ServiceName].API/[ServiceName].API.csproj
```

### Project Structure

```
REZsupport/
├── Services/
│   ├── Product/
│   │   ├── Product.API/
│   │   │   ├── Controllers/
│   │   │   │   └── ProductsController.cs
│   │   │   ├── Middleware/
│   │   │   │   └── GlobalExceptionHandlingMiddleware.cs
│   │   │   ├── Program.cs
│   │   │   ├── appsettings.json
│   │   │   └── Dockerfile
│   │   ├── Product.Application/
│   │   │   ├── Features/
│   │   │   │   └── Products/
│   │   │   │       ├── Commands/
│   │   │   │       │   ├── CreateProduct/
│   │   │   │       │   ├── UpdateProduct/
│   │   │   │       │   └── DeleteProduct/
│   │   │   │       └── Queries/
│   │   │   │           ├── GetAllProducts/
│   │   │   │           └── GetProductById/
│   │   │   ├── DTOs/
│   │   │   ├── Behaviors/
│   │   │   │   └── ValidationBehavior.cs
│   │   │   └── Mappings/
│   │   ├── Product.Core/
│   │   │   ├── Entities/
│   │   │   │   ├── BaseEntity.cs
│   │   │   │   └── Product.cs
│   │   │   ├── Interfaces/
│   │   │   │   ├── IGenericRepository.cs
│   │   │   │   ├── IProductRepository.cs
│   │   │   │   └── IUnitOfWork.cs
│   │   │   └── Exceptions/
│   │   └── Product.Infrastructure/
│   │       ├── Persistence/
│   │       │   └── ApplicationDbContext.cs (with seed data)
│   │       ├── Repositories/
│   │       │   ├── GenericRepository.cs
│   │       │   ├── ProductRepository.cs
│   │       │   └── UnitOfWork.cs
│   │       └── Migrations/
│   └── Inventory/
│       ├── Inventory.API/
│       │   ├── Controllers/
│       │   │   ├── VenuesController.cs
│       │   │   ├── SectionsController.cs
│       │   │   └── ProductsController.cs
│       │   ├── Middleware/
│       │   ├── Program.cs
│       │   └── appsettings.json
│       ├── Inventory.Application/
│       │   ├── Features/
│       │   │   ├── Venues/
│       │   │   │   ├── Commands/ (Create, Update, Delete)
│       │   │   │   └── Queries/ (GetAll, GetById)
│       │   │   ├── Sections/
│       │   │   │   ├── Commands/ (Create, Update, Delete)
│       │   │   │   └── Queries/ (GetAll, GetById)
│       │   │   └── Products/
│       │   │       ├── Commands/ (Create, Update, Delete)
│       │   │       └── Queries/ (GetAll, GetById)
│       │   ├── DTOs/
│       │   ├── Behaviors/
│       │   └── Mappings/
│       ├── Inventory.Core/
│       │   ├── Entities/
│       │   │   ├── BaseEntity.cs
│       │   │   ├── Venue.cs
│       │   │   ├── Section.cs
│       │   │   └── Product.cs
│       │   └── Interfaces/
│       └── Inventory.Infrastructure/
│           ├── Persistence/
│           │   └── ApplicationDbContext.cs (with seed data)
│           ├── Repositories/
│           └── Migrations/
├── docker-compose.yml
└── README.md
```

### Technologies Used

- .NET 8.0 SDK
- ASP.NET Core Web API
- Entity Framework Core 8.0.11
- MediatR 14.0.0 (Inventory) / 13.1.0 (Product)
- FluentValidation 12.1.1 (Inventory) / 12.1.0 (Product)
- AutoMapper 12.0.1
- Serilog 10.0.0
- Polly 8.6.5
- Swashbuckle (Swagger/OpenAPI)
- SQL Server / Azure SQL Edge
- Docker & Docker Compose

### Database Configuration

**Connection String:**

```
Server=localhost;Database=RezDemoDB;User Id=admin;Password=admin1234;TrustServerCertificate=True;
```

Both microservices share the same SQL Server instance but use separate schemas/tables:

- **Product Service:** Products table
- **Inventory Service:** Venues, Sections, Products tables (hierarchical relationships)

### Development Notes

- Both APIs use Swagger UI at their root URLs for easy testing
- Serilog logs are written to `logs/log-YYYYMMDD.txt` with daily rolling
- Database migrations include seed data and are applied automatically on startup
- Graceful error handling allows APIs to start even if database is unavailable
- All delete operations are soft deletes (IsDeleted flag)
- CQRS pattern with separate Command and Query handlers
- Validation pipeline using FluentValidation behaviors

### License

MIT
