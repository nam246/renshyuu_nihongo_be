import { IsString, IsEnum, IsOptional, IsArray } from 'class-validator';
import { Level } from '@prisma/client';

export class CreateGrammarDto {
  @IsString()
  pattern!: string; // mẫu ngữ pháp

  @IsString()
  structure!: string; // cấu trúc

  @IsString()
  meaning!: string; // nghĩa

  @IsString()
  @IsOptional()
  explaination?: string; // giải thích chi tiết (lưu ý: nên sửa thành "explanation" trong model)

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
}
