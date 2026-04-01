import { Injectable } from '@nestjs/common';
import { CreateReadingDto } from './dto/create-reading.dto';
import { UpdateReadingDto } from './dto/update-reading.dto';

@Injectable()
export class ReadingService {
  create(createReadingDto: CreateReadingDto) {
    return 'This action adds a new reading';
  }

  findAll() {
    return `This action returns all reading`;
  }

  findOne(id: string) {
    return `This action returns a #${id} reading`;
  }

  update(id: string, updateReadingDto: UpdateReadingDto) {
    return `This action updates a #${id} reading`;
  }

  remove(id: string) {
    return `This action removes a #${id} reading`;
  }
}
