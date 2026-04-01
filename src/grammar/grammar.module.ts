import { Module } from '@nestjs/common';
import { GrammarService } from './grammar.service';
import { GrammarController } from './grammar.controller';
import { PrismaService } from '../prisma.service';

@Module({
  controllers: [GrammarController],
  providers: [GrammarService, PrismaService],
})
export class GrammarModule {}
