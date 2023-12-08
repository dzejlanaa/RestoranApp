import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestoranComponent } from './restoran.component';

describe('ReceptiComponent', () => {
  let component: RestoranComponent;
  let fixture: ComponentFixture<RestoranComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestoranComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestoranComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
