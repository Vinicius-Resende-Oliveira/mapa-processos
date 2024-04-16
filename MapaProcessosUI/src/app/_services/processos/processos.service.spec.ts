/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProcessosService } from './processos.service';

describe('Service: Processos', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProcessosService]
    });
  });

  it('should ...', inject([ProcessosService], (service: ProcessosService) => {
    expect(service).toBeTruthy();
  }));
});
