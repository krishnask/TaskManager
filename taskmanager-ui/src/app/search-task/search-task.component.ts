import { Component, OnInit } from '@angular/core';
import {ITaskFilter} from '../Shared/ITaskFilter';
import { TaskSearchService } from '../task-search.service';


@Component({
  selector: 'app-search-task',
  templateUrl: './search-task.component.html',
  styleUrls: ['./search-task.component.css']
})
export class SearchTaskComponent implements OnInit {
  
  constructor(private tss:TaskSearchService) {
    this.taskFilter = tss.taskFilter;
   }
  taskFilter:ITaskFilter;
  ngOnInit() {
  }


}
