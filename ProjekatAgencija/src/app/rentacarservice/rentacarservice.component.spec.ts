import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentacarserviceComponent } from './rentacarservice.component';

describe('RentacarserviceComponent', () => {
  let component: RentacarserviceComponent;
  let fixture: ComponentFixture<RentacarserviceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentacarserviceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentacarserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
