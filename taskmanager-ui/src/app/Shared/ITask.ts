import { iterateListLike } from "../../../node_modules/@angular/core/src/change_detection/change_detection_util";

export interface ITask{
    taskId:number;
    taskName: string;
    priority:number;
    parent:string;
    startDate:string;
    endDate:string;
}
export class Task implements ITask
{
    taskId:number;
    taskName: string;
    priority:number;
    parent:string;
    startDate:string;
    endDate:string;
}