import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirdetailsComponent } from './airdetails.component';

describe('AirdetailsComponent', () => {
  let component: AirdetailsComponent;
  let fixture: ComponentFixture<AirdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
