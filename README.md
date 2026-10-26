# WorkoutJournal

WorkoutJournal is an ASP.NET Core MVC web application for planning and tracking gym workouts.
A user registers, creates a workout for a chosen day from a ready-made training program,
adjusts the exercises (sets, reps, weight), and marks whether the workout was completed.

This project was built as the ASP.NET Fundamentals course project.

## Main features

- Register, log in and log out (ASP.NET Core Identity).
- Every user sees and manages only their own workouts.
- **Create** a workout: pick a date (past dates are not allowed), write a note and choose a training program. The exercises of the program are copied into the new workout.
- **Read** the list of workouts with the day, the date and a coloured status badge.
- **Update** a workout: change the date, note, status and every exercise (exercise type, sets, reps, weight).
- **Delete** a workout from the edit page, with a confirmation step.
- **MonthlyProgress** to display the progress of the user grouped by months.
- Workout statuses: `NotStarted`, `Completed`, `PartiallyCompleted`, `Skipped`.
- Server-side and client-side validation.
- Responsive layout built with Bootstrap.

## Technologies

- C# and ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- Microsoft SQL Server (MSSQLLocalDB)
- ASP.NET Core Identity
- Razor views with a shared layout, partial views and sections
- Bootstrap 5 and Bootstrap Icons
- jQuery Validation (client-side validation)
- Dependency Injection for the services and the database context

## Project structure

| Project | What it contains |
| --- | --- |
| `WorkoutJournal.Data` | `DbContext`, entity models, migrations, seed data |
| `WorkoutJournal.Common` | shared enums such as `WorkoutStatus` |
| `WorkoutJournal.Services` | business logic behind interfaces (for example `IWorkoutService`) |
| `WorkoutJournal.ViewModels` | view models used by the views |
| `WorkoutJournal.Web` | controllers, Razor views, `wwwroot`, `Program.cs` |

### Entities

- `Workout` - date, note, status, owner (Identity user) and a list of exercises.
- `Exercise` - sets, reps and weight for one exercise inside a workout.
- `ExerciseType` - the name of an exercise (for example Bench Press). 20 types are seeded.
- `TrainingProgram` - a template that lists the exercises copied into a new workout.
- `TrainingProgramExercise` - a list of exercises that belong to specific program.

## Getting started

### Prerequisites

- .NET SDK 10
- SQL Server or SQL Server LocalDB (installed with Visual Studio)
- Visual Studio 2022 or newer, or the `dotnet` CLI

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/MuscuLopnul/WorkoutJournal.git
   cd WorkoutJournal
   ```
2. Check the connection string in `WorkoutJournal.Web/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=WorkoutJournal;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
   Change the server name if you use a different SQL Server instance.
3. Create the database by applying the migrations.

   Visual Studio Terminal with the CLI from the solution folder:
   ```
dotnet ef database update --project WorkoutJournal.Data --startup-project WorkoutJournal.Web
   ```
   The migrations also seed the exercise types and the training programs.
4. Run the application:
   ```
dotnet run --project WorkoutJournal.Web
   ```
   or press `F5` in Visual Studio. The site opens on the HTTPS address printed in the console (for example `https://localhost:7133`).

### Environment variables and credentials

No environment variables are needed.

## How to use

1. Register and log in.
2. Open **My workouts** or use the **New workout** button.
3. Choose a date, write a note and pick a training program, then press **Create**.
4. Open **Edit** next to a workout to change the exercises, set the status or delete the workout.
5. Check your monthly progress using **My progress** page.

## Author

[Kyryl Subchynskyi] - [https://github.com/MuscuLopnul]
