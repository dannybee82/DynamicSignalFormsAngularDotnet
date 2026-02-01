import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFormArrayComponent } from './create-form-array.component';

describe('CreateFormArrayComponent', () => {
  let component: CreateFormArrayComponent;
  let fixture: ComponentFixture<CreateFormArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateFormArrayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateFormArrayComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
