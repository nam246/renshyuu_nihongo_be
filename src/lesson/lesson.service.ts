import { Injectable, NotFoundException } from '@nestjs/common';
import { CreateLessonDto } from './dto/create-lesson.dto';
import { UpdateLessonDto } from './dto/update-lesson.dto';
import { PrismaService } from '../prisma/prisma.service';
import { Level } from '@prisma/client';

@Injectable()
export class LessonService {
  constructor(private prismaService: PrismaService) {}

  async create(createLessonDto: CreateLessonDto) {
    try {
      return await this.prismaService.lesson.create({
        data: {
          ...createLessonDto,
        },
      });
    } catch (error: any) {
      console.log(error);
      throw error;
    }
  }

  async findAll(level?: string) {
    try {
      return this.prismaService.lesson.findMany({
        orderBy: {},
        where: { level: level?.toUpperCase() as Level },
        include: {
          grammars: true,
          vocabularies: true,
          kanjis: true,
        },
      });
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findOne(id: string) {
    const lesson = await this.prismaService.lesson.findUnique({
      where: { id },
    });

    if (!lesson) {
      throw new NotFoundException(`Lesson with ID ${id} not found`);
    }
    return lesson;
  }

  async update(id: string, updateLessonDto: UpdateLessonDto) {
    const existingLesson = await this.prismaService.lesson.findUnique({
      where: { id },
    });

    if (!existingLesson) {
      throw new NotFoundException(`Lesson with ID ${id} not found`);
    }

    return await this.prismaService.lesson.update({
      where: { id },
      data: updateLessonDto,
    });
  }

  async remove(id: string) {
    const existingLesson = await this.prismaService.lesson.findUnique({
      where: { id },
    });

    if (!existingLesson) {
      throw new NotFoundException(`Lesson with ID ${id} not found`);
    }

    return await this.prismaService.lesson.delete({
      where: { id },
    });
  }
}
