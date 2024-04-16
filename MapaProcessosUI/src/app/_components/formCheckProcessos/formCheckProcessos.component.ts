import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Processo } from '../../_models/processo';

@Component({
  selector: 'app-formCheckProcessos',
  templateUrl: './formCheckProcessos.component.html',
  styleUrls: ['./formCheckProcessos.component.css']
})
export class FormCheckProcessosComponent implements OnInit {
  @Input() processo!: Processo
  @Output() selectedProcessoForm = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

  selectProcesso(processoId: string){
    this.selectedProcessoForm.emit(processoId);
  }
}
