import { ITask, Task } from "../Shared/ITask"
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TasksDalService } from "../tasks-dal.service";
import { Route } from "../../../node_modules/@angular/compiler/src/core";


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
    taskId:0,
    taskName: "empty",
    priority: 0,
    parent: "",
    startDate: "",
    endDate: ""
  };


  AddUpdate() {
console.log("TODO - call service here to update");
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
