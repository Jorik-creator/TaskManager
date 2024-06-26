# Task Manager Calendar Web App

A simple yet effective web application for managing events and resources using a calendar interface. Built with ASP.NET Core for the backend, React for the frontend, and DayPilot Pro for the calendar component.

## Features

### Event Management:
- Create, edit, and delete events with details like title, start/end times.
- Visualize events in a clear calendar view (day, week, or month).

### Intuitive Interface:
- User-friendly design for easy navigation and event management.
- Drag-and-drop functionality for rescheduling events.

## Technology Stack:
- **Backend:** C#, ASP.NET Core, Entity Framework Core, SQLite
- **Frontend:** React, DayPilot Pro (calendar component)
- **Additional:** Axios (for HTTP requests)

## Getting Started

### Prerequisites:
- .NET SDK
- Node.js and npm (or yarn)

### Backend Setup:
1. Clone the repository: `git clone https://github.com/Jorik-creator/TaskManager`
2. Navigate to the backend directory: `cd TaskManager`
3. Restore dependencies: `dotnet restore`
4. Apply migrations: `dotnet ef database update`
5. Run the backend: `dotnet run`

### Frontend Setup:
1. Navigate to the frontend directory: `cd task-manager-client`
2. Install dependencies: `npm install` (or `yarn install`)
3. Start the frontend: `npm start` (or `yarn start`)

### Access the App:
Open your browser and visit [http://localhost:3000](http://localhost:3000) (or the appropriate port).

## Configuration
Update the `axios.defaults.baseURL` in `src/Calendar.js` to match your backend URL if it's different from the default.

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Make your changes and commit them: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a pull request.

## License
This project is licensed under the MIT License.
