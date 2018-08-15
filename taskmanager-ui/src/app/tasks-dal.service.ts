import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITask } from './Shared/ITask';


@Injectable({
  providedIn: 'root'
})
export class TasksDalService {

  constructor(private http:HttpClient) { }
  url: string = 'http://localhost:4200/assets/tasks.json';

  public getTasks():Observable<ITask[]>
  {
    return this.http.get<ITask[]>(this.url);
    // TODO - error handle
  }

}
