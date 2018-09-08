import { Component, OnInit } from '@angular/core';
import { ITask } from '../Shared/ITask';
import { TasksDalService } from '../tasks-dal.service';
import{ITaskFilter} from '../Shared/ITaskFilter';
import { TaskSearchService } from '../task-search.service';
import {Router} from "@angular/router";
import {DatePipe} from '@angular/common';

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
public EndTask(task:ITask):void{
  console.log("EndTask");
  console.log(task);
  task.IsCompleted = true;
  
 this.dal.Save(task).subscribe(response => console.log(response), err => console.log(err));

 this.tasks = this.tasks.filter(t => t.TaskId !== task.TaskId);
}
  ngOnInit() { 
       this.dal.getTasks().subscribe(task => {
         this.tasks = task;
        }
        );
        this.taskFilter = this.tf.taskFilter;
  }
 
  

}
