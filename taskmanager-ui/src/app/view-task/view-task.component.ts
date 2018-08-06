import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {

  constructor() { }
  tasks : any[] =
  [
    {
    "taskName": "First Task",
    "parent": "First Parent",
    "priority": 2,
    "StartDate":"March 12 2016",
    "EndDate":"April 15 2018"
    },
    {
      "taskName": "Second Task",
      "parent": "Second Parent",
      "priority": 2,
      "StartDate":"March 13 2016",
      "EndDate":"April 15 2018"
    },
    {
      "taskName": "Third Task",
      "parent": "Third Parent",
      "priority": 2,
      "StartDate":"March 22 2016",
      "EndDate":"April 15 2018"
      }


  ]

  ngOnInit() {
  }

}
