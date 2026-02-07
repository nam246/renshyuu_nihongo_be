import 'dotenv/config'; // Load .env ở root
import { defineConfig, env } from 'prisma/config';

export default defineConfig({
  schema: 'prisma/schema.prisma', // Đường dẫn đến schema (bắt buộc nếu không có trong package.json)

  datasource: {
    url: env('DATABASE_URL'), // Bắt buộc dùng env() để type-safe
  },

  migrations: {
    path: 'prisma/migrations',
    seed: 'pnpx tsx prisma/seed.ts',
  },

  // Nếu bạn dùng shadow database (một số PostgreSQL cần khi migrate)
  // shadowDatabaseUrl: env('SHADOW_DATABASE_URL'),
});
