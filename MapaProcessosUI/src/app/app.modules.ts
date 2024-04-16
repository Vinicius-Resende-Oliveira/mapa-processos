import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routes';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { ConfigService } from './_services/configService/config.service';
import { HomeComponent } from './_components/home/home.component';
import { ListProcessoComponent } from './_components/listProcesso/listProcesso.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatTreeModule} from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';
import { FormCheckProcessosComponent } from './_components/formCheckProcessos/formCheckProcessos.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListProcessoComponent,
    FormCheckProcessosComponent
  ],
  imports: [
      BrowserModule,
      AppRoutingModule,
      ReactiveFormsModule,
      FormsModule,
      HttpClientModule,
      CommonModule,
      RouterModule,
      MatTreeModule,
      MatButtonModule, 
      MatIconModule,
      MatCardModule,
      NgxLoadingModule.forRoot({
        animationType: ngxLoadingAnimationTypes.circleSwish
      })
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  providers: [
      ConfigService,
      {
          provide: APP_INITIALIZER,
          useFactory: (configService: ConfigService)=>()=>configService.load(),
          deps: [ConfigService],
          multi: true
      },
      provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }