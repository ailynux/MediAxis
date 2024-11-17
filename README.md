# Hospital Management System

This project is a Hospital Management System built using ASP.NET Core for the backend and React with Material-UI for the frontend. The system allows for managing patients, appointments, and health records, with a professional and responsive user interface.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Backend Setup](#backend-setup)
- [Frontend Setup](#frontend-setup)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Management**: Role-based access for doctors, nurses, and patients.
- **Patient Management**: Add, update, and delete patient records.
- **Appointment Scheduling**: View, schedule, reschedule, and cancel appointments.
- **Health Records**: Securely view and manage health records.
- **Real-time Notifications**: Real-time updates using SignalR (planned).
- **Responsive Design**: Mobile and desktop-friendly UI with Material-UI.
- **Dark Mode**: Toggle between light and dark themes (planned).

## Technologies Used

### Backend

- **Framework**: ASP.NET Core
- **Database**: SQLite
- **Authentication**: JWT (JSON Web Tokens)
- **ORM**: Dapper

### Frontend

- **Framework**: React
- **UI Library**: Material-UI
- **State Management**: React Query
- **Routing**: React Router
- **HTTP Client**: Axios

## Getting Started

### Prerequisites

- **Node.js**: [Download and install Node.js](https://nodejs.org/)
- **.NET SDK**: [Download and install .NET SDK](https://dotnet.microsoft.com/download)

### Backend Setup

1. **Navigate to the backend directory**:
   ```sh
   cd backend
   ```

### Project Structure
hospital-management/
├── backend/
│   ├── Controllers/
│   │   ├── AppointmentController.cs
│   │   ├── HealthRecordsController.cs
│   │   ├── PatientController.cs
│   │   └── UserController.cs
│   ├── Data/
│   │   ├── DatabaseContext.cs
│   │   ├── AppointmentRepository.cs
│   │   ├── HealthRecordRepository.cs
│   │   ├── PatientRepository.cs
│   │   └── UserRepository.cs
│   ├── Models/
│   │   ├── Appointment.cs
│   │   ├── HealthRecord.cs
│   │   ├── Patient.cs
│   │   └── User.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── Startup.cs
├── frontend/
│   ├── public/
│   ├── src/
│   │   ├── components/
│   │   │   ├── Header.js
│   │   │   ├── Sidebar.js
│   │   │   └── HealthRecordTable.js
│   │   ├── pages/
│   │   │   ├── Dashboard.js
│   │   │   ├── HealthRecords.js
│   │   │   └── Patients.js
│   │   ├── App.js
│   │   ├── api.js
│   │   ├── index.js
│   │   └── theme.js
│   ├── package.json
│   └── [README.md](http://_vscodecontentref_/0)

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.
