import { Injectable, NotFoundException } from '@nestjs/common';
import { CreateGrammarDto } from './dto/create-grammar.dto';
import { UpdateGrammarDto } from './dto/update-grammar.dto';
import { PrismaService } from '../prisma/prisma.service';
import { Level } from '@prisma/client';
import { QueryGrammarDto } from './dto/query-grammar.dto';

@Injectable()
export class GrammarService {
  constructor(private prismaService: PrismaService) {}

  async create(createGrammarDto: CreateGrammarDto) {
    // const {lessonId,  ...grammarData} = createGrammarDto
    try {
      return await this.prismaService.grammar.create({
        data: {
          ...createGrammarDto,
        },
      });
    } catch (error: any) {
      console.log(error);
      throw error;
    }
  }

  async findAll(queryGrammarDto: QueryGrammarDto) {
    try {
      return this.prismaService.grammar.findMany({
        orderBy: { createdAt: 'desc' },
        where: {
          level: queryGrammarDto.level,
          lessonId: queryGrammarDto.lessonId,
        },
        include: { examples: true },
      });
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findGrammarByLevel(level: string) {
    try {
      const grammar = await this.prismaService.grammar.findMany({
        where: { level: level as Level },
      });
      if (grammar.length < 0) {
        throw new NotFoundException(
          `There are no grammar at this ${level} yet!`,
        );
      }
      return grammar;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findOne(id: string) {
    const grammar = await this.prismaService.grammar.findUnique({
      where: { id },
      include: { examples: true },
    });

    if (!grammar) {
      throw new NotFoundException(`Grammar with ID ${id} not found`);
    }
    return grammar;
  }

  async update(id: string, updateGrammarDto: UpdateGrammarDto) {
    const existingGrammar = await this.prismaService.grammar.findUnique({
      where: { id },
    });

    if (!existingGrammar) {
      throw new NotFoundException(`Grammar with ID ${id} not found`);
    }

    return await this.prismaService.grammar.update({
      where: { id },
      data: updateGrammarDto,
    });
  }

  async remove(id: string) {
    const existingGrammar = await this.prismaService.grammar.findUnique({
      where: { id },
    });

    if (!existingGrammar) {
      throw new NotFoundException(`Grammar with ID ${id} not found`);
    }

    return await this.prismaService.grammar.delete({
      where: { id },
    });
  }
}
