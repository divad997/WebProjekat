import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentacardetailsComponent } from './rentacardetails.component';

describe('RentacardetailsComponent', () => {
  let component: RentacardetailsComponent;
  let fixture: ComponentFixture<RentacardetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentacardetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentacardetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
