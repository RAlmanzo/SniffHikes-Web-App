# 🐾 SniffHikes Web App

**SniffHikes** is a full-stack web application designed for people who enjoy hiking with their dogs. It allows users to register, share hiking events and routes, interact via comments, and engage with a like-minded community. The application includes a role-based system with admin moderation features for content and user management.

---

## 📸 Key Features

- 🐶 Create, join, and manage **hiking events**
- 🗺️ Share and explore **hiking routes**
- 💬 Leave **comments** on events or posts
- 🔐 **User registration, login, and JWT-based authentication**
- 🛡️ Role-based **authorization policies** (e.g., admin access)
- 📊 Admin section: manage users, events, routes, and comments
- 📘 **Swagger** UI for API documentation
- 🗂️ Backend structured using **Onion/Clean Architecture**

---

## 🧰 Tech Stack

### 🔹 Frontend

- **ASP.NET Core MVC**
- **Vue.js 2**
- **HTML5, CSS, Bootstrap**

### 🔸 Backend

- **ASP.NET Core Web API**  
- **Entity Framework Core** (ORM)
- **Microsoft SQL Server**
- **Microsoft Identity** for user management
- **JWT Tokens** for authentication/authorization
- **Policy-based Authorization**
- **Swagger** (OpenAPI) for API documentation
- **xUnit** for unit testing

---

## 🧱 Architecture Overview

This project uses the **Onion (Clean) Architecture**, promoting separation of concerns and testability:

PRI.Project.Rosseel_Almanzo/

│

├── PRI.Project.Rosseel_Almanzo.API/ # API entry point (controllers, Swagger config)

├── PRI.Project.Rosseel_Almanzo.Core/ # Domain entities, interfaces, DTOs, validation

├── PRI.Project.Rosseel_Almanzo.Infrastructure/ # EF Core, Identity, repository implementations

├── PRI.Project.Rosseel_Almanzo.Web/ # MVC + Vue2 frontend

└── PRI.Project.Rosseel_Almanzo.Tests/ # xUnit test project with mocking

---

## 🧪 Authentication & Authorization

- ✅ **JWT-based token system** for user login
- 🔐 Secured API endpoints using **[Authorize]** attributes
- 🛡️ **Role-based policies** for admin functionality
- 🔑 Tokens include roles and expire after a configured time

---

## 🧪 Testing

- ✅ Unit testing with **xUnit**
- 🔁 Mocks and dependency injection for isolation
- 🧪 Tests for services

Run all tests:

```bash
dotnet test
```

## 🐳 Database & Migrations
Uses SQL Server as the primary database

Configured via secrets.json

EF Core Migrations are used for schema changes

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### 📘 Swagger

Swagger is integrated for all API endpoints:

Accessible at: https://localhost:7038/swagger

Supports JWT token entry for authorized endpoints

Auto-generated from attributes and annotations

### ⚙️ GitHub Actions – CI/CD (to be implemented)

A GitHub Actions workflow is set up to ensure quality and stability.

✅ On every push or pull request to main or dev:

Builds the solution with dotnet build

Runs all unit tests with dotnet test

Fails early if build or tests don't pass

This ensures reliable merges and production readiness.

### 🧠 What I Learned

This project gave me hands-on experience with:

🔧 Building full-stack .NET applications with MVC + Web API

🔐 Implementing JWT-based authentication and policy authorization

🧩 Working with modular Onion architecture

📦 Integrating frontend (Vue) within an ASP.NET Core MVC app

💬 Managing real user-generated content (comments, routes, events)

📘 API documentation with Swagger

🧪 Writing and structuring unit tests

## 🚀 Getting Started

### Requirements
.NET 8 SDK

SQL Server

Node.js (for Vue build support)

Run the backend API:
bash
Kopiëren
Bewerken
cd SniffHikes.API
dotnet run
Run the frontend (if split):
bash
Kopiëren
Bewerken
cd SniffHikes.Web
dotnet run

### 📬 Contact
Want to connect or ask questions?

📧 Email: your.email@example.com

💼 LinkedIn: Your Name

🐙 GitHub: your-username
