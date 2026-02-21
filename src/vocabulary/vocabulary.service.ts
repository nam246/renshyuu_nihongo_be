import { Injectable, NotFoundException, Query } from '@nestjs/common';
import { PrismaService } from '../prisma.service';
import { CreateVocabularyDto } from './dto/create-vocabulary.dto';
import { UpdateVocabularyDto } from './dto/update-vocabulary.dto';
import { QueryVocabularyDto } from './dto/query-vocabulary.dto';

@Injectable()
export class VocabularyService {
  constructor(private prismaService: PrismaService) {}

  async create(createVocabularyDto: CreateVocabularyDto) {
    try {
      const {
        kanjiId,
        lessonId,
        examples,
        exampleIds,
        mediaIds,
        ...vocabularyData
      } = createVocabularyDto;
      return await this.prismaService.vocabulary.create({
        data: {
          ...vocabularyData,
          lesson: lessonId
            ? {
                connect: { id: lessonId },
              }
            : undefined,
          kanjis: kanjiId
            ? {
                create: {
                  kanji: {
                    connect: { id: kanjiId },
                  },
                },
              }
            : undefined,
          examples: {
            create: examples,
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

  async update(id: string, updateVocabularyDto: UpdateVocabularyDto) {
    const existing = await this.prismaService.vocabulary.findUnique({
      where: { id },
    });

    if (!existing) {
      throw new NotFoundException(`Vocabulary with ID ${id} not found`);
    }

    const {
      kanjiId,
      lessonId,
      examples,
      exampleIds,
      mediaIds,
      ...vocabularyData
    } = updateVocabularyDto;

    return await this.prismaService.vocabulary.update({
      where: { id },
      data: {
        ...vocabularyData,
        lesson: lessonId
          ? {
              connect: { id: lessonId },
            }
          : undefined,
        kanjis: kanjiId
          ? {
              upsert: {
                where: {
                  vocabularyId_kanjiId: {
                    vocabularyId: id,
                    kanjiId: kanjiId,
                  },
                },
                create: {
                  kanji: { connect: { id: kanjiId } },
                },
                update: {},
              },
            }
          : undefined,
        examples: examples
          ? {
              deleteMany: {},
              create: examples,
            }
          : undefined,
      },
    });
  }

  async remove(id: string) {
    const existing = await this.prismaService.vocabulary.findUnique({
      where: { id },
    });

    if (!existing) {
      throw new NotFoundException(`Vocabulary with ID ${id} not found`);
    }

    return await this.prismaService.vocabulary.delete({
      where: { id },
    });
  }
}
