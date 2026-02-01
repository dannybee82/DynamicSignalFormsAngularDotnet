import { TestBed } from '@angular/core/testing';

import { FormArraysService } from './form-arrays.service';

describe('FormArraysService', () => {
  let service: FormArraysService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormArraysService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
