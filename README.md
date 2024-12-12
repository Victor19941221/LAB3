# Lab3
A brief description of what this project is and what it does.
Table of Contents

    About
    Features
    Prerequisites
    Getting Started
    Configuration
    Running the Application
    Database Setup
    Additional Information
    

About

This project is an ASP.NET Core web application that provides XYZ functionality. It uses ASP.NET Core Identity for authentication and authorization, supports external logins, and includes features like role management, user profile picture uploads, and two-factor authentication.
Features

    User Registration & Login: Users can register and log in with an email or username.
    Two-Factor Authentication (2FA): Enhance security using authenticator apps.
    Role Management: Administrators can create, edit, and remove roles; assign roles to users.
    Profile Management: Users can update their profiles, including uploading a profile picture.
    Email Confirmation & Password Reset: Users receive confirmation emails for registration and can reset their passwords.
    Enforced Driving License Claim: Demonstrates using policies to restrict access based on a "Korkort" (license type) claim.

Prerequisites

    .NET 9 SDK
    SQL Server or another compatible database provider
    Optional: Visual Studio 2022 or Visual Studio Code for development

Getting Started

    Clone the repository:

    git clone https://github.com/YourUsername/YourRepoName.git
    cd YourRepoName

    Check .gitignore and appsettings.json: Make sure sensitive data (like connection strings, passwords, API keys) are not checked into source control. Set them using user secrets or environment variables for local development.

Configuration

    Connection Strings:
    Update the ConnectionStrings:DefaultConnection in appsettings.json or in appsettings.Development.json.

    For example:

    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=YourDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }

    Email Settings:
    The application uses an IEmailSender implementation. Update credentials in EmailSender.cs or use environment variables. Replace the placeholder email/password with your own SMTP service credentials.

Running the Application

    Restore and Build:

dotnet restore
dotnet build

Apply Migrations:

dotnet ef database update

Run the application:

    dotnet run

    The application will be available at https://localhost:5001 or http://localhost:5000 by default (depending on your launch settings).

Database Setup

    The project uses EF Core Migrations to manage database schema.
    Run dotnet ef migrations add InitialCreate to create a new migration if needed.
    Run dotnet ef database update to apply migrations to your local database.

Additional Information

    Roles Initialization:
    The project automatically seeds some roles (Admin and User) via database migrations.

    Admin User:
    An admin user may be seeded into the database. Check the migrations or setup instructions for details.

    External Logins:
    Configure external login providers (like Google, Microsoft) in Program.cs by adding the relevant authentication handlers.
