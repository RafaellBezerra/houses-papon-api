## About the Project

This API, developed with **.NET 8** and following the principles of **Domain-Driven Design (DDD)**, provides a well-structured and efficient solution for managing rental properties and tenant-related operations. It acts as a rental management system where users can add tenants associated with homes, manage rental agreements, and handle payments associated with tenants, all stored securely in a **MySQL** database.

The architecture is based on **REST** standards, using standard **HTTP methods** to provide a clean and intuitive communication layer. It is also enhanced with **Swagger documentation**, offering an interactive and user-friendly interface for developers to explore and test the API endpoints.

Among the NuGet packages used, **FluentValidation** implements validation rules in a clean and maintainable way. **Entity Framework Core** acts as the ORM, simplifying database interactions by using .NET objects instead of raw SQL queries.

### Features

- **RESTful Architecture**: Clean and consistent HTTP endpoints following REST standards for easy integration and scalability.
- **Interactive API Docs (Swagger)**: Built-in Swagger UI to explore, test, and understand endpoints effortlessly.
- **Entity Framework Core (EF Core)**: Powerful ORM with LINQ support for efficient and type-safe database interactions.
- **FluentValidation Integration**: Centralized and maintainable validation logic, ensuring clean and reliable input handling.
- **Secure Cookie-Based Authentication**: Session-based authentication using HTTP-only cookies for enhanced security and simplified client-side management.

### Built with

![badge-dotnet]
![badge-windows]
![badge-vs]
![badge-mysql]
![badge-swagger]
![badge-railway]
![badge-csharp]

### Deployment

This API is deployed on [Railway](https://railway.app), providing a cloud-hosted environment for running and testing the application.  
Note: API endpoints require cookie-based authentication and access to the production database, which is restricted for security reasons.

## Getting Started

To install and run a local copy, follow these simple steps.

### Requirements

- Visual Studio version 2022+ or Visual Studio Code
- Windows 10+ or ​​Linux/Mac OS with [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed
- MySQL Server

[badge-dotnet]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-vs]: https://img.shields.io/badge/VISUAL%20STUDIO-%235c2d91?style=for-the-badge
[badge-windows]: https://img.shields.io/badge/WINDOWS-%230078D4?style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[badge-railway]: https://img.shields.io/badge/Railway-000?logo=railway&logoColor=white&style=for-the-badge
[badge-csharp]: https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=fff&style=for-the-badge