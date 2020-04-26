import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test2',
  templateUrl: './test2.component.html',
})
export class Test2Component implements OnInit {
  name: string;
  secondName: string;
  dateBirth: Date;
  preResult: string = "";
  result: string = "";
  test: number = 3;
  ResArray: string[]=[];
  
  constructor() { }

  ngOnInit(): void {
    this.preResult = "5";
  }

  Next() {
    this.ResArray.push(this.preResult);
    if (this.ResArray.length == 23) {
      console.log('test');
    }
  }
  Back() {
    this.ResArray.splice(-1, 1)
  }
}
