export interface ITask{
    taskName: string;
    priority:number;
    parent:string;
    startDate:Date;
    endDate:Date;
}