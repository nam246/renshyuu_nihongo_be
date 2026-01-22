import { IsEnum, IsOptional, IsString } from 'class-validator';
import { Level } from '../../generated/prisma/enums';

export class QueryVocabularyDto {
  @IsOptional()
  @IsString()
  lessonId?: string;

  @IsOptional()
  @IsEnum(Level)
  level?: Level;
}
