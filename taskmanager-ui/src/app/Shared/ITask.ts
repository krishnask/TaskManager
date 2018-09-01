import { iterateListLike } from "../../../node_modules/@angular/core/src/change_detection/change_detection_util";

export interface ITask{
    TaskId:number;
    TaskName: string;
    Priority:number;
    ParentTaskName:string;
    StartDate:string;
    EndDate:string;
}
export class Task implements ITask
{
    TaskId:number;
    TaskName: string;
    Priority:number;
    ParentTaskName:string;
    StartDate:string;
    EndDate:string;
}