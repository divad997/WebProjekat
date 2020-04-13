import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AircompanylistComponent } from './aircompanylist.component';

describe('AircompanylistComponent', () => {
  let component: AircompanylistComponent;
  let fixture: ComponentFixture<AircompanylistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AircompanylistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AircompanylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
