import { Module } from '@nestjs/common';
import { MockTestService } from './mock-test.service';
import { MockTestController } from './mock-test.controller';

@Module({
  controllers: [MockTestController],
  providers: [MockTestService],
})
export class MockTestModule {}
