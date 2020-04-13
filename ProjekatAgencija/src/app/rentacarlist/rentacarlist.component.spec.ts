import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentacarlistComponent } from './rentacarlist.component';

describe('RentacarlistComponent', () => {
  let component: RentacarlistComponent;
  let fixture: ComponentFixture<RentacarlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentacarlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentacarlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
