# Sport Center Victory (ASP.NET Core MVC Project)

This is a university project for managing a sports center (Fitness, CrossFit, Powerlifting), including user memberships, programs, store, and events. Still under development. Some of the features are not implemented.

## 📸 Screenshot (Main page)
<div style="line-height: 0;">
   <img src="https://dl.dropboxusercontent.com/scl/fi/iuxb282v8781apljgrrxv/MainPage01.png?rlkey=lw2uxesdhbuhvv5vv7quwyw0u&st=0qow1wg3" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/zjdpr3stbckldxya48440/MainPaige02.png?rlkey=da66jaxm1eexsijudoyvqil0l&st=alqxyu7g" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/pr12kf07ersblnud0ai6v/MainPaige03.png?rlkey=9sgkmdrdt752e2ff924pyw35f&st=pgyx2j5r" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/y6j737mb8kd4z0ij92czv/MainPaige04.png?rlkey=8a614rw4m3q38ej5tbfvkovd6&st=63x1c5jq" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/4pv03oet9ryv1944mc3yn/MainPaige05.png?rlkey=n90njo6hfar8rjtnfmtwq395x&st=fko5aqt8" width="750" style="display:block;"/>
</div>

## 🚀 How to Run

1. Make sure you have:
   - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
   - SQL Server or SQL Express

2. Clone the repo:
   ```bash
   git clone https://github.com/RadoslavNikolov23/SportCenterVictory.git
   ```

3. Navigate to the main project folder and apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

## 🔐 Seeded Users (some of them)

- **Admin**  
  Email: `admin@sportcentervictory.com`  
  Password: `Admin123!`

- **Manager**  
  Email: `manager@sportcentervictory.com`  
  Password: `Rado123!`

- **One of the Trainers**  
  Email: `sofiazlateva@sportcentervictory.com`  
  Password: `"Sofia123!`

- **One of the Users**  
  Email: `victoriadimitrova@sportcentervictory.com"`  
  Password: `Victoria123!`


## 💾 Data Seeding

- Application users, roles, and user roles are seeded in the `ApplicationUserConfiguration.cs`, `ApplicationRoleConfiguration.cs` and `ApplicationUserRoleConfiguration.cs`
- Other data like Trainers, Products, Memberships, etc., are seeded from JSON files using EF Core `HasData` in the `Configuration` classes.

## 📦 Project Structure

- `SportCenterVictory` – Main ASP.NET Core MVC app (UI, controllers, views, areas)
- `SVC.Services` – Business logic and service interfaces
- `SCV.Data` – Entity models, DbContext, seeding logic
- `SCV.GlCommon` – Shared utilities
- `SCV.Web` – Applciation infrastructure and ViewModels
- `SCV.Test` – Integration Tests, Service Tests and WebTests

## 📝 GitHub Project Notes (Updated)

- `Configure database connection in appsettings.json (DefaultConnection)`  
  > Ensure your local database connection string is properly set in `appsettings.json` under `"ConnectionStrings": { "DefaultConnection": "..." }`.
  
- `Initialize EF Core Migrations and apply base database schema`  
  > Run `Update-Database` in the **Package Manager Console** to apply all EF Core migrations in order. The database will be created and all migration steps executed based on their creation order.

- `When running Update-Database all of the Seeds will be applied in the oreder that the migrations are created!`  
  > Roles like **Admin**, **Manager**, and **Trainer** are seeded directly in code using the `ApplicationUserConfiguration.cs`, `ApplicationRoleConfiguration.cs` and `ApplicationUserRoleConfiguration.cs` classes during the migrations.
  > All domain-specific data such as **Trainers**, **Products**, **Memberships**, **WorkoutPlans**, etc., are seeded through JSON files.
  > This ensures all relevant data is populated automatically upon database creation.

