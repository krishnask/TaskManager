import { Injectable } from '@angular/core';
import{ITaskFilter} from './Shared/ITaskFilter';
@Injectable({
  providedIn: 'root'
})
export class TaskSearchService {

  constructor() { }

  public taskFilter:ITaskFilter =
  {
      "TaskName" :"", "ParentTaskName" :"", "PriorityFrom" :null, "PriorityTo" :null,"StartDate" :  "", 
      "EndDate" : null
  }
}
