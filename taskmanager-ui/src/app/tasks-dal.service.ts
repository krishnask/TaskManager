import { Injectable } from '@angular/core';
import { HttpClient,  HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ITask, Task } from './Shared/ITask';
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
    console.log("Get Tasks");
    return this.http.get<ITask[]>(environment.tasksUrl)
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
  {
    return this.getTasks().pipe(
      map(tasks => tasks.find(task => task.TaskId === TaskId))
    );
  }
 public Save(task:Task)
 {
   if(task.TaskId)
   {
      return this.Put(task);
   }
   else{
     return this.Post(task);
   }
 }
 private Put(task:Task)
 {
  const httpOptions = {
    headers : new HttpHeaders({
     'Content-Type': 'application/json'
   })
 };

 var body = JSON.stringify(task);
 const url = `${environment.tasksUrl}/${task.TaskId}`;
console.log(url);
console.log(body);
  return this.http
    .put(url, body, httpOptions)
    .pipe(catchError(this.handleError));

 }
 // Add New Task
 private Post(task:Task)
 {
   const httpOptions = {
   headers : new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
  var body = JSON.stringify(task);
  
  return this.http
    .post(environment.tasksUrl, body,httpOptions)
    .pipe(catchError(this.handleError));
 }
  private handleError(res: HttpErrorResponse | any) {
    console.error(res.error || res.body.error);
    return observableThrowError(res.error || 'Server error');
  }

}
