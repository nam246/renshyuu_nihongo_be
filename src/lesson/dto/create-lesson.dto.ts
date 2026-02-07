import { IsString, IsEnum, IsOptional, IsInt, Min } from 'class-validator';
import { Level, Source } from '@prisma/client';
import { Type } from 'class-transformer';

export class CreateLessonDto {
  @IsString()
  lessonTitle!: string; // Số bài học

  @IsEnum(Source)
  @IsOptional()
  source?: Source; // minna no nihongo? || soumatome?

  @IsEnum(Level)
  level!: Level;

  // KHÔNG thêm vocabularyIds, grammarIds, kanjiIds vào đây
  // Vì Vocabulary, Grammar, Kanji sẽ tự link đến Lesson khi tạo
}
