# Tracker Dashboard - Front End User Guide

## Overview
The Tracker application is a simple yet powerful dashboard for managing industrial projects, machines, and issue tracking. It allows you to organize projects with multiple machines, assign people to projects, report issues, and track their resolution.

## Features

### 1. **Dashboard (Home)**
- **Quick Overview**: View all projects at a glance with key statistics
- **Project Cards**: Each project displays:
  - Number of associated machines
  - Number of people assigned
  - Open and total issue count
  - Project status color-coded by open issues (green = all resolved, yellow = open issues)
- **Quick Actions**: 
  - Create new projects
  - View project details
  - Report issues directly from dashboard

### 2. **Project Management**
#### Create a Project
1. Click "New Project" button on dashboard or go to Projects page
2. Enter project name and optional description
3. Click "Create Project"

#### View Project Details
1. From dashboard or Projects page, click "View Details"
2. See complete project information in tabbed interface:
   - **Machines Tab**: All machines associated with the project
   - **People Tab**: Team members assigned to the project
   - **Issues Tab**: All issues related to the project

#### Add People to a Project
1. Open project details
2. Go to "People" tab
3. Click "Add Person" button
4. Select from existing people or create new

#### Edit Project
1. Click "Edit Project" button on project details page
2. Update project name and/or description
3. Save changes

### 3. **Machine Management**
#### Add a Machine
1. From project details, go to "Machines" tab
2. Click "Add Machine"
3. Enter machine serial number
4. Select the project
5. Save

#### View Machine Details
1. Click on a machine from project details
2. See machine information and related issues
3. View statistics (total, open, and resolved issues)

### 4. **Issue Tracking**

#### Report an Issue
1. Click "Report Issue" button (available from dashboard, project details, or Issues page)
2. Fill in issue details:
   - **Title**: Brief issue name
   - **Description**: Detailed problem description
   - **Severity**: Choose from Low, Medium, High, Critical
   - **Project**: Select affected project
   - **Machine** (optional): Select specific machine if applicable
   - **Reported By**: Select who reported the issue
   - **Assign To** (optional): Assign to team member for resolution
3. Click "Report Issue"

#### View Issues
- **All Issues Page**: Click "Issues" in navigation
- **Filtering**: View by status:
  - **All Issues**: Every issue in the system
  - **Open Issues**: Only unresolved issues (sorted by severity)
  - **Resolved Issues**: Only completed issues
- **Issue List**: Shows title, project, machine, severity, reporter, assignee, status, and date

#### Issue Details & Resolution
1. Click on any issue to view full details
2. See complete information:
   - Issue title and description
   - Severity level (color-coded)
   - Project and machine reference
   - Who reported and who it's assigned to
   - Dates reported and resolved
3. **To Resolve an Issue**:
   - Click "Mark as Resolved" button
   - Enter resolution notes
   - Save
   - Issue moves to resolved state with timestamp

### 5. **People Management**
#### Add a Person
1. Go to People page from navigation
2. Click "Add Person"
3. Enter:
   - First Name
   - Last Name
   - Email Address
4. Save

#### View People
- People page lists all registered people
- Shows name, email, and number of assigned projects
- All people are available for assignment to projects or issues

## Navigation

### Main Menu
- **Dashboard**: Overview of all projects and quick stats
- **Projects**: Full list and management of projects
- **Issues**: Complete issue tracking system
- **People**: Team member directory

## Color Coding

### Severity Badges
- 🔴 **Critical**: Red - Immediate attention required
- 🟠 **High**: Orange/Yellow - Important issue
- 🔵 **Medium**: Blue - Standard priority
- ⚪ **Low**: Gray - Minor issue

### Status Indicators
- 🟢 **Resolved**: Green - Issue completed
- 🟡 **Open**: Yellow - Issue pending
- ✅ **All Resolved**: Project with no open issues

## Quick Tips

1. **Efficient Workflow**:
   - Start by creating projects
   - Add machines to projects
   - Add team members to projects
   - Report issues as they occur
   - Track and resolve issues

2. **Best Practices**:
   - Use descriptive issue titles
   - Provide detailed descriptions for complex issues
   - Assign issues to responsible team members
   - Add resolution notes when closing issues
   - Keep machine serial numbers consistent and clear

3. **Finding Information**:
   - Use the Issues page to quickly see what needs attention
   - Project details provide full context for issues
   - Filter by status to focus on open or resolved items

## Sample Data
To test the application with sample data:
1. Navigate to `/SeedData`
2. Click "Add Sample Data"
3. The system will populate with sample projects, machines, people, and issues

## Roles and Responsibilities

### Project Roles (via Machine assignments)
- **Project**: Project management/oversight
- **Controls**: PLC and automation control systems
- **Fluid**: Hydraulic and pneumatic systems
- **Software**: Software and firmware
- **Computer**: Computing and networking hardware
- **Vision**: Vision systems and cameras
- **Programming**: Robot and system programming
- **Quality**: Quality assurance and testing
- **Service**: Field service and maintenance

People can be assigned to multiple machines and roles as needed.

## Getting Help

- All pages include intuitive buttons and navigation
- Forms provide clear validation and error messages
- Tabbed interfaces organize information logically
- Color coding provides quick visual reference
- Responsive design works on desktop and mobile
