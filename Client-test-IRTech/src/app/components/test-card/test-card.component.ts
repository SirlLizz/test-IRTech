import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
    selector: 'app-test-card',
    templateUrl: './test-card.component.html',
    styleUrls: ['./test-card.component.css']
})
export class TestCardComponent {
    @Input() public Title: string = "";
    @Output() public onStartTestButtonClick: EventEmitter<string> = new EventEmitter<string>();

    public onStartButtonClick(): void {
        this.onStartTestButtonClick.emit(this.Title);
    }
}
