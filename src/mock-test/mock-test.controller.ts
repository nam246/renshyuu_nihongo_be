import {
  Controller,
  Get,
  Post,
  Body,
  Patch,
  Param,
  Delete,
} from '@nestjs/common';
import { MockTestService } from './mock-test.service';
import { CreateMockTestDto } from './dto/create-mock-test.dto';
import { UpdateMockTestDto } from './dto/update-mock-test.dto';

@Controller('mock-test')
export class MockTestController {
  constructor(private readonly mockTestService: MockTestService) {}

  @Post()
  create(@Body() createMockTestDto: CreateMockTestDto) {
    return this.mockTestService.create(createMockTestDto);
  }

  @Get()
  findAll() {
    return this.mockTestService.findAll();
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.mockTestService.findOne(id);
  }

  @Patch(':id')
  update(
    @Param('id') id: string,
    @Body() updateMockTestDto: UpdateMockTestDto,
  ) {
    return this.mockTestService.update(id, updateMockTestDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.mockTestService.remove(id);
  }
}
