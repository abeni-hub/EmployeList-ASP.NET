# 👥 Employee List Management System

A simple **ASP.NET Core MVC project** for managing employee records.  
This project is part of my learning journey with **.NET** and demonstrates how to build a basic **CRUD (Create, Read, Update, Delete)** application step-by-step.

---

## 📚 Project Overview
The **Employee List Management System** allows you to:
- Add new employees
- View a list of all employees
- Edit employee details
- Delete employees

This project focuses on **backend fundamentals**, MVC pattern, and working with **Entity Framework Core** for database operations.

---

## 🛠 Tech Stack
- **.NET 8.0 SDK** (or the version you're using)
- **C#**
- **ASP.NET Core MVC**
- **Entity Framework Core** (EF Core)
- **SQL Server / LocalDB**
- **Bootstrap 5** (for styling)
- **Visual Studio 2022**

---

## 📂 Folder Structure
```bash
EmployeeListApp/
│
├── Controllers/ # MVC Controllers
│ └── EmployeeController.cs
│
├── Models/ # Application data models
│ └── Employee.cs
│
├── Views/ # Razor Views for UI
│ └── Employee/
│ ├── Index.cshtml
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ └── Delete.cshtml
│
├── Migrations/ # EF Core migrations
├── appsettings.json # Configuration file (DB connection string)
├── Program.cs # Application startup
└── README.md

```


---

## 🚀 Getting Started

### **1. Clone the Repository**
```bash
git clone https://github.com/abeni-hub/EmployeeList-ASP.NET.git
cd EmployeeList-ASP.NET
```
### **2. Open in Visual Studio 2022**
```
Open the .sln file in Visual Studio 2022.
```
### **3. Configure Database**

Update the appsettings.json file with your SQL Server connection string:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeListDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
### **4. Apply Migrations**

Open Package Manager Console in Visual Studio and run:
```bash
Update-Database
```
this create the database with required tables

### **5. Run the Application**
```bash
dotnet run
```

### 🧩 Features

Add Employee – Create new employee records.

View Employees – See all employees in a list.

Edit Employee – Update employee details.

Delete Employee – Remove employees from the database.

Bootstrap UI – Simple and clean interface.


### The Postman Test
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/90ca65d5-2671-4d72-ae47-9d8d87ae9a01" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2a8aaa45-b61a-4a77-9903-08f8d88c4f79" />
