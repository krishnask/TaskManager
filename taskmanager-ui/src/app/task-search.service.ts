import { Injectable } from '@angular/core';
import{ITaskFilter} from './Shared/ITaskFilter';
@Injectable({
  providedIn: 'root'
})
export class TaskSearchService {

  constructor() { }

  public taskFilter:ITaskFilter =
  {
      "taskName" :"", "parent" :"", "priorityFrom" :null, "priorityTo" :null,"startDate" :  null, 
      "endDate" : null
  }
}
