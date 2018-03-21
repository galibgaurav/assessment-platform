import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import {environment} from '../environments/environment';
import {Http} from '@angular/http';
@Injectable()
export class AppConfig implements OnInit{

    config: Observable<Response>;
    public currentEnvironment :any =null;
    httpClient:HttpClient;
    http:Http;
    configData:any=null;
    private headers: Headers;
    constructor(httpClient: HttpClient,http:Http) {
            this.httpClient=httpClient;
            this.http=http;
    }
    ngOnInit()
    {
       
    }
    
    

    public load():Observable<any> {debugger;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
           return this.http.get("http://localhost:4200/")
            .map(response=> {return response.json();})
            .catch(this.handleError);
        }
        private handleError(error: Response) {
            return Observable.throw(error.statusText);
        }
    }