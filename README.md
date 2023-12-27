# Khata Inventory Management System

Welcome to the Khata Inventory Management System repository! Khata is a comprehensive inventory management system designed to facilitate CRUD operations and user authentication through login/signup functionalities.

## Table of Contents

1. [Technologies Used](#technologies-used)
2. [Getting Started](#getting-started)
3. [Project Structure](#project-structure)
4. [Setting Up Database](#setting-up-database)
5. [Running the Project](#running-the-project)
6. [Contributing](#contributing)
7. [License](#license)

## Technologies Used

- **Blazor Web Server**: Utilized for the frontend development, providing a rich and interactive user interface.
- **ASP.Net and C#**: The backbone of the application, used for logic building and backend development.
- **SQL Server**: The database management system employed for data storage and retrieval.

## Getting Started

To start working with Khata, follow these steps:

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/chmuhammadasim/Inventory-Management-Blazor.git
   ```

2. Open the solution file located in the `IMS` folder using Visual Studio or VS Code.

## Project Structure

The project is organized into the following folders:

1. **IMS.CoreBusiness**: This folder contains model classes defining entities crucial to the application's domain.

2. **IMS.Plugins.EFCore**: Here, you'll find classes that hold the function definitions responsible for executing operations on the database using Entity Framework Core.

3. **IMS.UserCases**: This layer acts as a data link, connecting the functions defined in `IMS.Plugins.EFCore` to the frontend.

4. **IMS**: The main project file that ties everything together.

5. **IMSProject**: The frontend project responsible for delivering a seamless user experience.

## Setting Up Database

Before running the project, ensure you have set up a SQL Server database and added the connection string to the `appsettings.js` and `appsettings.Development.js` files.

```javascript
// appsettings.js
{
  "ConnectionStrings": {
    "DefaultConnection": "your-database-connection-string"
  }
}
```

## Running the Project

Run the project in Visual Studio or VS Code by loading the solution file in the `IMS` folder. Make sure the database connection string is correctly configured.

## Contributing

Contributions are welcome! If you encounter any issues or have suggestions for improvement, feel free to open an issue or create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
