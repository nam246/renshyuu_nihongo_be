import { IsString, IsEnum, IsOptional, IsArray } from 'class-validator';
import { Level, WordType } from '../../../prisma/generated/client';

export class CreateVocabularyDto {
  @IsString()
  word!: string;

  @IsString()
  @IsOptional()
  kana?: string; // Thêm field này

  @IsString()
  @IsOptional()
  kanjiId?: string; // Nên xóa @unique trong model nếu nhiều vocab dùng chung kanji

  @IsString()
  @IsOptional()
  romaji?: string;

  @IsString()
  meaning!: string;

  @IsEnum(WordType)
  wordType!: WordType;

  @IsEnum(Level)
  level!: Level;

  @IsString()
  @IsOptional() // Nên là optional vì trong model có onDelete: SetNull
  lessonId?: string;

  @IsArray()
  @IsString({ each: true })
  @IsOptional()
  exampleIds?: string[]; // Đổi thành mảng

  @IsArray()
  @IsString({ each: true })
  @IsOptional()
  mediaIds?: string[]; // Đổi thành mảng, và nên là optional
}
