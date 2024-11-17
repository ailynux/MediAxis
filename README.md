<div align="center">

# 🏥 Hospital Management System

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-7.0-brightgreen.svg)](https://docs.microsoft.com/en-us/aspnet/core/)
[![React](https://img.shields.io/badge/React-18.0-blue.svg)](https://reactjs.org/)
[![Material-UI](https://img.shields.io/badge/Material--UI-5.0-purple.svg)](https://mui.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A modern, full-stack Hospital Management System built with ASP.NET Core and React.
Streamline patient care, appointment scheduling, and health record management with our intuitive interface.

[Features](#features) • [Quick Start](#quick-start) • [Documentation](#documentation) • [Contributing](#contributing)

![Hospital Management System Dashboard](https://via.placeholder.com/800x400?text=Hospital+Management+System+Dashboard)

</div>

## ✨ Features

### Core Functionality

- 👥 **User Management**

  - Role-based access control (Doctors, Nurses, Patients)
  - Secure authentication using JWT
  - Customizable user profiles

- 🏥 **Patient Management**

  - Comprehensive patient records
  - Medical history tracking
  - Document upload and management

- 📅 **Appointment Scheduling**

  - Real-time availability checking
  - Automated reminders
  - Conflict detection
  - Multi-provider support

- 📋 **Health Records**
  - Secure electronic health records (EHR)
  - Digital prescription management
  - Lab result integration
  - HIPAA-compliant data storage

### Technical Features

- 🔄 Real-time updates using SignalR
- 📱 Responsive design for all devices
- 🌓 Dark/Light theme support
- 🔒 Enhanced security measures
- 📊 Advanced analytics dashboard

## 🚀 Quick Start

### Prerequisites

```bash
# Required installations
Node.js (v14+)
.NET SDK (6.0+)
SQLite
```

### Backend Setup

```bash
# Clone repository
git clone https://github.com/yourusername/hospital-management.git

# Navigate to backend
cd hospital-management/backend

# Install dependencies
dotnet restore

# Update database
dotnet ef database update

# Start server
dotnet run
```

### Frontend Setup

```bash
# Navigate to frontend
cd ../frontend

# Install dependencies
npm install

# Start development server
npm start
```

## 🏗️ Architecture

```
hospital-management/
├── backend/
│   ├── Controllers/         # API endpoints
│   ├── Data/               # Database context & repositories
│   ├── Models/             # Domain models
│   ├── Services/           # Business logic
│   └── Program.cs          # Application entry point
│
├── frontend/
│   ├── src/
│   │   ├── components/     # Reusable UI components
│   │   ├── pages/         # Main application views
│   │   ├── services/      # API integration
│   │   └── utils/         # Helper functions
│   └── package.json
```

## 🛠️ Technologies

### Backend Stack

- **ASP.NET Core** - Web API framework
- **SQLite** - Database
- **Dapper** - Micro-ORM
- **JWT** - Authentication
- **SignalR** - Real-time communications

### Frontend Stack

- **React** - UI framework
- **Material-UI** - Component library
- **React Query** - Data fetching
- **React Router** - Navigation
- **Axios** - HTTP client

## 📖 Documentation

Detailed documentation available in the [`/docs`](docs/) directory:

- [API Documentation](docs/api.md)
- [Database Schema](docs/schema.md)
- [Deployment Guide](docs/deployment.md)
- [Contributing Guidelines](docs/contributing.md)

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Material-UI for the amazing component library
- The ASP.NET Core team
- All our contributors

---

<div align="center">

Made with ❤️ by Ailyn Diaz

[⬆ Back to top](#hospital-management-system)

</div>
