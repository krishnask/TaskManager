import { ITask, Task } from "../Shared/ITask"
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TasksDalService } from "../tasks-dal.service";
import { Route } from "../../../node_modules/@angular/compiler/src/core";
import {DatePipe} from '@angular/common';


@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {
  @Input() task: ITask;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false; // true if navigated here
  buttonCaption:string;
  task1: ITask = {
    TaskId:0,
    TaskName: "empty",
    Priority: 0,
    ParentTaskName: "",
    StartDate: "",
    EndDate: ""
  };


  AddUpdate() {
this.taskService.Save(this.task).subscribe(response => console.log(response), err => console.log(err));
  }

  Cancel() {
    
    if(this.navigated =true)
    {
      const url = '../../view';
      this.router.navigate([url]);
    }
    else{
      const url = '../view';
      this.router.navigate([url]);
    }   
  }
  constructor(   private taskService: TasksDalService,
    private route: ActivatedRoute, private router : Router) {
      this.task = new Task();
     }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['id'] !== undefined) {
        const id = +params['id'];
        this.navigated = true;
        this.buttonCaption = "Update";
         this.taskService.getTask(id).subscribe(task => 
        {
          this.task = task;
        })
      } else {
        this.navigated = false;
        this.buttonCaption = "Add";
      }
    });
  }


}
