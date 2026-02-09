import {
  IsString,
  IsEnum,
  IsOptional,
  IsArray,
  IsInt,
  Min,
} from 'class-validator';
import { Level } from '../../../prisma/generated/client';
import { Type } from 'class-transformer';

export class CreateKanjiDto {
  @IsString()
  character!: string; // @unique trong model

  @IsString()
  kana!: string;

  @IsString()
  @IsOptional()
  onyomi?: string;

  @IsString()
  @IsOptional()
  kunyomi?: string;

  @IsString()
  meaning!: string;

  @IsEnum(Level)
  level!: Level;

  @IsInt()
  @Min(1)
  @IsOptional()
  @Type(() => Number)
  strokeCount?: number;

  @IsString()
  @IsOptional()
  lessonId?: string;

  @IsArray()
  @IsString({ each: true })
  @IsOptional()
  exampleIds?: string[];

  // KHÔNG thêm vocabularyIds vào đây
  // Vì Vocabulary sẽ tự link đến Kanji khi tạo
}
