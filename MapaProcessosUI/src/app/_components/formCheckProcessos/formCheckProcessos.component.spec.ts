/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FormCheckProcessosComponent } from './formCheckProcessos.component';

describe('FormCheckProcessosComponent', () => {
  let component: FormCheckProcessosComponent;
  let fixture: ComponentFixture<FormCheckProcessosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormCheckProcessosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormCheckProcessosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
