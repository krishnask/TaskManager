import { Component, OnInit } from '@angular/core';
import { ITask } from "../Shared/ITask"

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {
  task: ITask = {
    taskName: "",
    priority: 0,
    parent: "",
    startDate: "",
    endDate: ""
  };
 

  AddUpdate() {
    console.log("Task Name is");
    console.log(this.task);
    console.log("Method AddUpdate Called....");
  }
  constructor() { }

  ngOnInit() {
  }


}
