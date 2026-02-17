import { Injectable, BadRequestException } from '@nestjs/common';
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

  async toggle(createBookmarkDto: CreateBookmarkDto) {
    const { userId, vocabularyId, kanjiId, grammarId } = createBookmarkDto;

    // Xác định loại bookmark và where clause
    const whereClause = this.buildWhereClause(
      userId,
      vocabularyId,
      kanjiId,
      grammarId,
    );

    if (!whereClause) {
      throw new BadRequestException(
        'Must provide one of: vocabularyId, kanjiId, or grammarId',
      );
    }

    try {
      const existingBookmark = await this.prismaService.bookmark.findUnique({
        where: whereClause,
      });

      if (existingBookmark) {
        // Xóa bookmark
        await this.prismaService.bookmark.delete({
          where: { id: existingBookmark.id },
        });
        return { isBookmarked: false };
      } else {
        // Tạo bookmark mới
        await this.create(createBookmarkDto);
        return { isBookmarked: true };
      }
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  private buildWhereClause(
    userId: string,
    vocabularyId?: string,
    kanjiId?: string,
    grammarId?: string,
  ) {
    if (vocabularyId) {
      return { userId_vocabularyId: { userId, vocabularyId } };
    }
    if (kanjiId) {
      return { userId_kanjiId: { userId, kanjiId } };
    }
    if (grammarId) {
      return { userId_grammarId: { userId, grammarId } };
    }
    return null;
  }

  async findAllByUserId(userId: string) {
    try {
      const bookmarks = await this.prismaService.bookmark.findMany({
        include: {
          grammar: true,
          vocabulary: true,
          kanji: true,
        },
        where: { userId },
      });
      return bookmarks;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async checkBookmarkStatus(
    userId: string,
    itemId: string,
    itemType: 'vocabulary' | 'grammar' | 'kanji',
  ) {
    const whereClause = this.buildWhereClause(
      userId,
      itemType === 'vocabulary' ? itemId : undefined,
      itemType === 'kanji' ? itemId : undefined,
      itemType === 'grammar' ? itemId : undefined,
    );

    if (!whereClause) return { isBookmarked: false };

    try {
      const bookmark = await this.prismaService.bookmark.findUnique({
        where: whereClause,
      });
      return { isBookmarked: !!bookmark };
    } catch (error) {
      console.log(error);
      return { isBookmarked: false };
    }
  }

  async findBookmarkedVocabulary(userId: string) {
    try {
      const bookmark = await this.prismaService.bookmark.findMany({
        where: { userId },
        include: { vocabulary: true },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findBookmarkedGrammar(userId: string) {
    try {
      const bookmark = await this.prismaService.bookmark.findMany({
        where: { userId },
        include: { grammar: true },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findBookmarkedKanji(userId: string) {
    try {
      const bookmark = await this.prismaService.bookmark.findMany({
        where: { userId },
        include: { kanji: true },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async findOne(id: string) {
    try {
      const bookmark = await this.prismaService.bookmark.findUnique({
        where: { id },
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
        where: { id },
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
        where: { id },
      });
      return bookmark;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
