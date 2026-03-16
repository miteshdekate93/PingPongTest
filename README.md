# Ping Pong App 🏓

![Build](https://github.com/miteshdekate93/PingPongTest/actions/workflows/ci.yml/badge.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Tests](https://img.shields.io/badge/tests-xUnit-blue)
![License](https://img.shields.io/badge/license-MIT-green)

A full-featured Ping Pong **player management system** built with ASP.NET MVC, Entity Framework, and a comprehensive xUnit test suite. Demonstrates clean MVC architecture, database-driven CRUD operations, and CI/CD best practices.

---

## Features

- ✅ Player registration and profile management
- ✅ CRUD operations (Create, Read, Update, Delete players)
- ✅ Entity Framework Code-First database with auto-migration
- ✅ Comprehensive xUnit unit and integration test suite
- ✅ GitHub Actions CI pipeline — tests run on every push and PR
- ✅ Docker support for containerized deployment

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET MVC 5 / .NET 8 |
| ORM | Entity Framework 6 |
| Testing | xUnit, Moq |
| Frontend | Bootstrap 4, jQuery |
| Database | SQL Server / LocalDB |
| CI/CD | GitHub Actions |
| Container | Docker |

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server or LocalDB
- Docker (optional)

### Run Locally

```bash
git clone https://github.com/miteshdekate93/PingPongTest.git
cd PingPongTest/PingPong4
dotnet run
```

Open http://localhost:5000

### Run with Docker

```bash
docker-compose up --build
```

Open http://localhost:8080

---

## Running Tests

```bash
cd PingPong.Tests
dotnet test --verbosity normal
```

Test output:
```
Test Run Successful.
Total tests: 8
     Passed: 8
     Failed: 0
```

---

## Routes / Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/Players` | List all players |
| GET | `/Players/Create` | New player form |
| POST | `/Players/Create` | Create a player |
| GET | `/Players/Edit/{id}` | Edit player form |
| POST | `/Players/Edit/{id}` | Update player |
| GET | `/Players/Delete/{id}` | Delete confirmation |
| POST | `/Players/Delete/{id}` | Delete a player |
| GET | `/Players/Details/{id}` | Player details |

---

## Project Structure

```
PingPongTest/
├── PingPong4/                  # Main MVC application
│   ├── Controllers/
│   │   └── PlayersController.cs
│   ├── Models/
│   │   └── Player.cs
│   ├── Context/
│   │   ├── DatabaseContext.cs
│   │   └── DatabaseInitializer.cs
│   └── Views/Players/         # CRUD views
│
├── PingPong.Tests/             # xUnit test project
│   ├── PlayerServiceTests.cs
│   └── PingPong.Tests.csproj
│
└── docker-compose.yml
```

---

## License

MIT © [miteshdekate93](https://github.com/miteshdekate93)
