import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicSignalFormComponent } from './dynamic-signal-form.component';

describe('DynamicSignalFormComponent', () => {
  let component: DynamicSignalFormComponent;
  let fixture: ComponentFixture<DynamicSignalFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DynamicSignalFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DynamicSignalFormComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
