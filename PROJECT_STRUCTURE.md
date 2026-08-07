# Project Structure

## Folder Tree

```
/workspace
├── .git/                          # Git repository metadata
├── .gitignore                     # Git ignore rules
├── README.md                      # Project documentation
├── Atrin-Foundation-v1.0.tar.gz   # Foundation archive (compressed)
├── Atrin/
│   ├── Atrin-Foundation-v1.0.zip  # Foundation archive (zipped)
│   ├── backend/                   # Backend (.NET solution)
│   │   ├── Atrin.sln              # Solution file
│   │   ├── Atrin.Api/             # API Layer
│   │   │   ├── Atrin.Api.csproj
│   │   │   ├── Program.cs         # Application entry point
│   │   │   ├── appsettings.json   # Configuration settings
│   │   │   ├── appsettings.Production.json
│   │   │   ├── Controllers/
│   │   │   │   └── AuthController.cs
│   │   │   ├── Extensions/
│   │   │   │   └── ServiceCollectionExtensions.cs
│   │   │   ├── Filters/
│   │   │   │   └── ApiConventionAttribute.cs
│   │   │   ├── Middleware/
│   │   │   │   └── ExceptionHandlingMiddleware.cs
│   │   │   └── Properties/
│   │   │       └── launchSettings.json
│   │   ├── Atrin.Application/     # Application Layer (Business Logic)
│   │   │   ├── Atrin.Application.csproj
│   │   │   ├── ApplicationDependencyInjection.cs
│   │   │   ├── Common/
│   │   │   │   ├── Behaviors/
│   │   │   │   │   └── ValidationBehavior.cs
│   │   │   │   ├── Interfaces/
│   │   │   │   │   ├── IApplicationDbContext.cs
│   │   │   │   │   └── IServices.cs
│   │   │   │   └── Models/
│   │   │   │       └── AuthModels.cs
│   │   │   ├── Features/
│   │   │   │   ├── Auth/
│   │   │   │   │   └── AuthValidators.cs
│   │   │   │   └── Users/
│   │   │   └── Mappings/
│   │   │       └── MappingProfile.cs
│   │   ├── Atrin.Domain/          # Domain Layer (Entities & Business Rules)
│   │   │   ├── Atrin.Domain.csproj
│   │   │   ├── Common/
│   │   │   │   └── BaseEntity.cs
│   │   │   ├── Entities/
│   │   │   │   └── User.cs
│   │   │   ├── Enums/
│   │   │   │   └── Enums.cs
│   │   │   ├── Events/
│   │   │   │   └── DomainEvents.cs
│   │   │   └── ValueObjects/
│   │   │       └── ValueObjects.cs
│   │   ├── Atrin.Infrastructure/  # Infrastructure Layer (Data Access & External Services)
│   │   │   ├── Atrin.Infrastructure.csproj
│   │   │   ├── InfrastructureDependencyInjection.cs
│   │   │   ├── Identity/
│   │   │   ├── Persistence/
│   │   │   │   ├── ApplicationDbContext.cs
│   │   │   │   ├── DatabaseSeeder.cs
│   │   │   │   ├── Configurations/
│   │   │   │   │   └── EntityConfigurations.cs
│   │   │   │   └── Migrations/
│   │   │   └── Services/
│   │   │       ├── InfrastructureServices.cs
│   │   │       └── TokenService.cs
│   │   └── Atrin.Shared/          # Shared Kernel (Common Utilities)
│   │       ├── Atrin.Shared.csproj
│   │       ├── Constants/
│   │       │   └── ApplicationConstants.cs
│   │       ├── Exceptions/
│   │       │   └── AtrinException.cs
│   │       └── Results/
│   │           └── Result.cs
│   ├── docker/                    # Docker configuration files (empty)
│   ├── docs/                      # Documentation files (empty)
│   └── frontend/                  # Frontend Application
│       └── web/                   # Web Client
│           ├── public/            # Static assets
│           └── src/               # Source code
│               ├── components/    # UI Components
│               │   ├── common/
│               │   ├── layout/
│               │   └── ui/
│               ├── contexts/      # React Contexts
│               ├── hooks/         # Custom Hooks
│               ├── lib/           # Utility libraries
│               ├── pages/         # Page components
│               ├── services/      # API services
│               └── types/         # TypeScript type definitions
└── PROJECT_STRUCTURE.md           # This file
```

---

## Architecture Summary

### Overview

**Atrin** is a full-stack application following **Clean Architecture** principles with a clear separation of concerns across multiple layers. The project consists of a **.NET backend** and a **React/TypeScript frontend**.

---

### Backend Architecture (.NET)

The backend follows **Clean Architecture** with four distinct layers:

#### 1. **Atrin.Api** (Presentation Layer)
- **Purpose**: Exposes RESTful API endpoints
- **Responsibilities**:
  - HTTP request handling
  - Request/response mapping
  - Authentication & authorization
  - Global exception handling via middleware
- **Key Components**:
  - `Controllers/` - API controllers (e.g., `AuthController`)
  - `Middleware/` - Cross-cutting concerns (e.g., `ExceptionHandlingMiddleware`)
  - `Filters/` - API conventions and action filters
  - `Extensions/` - Service collection extensions for DI

#### 2. **Atrin.Application** (Application Layer)
- **Purpose**: Contains business logic and application workflows
- **Responsibilities**:
  - Use case orchestration
  - Input validation
  - DTO mapping
  - Interface definitions for infrastructure
- **Key Components**:
  - `Features/` - Feature-based organization (Auth, Users)
  - `Common/Behaviors/` - Pipeline behaviors (e.g., validation)
  - `Common/Interfaces/` - Contracts for infrastructure
  - `Mappings/` - AutoMapper profiles

#### 3. **Atrin.Domain** (Domain Layer)
- **Purpose**: Core business logic and domain models
- **Responsibilities**:
  - Entity definitions
  - Value objects
  - Domain events
  - Business rules enforcement
- **Key Components**:
  - `Entities/` - Domain entities (e.g., `User`)
  - `ValueObjects/` - Immutable value types
  - `Enums/` - Domain enumerations
  - `Events/` - Domain events for event-driven patterns
  - `Common/` - Base classes (e.g., `BaseEntity`)

#### 4. **Atrin.Infrastructure** (Infrastructure Layer)
- **Purpose**: Implementation of technical concerns
- **Responsibilities**:
  - Database access (Entity Framework Core)
  - External service integrations
  - Identity management
  - Token generation
- **Key Components**:
  - `Persistence/` - DbContext, migrations, seeding
  - `Services/` - External service implementations
  - `Identity/` - Authentication/authorization services

#### 5. **Atrin.Shared** (Shared Kernel)
- **Purpose**: Cross-cutting utilities shared across layers
- **Responsibilities**:
  - Common result types
  - Standardized exceptions
  - Application constants
- **Key Components**:
  - `Results/` - Result pattern implementation
  - `Exceptions/` - Custom exception types
  - `Constants/` - Application-wide constants

---

### Frontend Architecture (React/TypeScript)

The frontend is organized using a **feature-based structure** with reusable components:

#### Structure

| Directory | Purpose |
|-----------|---------|
| `components/common/` | Reusable UI components |
| `components/layout/` | Layout components (header, footer, sidebar) |
| `components/ui/` | Base UI primitives (buttons, inputs, modals) |
| `contexts/` | React context providers for global state |
| `hooks/` | Custom React hooks |
| `lib/` | Utility functions and helper libraries |
| `pages/` | Page-level components (routes) |
| `services/` | API client services |
| `types/` | TypeScript type definitions and interfaces |

---

### Design Patterns & Principles

1. **Clean Architecture**: Strict layer separation with dependencies pointing inward
2. **CQRS Pattern**: Separation of commands and queries in application layer
3. **Repository Pattern**: Abstracted data access through interfaces
4. **Dependency Injection**: All layers use constructor injection
5. **Result Pattern**: Standardized response handling via `Result<T>`
6. **Pipeline Behaviors**: Cross-cutting concerns via MediatR behaviors
7. **Domain-Driven Design**: Rich domain model with entities, value objects, and domain events

---

### Technology Stack

| Layer | Technologies |
|-------|-------------|
| Backend | .NET, ASP.NET Core, Entity Framework Core, AutoMapper |
| Frontend | React, TypeScript |
| Database | SQL Server (via EF Core migrations) |
| Authentication | JWT tokens, Identity |

---

### Key Files

| File | Description |
|------|-------------|
| `Atrin.sln` | Visual Studio solution file |
| `Program.cs` | Application entry point and pipeline configuration |
| `ApplicationDbContext.cs` | EF Core database context |
| `ApplicationDependencyInjection.cs` | Application layer DI registration |
| `InfrastructureDependencyInjection.cs` | Infrastructure layer DI registration |
