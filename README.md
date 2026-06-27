# CareerPilot.Api

CareerPilot.Api is a job search management API built with **ASP.NET Core**, **Entity Framework Core**, **SQL Server** and **Azure SQL Database**.
The goal of the project is to help users organize their job search process by tracking job offers, applications, statuses, notes, technologies required in job ads and basic recruitment statistics.

This project was created as a portfolio application to practice backend development, relational databases, Clean Architecture and cloud database integration with Azure.

---

## Project Status

The project is currently in development.

Planned core version:

* REST API for managing job offers and applications
* SQL Server database with Entity Framework Core
* Azure SQL Database support
* Clean Architecture structure
* FluentValidation for request validation
* Swagger documentation
* Docker support for local development

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
* .NET 9
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
├── CareerPilot.Api
├── CareerPilot.Application
├── CareerPilot.Domain
├── CareerPilot.Infrastructure
└── CareerPilot.Tests
```

---

## Example Domain Entities

Planned main entities:

```txt
User
Company
JobOffer
Application
ApplicationStage
Note
Skill
JobOfferSkill
```

Example relationships:

* one company can have many job offers
* one job offer can have one application
* one application can have many stages
* one job offer can have many notes
* one job offer can include many required skills

---

## Example API Endpoints

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

* [ ] Create Clean Architecture solution structure
* [ ] Add core domain entities
* [ ] Configure SQL Server database
* [ ] Add Entity Framework Core migrations
* [ ] Create CRUD for job offers
* [ ] Create CRUD for applications
* [ ] Add application statuses
* [ ] Add FluentValidation
* [ ] Add Swagger documentation

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
::: 
