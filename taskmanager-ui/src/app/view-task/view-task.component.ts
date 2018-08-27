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

  


private tasks:ITask[];
public taskFilter:ITaskFilter;
public EditTask(taskId:number):void{
  const link = '../edit/'+ taskId;
  this.router.navigate([link]);
}
//   mytask: ITask[] = 
//   [
//     {
//         "taskName": "First Task",
//         "parent": "First Parent",
//         "priority": 2,
//         "startDate": new Date("2015-03-25"),
//         "endDate": new Date("2015-03-25")
//     },
//     {
//         "taskName": "Second Task",
//         "parent": "Second Parent",
//         "priority": 5,
//         "startDate": new Date("2015-03-25"),
//         "endDate": new Date("2015-03-25")
//     },
//     {
//         "taskName": "custom one",
//         "parent": "here too a custom",
//         "priority": 20,
//         "startDate": new Date("2015-03-25"),
//         "endDate": new Date("2017-03-17")
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
