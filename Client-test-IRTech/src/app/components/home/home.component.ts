import {Component, ComponentRef, AfterViewInit, ViewChild, ViewContainerRef, EventEmitter} from '@angular/core';
import {TestCardComponent} from "../test-card/test-card.component";
import {HttpService} from "../../services/http.service";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit{

  @ViewChild('container', { read: ViewContainerRef })
  private viewRef: ViewContainerRef;
  constructor(private httpService: HttpService){

  }

  ngAfterViewInit(){
    this.viewRef.clear();

    this.httpService.GetTests().then(tests =>{
      console.log(tests)
      for (let i = 0; i < tests.length; i++) {
        let testCardComponentRef = this.viewRef.createComponent(TestCardComponent);
        (<TestCardComponent >(
          testCardComponentRef.instance
        )).Title = tests[i].name;

        (<TestCardComponent >(
          testCardComponentRef.instance
        )).onStartTestButtonClick.subscribe(()=> {this.startTest(tests[i].name, tests[i].id)})
      }
    })


  }
  public isTestActive: boolean = false;
  public currentTestData: {
      title: string;
      questions:[];
  } = {
      title: '',
      questions: []
  };

  public startTest(testName: string, testId: string) {
      this.isTestActive = true;
    this.httpService.GetQuestions(testId).then(questions =>{
      console.log(questions)
      this.currentTestData = {
        title: 'Test ' + testName,
        questions: questions
      }
    })

  }

}
