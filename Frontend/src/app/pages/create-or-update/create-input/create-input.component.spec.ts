import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInputComponent } from './create-input.component';

describe('CreateInputComponent', () => {
  let component: CreateInputComponent;
  let fixture: ComponentFixture<CreateInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInputComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
