import {
  Controller,
  Get,
  Post,
  Body,
  Patch,
  Param,
  Delete,
  UseGuards,
} from '@nestjs/common';
import { BookmarkService } from './bookmark.service';
import { CreateBookmarkDto } from './dto/create-bookmark.dto';
import { UpdateBookmarkDto } from './dto/update-bookmark.dto';
import { JwtAuthGuard } from '../auth/guards/jwt-auth.guard';

@Controller('bookmark')
// @UseGuards(JwtAuthGuard)
export class BookmarkController {
  constructor(private readonly bookmarkService: BookmarkService) {}

  @Post()
  create(@Body() createBookmarkDto: CreateBookmarkDto) {
    return this.bookmarkService.create(createBookmarkDto);
  }

  @Post('toggle')
  toggle(@Body() createBookmarkDto: CreateBookmarkDto) {
    return this.bookmarkService.toggle(createBookmarkDto);
  }

  @Get('status/:userId/:itemId/:itemType')
  checkBookmarkStatus(
    @Param('userId') userId: string,
    @Param('itemId') itemId: string,
    @Param('itemType') itemType: 'vocabulary' | 'grammar' | 'kanji',
  ) {
    return this.bookmarkService.checkBookmarkStatus(userId, itemId, itemType);
  }

  @Get(':userId')
  findAllByUserId(@Param('userId') userId: string) {
    return this.bookmarkService.findAllByUserId(userId);
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.bookmarkService.findOne(id);
  }

  @Patch(':id')
  update(
    @Param('id') id: string,
    @Body() updateBookmarkDto: UpdateBookmarkDto,
  ) {
    return this.bookmarkService.update(id, updateBookmarkDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.bookmarkService.remove(id);
  }
}
