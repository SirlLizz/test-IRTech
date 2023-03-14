import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-test-label',
  templateUrl: './test-label.component.html',
  styleUrls: ['./test-label.component.css']
})
export class TestLabelComponent {
  @Input() public Title: string = "";
  @Input() public Scale: number = 5;

}
