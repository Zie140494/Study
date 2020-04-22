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
  preResult: string = "t";
  result: string = "";
  test: number = 3;

  constructor() { }

  ngOnInit(): void {
    this.preResult = "";
  }
  
}
