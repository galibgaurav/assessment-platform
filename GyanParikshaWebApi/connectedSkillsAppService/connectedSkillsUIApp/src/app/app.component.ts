import { Component ,OnInit} from '@angular/core';
import { Options } from 'selenium-webdriver/chrome';
import { Observable } from 'rxjs/Observable';
import {HttpClient} from '@angular/common/http';
import { AppConfig } from './app.config';


@Component({
  selector: 'app-root',
  providers:[AppConfig],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  loginprovider:string [];
  appConfig : AppConfig;
  public configData: Observable<any>;
  constructor(private httpClient:HttpClient, appConfig:AppConfig)
  {
    this.appConfig=appConfig;
  }
  //To-Do
  ngOnInit(){
   this.getLoginProviders();
  }
   getLoginProviders (): void{
    try {
      this.configData=this.appConfig.load();  
      debugger;
      this.configData.subscribe(result=>console.log("hahaha"+result));
    } catch (error) {
      console.log(error);
    }
    
      //console.log("json Data "+this.appConfig.configData);
      // let result : any = this.httpClient.get("http://localhost:8081/api/Account/ExternalLogins?returnUrl=%2F&generateState=true")
      // .subscribe(data=>console.log(data));
     }

  title = 'app';
  //login to the app
  login(providerName:string) : void {
   //this.httpClient.
  }

}
