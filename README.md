# CareerPilot.Api

CareerPilot.Api is a job search management API built with **ASP.NET Core**, **Entity Framework Core**, **SQL Server** and **Azure SQL Database**.
The goal of the project is to help users organize their job search process by tracking job offers, applications, statuses, notes, technologies required in job ads and basic recruitment statistics.

This project was created as a portfolio application to practice backend development, relational databases, Clean Architecture and cloud database integration with Azure.

---

## Project Status

The project is currently in development.

Already working:

* Clean Architecture solution split into Api, Application, Domain, Infrastructure and Tests
* Domain model with EF Core mapping and an initial migration
* SQL Server running in Docker, with the API containerised next to it
* Request DTOs and FluentValidation validators
* Swagger UI served in the Development environment

Still planned:

* REST controllers (CRUD for job ads and applications) - the API currently exposes no endpoints
* Azure SQL Database support
* Dashboard statistics

---

## Main Features

### Job Offers

Users can save and manage job offers they are interested in.

Planned fields include:

* job title
* company name
* job offer URL
* location
* work mode: remote, hybrid or on-site
* salary range
* job description
* required technologies
* notes
* date added

### Applications

Users can track applications sent for selected job offers.

Example application statuses:

* Saved
* Applied
* HR Call
* Technical Interview
* Task
* Rejected
* Offer

### Notes

Users can add notes connected with a job offer or recruitment process, for example:

* recruiter information
* interview notes
* follow-up reminders
* feedback after the interview

### Skills and Technologies

The application can store technologies mentioned in job offers, such as:

* C#
* .NET
* ASP.NET Core
* SQL
* Entity Framework Core
* Docker
* Azure
* REST API

### Dashboard

Planned dashboard statistics:

* total number of saved job offers
* number of applications sent
* number of rejected applications
* number of interviews
* most common technologies in job offers
* application conversion rate

---

## Tech Stack

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* FluentValidation
* Swagger / OpenAPI
* SQL Server
* Azure SQL Database
* Docker
* Clean Architecture
* SQL Server Management Studio

---

## Running Locally

Requirements: Docker Desktop and the .NET 10 SDK (the latter only for running migrations from the host).

### 1. Start the API and the database

```bash
cd CareerPilot
docker compose up --build
```

This builds the API image and starts two containers:

* `careerpilot` - the API, exposed on the host as **http://localhost:5219** (Swagger UI at `/swagger`)
* `db` - SQL Server 2022, exposed on the host as **localhost,1433**

The API waits for the database healthcheck before starting, so the first run takes a bit longer while SQL Server boots.
Database files live in the named volume `sql_data`, so they survive `docker compose down`. Use `docker compose down -v` to wipe them.

### 2. Apply the database migrations

The containers only start the database - the schema is created by EF Core migrations, run from the host:

```bash
cd CareerPilot
ASPNETCORE_ENVIRONMENT=Development dotnet ef database update \
  --project CareerPilot.Infrastructure \
  --startup-project CareerPilot.Api
```

On PowerShell, set the variable first: `$env:ASPNETCORE_ENVIRONMENT = 'Development'`.

Two details worth knowing:

* `--project` points at Infrastructure because that is where `AppDbContext` and the migrations live; `--startup-project` points at Api because that is where the context is registered and the configuration is read from.
* `ASPNETCORE_ENVIRONMENT=Development` is required, because the connection string only exists in `appsettings.Development.json`.

### Configuration

The local SA password is kept as-is in `compose.yaml` and `appsettings.Development.json`. This is a deliberate trade-off for a portfolio project: the database is local, holds no real data, and a plain `docker compose up` keeps the repo easy to review. Before this project goes any further (deployment, real data, more than one developer), the password should move to a `.env` file next to `compose.yaml` - `.env` and `.env.*` are already gitignored.

---

## Azure Usage

The first Azure service planned for this project is **Azure SQL Database**.

The application can be developed locally with SQL Server and later connected to Azure SQL Database by changing the connection string.

Planned Azure-related goals:

* create Azure SQL Database
* connect ASP.NET Core API to Azure SQL Database
* keep local and cloud database configurations separated
* store connection strings safely outside the repository

Future Azure ideas:

* Azure Blob Storage for uploaded CV files
* Azure App Service for hosting the API
* Application Insights for monitoring
* Azure Key Vault for secrets

---

## Project Structure

```txt
CareerPilot
│
├── CareerPilot.Api             (controllers, DI setup, Dockerfile)
├── CareerPilot.Application     (DTOs, FluentValidation validators)
├── CareerPilot.Domain          (entities, enums)
├── CareerPilot.Infrastructure  (AppDbContext, EF Core migrations)
├── CareerPilot.Tests
└── compose.yaml                (API + SQL Server for local development)
```

---

## Domain Entities

Currently implemented and mapped to the database:

```txt
JobAd            - a saved job ad, with its application status and dates
JobInterview     - an interview connected with a job ad
EmployerMessage  - a message received from an employer
ApplicationFile  - a reusable application material (CV, cover letter)
```

Relationships:

* one job ad can have many interviews

Enums:

* `ApplicationStatus`: NotSent, Sent, JobInterview, Rejected, Accepted
* `JobAdStatus`: Active, Archived
* `ApplicationFileType`

Note that the application status lives directly on `JobAd` - there is no separate `Application` entity. Companies, notes and skills are not modelled as entities yet.

---

## Example API Endpoints

Planned - no controllers are implemented yet, so the running API currently serves only Swagger.

```http
GET    /api/job-offers
GET    /api/job-offers/{id}
POST   /api/job-offers
PUT    /api/job-offers/{id}
DELETE /api/job-offers/{id}

GET    /api/applications
GET    /api/applications/{id}
POST   /api/applications
PATCH  /api/applications/{id}/status
DELETE /api/applications/{id}

GET    /api/dashboard/statistics
```

---

## Roadmap

### Version 1 - MVP

* [x] Create Clean Architecture solution structure
* [x] Add core domain entities
* [x] Configure SQL Server database (Docker + EF Core)
* [x] Add Entity Framework Core migrations
* [x] Add application statuses
* [x] Add FluentValidation
* [x] Add Swagger documentation
* [ ] Create CRUD for job offers
* [ ] Create CRUD for applications

### Version 2 - Azure SQL Database

* [ ] Create Azure SQL Database
* [ ] Configure cloud connection string
* [ ] Test EF Core migrations with Azure SQL
* [ ] Add environment-based configuration
* [ ] Update README with Azure setup

### Version 3 - Dashboard

* [ ] Add recruitment statistics
* [ ] Count applications by status
* [ ] Show most common technologies
* [ ] Add simple job search progress summary

### Version 4 - Extra Features

* [ ] Upload CV files
* [ ] Add Azure Blob Storage
* [ ] Assign CV versions to applications
* [ ] Add reminders
* [ ] Add basic job offer analysis

---

## Author

Created by **Natalia Szolc** as a backend development portfolio project.

GitHub: [github.com/nszolc](https://github.com/nszolc)
Portfolio: [nszolc.dev](https://nszolc.dev)
