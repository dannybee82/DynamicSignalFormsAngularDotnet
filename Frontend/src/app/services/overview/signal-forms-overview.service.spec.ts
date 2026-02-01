import { TestBed } from '@angular/core/testing';

import { SignalFormsOverviewService } from './signal-forms-overview.service';

describe('SignalFormsOverviewService', () => {
  let service: SignalFormsOverviewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignalFormsOverviewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
