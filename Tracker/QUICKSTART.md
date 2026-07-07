# Quick Start Guide - Tracker Dashboard

## Installation & Setup

### Prerequisites
- .NET 10 SDK
- Visual Studio 2026 or compatible IDE
- SQL Server or compatible database

### Steps

1. **Update Database**:
   ```bash
   cd Tracker
   dotnet ef database update
   ```

2. **Run the Application**:
   ```bash
   dotnet run
   ```

   The app will be available at `https://localhost:5001`

3. **(Optional) Add Sample Data**:
   - Navigate to `https://localhost:5001/SeedData`
   - Click "Add Sample Data"
   - Database will be populated with example projects, machines, people, and issues

## First-Time User Workflow

### 5-Minute Setup

1. **Go to Dashboard** (`/`)
   - See the main overview
   - Notice "No projects yet" message

2. **Create Your First Project**
   - Click "New Project"
   - Enter: Name = "My First Project"
   - Enter: Description = "Test project"
   - Click "Create Project"
   - You're redirected to project details

3. **Add a Person**
   - Go to "People" in navigation
   - Click "Add Person"
   - Fill in: First Name, Last Name, Email
   - Click "Add Person"

4. **Assign Person to Project**
   - Go to Projects → Your Project → Details
   - Click "People" tab
   - Click "Add Person"
   - Select the person you just created
   - Click "Add to Project"

5. **Add a Machine**
   - Still in Project Details → "Machines" tab
   - Click "Add Machine"
   - Enter Serial Number (e.g., "MACHINE-001")
   - Click "Add Machine"

6. **Report an Issue**
   - Click "Report Issue" button
   - Fill in:
	 - Title: "Test Issue"
	 - Description: "This is a test issue"
	 - Severity: "Medium"
	 - Project: Select your project
	 - Machine: Select your machine (optional)
	 - Reported By: Select the person
   - Click "Report Issue"

7. **Resolve the Issue**
   - Click on the issue in the Issues list
   - Click "Mark as Resolved"
   - Enter resolution notes
   - Click "Mark as Resolved"
   - Issue now shows as Resolved ✅

## Main Pages Overview

| Page | Purpose | Access |
|------|---------|--------|
| Dashboard | Quick overview of all projects | `/` or Dashboard nav |
| Projects | Manage all projects | Projects nav → Index |
| Project Details | View/edit specific project | Projects → Details |
| Issues | View and filter all issues | Issues nav |
| Issue Details | Resolve issues | Issues → Select Issue |
| People | Manage team members | People nav |

## Common Tasks

### Create a New Project
1. Dashboard → "New Project" OR Projects → "Create New Project"
2. Enter project information
3. Click "Create Project"

### Report an Issue
1. Any page → "Report Issue" button
2. Fill in issue details
3. Click "Report Issue"

### Resolve an Issue
1. Issues → Click issue → Click "Mark as Resolved"
2. Enter resolution notes
3. Click "Mark as Resolved"

### Add a Team Member to a Project
1. Project Details → People tab → "Add Person"
2. Select person from dropdown
3. Click "Add to Project"

### Add a Machine to a Project
1. Project Details → Machines tab → "Add Machine"
2. Enter serial number
3. Select project
4. Click "Add Machine"

## Understanding the Dashboard

### Project Card Statistics
- **Machines**: Total machines in project
- **People**: Team members assigned
- **Open Issues**: Unresolved issues needing attention

### Status Colors
- 🟢 Green: All issues resolved
- 🟡 Yellow: Issues need attention

### Severity Levels
- 🔴 **Critical**: Immediate attention required
- 🟠 **High**: Important, needs prompt attention
- 🔵 **Medium**: Standard priority
- ⚪ **Low**: Minor issue, can wait

## Filtering & Searching

### Filter Issues by Status
- **All Issues**: Every issue in system
- **Open**: Unresolved issues (sorted by severity)
- **Resolved**: Completed issues

### Sort Order
- **Open Issues**: By severity first (Critical → High → Medium → Low), then by date
- **Resolved Issues**: By resolution date (newest first)

## Navigation Tips

1. **Breadcrumb Navigation**: 
   - Click project names in details to navigate back
   - "Back" buttons available on most pages

2. **Quick Links**:
   - "View Details" from dashboard goes to project
   - "Report Issue" available almost everywhere
   - "Back to Project" links from related pages

3. **Tab Organization**:
   - Project details use tabs: Machines, People, Issues
   - Switch between tabs without losing data

## Best Practices

✅ **Do**:
- Use descriptive project names and descriptions
- Add detailed issue descriptions
- Assign issues to responsible team members
- Add resolution notes when closing issues
- Use appropriate severity levels
- Keep machine serial numbers consistent

❌ **Don't**:
- Leave issues unassigned too long
- Use vague issue titles
- Create projects without descriptions
- Skip adding people to projects
- Leave sensitive machines untracked

## Troubleshooting

### No Projects Showing
- Check if database was updated: `dotnet ef database update`
- Create a new project manually

### Machines Not Showing
- Add machine from Project Details → Machines tab
- Refresh the page

### People Not Showing in Dropdowns
- Create people first from People page
- Ensure they're added to project

### Changes Not Saving
- Check browser console for errors (F12)
- Ensure all required fields are filled
- Try refreshing the page

## Support

For detailed feature documentation, see: `DASHBOARD_GUIDE.md`
For technical implementation details, see: `IMPLEMENTATION_SUMMARY.md`

---

**Ready to start?** Go to `https://localhost:5001/` and create your first project! 🚀
