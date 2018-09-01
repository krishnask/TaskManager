import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ITask } from './Shared/ITask';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError as observableThrowError } from 'rxjs';
import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class TasksDalService {

  constructor(private http:HttpClient) { }
  taskUrl: string = 'assets/tasks.json';

  public getTasks()
  {
    return this.http.get<ITask[]>(environment.getTasksUrl)
    .pipe(map(data => 
      {
        for (let d of data)
        {
          d.StartDate = d.StartDate.substr(0,10);
          d.EndDate = d.EndDate.substr(0,10);
        }
        return data;
      }
     
      ), catchError(this.handleError));
  }
  public getTask(TaskId:number):Observable<ITask>
  {``
    return this.getTasks().pipe(
      map(tasks => tasks.find(task => task.TaskId === TaskId))
    );
  }
  private handleError(res: HttpErrorResponse | any) {
    console.error(res.error || res.body.error);
    return observableThrowError(res.error || 'Server error');
  }

}
