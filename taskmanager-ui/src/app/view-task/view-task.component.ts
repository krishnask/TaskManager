import { Component, OnInit } from '@angular/core';
import { ITask } from '../Shared/ITask';
import { TasksDalService } from '../tasks-dal.service';
import{ITaskFilter} from '../Shared/ITaskFilter';
import { TaskSearchService } from '../task-search.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {

  constructor(private dal:TasksDalService , private tf:TaskSearchService, private router: Router) { }
  //Delete me ASAP

  


public tasks:ITask[];
public taskFilter:ITaskFilter;
public EditTask(TaskId:number):void{
  const link = '../edit/'+ TaskId;
  this.router.navigate([link]);
}
//   mytask: ITask[] = 
//   [
//     {
//         "TaskName": "First Task",
//         "ParentTaskName": "First ParentTaskName",
//         "Priority": 2,
//         "StartDate": new Date("2015-03-25"),
//         "EndDate": new Date("2015-03-25")
//     },
//     {
//         "TaskName": "Second Task",
//         "ParentTaskName": "Second ParentTaskName",
//         "Priority": 5,
//         "StartDate": new Date("2015-03-25"),
//         "EndDate": new Date("2015-03-25")
//     },
//     {
//         "TaskName": "custom one",
//         "ParentTaskName": "here too a custom",
//         "Priority": 20,
//         "StartDate": new Date("2015-03-25"),
//         "EndDate": new Date("2017-03-17")
//     }
// ]

  ngOnInit() { 
       this.dal.getTasks().subscribe(task => {
         this.tasks = task;
        }
        );
        this.taskFilter = this.tf.taskFilter;
  }
 
  

}
