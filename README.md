# Online Courses Subscription Platform

## Description

The **Online Courses Subscription Platform** [api]
This project is built using **ASP.NET Core**, **Entity Framework Core**, and **PostgreSQL** 
---
## ReadMe ## GitIgnore 

## Technologies Used

- **ASP.NET Core**: For building the backend API.
- **Entity Framework Core**: For database interaction and ORM.
- **PostgreSQL**: Database management system.
- **Swagger**: API documentation and testing interface.
- **LINQ**: Data querying for easy manipulation of collections.

---

## API Endpoints
## The all have CRUD methouds
### User Management

- **POST** `/api/users` - Create a new user.
- **GET** `/api/users/{id}` - Get user details by ID.
- **GET** `/api/users` - Get a list of all users.

### Subscription Management

- **POST** `/api/subscriptions/purchase` - Purchase a new subscription.
- **POST** `/api/subscriptions/{id}/cancel` - Cancel an existing subscription.
- **GET** `/api/subscriptions/user/{userId}` - Get all subscriptions for a specific user.

### Course Management

- **POST** `/api/courses` - Add a new course.
- **PUT** `/api/courses/{id}` - Update course details.
- **GET** `/api/courses` - Get all courses.
- **GET** `/api/courses/{id}` - Get a course by ID.

### Course Access

- **POST** `/api/access/grant` - Grant course access to a user.
- **POST** `/api/access/revoke` - Revoke course access from a user.
- **GET** `/api/access/user/{userId}` - Get all course access records for a user.

### Plan Management

- **POST** `/api/plans` - Add a new subscription plan.
- **PUT** `/api/plans/{id}` - Update a subscription plan.
- **GET** `/api/plans` - Get all plans.
- **PATCH** `/api/plans/{id}/toggle` - Toggle the active status of a plan.

### Payment Management

- **POST** `/api/payments` - Record a new payment for a subscription.
- **GET** `/api/payments` - Get a list of all payments.
- **GET** `/api/payments/{id}` - Get payment details by ID.

---

## Getting Started

### Prerequisites

Make sure you have the following installed:
- **.NET SDK** (version 6.0 or higher)
- **PostgreSQL** or **SQL Server**
- A **code editor** like Visual Studio Code or Visual Studio

### Setting Up the Project

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/yourrepository.git
