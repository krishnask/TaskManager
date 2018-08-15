export interface ITaskFilter
{
    taskName :string;
    parent :string;
    priorityFrom :number;
    priorityTo :number;
    startDate :Date;
    endDate :Date;
}