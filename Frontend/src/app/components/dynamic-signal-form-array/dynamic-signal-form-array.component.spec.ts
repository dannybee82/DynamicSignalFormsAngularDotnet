import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicSignalFormArrayComponent } from './dynamic-signal-form-array.component';

describe('DynamicSignalFormArrayComponent', () => {
  let component: DynamicSignalFormArrayComponent;
  let fixture: ComponentFixture<DynamicSignalFormArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DynamicSignalFormArrayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DynamicSignalFormArrayComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
