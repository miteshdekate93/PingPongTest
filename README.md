# Ping Pong App

![CI](https://github.com/miteshdekate93/PingPongTest/actions/workflows/ci.yml/badge.svg)
![.NET](https://img.shields.io/badge/.NET-8-purple)
![xUnit](https://img.shields.io/badge/Tests-xUnit-green)

A ping pong player management app with a full unit test suite. Demonstrates ASP.NET MVC, Entity Framework, and proper testing practices with xUnit and Moq.

## What It Does

Manage ping pong players — add players, track their games won/lost, view rankings. The focus of this project is the test suite, not the app itself.

## Tech Stack

- ASP.NET MVC + Entity Framework
- xUnit test framework
- Moq for mocking dependencies
- GitHub Actions (tests run on every push)
- Docker

## Run It

```bash
git clone https://github.com/miteshdekate93/PingPongTest.git
cd PingPongTest/PingPong4
dotnet run
```

## Run the Tests

```bash
cd PingPong.Tests
dotnet test --verbosity normal
```

8 tests covering: player creation, win rate calculation, validation, CRUD operations, sorting by ranking.
