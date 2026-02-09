import { Injectable } from '@nestjs/common';
import { CreateBookmarkDto } from './dto/create-bookmark.dto';
import { UpdateBookmarkDto } from './dto/update-bookmark.dto';
import { PrismaService } from '../prisma.service';

@Injectable()
export class BookmarkService {
  constructor(private readonly prismaService: PrismaService) {}

  async create(createBookmarkDto: CreateBookmarkDto) {
    try {
      const { userId, vocabularyId, kanjiId, grammarId } = createBookmarkDto;
      const bookmark = await this.prismaService.bookmark.create({
        data: {
          userId,
          vocabularyId,
          kanjiId,
          grammarId,
        },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findAll() {
    try {
      const bookmarks = await this.prismaService.bookmark.findMany();
      return bookmarks;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findOne(id: string) {
    try {
      const bookmark = await this.prismaService.bookmark.findUnique({
        where: {
          id,
        },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async update(id: string, updateBookmarkDto: UpdateBookmarkDto) {
    try {
      const bookmark = await this.prismaService.bookmark.update({
        where: {
          id,
        },
        data: updateBookmarkDto,
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async remove(id: string) {
    try {
      const bookmark = await this.prismaService.bookmark.delete({
        where: {
          id,
        },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
