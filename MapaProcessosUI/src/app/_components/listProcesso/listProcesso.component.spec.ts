/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListProcessoComponent } from './listProcesso.component';

describe('ListProcessoComponent', () => {
  let component: ListProcessoComponent;
  let fixture: ComponentFixture<ListProcessoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListProcessoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListProcessoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
