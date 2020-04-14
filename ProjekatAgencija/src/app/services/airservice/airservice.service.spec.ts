import { TestBed } from '@angular/core/testing';

import { AirserviceService } from './airservice.service';

describe('AirserviceService', () => {
  let service: AirserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AirserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
