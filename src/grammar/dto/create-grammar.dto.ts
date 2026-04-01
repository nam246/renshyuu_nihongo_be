import {
  IsString,
  IsEnum,
  IsOptional,
  IsArray,
  ValidateNested,
} from 'class-validator';
import { Level } from '../../../prisma/generated/client';

import { Type } from 'class-transformer';

class CreateExampleDto {
  @IsString()
  title!: string;

  @IsString()
  description!: string;
}

export class CreateGrammarDto {
  @IsString()
  pattern!: string; // mẫu ngữ pháp

  @IsString()
  structure!: string; // cấu trúc

  @IsString()
  meaning!: string; // nghĩa

  @IsString()
  @IsOptional()
  explanation?: string; // Sửa lỗi chính tả explaination -> explanation

  @IsString()
  @IsOptional()
  notes?: string;

  @IsEnum(Level)
  level!: Level;

  @IsString()
  @IsOptional()
  lessonId?: string; // Optional vì trong model là optional

  @IsArray()
  @IsString({ each: true })
  @IsOptional()
  exampleIds?: string[]; // Mảng vì examples là relation one-to-many

  @IsArray()
  @ValidateNested({ each: true })
  @Type(() => CreateExampleDto)
  @IsOptional()
  examples?: CreateExampleDto[]; // Nested creation
}
