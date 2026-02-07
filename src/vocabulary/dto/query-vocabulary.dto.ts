import { IsEnum, IsOptional, IsString } from 'class-validator';
import { Level } from '@prisma/client';

export class QueryVocabularyDto {
  @IsOptional()
  @IsString()
  lessonId?: string;

  @IsOptional()
  @IsEnum(Level)
  level?: Level;
}
