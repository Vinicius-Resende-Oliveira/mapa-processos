import { Component, OnInit } from '@angular/core';
import { Processo } from '../../_models/processo';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';
import { SubjectService } from '../../_services/subjectService/Subject.service';
import { ProcessosService } from '../../_services/processos/processos.service';


@Component({
  selector: 'app-listProcesso',
  templateUrl: './listProcesso.component.html',
  styleUrls: ['./listProcesso.component.css']
})
export class ListProcessoComponent implements OnInit {

  processos: Processo[] = [];
  treeControl!: NestedTreeControl<Processo>;
  dataSource = new MatTreeNestedDataSource<Processo>();
  
  constructor(
    readonly processoService: ProcessosService,
    readonly subjectService: SubjectService) { }
  
  ngOnInit(): void {
    this.subjectService.ProcessosSubject.subscribe({
      next: (processos) => {
        if(processos.length > 0){
          this.processos = processos;
          this.dataSource.data = this.processos;
          this.treeControl = new NestedTreeControl<Processo>(node => node.subsProcessosNavigation);
          console.log(this.dataSource);
        }
      }
    })
  }

  hasChild = (_: number, node: Processo) => !!node.subsProcessosNavigation && node.subsProcessosNavigation.length > 0;

  removerProcesso(processo: Processo) {
    console.log(processo);

    if(processo.id){
      this.processoService.removeProcesso(processo.id).subscribe({
        next: (result) => {
          console.log("Item removido", processo);
          window.location.reload()
        },
        error(err) {
          console.warn("Erro ao remover o item: " + processo.id, err)
        },
      });
    }
  }
}