import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleShipmentComponent } from './schedule-shipment.component';

describe('ScheduleShipmentComponent', () => {
  let component: ScheduleShipmentComponent;
  let fixture: ComponentFixture<ScheduleShipmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScheduleShipmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleShipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
