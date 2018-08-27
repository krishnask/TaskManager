import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ITask } from './Shared/ITask';
import { catchError, map } from 'rxjs/operators';
import { Observable, throwError as observableThrowError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TasksDalService {

  constructor(private http:HttpClient) { }
  taskUrl: string = 'http://localhost:4200/assets/tasks.json';

  public getTasks()
  {
    return this.http.get<ITask[]>(this.taskUrl)
    .pipe(map(data => data), catchError(this.handleError));
  }
  public getTask(taskId:number):Observable<ITask>
  {
    return this.getTasks().pipe(
      map(tasks => tasks.find(task => task.taskId === taskId))
    );
  }
  private handleError(res: HttpErrorResponse | any) {
    console.error(res.error || res.body.error);
    return observableThrowError(res.error || 'Server error');
  }

}
