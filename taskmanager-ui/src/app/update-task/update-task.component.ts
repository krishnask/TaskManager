import { Component, OnInit } from '@angular/core';
import { ITask } from "../Shared/ITask"

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {
  task: ITask = {
    taskName: "My First Task",
    priority: 2,
    parent: "My Parent",
    startDate: new Date(2018, 8, 2),
    endDate: new Date(8 / 8 / 2018)
  };
  GetDate(date: Date) {

  };
  pad(d) {
    return (d < 10) ? '0' + d.toString() : d.toString();
  }
  GetStartDate() {
    return this.task.startDate.getFullYear() + "-" + this.pad(this.task.startDate.getMonth()) + "-" + this.pad(this.task.startDate.getDate());
  }
  GetEndDate() {
    return this.task.endDate.getFullYear() + "-" + this.pad(this.task.endDate.getMonth()) + "-" + this.pad(this.task.endDate.getDate());
  }
  AddUpdate() {
    console.log("Task Name is");
    console.log(this.task);
    console.log("Method AddUpdate Called....");
  }
  constructor() { }

  ngOnInit() {
  }


}
