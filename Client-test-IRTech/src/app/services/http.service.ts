import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../enviroments/enviroment";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  GetTests(){
    return fetch(environment.SERVER_HOST+'api/Tests',{
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        return data
      });
  }

  GetQuestions(testId:string){
    return fetch(environment.SERVER_HOST+'api/Questions/test/'+testId,{
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        return data
      });
  }
}
