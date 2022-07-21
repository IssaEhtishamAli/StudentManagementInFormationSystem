import { TestBed } from '@angular/core/testing';

import { UserregisterService } from './userregister.service';

describe('UserregisterService', () => {
  let service: UserregisterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserregisterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
