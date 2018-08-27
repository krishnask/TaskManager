import { ITask, Task } from "../Shared/ITask"
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { TasksDalService } from "../tasks-dal.service";


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

  task1: ITask = {
    taskId:0,
    taskName: "empty",
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

  Cancel() {
    console.log("cancel");
  }
  constructor(   private taskService: TasksDalService,
    private route: ActivatedRoute) {
      console.log("constructor - update task");
      this.task = new Task();
     }

  ngOnInit(): void {
    console.log("ngOnInit - update task");
    this.route.params.forEach((params: Params) => {
      if (params['id'] !== undefined) {
        const id = +params['id'];
        console.log(id);
        this.navigated = true;
         this.taskService.getTask(id).subscribe(task => 
        {
          console.log("asignment");
          this.task = task;
          console.log("Before");
        console.log(this.task);
        console.log("after");
        })
      } else {
        console.log("No id passed");
        this.navigated = false;
       // this.task = new Task();
      }
    });
  }


}
