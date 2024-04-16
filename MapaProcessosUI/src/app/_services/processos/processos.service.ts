import { Injectable } from '@angular/core';
import { SubjectService } from '../subjectService/Subject.service';
import { Config } from '../../_models/config';
import { Processo } from '../../_models/processo';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddProcessoRequest } from '../../_models/addProcessoRequest';

@Injectable({
  providedIn: 'root'
})
export class ProcessosService {

  private url: string = "https://localhost:44309/api/Processo";
  constructor(
    readonly subjectService: SubjectService,
    readonly httpClient: HttpClient
    ) 
  { 

    subjectService.ConfigSettingsSubject.subscribe({
      next: (config: Config) => {
        if(config && config.links) {
          this.url = config.links.api + "/Processo"
        }
      }
    })
  }

  GetAllProcessos(): Observable<Processo[]> {
    console.log("GetAllProcessos")
    return this.httpClient.get<Processo[]>(this.url);
  }

  removeProcesso(processoId: string): Observable<any> {
    return this.httpClient.delete(this.url + "/" + processoId);
  }

  addProcesso(processo: AddProcessoRequest): Observable<any> {
    console.log("addProcesso", processo);

    return this.httpClient.post<any>(this.url, processo);
  }
}
