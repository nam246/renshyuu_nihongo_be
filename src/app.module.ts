import 'dotenv/config';

import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { VocabularyModule } from './vocabulary/vocabulary.module';
import { LessonModule } from './lesson/lesson.module';
import { GrammarModule } from './grammar/grammar.module';
import { KanjiModule } from './kanji/kanji.module';
import { QuestionModule } from './question/question.module';
import { MockTestModule } from './mock-test/mock-test.module';
import { AuthModule } from './auth/auth.module';

@Module({
  imports: [
    VocabularyModule,
    LessonModule,
    GrammarModule,
    KanjiModule,
    QuestionModule,
    MockTestModule,
    AuthModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
