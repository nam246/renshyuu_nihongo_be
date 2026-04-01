import { Test, TestingModule } from '@nestjs/testing';
import { MockTestController } from './mock-test.controller';
import { MockTestService } from './mock-test.service';

describe('MockTestController', () => {
  let controller: MockTestController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MockTestController],
      providers: [MockTestService],
    }).compile();

    controller = module.get<MockTestController>(MockTestController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
