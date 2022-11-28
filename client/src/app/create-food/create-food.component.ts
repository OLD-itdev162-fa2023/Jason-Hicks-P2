import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-food',
  templateUrl: './create-food.component.html',
  styleUrls: ['./create-food.component.css']
})
export class CreateFoodComponent implements OnInit {
  model: any = {}
  constructor(
    private http: HttpClient,
    private route: Router) { }

  ngOnInit(): void {
  }

  createFood() {
    this.model.date = new Date();
    this.http.post('http://localhost:5163/api/foods', this.model).subscribe(
      response => { this.home() },
      error => { console.log(error) }
    );
  }

  cancel() {
    this.home();
  }

  home() {
    this.route.navigate(["/"]);
  }
}
