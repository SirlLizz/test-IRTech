import {
  Component
} from '@angular/core';
import {HttpService} from "../../services/http.service";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent{

  public allTests:[{
    id:string,
    name:string
  }]

  constructor(private httpService: HttpService){
    this.restoreTests()
  }

  public isTestActive: boolean = false;
  public currentTestData: {
    id:string,
    title: string;
    questions:[{
      id:string,
      description:string,
      responceScale:number
    }];
  } = {
    id:'',
    title: '',
    questions: [{
      id: "",
      description: "",
      responceScale: 10
    }]
  };

  public restoreTests(){
    this.httpService.GetTests().then(tests =>{
      console.log(tests)
      this.allTests = tests as [{
        id:string,
        name:string
      }]
    })
    console.log(this.allTests)
  }

  public startTest(testName: string, testId: string) {
    this.isTestActive = true;
    this.httpService.GetQuestions(testId).then(questions =>{
      console.log(questions)
      this.currentTestData = {
        id: testId,
        title: 'Тест: "' + testName+'"',
        questions: questions
      }
    })

  }

}
