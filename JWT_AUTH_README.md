# JWT Authentication API Documentation

## Overview
This project implements JWT (JSON Web Token) authentication for the NestJS backend. It provides endpoints for user registration, login, and profile access with token-based authorization.

## Installation
The required packages have been installed:
- `@nestjs/jwt` - JWT token generation and verification
- `@nestjs/passport` - Passport strategy integration
- `passport-jwt` - JWT authentication strategy
- `bcryptjs` - Password hashing

## Environment Variables
Create a `.env` file in the root directory with the following variables:

```env
DATABASE_URL=postgresql://user:password@localhost:5432/renshyuu_nihongo
JWT_SECRET=your-super-secret-jwt-key-change-in-production
JWT_EXPIRES_IN=24h
PORT=3000
```

## API Endpoints

### 1. Register
**POST** `/auth/register`

Register a new user account.

**Request Body:**
```json
{
  "email": "user@example.com",
  "username": "username",
  "password": "password123",
  "name": "User Name"
}
```

**Response (201 Created):**
```json
{
  "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": "uuid",
    "email": "user@example.com",
    "username": "username",
    "name": "User Name"
  }
}
```

**Error Responses:**
- `400 Bad Request` - Email or username already exists
- `400 Bad Request` - Validation error (invalid email, short password, etc.)

---

### 2. Login
**POST** `/auth/login`

Authenticate a user and receive a JWT token.

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

**Response (200 OK):**
```json
{
  "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "user": {
    "id": "uuid",
    "email": "user@example.com",
    "username": "username",
    "name": "User Name"
  }
}
```

**Error Responses:**
- `401 Unauthorized` - Invalid email or password

---

### 3. Get Profile
**GET** `/auth/profile`

Retrieve the current authenticated user's profile.

**Headers:**
```
Authorization: Bearer <access_token>
```

**Response (200 OK):**
```json
{
  "id": "uuid",
  "email": "user@example.com",
  "username": "username",
  "name": "User Name"
}
```

**Error Responses:**
- `401 Unauthorized` - Invalid or missing token
- `401 Unauthorized` - Expired token

---

## Usage in Other Modules

### Protecting Routes
Use the `JwtAuthGuard` to protect routes that require authentication:

```typescript
import { UseGuards } from '@nestjs/common';
import { JwtAuthGuard } from './auth/guards/jwt-auth.guard';

@Get('protected-route')
@UseGuards(JwtAuthGuard)
protectedRoute() {
  // This route requires a valid JWT token
}
```

### Accessing Current User
Use the `@CurrentUser()` decorator to get the current authenticated user:

```typescript
import { CurrentUser } from './auth/decorators/current-user.decorator';

@Get('profile')
@UseGuards(JwtAuthGuard)
getProfile(@CurrentUser() user: any) {
  return user;
}
```

### Exporting Auth Module
The auth module is already exported and can be imported in other modules:

```typescript
import { Module } from '@nestjs/common';
import { AuthModule } from './auth/auth.module';

@Module({
  imports: [AuthModule],
})
export class YourModule {}
```

## JWT Token Structure
The JWT token includes the following claims:
- `sub` - User ID (subject)
- `email` - User email
- `username` - Username
- `iat` - Issued at timestamp
- `exp` - Expiration timestamp

## Password Security
- Passwords are hashed using bcryptjs with a salt rounds of 10
- Raw passwords are never stored in the database
- Passwords are validated on login by comparing the hashed values

## Error Handling
The API includes proper error handling with appropriate HTTP status codes:
- `400 Bad Request` - Invalid input or duplicate user
- `401 Unauthorized` - Invalid credentials or expired token
- `500 Internal Server Error` - Server-side errors

## Security Considerations
1. **Change JWT_SECRET**: Always use a strong, randomly generated secret in production
2. **HTTPS**: Always use HTTPS in production
3. **Token Expiration**: Default is 24 hours. Adjust `JWT_EXPIRES_IN` as needed
4. **CORS**: Configure CORS if the frontend is on a different domain

## Testing the API

### Using curl:

**Register:**
```bash
curl -X POST http://localhost:3000/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "username": "testuser",
    "password": "password123",
    "name": "Test User"
  }'
```

**Login:**
```bash
curl -X POST http://localhost:3000/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "password123"
  }'
```

**Get Profile:**
```bash
curl -X GET http://localhost:3000/auth/profile \
  -H "Authorization: Bearer YOUR_ACCESS_TOKEN"
```

## Project Structure
```
src/auth/
├── auth.controller.ts          # API endpoints
├── auth.service.ts             # Authentication logic
├── auth.module.ts              # Module configuration
├── dto/                         # Data transfer objects
│   ├── register.dto.ts
│   ├── login.dto.ts
│   └── auth-response.dto.ts
├── entities/                    # Entities
│   └── user.entity.ts
├── strategies/                  # Passport strategies
│   └── jwt.strategy.ts
├── guards/                      # Route guards
│   └── jwt-auth.guard.ts
└── decorators/                  # Custom decorators
    └── current-user.decorator.ts
```

## Next Steps
1. Add refresh token functionality
2. Implement role-based access control (RBAC)
3. Add email verification for new users
4. Implement password reset functionality
5. Add rate limiting for login attempts
