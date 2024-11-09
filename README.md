# API  E-commerce System with Microservices
## Overview:
This e-commerce platform is designed with a microservice architecture to ensure scalability, flexibility, and maintainability. Each service focuses on a specific domain, including user authentication, product management, shopping cart, orders, coupons, and rewards. Services communicate asynchronously using RabbitMQ or Azure Service Bus. Ocelot serves as the API Gateway for routing, and Stripe handles secure payment processing. The system is built using ASP.NET Core and SQL Server for data storage, with integration for rewarding users post-purchase.

## Technology Stack
- `Backend Framework`: ASP.NET Core
- `Message Queue`: RabbitMQ, Azure Service Bus (for message-driven communication)
- `API Gateway`: Ocelot
- `Payment Gateway`: Stripe (for payment processing)
- `Database`: SQL Server

## Microservice Structure & Database Design
Each microservice will have its own SQL Server database to ensure that each domain is separated for better scalability and maintainability.
- `AuthAPI`: Stores user accounts, roles, and tokens.
- `ProductAPI`: Stores product, category, and brand data.
- `CouponAPI`: Stores coupon codes and discount information.
- `CartAPI`: Stores user-specific cart data.
- `OrderAPI`: Tracks orders, payments, and statuses.
- `RewardAPI`: Tracks rewards and user-specific points or discounts.

### 1. AuthAPI
Responsibilities:
- User authentication and role management.
- JWT token generation for secure API access.
#### Key Components:
- Controllers: Handle login, registration, and role assignment.
- Identity Framework: For managing user roles and secure password hashing.
### 2. ProductAPI
Responsibilities: Manage products, categories, brands, and product photos.

### 3. CouponAPI
Responsibilities:
- Manage discount coupons that users can apply to orders.
### 4. CartAPI
Responsibilities:
- Manage shopping carts for users, allowing them to add, update, and remove items.
### 5. OrderAPI
Responsibilities:
- Handle the creation of orders and manage payments via Stripe.
### 6. RewardAPI
Responsibilities:
- Reward users for successful purchases by giving them points or discounts.
### 7. EmailAPI
Responsibilities:
- Send email notifications to users for account actions, order confirmations, and reward updates.
#### Key Components:
Controllers: Queue and send emails for various events.
RabbitMQ or Azure Service Bus: For asynchronous email processing.
### 8. Message Bus
Responsibilities:
- Facilitate communication between services through RabbitMQ or Azure Service Bus.
- Ensure services are decoupled and operate asynchronously.
### 9. API Gateway (Ocelot)
Responsibilities:
- Serve as the entry point for all API requests and route them to the appropriate microservice.
- Secure all routes using JWT tokens.

## Deployment

- `AuthAPI`: [Demo](ecommerceserviceauthapi.azurewebsites.net)
- `ProductAPI`: [Demo](ecommerceserviceauthapi.azurewebsites.net)
- `CouponAPI`: [Demo](ecommerceserviceauthapi.azurewebsites.net)
- `CartAPI`: [Demo](ecommerceserviceauthapi.azurewebsites.net)
- `OrderAPI`: [Demo](ecommerceserviceorder.azurewebsites.net)
- `EmailAPI`: [Demo](ecommerceserviceemailapi.azurewebsites.net)
- `RewardAPI`: [Demo](ecommerceservicerewardapi.azurewebsites.net)
- `API Gateway`: [Demo](ecommercegatewaysolution.azurewebsites.net) 
