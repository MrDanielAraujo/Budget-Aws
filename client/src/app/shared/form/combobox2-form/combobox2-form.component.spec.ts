import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Combobox2FormComponent } from './combobox2-form.component';

describe('Combobox2FormComponent', () => {
  let component: Combobox2FormComponent;
  let fixture: ComponentFixture<Combobox2FormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [Combobox2FormComponent]
    });
    fixture = TestBed.createComponent(Combobox2FormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
