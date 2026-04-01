import {
  Controller,
  Get,
  Post,
  Body,
  Patch,
  Param,
  Delete,
  Query,
} from '@nestjs/common';
import { GrammarService } from './grammar.service';
import { CreateGrammarDto } from './dto/create-grammar.dto';
import { UpdateGrammarDto } from './dto/update-grammar.dto';
import { QueryGrammarDto } from './dto/query-grammar.dto';

@Controller('grammar')
export class GrammarController {
  constructor(private readonly grammarService: GrammarService) {}

  @Post()
  create(@Body() createGrammarDto: CreateGrammarDto) {
    return this.grammarService.create(createGrammarDto);
  }

  @Get()
  findAll(@Query() queryGrammarDto: QueryGrammarDto) {
    return this.grammarService.findAll(queryGrammarDto);
  }

  // chắc xóa cái này đi, gộp lại 1 cái Query param trong findAll thôi.
  @Get()
  findGrammarByLevel(@Query() level: string) {
    return this.grammarService.findGrammarByLevel(level);
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.grammarService.findOne(id);
  }

  @Patch(':id')
  update(@Param('id') id: string, @Body() updateGrammarDto: UpdateGrammarDto) {
    return this.grammarService.update(id, updateGrammarDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.grammarService.remove(id);
  }
}
