import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  result: string = "";
  preResult: string = "";
  resView = "";
  baseUrl: string;
  name: string;
  secondName: string;
  dateBirth: Date;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl }

  ngOnInit(): void {
    console.log(this.baseUrl);
    }
  setPreResult(i) {
    this.preResult = i.toString();
    //this.result.length
  }
  Next(t) {
    this.result = this.result + this.preResult;
    this.preResult = '';

    if (this.result.length > 3) {
      switch (this.result) {
        case "1111":
          this.resView = "1";
          break;
        case "1112":
          this.resView = "2";
          break;
        case "1121":
          this.resView = "3";
          break;
        case "1122":
          this.resView = "4";
          break;
        case "1211":
          this.resView = "5";
          break;
        case "1212":
          this.resView = "6";
          break;
        case "1221":
          this.resView = "7";
          break;
        case "1222":
          this.resView = "8";
          break;
        case "2111":
          this.resView = "9";
          break;
        case "2112":
          this.resView = "10";
          break;
        case "2121":
          this.resView = "11";
          break;
        case "2122":
          this.resView = "12";
          break;
        case "2211":
          this.resView = "13";
          break;
        case "2212":
          this.resView = "14";
          break;
        case "2221":
          this.resView = "15";
          break;
        case "2222":
          this.resView = "16";
          break;

      }
      //this.resView = this.result;

    }
  }
  back() {
    this.result = this.result.substring(0, this.result.length - 1);
  }
  test() {
    console.log('name', this.name);
    console.log('secondName', this.secondName);
    console.log('dateBirth', this.dateBirth)
    //HttpClient

    var response = prompt("Введите пароль");
    if (response != '1234')
      alert("Пароль не правильный")
    else {
      alert("Пароль правильный")
    }
  }
}
