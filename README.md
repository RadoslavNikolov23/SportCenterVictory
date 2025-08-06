# Sport Center Victory (ASP.NET Core MVC Project)

This is a university project for managing a sports center (Fitness, CrossFit, Powerlifting), including user memberships, programs, store, and events. For more information scroll down below.

## 📸 Screenshot (Main page)
<div style="line-height: 0;">
   <img src="https://dl.dropboxusercontent.com/scl/fi/iuxb282v8781apljgrrxv/MainPage01.png?rlkey=lw2uxesdhbuhvv5vv7quwyw0u&st=0qow1wg3" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/zjdpr3stbckldxya48440/MainPaige02.png?rlkey=da66jaxm1eexsijudoyvqil0l&st=alqxyu7g" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/pr12kf07ersblnud0ai6v/MainPaige03.png?rlkey=9sgkmdrdt752e2ff924pyw35f&st=pgyx2j5r" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/y6j737mb8kd4z0ij92czv/MainPaige04.png?rlkey=8a614rw4m3q38ej5tbfvkovd6&st=63x1c5jq" width="750" style="display:block;"/>
   <img src="https://dl.dropboxusercontent.com/scl/fi/4pv03oet9ryv1944mc3yn/MainPaige05.png?rlkey=n90njo6hfar8rjtnfmtwq395x&st=fko5aqt8" width="750" style="display:block;"/>
</div>

---

## 🏋️‍♂️ Project Overview

**Sport Center Victory** is a full-featured ASP.NET Core MVC web application developed as a student project, simulating a modern multi-sport facility platform. It supports three main sport disciplines — **Fitness**, **CrossFit**, and **Powerlifting** — each offering tailored content such as **events**, **memberships**, dedicated zones (e.g., *Fitness Center*, *CrossFit Arena*, *Powerlifting Zone*), and **trainer/coach interactions**. Registered users can explore and join events, purchase sport-specific memberships, add favorite trainers, and interact with each sport's unique features.

Each sport section is enriched with additional functionality:
- **Fitness**: includes a searchable **exercise database** with over 800 exercises and a **Workout Plan** section where users can explore plans with attached exercises.
- **CrossFit**: features **CrossFit Classes** that users can join and a daily **Workout of the Day (WOD)** automatically pulled and stored from [CrossFit.com](https://crossfit.com).
- **Store**: users can purchase **supplements and equipment**, manage their cart, and buy memberships directly.

The app also includes user-friendly features like **Contact Us**, **Privacy**, and **About** sections. Each registered user has access to a **User Panel** to manage memberships, joined events, favorite trainers, submitted feedback, and more.

---

## 👥 Roles & Permissions

The application uses a **role-based access system** with four predefined roles: **User**, **Trainer**, **Manager**, and **Admin**.

- **User**: Default role upon registration. Can purchase memberships, join events and classes, favorite trainers, and leave feedback.
- **Trainer**: In addition to user features, can manage their own bio, add/edit workout plans, exercises, and CrossFit classes, and view users who have marked them as a favorite.
- **Manager**: Inherits trainer permissions and can approve/delete user feedback, manage all content (events, exercises, bios, etc.), and review site-wide data in an admin dashboard.
- **Admin**: Has full access across the platform, including role assignment (excluding other admin roles) and permanent user deletion.

Feedback submitted by users appears on the homepage if approved by a Manager/Admin. Only three approved feedbacks are displayed at a time, chosen dynamically from the database.

---

## 🤝 Credits & Contributions

This project wouldn't be possible without the amazing contributions and tools from the community:

- 💡  Data Exercises and some of the implementaion about them are inspired and forked from [yuhonas](https://github.com/yuhonas)
- 🖼️ High-quality images sourced from [Unsplash](https://unsplash.com)
- 🛒 Sample product ideas from [MyProtein.com](https://www.myprotein.com/) — a personal favorite and highly recommended!
- 🤖 Technical guidance, testing, and support: **SotftUni**, **ChatGPT**, GitHub users, Stack Overflow, and the .NET community.

Huge thanks to all the open-source contributors and platforms that inspired and supported this project’s development!


---

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

- Check the GitHub Project Notes (Updated) below.

## 📦 Project Structure

- `SportCenterVictory` – Main ASP.NET Core MVC app (UI, controllers, views, areas)
- `SVC.Services` – Business logic and service interfaces
- `SCV.Data` – Entity models, DbContext, seeding logic
- `SCV.GlCommon` – Shared utilities
- `SCV.Web` – Applciation infrastructure and ViewModels
- `SCV.Test` – Integration Tests, Service Tests and WebTests

## 🧠 Application Logic & Architecture

- 🗂️ The application includes an **Administration area** with **7 controllers** and **36 views**, enabling management of key modules like Exercises, Events, Memberships, Trainers, Orders, Roles, and Feedback.
- 🚀 There are **9 main controllers** serving the core user-facing functionalities such as Fitness, CrossFit, Powerlifting, Store, and Account-related operations.
- 🧩 A total of **36 Razor Views** support these controllers, along with **5 Partial Views** used across shared layouts and components like Navbar, Footer, Cards, and Dropdowns.
- 🔧 Over **18 services** are used in the project, following dependency injection principles to maintain a clean, modular architecture.
- 🗃️ The project contains over **17 model entities**, including a custom `ApplicationUser` (extends `IdentityUser`), and **6 mapping tables** for many-to-many relations (e.g., user-to-class, user-to-membership, order-to-product).

### 📌 Additional Features

- 🛢️ Uses **Microsoft SQL Server** for data storage, with rich entity configuration and dynamic data seeding (trainers, roles, users, etc.).
- 📧 Includes an integrated **Email Sender** service that allows users to send messages through the **Contact page**, delivered directly to admin email.
- 🎨 All styling is handled via **CSS**, and interactive features are built with **custom JavaScript**. All static files are stored in the `wwwroot` folder.
- 🖼️ Images are hosted using **Dropbox** for improved loading times, except **Exercise images**, which are stored locally in `wwwroot/imagesExercises/` due to development time constraints.
- 📱 The website is designed to be **fully responsive**, optimized for mobile and small-screen devices.

### 🏷️ Badges

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue?logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-red?logo=MicrosoftSQLServer&logoColor=white)
![Entity Framework](https://img.shields.io/badge/ORM-Entity_Framework_Core-green?logo=efcore&logoColor=white)
![Responsive](https://img.shields.io/badge/UI-Responsive-lightgrey?logo=css3&logoColor=blue)
![Dropbox](https://img.shields.io/badge/Image_Hosting-Dropbox-blue?logo=dropbox&logoColor=white)
![Email Service](https://img.shields.io/badge/Feature-Email_Sender-important?logo=gmail&logoColor=white)


## 📝 GitHub Project Notes (Updated)

- **Configure the Email Sender options in `appsettings.json` and `secrets.json`**  
  > The app reads SMTP credentials (host, port, sender/receiver email, username and password) from:  
  > `"EmailSettings": { "Host": "smtp.example.com", "Port": 587, "Username": "exampleName", "Password": "your-password", "SenderEmail": "you@example.com" and "ReceiverEmail": "example@email.com" }`  
  > For security, the actual credentials should be placed in `secrets.json` or use environment variables.


- **Configure the database connection in `appsettings.json`** and `secrets.json`**   
  > Make sure your local database connection string is correctly set under:  
  > `"ConnectionStrings": { "DefaultConnection": "your-local-connection-string" }`.
  > For security, the actual credentials should be placed in `secrets.json` or use environment variables.

- **Initialize EF Core Migrations and create the database**  
  > Run `Update-Database` in the **Package Manager Console** to apply all EF Core migrations.  
  > This will create the database and apply all migration steps in the correct order.

- **Seed data during migration and runtime checks**  
  > The Identity roles **Admin**, **Manager**, and **Trainer**, along with the default users (ApplicationUser and ApplicationUserRole), are seeded dynamically at runtime via an extension method called during application startup (`Program.cs`).  
  > All other domain data such as **Exercises**, **Products**, **Memberships**, **WorkoutPlans**, etc., are seeded from JSON files during the migration `Update-Database`.  
  > Only the **UserFeedback** data and **Trainer** data is managed dynamically—on every web app startup, it checks for existing feedback entries and ensures the entity is kept up-to-date automatically.


