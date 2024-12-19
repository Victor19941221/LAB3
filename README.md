# Lab3

A brief description of what this project is and what it does.

## Table of Contents

- [About](#about)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Database Setup](#database-setup)
- [Additional Information](#additional-information)

## About

This project is an ASP.NET Core web application that provides XYZ functionality. It uses ASP.NET Core Identity for authentication and authorization, supports external logins, and includes features like role management, user profile picture uploads, and two-factor authentication.

## Features

- **User Registration & Login:** Users can register and log in with an email or username.
- **Two-Factor Authentication (2FA):** Enhance security using authenticator apps.
- **Role Management:** Administrators can create, edit, and remove roles; assign roles to users.
- **Profile Management:** Users can update their profiles, including uploading a profile picture.
- **Email Confirmation & Password Reset:** Users receive confirmation emails for registration and can reset their passwords.
- **Enforced Driving License Claim:** Demonstrates using policies to restrict access based on a "Korkort" (license type) claim.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database provider
- Optional: [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) for development

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Victor19941221/Lab3.git
   cd Lab3
   ```

2. **Check `.gitignore` and `appsettings.json`:**
   Ensure sensitive data (like connection strings, passwords, API keys) are not checked into source control. Use user secrets or environment variables for local development.

## Configuration

1. **Connection Strings:**
   Update the `ConnectionStrings:DefaultConnection` in `appsettings.json` or `appsettings.Development.json`.

   For example:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=YourDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

2. **Email Settings:**
   The application uses an `IEmailSender` implementation. Update credentials in `EmailSender.cs` or use environment variables. Replace the placeholder email/password with your own SMTP service credentials.

## Running the Application

1. **Restore and Build:**
   ```bash
   dotnet restore
   dotnet build
   ```

2. **Apply Migrations:**
   ```bash
   dotnet ef database update
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

   The application will be available at `https://localhost:5001` or `http://localhost:5000` by default (depending on your launch settings).

## Database Setup

- The project uses EF Core Migrations to manage the database schema.
- Run the following command to create a new migration if needed:
  ```bash
  dotnet ef migrations add InitialCreate
  ```
- Apply migrations to your local database:
  ```bash
  dotnet ef database update
  ```

## Additional Information

- **Roles Initialization:** The project automatically seeds some roles (Admin and User) via database migrations.
- **Admin User:** An admin user is seeded into the database. Check the migrations  for details.
