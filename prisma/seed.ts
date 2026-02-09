import { PrismaClient } from './generated/client';
import { PrismaPg } from '@prisma/adapter-pg';
import * as bcrypt from 'bcryptjs';
import { lessonsData } from './data';

const adapter = new PrismaPg({
  connectionString: process.env.DATABASE_URL,
});

const prisma = new PrismaClient({ adapter });

async function main() {
  console.log('🌱 Starting seed...');

  // Hash passwords
  const aliceHashedPassword = await bcrypt.hash('admin', 10);
  const bobHashedPassword = await bcrypt.hash('123456789', 10);

  const alice = await prisma.user.upsert({
    where: { email: 'alice@prisma.io' },
    update: {},
    create: {
      email: 'alice@prisma.io',
      name: 'Alice Erice',
      username: 'admin',
      password: aliceHashedPassword,
    },
  });
  const bob = await prisma.user.upsert({
    where: { email: 'bob@prisma.io' },
    update: {},
    create: {
      email: 'bob@prisma.io',
      name: 'Bob',
      username: 'bobbiesboba12',
      password: bobHashedPassword,
    },
  });
  console.log('created user', bob, alice);

  // Xóa data cũ
  console.log('🗑️  Cleaning old data...');
  await prisma.example.deleteMany();
  await prisma.vocabularyKanji.deleteMany();
  await prisma.vocabulary.deleteMany();
  await prisma.grammar.deleteMany();
  await prisma.kanji.deleteMany();
  await prisma.lesson.deleteMany();

  // Tạo lessons với nested data
  console.log('📚 Creating lessons...');
  let count = 0;
  for (const lesson of lessonsData) {
    await prisma.lesson.create({ data: lesson });
    count++;
    if (count % 10 === 0) {
      console.log(`✅ Created ${count}/${lessonsData.length} lessons`);
    }
  }

  console.log('🎉 Seed completed!');
}

main()
  .catch((e) => {
    console.error('❌ Seed failed:', e);
    process.exit(1);
  })
  .finally(async () => {
    await prisma.$disconnect();
  });
