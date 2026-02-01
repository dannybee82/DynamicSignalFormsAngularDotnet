import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInputWithOptionsComponent } from './create-input-with-options.component';

describe('CreateInputWithOptionsComponent', () => {
  let component: CreateInputWithOptionsComponent;
  let fixture: ComponentFixture<CreateInputWithOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateInputWithOptionsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInputWithOptionsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
