import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-test-label',
  templateUrl: './test-label.component.html',
  styleUrls: ['./test-label.component.css']
})
export class TestLabelComponent {
  @Input() public Id:string = "";
  @Input() public Title: string = "";
  @Input() public Scale: number = 5;
  public TestAnswer: string = "0";
  @Output() InputAnswer = new EventEmitter<{id:string, answer:string}>();

  OnInput(input: string){
    this.TestAnswer = input
    this.InputAnswer.emit({id: this.Id, answer: input})
  }

}
