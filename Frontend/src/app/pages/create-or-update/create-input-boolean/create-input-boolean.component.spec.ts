import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInputBooleanComponent } from './create-input-boolean.component';

describe('CreateInputBooleanComponent', () => {
  let component: CreateInputBooleanComponent;
  let fixture: ComponentFixture<CreateInputBooleanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateInputBooleanComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInputBooleanComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
