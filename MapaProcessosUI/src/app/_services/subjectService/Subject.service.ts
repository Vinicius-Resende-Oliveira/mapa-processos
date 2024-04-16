import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Config } from '../../_models/config';
import { Processo } from '../../_models/processo';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  private readonly contextConfigSettingsSubject!: BehaviorSubject<Config>;
  public ConfigSettingsSubject!: Observable<Config>;

  private readonly contextProcessosSubject!: BehaviorSubject<Processo[]>;
  public ProcessosSubject!: Observable<Processo[]>;

  constructor() { 
    var config = new Config();
    this.contextConfigSettingsSubject = new BehaviorSubject<Config>(config);
    this.ConfigSettingsSubject = this.contextConfigSettingsSubject.asObservable();

    var processos: Processo[] = [];
    this.contextProcessosSubject = new BehaviorSubject<Processo[]>(processos);
    this.ProcessosSubject = this.contextProcessosSubject.asObservable();
  }

  getConfigSettings(): Config {
    return this.contextConfigSettingsSubject.getValue();
  }

  CarregarConfigSettings(paramsConfigSettings: Config){
    console.log("params", paramsConfigSettings)
    this.contextConfigSettingsSubject.next(paramsConfigSettings);
    return paramsConfigSettings;
  }

  getProcessos(): Processo[] {
    return this.contextProcessosSubject.getValue();
  }

  CarregarProcessos(paramsProcessos: Processo[]){
    console.log("params", paramsProcessos)
    this.contextProcessosSubject.next(paramsProcessos);
    return paramsProcessos;
  }


}
