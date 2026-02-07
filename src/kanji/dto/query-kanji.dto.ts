import { IsEnum, IsOptional, IsString } from 'class-validator';
import { Level } from '@prisma/client';

export class QueryKanjiDto {
  @IsOptional()
  @IsString()
  lessionId?: string;

  @IsOptional()
  @IsEnum(Level)
  level?: Level;
}
