import { Injectable } from '@angular/core';
import { Config } from '../../_models/config';
import { HttpClient } from '@angular/common/http';
import { SubjectService } from '../subjectService/Subject.service';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  public settings!: Config
  constructor(
    private readonly http: HttpClient,
    private readonly subjectService: SubjectService
    ) { }

  load() {
    return this.http.get<Config>('../assets/settings/appConfig.json').pipe().subscribe({
      next: (result) => {
        console.log("LOAD CONFIG", result);
        this.settings = result
        console.log(this.settings);
        this.subjectService.CarregarConfigSettings(result);
      },
      error: (err) => {
        console.error("ERROR LOAD CONFIG", err)
      },
    })
  }

}
