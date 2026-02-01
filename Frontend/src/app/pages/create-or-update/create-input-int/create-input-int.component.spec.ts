import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInputIntComponent } from './create-input-int.component';

describe('CreateInputIntComponent', () => {
  let component: CreateInputIntComponent;
  let fixture: ComponentFixture<CreateInputIntComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateInputIntComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInputIntComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
