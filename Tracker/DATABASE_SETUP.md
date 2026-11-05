# Database Setup Guide

## Overview
This project uses **PostgreSQL** with **Entity Framework Core 10.0** for database management.

## Prerequisites
- PostgreSQL installed locally or running in Docker
- .NET 10 SDK installed
- dotnet-ef tools installed (already done)

## Connection Strings

### Development
Located in `appsettings.Development.json`:
```json
"TrackerContext": "Host=localhost;Database=tracker_dev;Username=postgres;Password=postgres"
```

### Production
Located in `appsettings.json`:
```json
"TrackerContext": "Host=localhost;Database=tracker;Username=postgres;Password=postgres"
```

## Quick Start

### 1. Start PostgreSQL
If using Docker:
```bash
docker run --name tracker-postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

### 2. Apply Migrations to Create Database
```bash
cd Tracker
dotnet ef database update
```

This will:
- Create the database (tracker_dev or tracker depending on environment)
- Create all tables: Projects, Machines, People, Roles, Issues
- Set up all relationships and foreign keys

## Common Entity Framework Commands

### Create a New Migration
After changing models:
```bash
dotnet ef migrations add <MigrationName>
```

### Apply Migrations
```bash
dotnet ef database update
```

### Remove Last Migration (if not applied)
```bash
dotnet ef migrations remove
```

### View All Migrations
```bash
dotnet ef migrations list
```

### Update to Specific Migration
```bash
dotnet ef database update <MigrationName>
```

### Rollback All Migrations
```bash
dotnet ef database update 0
```

### Generate SQL Script
```bash
dotnet ef migrations script
```
## Additional Resources
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Npgsql EF Core Provider](https://www.npgsql.org/efcore/)
