# JWT Authentication - Frontend Integration Guide

## Setup

### 1. Install Required Dependencies
```bash
npm install axios
# or
pnpm add axios
```

### 2. Create an API Client with Interceptors

**api/client.ts**
```typescript
import axios, { AxiosInstance } from 'axios';

const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:3000';

export class ApiClient {
  private client: AxiosInstance;
  private token: string | null = null;

  constructor() {
    this.client = axios.create({
      baseURL: API_BASE_URL,
      headers: {
        'Content-Type': 'application/json',
      },
    });

    // Load token from localStorage on initialization
    if (typeof window !== 'undefined') {
      this.token = localStorage.getItem('access_token');
      if (this.token) {
        this.setAuthHeader(this.token);
      }
    }

    // Add request interceptor
    this.client.interceptors.request.use((config) => {
      if (this.token) {
        config.headers.Authorization = `Bearer ${this.token}`;
      }
      return config;
    });

    // Add response interceptor for handling 401 errors
    this.client.interceptors.response.use(
      (response) => response,
      (error) => {
        if (error.response?.status === 401) {
          // Handle token expiration
          this.clearToken();
          // Redirect to login or refresh token
          window.location.href = '/login';
        }
        return Promise.reject(error);
      }
    );
  }

  setAuthHeader(token: string) {
    this.token = token;
    this.client.defaults.headers.common['Authorization'] = `Bearer ${token}`;
  }

  clearToken() {
    this.token = null;
    delete this.client.defaults.headers.common['Authorization'];
    localStorage.removeItem('access_token');
    localStorage.removeItem('user');
  }

  getToken() {
    return this.token;
  }

  async get(url: string, config = {}) {
    return this.client.get(url, config);
  }

  async post(url: string, data = {}, config = {}) {
    return this.client.post(url, data, config);
  }

  async patch(url: string, data = {}, config = {}) {
    return this.client.patch(url, data, config);
  }

  async delete(url: string, config = {}) {
    return this.client.delete(url, config);
  }
}

export const apiClient = new ApiClient();
```

## Authentication Hooks

**hooks/useAuth.ts**
```typescript
import { useState, useCallback, useEffect } from 'react';
import { apiClient } from '@/api/client';

interface User {
  id: string;
  email: string;
  username: string;
  name?: string;
}

interface AuthResponse {
  access_token: string;
  user: User;
}

export function useAuth() {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  // Load user from localStorage on mount
  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    const storedToken = localStorage.getItem('access_token');
    if (storedUser && storedToken) {
      setUser(JSON.parse(storedUser));
      apiClient.setAuthHeader(storedToken);
    }
  }, []);

  const register = useCallback(
    async (email: string, username: string, password: string, name?: string) => {
      setLoading(true);
      setError(null);
      try {
        const response = await apiClient.post('/auth/register', {
          email,
          username,
          password,
          name,
        });
        const data: AuthResponse = response.data;
        localStorage.setItem('access_token', data.access_token);
        localStorage.setItem('user', JSON.stringify(data.user));
        apiClient.setAuthHeader(data.access_token);
        setUser(data.user);
        return data;
      } catch (err: any) {
        const message = err.response?.data?.message || 'Registration failed';
        setError(message);
        throw err;
      } finally {
        setLoading(false);
      }
    },
    []
  );

  const login = useCallback(
    async (email: string, password: string) => {
      setLoading(true);
      setError(null);
      try {
        const response = await apiClient.post('/auth/login', {
          email,
          password,
        });
        const data: AuthResponse = response.data;
        localStorage.setItem('access_token', data.access_token);
        localStorage.setItem('user', JSON.stringify(data.user));
        apiClient.setAuthHeader(data.access_token);
        setUser(data.user);
        return data;
      } catch (err: any) {
        const message = err.response?.data?.message || 'Login failed';
        setError(message);
        throw err;
      } finally {
        setLoading(false);
      }
    },
    []
  );

  const logout = useCallback(() => {
    apiClient.clearToken();
    setUser(null);
    localStorage.removeItem('user');
    localStorage.removeItem('access_token');
  }, []);

  const isLoggedIn = !!user;

  return {
    user,
    loading,
    error,
    register,
    login,
    logout,
    isLoggedIn,
  };
}
```

## Example: Login Page

**app/(auth)/login/page.tsx**
```typescript
'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth } from '@/hooks/useAuth';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

export default function LoginPage() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const { login, loading, error } = useAuth();
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await login(email, password);
      router.push('/dashboard');
    } catch (err) {
      // Error is handled by useAuth hook
      console.error(err);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      {error && <div className="text-red-500">{error}</div>}
      <Input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        disabled={loading}
      />
      <Input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        disabled={loading}
      />
      <Button type="submit" disabled={loading}>
        {loading ? 'Logging in...' : 'Login'}
      </Button>
    </form>
  );
}
```

## Example: Register Page

**app/(auth)/register/page.tsx**
```typescript
'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth } from '@/hooks/useAuth';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

export default function RegisterPage() {
  const [formData, setFormData] = useState({
    email: '',
    username: '',
    password: '',
    name: '',
  });
  const { register, loading, error } = useAuth();
  const router = useRouter();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await register(
        formData.email,
        formData.username,
        formData.password,
        formData.name
      );
      router.push('/dashboard');
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      {error && <div className="text-red-500">{error}</div>}
      <Input
        type="email"
        name="email"
        placeholder="Email"
        value={formData.email}
        onChange={handleChange}
        disabled={loading}
        required
      />
      <Input
        type="text"
        name="username"
        placeholder="Username"
        value={formData.username}
        onChange={handleChange}
        disabled={loading}
        required
      />
      <Input
        type="text"
        name="name"
        placeholder="Full Name"
        value={formData.name}
        onChange={handleChange}
        disabled={loading}
      />
      <Input
        type="password"
        name="password"
        placeholder="Password (min 6 characters)"
        value={formData.password}
        onChange={handleChange}
        disabled={loading}
        required
      />
      <Button type="submit" disabled={loading}>
        {loading ? 'Registering...' : 'Register'}
      </Button>
    </form>
  );
}
```

## Protected Routes

**app/(private)/layout.tsx**
```typescript
'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth } from '@/hooks/useAuth';

export default function PrivateLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const { isLoggedIn, loading } = useAuth();
  const router = useRouter();

  useEffect(() => {
    if (!loading && !isLoggedIn) {
      router.push('/login');
    }
  }, [isLoggedIn, loading, router]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (!isLoggedIn) {
    return null;
  }

  return <>{children}</>;
}
```

## Environment Variables

Create a `.env.local` file in your Next.js project:

```env
NEXT_PUBLIC_API_URL=http://localhost:3000
```

## Summary

1. **API Client** handles authentication headers and token management
2. **useAuth Hook** provides easy access to authentication functions
3. **Protected Routes** ensure only authenticated users can access certain pages
4. **Token Storage** uses localStorage (consider using cookies for better security)
5. **Automatic Redirects** on authentication failure

Remember to always use HTTPS in production and consider using HTTP-only cookies instead of localStorage for better security.
