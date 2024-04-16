import { Component, Input, OnInit } from '@angular/core';
import { ProcessosService } from '../../_services/processos/processos.service';
import { Processo } from '../../_models/processo';
import { SubjectService } from '../../_services/subjectService/Subject.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public loading = false;
  @Input() processos: Processo[] = [];

  processoForm = new FormGroup({
    nome: new FormControl(''),
    descricao: new FormControl(''),
    idProcessoPai: new FormControl('')
  });


  constructor(
    readonly processoService: ProcessosService,
    readonly subjectService: SubjectService) { }

  ngOnInit() {
    this.loading = true;
    this.processoService.GetAllProcessos().subscribe({
      next: (result) => {
        console.log("GetAllProcessos",result);
        this.processos = result; 
        this.subjectService.CarregarProcessos(result);
        this.loading = false;
      },
      error: (err) => {
        console.warn("GetAllProcessos", err)
        this.loading = false;
      }
    })
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.processoForm.value);
    var processoPai: string | null = this.processoForm.controls["idProcessoPai"].value
    if(processoPai === '')
      processoPai = null;

    this.processoService.addProcesso({
      nome: this.processoForm.controls["nome"].value,
      descricao: this.processoForm.controls["descricao"].value,
      idProcessoPai: processoPai,
    }).subscribe({
      next: (result) => {
        console.log(result);
        window.location.reload();
      }
    })
  }

  selectProcesso(processo: string | null) {
    console.log("processo sselcionado", processo);
    
    this.processoForm.patchValue({
      idProcessoPai: processo
    });
  }

}
