# TuksConnect

A campus events app. It's an Angular front end on top of an ASP.NET Core Web API: users can list, add, edit and delete events, each with a title, location and ticket price.

Built for INF 354 (Assignment 1) at the University of Pretoria.

## Features

- **Events list**: view every event.
- **Add event**: create an event with a title, location and ticket price.
- **Edit event**: update an existing event.
- **Delete event**: remove an event from the list.
- **REST API** with Swagger UI for exploring and testing the endpoints.
- **Unit tests** for the event controller (xUnit + Moq).

## Tech stack

| Layer | Technology |
|---|---|
| Front end | Angular 21, Bootstrap 5 |
| API | ASP.NET Core Web API (.NET 8), Swagger |
| Data | Entity Framework Core with SQL Server LocalDB, repository pattern |
| Tests | xUnit, Moq |

## API endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/api/event` | List all events |
| GET | `/api/event/{id}` | Get one event |
| POST | `/api/event` | Create an event |
| PUT | `/api/event/{id}` | Update an event |
| DELETE | `/api/event/{id}` | Delete an event |

## Running locally

### Prerequisites
- Visual Studio 2022 (with the **ASP.NET and web development** workload, which includes SQL Server LocalDB) or the .NET 8 SDK
- Node.js and the Angular CLI (`npm install -g @angular/cli`)

### 1. Start the API
1. Open `TuksConnectAPI.sln` in Visual Studio.
2. Create the database by running this in the **Package Manager Console**:
   ```
   Update-Database
   ```
   This applies the EF Core migrations to `TuksConnectDB` on `(localdb)\mssqllocaldb`.
3. Run the `https` profile. The API listens on `https://localhost:7226`, and Swagger is at `https://localhost:7226/swagger`.

### 2. Start the Angular app
```bash
cd tuksconnect-ui
npm install
ng serve
```
Open `http://localhost:4200`. The API only allows requests from this address (CORS).

### Running the tests
Open **Test Explorer** in Visual Studio and run all tests, or use:
```bash
dotnet test
```

## Project structure

```
TuksConnectAPI/          # ASP.NET Core Web API
├── Controllers/EventController.cs
├── Data/AppDbContext.cs
├── Models/Event.cs
├── Repositories/        # IEventRepository + EventRepository
└── Migrations/
TuksConnectAPI.Tests/    # xUnit tests
tuksconnect-ui/          # Angular front end
└── src/app/
    ├── components/      # event-list, add-event, edit-event, navbar
    └── services/event.service.ts
```
