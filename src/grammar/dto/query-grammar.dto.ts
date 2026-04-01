import { IsString, IsEnum, IsOptional, IsArray } from 'class-validator';
import { Type } from 'class-transformer';
import { Level } from '../../../prisma/generated/client';

export class QueryGrammarDto {
  @IsOptional()
  @IsString()
  lessonId?: string;

  @IsOptional()
  @IsEnum(Level)
  level?: Level;
}
