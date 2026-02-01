import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTextareaComponent } from './create-textarea.component';

describe('CreateTextareaComponent', () => {
  let component: CreateTextareaComponent;
  let fixture: ComponentFixture<CreateTextareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateTextareaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateTextareaComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
