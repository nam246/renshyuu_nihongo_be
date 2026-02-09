import { IsEnum, IsOptional, IsString } from 'class-validator';
import { Level } from '../../../prisma/generated/client';

export class QueryVocabularyDto {
  @IsOptional()
  @IsString()
  lessonId?: string;

  @IsOptional()
  @IsEnum(Level)
  level?: Level;
}
