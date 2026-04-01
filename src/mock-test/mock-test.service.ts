import { Injectable } from '@nestjs/common';
import { CreateMockTestDto } from './dto/create-mock-test.dto';
import { UpdateMockTestDto } from './dto/update-mock-test.dto';

@Injectable()
export class MockTestService {
  create(createMockTestDto: CreateMockTestDto) {
    return 'This action adds a new mockTest';
  }

  findAll() {
    return `This action returns all mockTest`;
  }

  findOne(id: string) {
    return `This action returns a #${id} mockTest`;
  }

  update(id: string, updateMockTestDto: UpdateMockTestDto) {
    return `This action updates a #${id} mockTest`;
  }

  remove(id: string) {
    return `This action removes a #${id} mockTest`;
  }
}
