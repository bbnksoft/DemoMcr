# Quick Start Guide

## Running the Application

### Option 1: Docker Compose (Recommended)

```bash
cd REZsupport
docker-compose up -d
```

- API: http://localhost:5000/swagger
- SQL Server: localhost:1433

### Option 2: Local Development

1. Start SQL Server:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
```

2. Run the API:

```bash
cd REZsupport/Services/Product.API
dotnet run
```

- API: https://localhost:7000/swagger (or http://localhost:5000/swagger)

## Testing the API

### Create Product

```bash
curl -X POST "http://localhost:5000/api/products" -H "Content-Type: application/json" -d "{\"name\":\"Test Product\",\"description\":\"Test Description\",\"price\":29.99,\"stockQuantity\":100,\"sku\":\"TEST001\",\"category\":\"Electronics\",\"isActive\":true}"
```

### Get All Products

```bash
curl -X GET "http://localhost:5000/api/products"
```

### Get Product by ID

```bash
curl -X GET "http://localhost:5000/api/products/{id}"
```

### Update Product

```bash
curl -X PUT "http://localhost:5000/api/products/{id}" -H "Content-Type: application/json" -d "{\"name\":\"Updated Product\",\"description\":\"Updated Description\",\"price\":39.99,\"stockQuantity\":50,\"sku\":\"TEST001\",\"category\":\"Electronics\",\"isActive\":true}"
```

### Delete Product

```bash
curl -X DELETE "http://localhost:5000/api/products/{id}"
```

## Architecture Overview

### Clean Architecture Layers

1. **Product.Core (Domain Layer)**

   - Entities: `Product`, `BaseEntity`
   - Interfaces: `IRepository`, `IUnitOfWork`
   - Exceptions: `NotFoundException`, `ValidationException`

2. **Product.Application (Application Layer)**

   - CQRS Commands: `CreateProduct`, `UpdateProduct`, `DeleteProduct`
   - CQRS Queries: `GetProductById`, `GetAllProducts`
   - DTOs: `ProductDto`, `CreateProductDto`, `UpdateProductDto`
   - Validators: FluentValidation for all commands
   - Behaviors: `ValidationBehavior` for MediatR pipeline

3. **Product.Infrastructure (Infrastructure Layer)**

   - `ApplicationDbContext`: EF Core DbContext
   - `Repository<T>`: Generic repository implementation
   - `UnitOfWork`: Unit of Work pattern
   - Polly retry policies for resilience

4. **Product.API (API Layer)**
   - `ProductsController`: REST API endpoints
   - `GlobalExceptionHandlingMiddleware`: Global error handling
   - Serilog configuration for logging
   - Swagger/OpenAPI documentation

## Key Features

✅ **Clean Architecture** - Separation of concerns across layers
✅ **CQRS Pattern** - Commands and Queries separation
✅ **MediatR** - Mediator pattern for decoupling
✅ **Repository & UoW** - Data access abstraction
✅ **EF Core 8** - ORM with migrations
✅ **FluentValidation** - Declarative validation rules
✅ **Global Exception Handling** - Centralized error management
✅ **Serilog** - Structured logging to console and files
✅ **Polly** - Retry policies for database resilience
✅ **Swagger/OpenAPI** - Interactive API documentation
✅ **Docker Support** - Containerized deployment
✅ **Azure SQL Edge** - Production-ready database

## Database Migrations

Migrations are automatically applied on application startup. The initial migration creates the Products table with the following schema:

- Id (GUID, Primary Key)
- Name (string, required, max 200 chars)
- Description (string, optional, max 1000 chars)
- Price (decimal 18,2)
- StockQuantity (int)
- SKU (string, optional, max 50 chars)
- Category (string, optional, max 100 chars)
- IsActive (bool)
- CreatedAt (datetime)
- UpdatedAt (datetime, nullable)
- CreatedBy (string, nullable)
- UpdatedBy (string, nullable)
- IsDeleted (bool, soft delete)

## Logging

Logs are written to:

- Console (for Docker/development)
- `logs/log-YYYYMMDD.txt` (daily rolling files)

Log levels:

- Information: General application flow
- Warning: Potential issues
- Error: Exceptions and errors
- Debug: Detailed information (Development only)

## Environment Variables

Configure via `appsettings.json` or environment variables:

- `ConnectionStrings__DefaultConnection`: Database connection string
- `ASPNETCORE_ENVIRONMENT`: Development/Staging/Production
- `Serilog__MinimumLevel__Default`: Minimum log level

## Troubleshooting

### SQL Server Connection Issues

- Ensure SQL Server is running: `docker ps`
- Check connection string in appsettings.json
- Verify firewall settings for port 1433

### Migration Issues

- Migrations are applied automatically on startup
- Check logs for migration errors
- Manually apply: `dotnet ef database update --startup-project ../Product.API`

### Build Errors

- Clean and rebuild: `dotnet clean && dotnet build`
- Restore packages: `dotnet restore`
- Check .NET 8.0 SDK is installed: `dotnet --version`

## Production Deployment

1. Update connection string in docker-compose.yml or appsettings.json
2. Change SQL SA password in production
3. Configure HTTPS certificates
4. Set `ASPNETCORE_ENVIRONMENT=Production`
5. Review and adjust Serilog configuration
6. Deploy using Docker Compose or Kubernetes

## Security Considerations

⚠️ **Important for Production:**

- Change default SQL Server password
- Enable authentication/authorization
- Configure CORS properly
- Use HTTPS
- Implement rate limiting
- Add API key/JWT authentication
- Enable SQL Server authentication mode
- Use secrets management (Azure Key Vault, etc.)
