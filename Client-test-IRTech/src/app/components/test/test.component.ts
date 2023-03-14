import {
  Component,
  Input,
  Inject
} from '@angular/core';
import {HttpService} from "../../services/http.service";
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent{
  @Input() testData: {
    id:string;
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
      id:"",
      description:"",
      responceScale:10
    }]
  };
  userName:string = "";

  answers:any = {};

  constructor(private httpService:HttpService, private dialog: MatDialog) {
  }
  onSendButtonClick() {
    if(this.userName!==""){

      if(Object.keys(this.answers).length == this.testData.questions.length){
        let transferObject=[];
        for (let key in this.answers){
          transferObject.push({
            userName: this.userName,
            responce: this.answers[key],
            test: {
              id: this.testData.id
            },
            question: {
              id: key,
              test: {}
            }
          })
        }
        console.log(transferObject)
        this.httpService.SendAnswer(transferObject)
      }else{
        alert("Не на все вопросы дан ответ!")
      }
    }else{
      alert("Введите имя пользователя!")
    }
  }

  onChangedData($event: { id: string; answer: string }) {
    this.answers[$event.id] = $event.answer
  }

  OnInput(value: string) {
    this.userName = value;
  }

  openDialog(): void {
    this.httpService.GetTestStats(this.testData.id).then(stats =>{
      let transferObject = []
      for (let key in stats){
        transferObject.push({
          question: key,
          value: stats[key]
        })
      }
      const dialogRef = this.dialog.open(DialogOverviewStatsTest, {
        data: transferObject,
      });

      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
      });
    })

  }
}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-overview-example-dialog.html',
})
export class DialogOverviewStatsTest {
  constructor(
    public dialogRef: MatDialogRef<DialogOverviewStatsTest>,
    @Inject(MAT_DIALOG_DATA) public data:[{
      question: "",
      value: ""
    }],
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
