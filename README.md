# IdentityHub

An ASP.NET Core service for managing user identities, roles, and authentication.

## Project Structure

This project is organized into the following main components:

*   **`src/IdentityHub.API`**: The main ASP.NET Core API project. This is the entry point for client applications.
*   **`src/IdentityHub.Domain`**: Contains the core business logic and domain entities. This layer defines the fundamental objects and rules of the IdentityHub.
*   **`src/IdentityHub.Application`**: Intended for application-specific logic, such as use cases or services that orchestrate domain objects. (Note: The specific contents and role of this layer may need further definition as the project evolves.)
*   **`src/IdentityHub.Infrastructure`**: Handles data persistence using Entity Framework Core (configured for SQL Server) and other cross-cutting concerns like database migrations and external service integrations.
*   **`src/IdentityHub.Tests`**: Contains unit tests and potentially integration tests for the various parts of the IdentityHub application.

## Domain Entities

The core domain of IdentityHub revolves around the following entities:

*   **`User`**: Represents a user in the system.
    *   `IdentificadorUser` (Guid): Unique identifier for the user.
    *   `Nome` (string): User's name.
    *   `Email` (string): User's email address (likely used for login).
    *   `PasswordHash` (string): Hashed version of the user's password.
    *   `PasswordSalt` (string): Salt used for hashing the password.
    *   `IsActive` (bool): Indicates if the user account is active.
    *   `DataHoraCriacao` (DateTime): Timestamp of when the user was created.
    *   `DataHoraUltimaAlteracao` (DateTime): Timestamp of the last modification to the user's details.
    *   `DataHoraExclusao` (DateTime): Timestamp for soft deletion, if applicable.
*   **`Role`**: Represents a role that can be assigned to users (e.g., "Administrator", "User").
    *   `IdentificadorRole` (Guid): Unique identifier for the role.
    *   `Nome` (string): Name of the role.
    *   `Descricao` (string): A brief description of the role's purpose.
*   **`UserRole`**: A linking entity that manages the many-to-many relationship between Users and Roles.
    *   `IdentificadorUserRole` (Guid): Unique identifier for the user-role assignment.
    *   `User` (User): Reference to the User.
    *   `Role` (Role): Reference to the Role.
*   **`LoginHistory`**: Records login attempts made by users.
    *   `IdentificadorHistorico` (Guid): Unique identifier for the login history record.
    *   `User` (User): Reference to the User who attempted to log in.
    *   `LoginDate` (DateTime): Timestamp of the login attempt.
    *   `IpAdress` (string): IP address from which the login attempt was made.
    *   `IsSuccessful` (bool): Indicates whether the login attempt was successful.

## Setup and Configuration

This is a .NET project. To get started:

1.  **Database Configuration**:
    *   The API project (`src/IdentityHub.API`) uses Entity Framework Core and is configured to connect to a SQL Server database.
    *   The connection string is located in `src/IdentityHub.API/appsettings.json` and can be overridden for development in `src/IdentityHub.API/appsettings.Development.json`. You will need to update this to point to your SQL Server instance.
    *   Ensure you have the .NET SDK installed.
    *   Run Entity Framework migrations to set up the database schema (e.g., using `dotnet ef database update` from the `src/IdentityHub.Infrastructure` or `src/IdentityHub.API` directory, assuming EF tools are installed and a `DbContext` is correctly set up for migrations in `IdentityHub.Infrastructure`).

2.  **Building and Running the Project**:
    *   Navigate to the API project directory: `cd src/IdentityHub.API`
    *   Build the project: `dotnet build`
    *   Run the project: `dotnet run`

## API Endpoints

The `Program.cs` in `IdentityHub.API` is configured to use controllers (`builder.Services.AddControllers();` and `app.MapControllers();`). However, specific controller classes and their corresponding API endpoints are not yet clearly defined within the provided project structure.

This section should be updated once controllers and routes are added to the `IdentityHub.API` project.

## How to Contribute

We welcome contributions! If you'd like to contribute to IdentityHub, please follow these general steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix (e.g., `feature/your-feature-name` or `fix/issue-description`).
3.  Make your changes, ensuring you adhere to the project's coding style and add tests where appropriate.
4.  Commit your changes with clear and descriptive commit messages.
5.  Push your branch to your forked repository.
6.  Open a pull request against the main branch of this repository.

## License

This project is licensed under the terms of the LICENSE file.
