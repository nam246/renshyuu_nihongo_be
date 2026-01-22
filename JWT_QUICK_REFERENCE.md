# JWT Authentication - Quick Reference Guide

## 🚀 Getting Started

### 1. Install Dependencies ✅
```bash
pnpm add @nestjs/jwt @nestjs/passport passport passport-jwt bcryptjs
```

### 2. Configure Environment Variables
Create `.env` file:
```env
JWT_SECRET=your-super-secret-jwt-key
JWT_EXPIRES_IN=24h
DATABASE_URL=postgresql://user:password@localhost:5432/db
PORT=3000
```

### 3. Start Server
```bash
pnpm start:dev
```

---

## 📝 API Endpoints

### Register
```bash
curl -X POST http://localhost:3000/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "username": "username",
    "password": "password123",
    "name": "User Name"
  }'
```

**Response:**
```json
{
  "access_token": "eyJhbGci...",
  "user": {
    "id": "uuid",
    "email": "user@example.com",
    "username": "username",
    "name": "User Name"
  }
}
```

---

### Login
```bash
curl -X POST http://localhost:3000/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "password123"
  }'
```

**Response:**
```json
{
  "access_token": "eyJhbGci...",
  "user": {
    "id": "uuid",
    "email": "user@example.com",
    "username": "username",
    "name": "User Name"
  }
}
```

---

### Get Profile (Protected)
```bash
curl -X GET http://localhost:3000/auth/profile \
  -H "Authorization: Bearer YOUR_ACCESS_TOKEN"
```

**Response:**
```json
{
  "id": "uuid",
  "email": "user@example.com",
  "username": "username",
  "name": "User Name"
}
```

---

## 🔐 Using in Your Routes

### Protect a Route
```typescript
import { UseGuards } from '@nestjs/common';
import { JwtAuthGuard } from './auth/guards/jwt-auth.guard';

@Get('protected')
@UseGuards(JwtAuthGuard)
protectedRoute() {
  return { message: 'This is protected' };
}
```

### Access Current User
```typescript
import { CurrentUser } from './auth/decorators/current-user.decorator';
import { UseGuards } from '@nestjs/common';
import { JwtAuthGuard } from './auth/guards/jwt-auth.guard';

@Get('me')
@UseGuards(JwtAuthGuard)
getCurrentUser(@CurrentUser() user: any) {
  return user;
  // user contains: { id, email, username }
}
```

---

## 📁 File Structure

```
src/auth/
├── auth.controller.ts              # Register, Login, Profile endpoints
├── auth.service.ts                 # Password hashing, JWT generation
├── auth.module.ts                  # JWT configuration
├── strategies/jwt.strategy.ts       # Passport JWT strategy
├── guards/jwt-auth.guard.ts         # Route protection
├── decorators/current-user.decorator.ts  # Get user from request
├── dto/
│   ├── register.dto.ts
│   ├── login.dto.ts
│   └── auth-response.dto.ts
└── entities/user.entity.ts
```

---

## 🛡️ Security Features

| Feature | Implementation |
|---------|-----------------|
| Password Hashing | bcryptjs (10 salt rounds) |
| Token Signing | HS256 algorithm |
| Token Expiration | Configurable (default 24h) |
| Route Protection | JWT Guard |
| Input Validation | class-validator |
| Error Handling | Proper HTTP status codes |

---

## 🔄 JWT Token Structure

```json
{
  "sub": "user-id",
  "email": "user@example.com",
  "username": "username",
  "iat": 1234567890,
  "exp": 1234671890
}
```

---

## ⚠️ Error Responses

| Error | Status | Response |
|-------|--------|----------|
| Invalid email/password | 401 | `Unauthorized` |
| Email already exists | 400 | `Email or username already exists` |
| Validation failed | 400 | `[validation error messages]` |
| Invalid token | 401 | `Unauthorized` |
| Expired token | 401 | `Unauthorized` |

---

## 📚 Documentation Files

- **JWT_AUTH_README.md** - Complete API documentation
- **FRONTEND_AUTH_INTEGRATION.md** - Next.js integration examples
- **IMPLEMENTATION_SUMMARY.md** - What was implemented
- **JWT_QUICK_REFERENCE.md** - This file

---

## 💡 Common Tasks

### Refresh Token Implementation
```typescript
// Add to auth.service.ts
refreshToken(token: string) {
  const decoded = this.jwtService.verify(token, {
    secret: process.env.REFRESH_SECRET,
  });
  return this.jwtService.sign(
    { email: decoded.email },
    { subject: decoded.sub }
  );
}
```

### Add Role-Based Access Control
```typescript
@Get('admin')
@UseGuards(JwtAuthGuard, RolesGuard)
@Roles('admin')
adminRoute() {
  return { message: 'Admin only' };
}
```

### Logout (Clear Client-Side Token)
```typescript
// Frontend
localStorage.removeItem('access_token');
localStorage.removeItem('user');
```

---

## 🧪 Testing

### Test Registration
```bash
# Should succeed
curl -X POST http://localhost:3000/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@test.com","username":"testuser","password":"pass123","name":"Test"}'

# Should fail (duplicate email)
curl -X POST http://localhost:3000/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@test.com","username":"other","password":"pass123"}'
```

### Test Login
```bash
# Should succeed
curl -X POST http://localhost:3000/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@test.com","password":"pass123"}'

# Should fail (wrong password)
curl -X POST http://localhost:3000/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@test.com","password":"wrongpass"}'
```

---

## 🔍 Troubleshooting

| Issue | Solution |
|-------|----------|
| "JWT secret not found" | Set `JWT_SECRET` in `.env` |
| 401 Unauthorized | Check token is valid and not expired |
| 400 Validation error | Verify all required fields are sent |
| Password always wrong | Ensure password is at least 6 characters |
| Token always expires | Adjust `JWT_EXPIRES_IN` in `.env` |

---

## 🔐 Production Checklist

- [ ] Change `JWT_SECRET` to a strong random value
- [ ] Use HTTPS only
- [ ] Set `NODE_ENV=production`
- [ ] Increase `JWT_EXPIRES_IN` to reasonable value
- [ ] Set up CORS properly
- [ ] Enable rate limiting
- [ ] Monitor failed login attempts
- [ ] Use environment variable management (not .env file)
- [ ] Enable HTTPS for all auth endpoints
- [ ] Implement refresh token rotation

---

**Happy authenticating! 🎉**
