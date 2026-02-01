import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInputFloatComponent } from './create-input-float.component';

describe('CreateInputFloatComponent', () => {
  let component: CreateInputFloatComponent;
  let fixture: ComponentFixture<CreateInputFloatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateInputFloatComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInputFloatComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
