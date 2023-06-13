/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TittleComponent } from './tittle.component';

describe('TittleComponent', () => {
  let component: TittleComponent;
  let fixture: ComponentFixture<TittleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TittleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TittleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
