import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Jquery} from 'jquery';
import {bootstrap} from 'bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import {APP_INITIALIZER} from '@angular/core';
import {AppConfig} from './app.config';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,HttpModule
  ],
  providers:[AppConfig],
  //  providers: [AppConfig,
  //   { 
  //     provide: APP_INITIALIZER,
  //     useFactory: (config: AppConfig) => () => config.load(), deps: [AppConfig], multi: true
  //   }
  //],
  bootstrap: [AppComponent]
})
export class AppModule { }
