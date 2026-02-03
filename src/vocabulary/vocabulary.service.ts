import { Injectable, NotFoundException, Query } from '@nestjs/common';
import { PrismaService } from '../prisma/prisma.service';
import { CreateVocabularyDto } from './dto/create-vocabulary.dto';
import { UpdateVocabularyDto } from './dto/update-vocabulary.dto';
import { QueryVocabularyDto } from './dto/query-vocabulary.dto';

@Injectable()
export class VocabularyService {
  constructor(private prismaService: PrismaService) {}

  async create(createVocabularyDto: CreateVocabularyDto) {
    try {
      const { kanjiId, lessonId, ...vocabularyData } = createVocabularyDto;
      return await this.prismaService.vocabulary.create({
        data: {
          ...vocabularyData,
          lesson: {
            connect: { id: lessonId },
          },
          kanjis: {
            connect: { id: kanjiId },
          },
        },
      });
    } catch (error: any) {
      console.log(error);
      throw error;
    }
  }

  async findAll(queryVocabularyDto: QueryVocabularyDto) {
    try {
      return await this.prismaService.vocabulary.findMany({
        orderBy: { createdAt: 'desc' },
        where: {
          lessonId: queryVocabularyDto.lessonId,
          level: queryVocabularyDto.level,
        },
        include: { examples: true },
      });
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async getFlashcards(dto: QueryVocabularyDto & { quantity?: number }) {
    return await this.prismaService.vocabulary.findMany({
      where: { level: dto.level },
      take: dto.quantity !== undefined ? dto.quantity : 10,
    });
  }

  async findByLessonId(lessonId: string) {
    try {
      return await this.prismaService.vocabulary.findMany({
        where: { lessonId: lessonId },
        include: { examples: true },
      });
    } catch (error) {
      throw new NotFoundException(error);
    }
  }

  async findOne(id: string) {
    try {
      return await this.prismaService.vocabulary.findUnique({
        where: { id: id },
        include: { examples: true },
      });
    } catch (error) {
      throw new NotFoundException(error);
    }
  }

  update(id: number, updateVocabularyDto: UpdateVocabularyDto) {
    return `This action updates a #${id} vocabulary`;
  }

  remove(id: number) {
    return `This action removes a #${id} vocabulary`;
  }
}
