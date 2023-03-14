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

  GetTestStats(testId:string){
    return fetch(environment.SERVER_HOST+'api/Answers/stats-test/'+testId,{
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        return data
      });
  }

  SendAnswer(answers: { userName: string; responce: number; test: { id: string; }; question: { id: string; test: {}; }; }[]){
    fetch(environment.SERVER_HOST+'api/Answers/',{
      method: "POST",
      body: JSON.stringify(answers),
      headers: {
        "Content-Type": "application/json",
        "Accept": "*/*"
      }
    })
  }
}
