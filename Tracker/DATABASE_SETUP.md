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

**⚠️ Important:** Update these with your actual PostgreSQL credentials!

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

### 3. Verify Database
You can connect to PostgreSQL and verify tables were created:
```bash
psql -h localhost -U postgres -d tracker_dev
\dt
```

## Database Schema

### Tables Created:
- **Projects** - Main project entity with self-reference
- **Machines** - Machine records with serial numbers
- **People** - Person records with contact information
- **Roles** - Role definitions with department leads
- **Issues** - Issue tracking with severity levels
- **MachineProjectPersons** - Many-to-many join table
- **MachineControlsPersons** - Many-to-many join table
- **MachineFluidPersons** - Many-to-many join table
- **MachineSoftwarePersons** - Many-to-many join table
- **MachineComputerPersons** - Many-to-many join table
- **MachineVisionPersons** - Many-to-many join table
- **MachineProgrammingPersons** - Many-to-many join table
- **MachineQualityPersons** - Many-to-many join table
- **MachineServicePersons** - Many-to-many join table

### Key Features:
- All entities have auto-generated `Id` primary keys
- Self-referencing relationships (Projects and Machines can reference other instances)
- Many-to-many relationships between Machines and People for different roles
- Foreign key constraints properly configured
- Cascade delete configured where appropriate

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

## Using the DbContext in Razor Pages

### Example: Inject in Page Model
```csharp
public class IndexModel : PageModel
{
	private readonly TrackerContext _context;

	public IndexModel(TrackerContext context)
	{
		_context = context;
	}

	public async Task OnGetAsync()
	{
		var projects = await _context.Projects
			.Include(p => p.Machines)
			.ToListAsync();
	}
}
```

### Example: Add New Entity
```csharp
public async Task<IActionResult> OnPostAsync()
{
	var person = new Person
	{
		FirstName = "John",
		LastName = "Doe",
		Email = "john.doe@example.com"
	};

	_context.People.Add(person);
	await _context.SaveChangesAsync();

	return RedirectToPage();
}
```

## Troubleshooting

### Connection Issues
- Verify PostgreSQL is running
- Check connection string credentials
- Ensure database exists or EF can create it

### Migration Issues
- Make sure you're in the Tracker directory
- Verify the project builds successfully
- Check that all model changes are saved

### Build Errors
- Clean and rebuild: `dotnet clean && dotnet build`
- Delete `Migrations` folder and recreate if needed

## Security Notes

⚠️ **Never commit real passwords to source control!**

For production:
1. Use User Secrets for development:
   ```bash
   dotnet user-secrets set "ConnectionStrings:TrackerContext" "Host=localhost;Database=tracker;Username=myuser;Password=mypassword"
   ```

2. Use environment variables or Azure Key Vault for production

## Additional Resources
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Npgsql EF Core Provider](https://www.npgsql.org/efcore/)
