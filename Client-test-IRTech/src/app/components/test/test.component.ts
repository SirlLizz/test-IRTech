import {AfterViewInit, Component, Input, ViewChild, ViewContainerRef} from '@angular/core';
import {TestCardComponent} from "../test-card/test-card.component";
import {askQuestion} from "@angular/cli/src/utilities/prompt";
import {TestLabelComponent} from "../test-label/test-label.component";

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements AfterViewInit{
  @Input() testData: {
    title: string;
    questions:[];
  } = {
    title: '',
    questions: []
  };
  @ViewChild('container') container: any
  private viewRef: ViewContainerRef;
  constructor() {
    for (let i = 0; i < this.testData.questions.length; i++) {
      console.log(this.testData.questions[i])
      let testLabelComponentRef = this.viewRef.createComponent(TestLabelComponent);
      (<TestLabelComponent >(
        testLabelComponentRef.instance
      )).Title = this.testData.questions[i]
    }
  }
  ngAfterViewInit(){

  }
}
