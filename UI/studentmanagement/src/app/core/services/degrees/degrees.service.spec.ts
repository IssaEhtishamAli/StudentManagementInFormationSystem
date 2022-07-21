import { TestBed } from '@angular/core/testing';

import { DegreesService } from './degrees.service';

describe('DegreesService', () => {
  let service: DegreesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DegreesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
