import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditJeloComponent } from './edit-jelo.component';

describe('EditJeloComponent', () => {
  let component: EditJeloComponent;
  let fixture: ComponentFixture<EditJeloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditJeloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditJeloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
