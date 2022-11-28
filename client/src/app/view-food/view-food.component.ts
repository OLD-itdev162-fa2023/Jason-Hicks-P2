import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-food',
  templateUrl: './view-food.component.html',
  styleUrls: ['./view-food.component.css']
})
export class ViewFoodComponent implements OnInit {
  food: any = {}

  constructor(private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getFood();
  }

  getFood(){
    let id = this.route.snapshot.paramMap.get('id');
    this.http.get(`http://localhost:5163/api/foods/${id}`).subscribe(food => {
      this.food = food;
    }
    );
  }
}
