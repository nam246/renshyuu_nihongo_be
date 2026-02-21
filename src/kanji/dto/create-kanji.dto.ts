import {
  IsString,
  IsEnum,
  IsOptional,
  IsArray,
  IsInt,
  Min,
  ValidateNested,
} from 'class-validator';
import { Level } from '../../../prisma/generated/client';
import { Type } from 'class-transformer';

export class CreateExampleDto {
  @IsString()
  title!: string;

  @IsString()
  description!: string;
}

export class CreateKanjiDto {
  @IsString()
  character!: string; // @unique trong model

  @IsString()
  @IsOptional()
  kana?: string;

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
  @ValidateNested({ each: true })
  @Type(() => CreateExampleDto)
  @IsOptional()
  examples?: CreateExampleDto[];

  @IsArray()
  @IsString({ each: true })
  @IsOptional()
  exampleIds?: string[];
}
