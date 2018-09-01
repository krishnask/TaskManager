import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { ITask } from './ITask';

@Pipe({
    name: 'searchFilter'
})
@Injectable()
export class FilterPipe implements PipeTransform {
    transform(items: ITask[], nameSearch: string, ParentTaskNameSearch: string, PriorityFromSearch:number, PriorityToSearch:number, StartDateSearch:string, EndDateSearch:string): ITask[] {
        
        if (!items) return [];
        return items.filter(items => {
            if(nameSearch && items.TaskName.toLocaleLowerCase().indexOf(nameSearch.toLocaleLowerCase()) == -1){
                return false;}
                if(ParentTaskNameSearch && items.ParentTaskName.toLocaleLowerCase().indexOf(ParentTaskNameSearch.toLocaleLowerCase()) == -1){
                    return false;}
                if(PriorityFromSearch && items.Priority< PriorityFromSearch){
                    return false;}
                if(PriorityToSearch && items.Priority> PriorityToSearch){
                    return false;}
           
                if(StartDateSearch )
                {
                     var filStartDate = new Date(StartDateSearch);
                     var StartDate = new Date(items.StartDate)
                     if(filStartDate.getDay() != StartDate.getDay())
                     return false;
                }

                if(EndDateSearch )
                {
                     var filEndDate = new Date(EndDateSearch);
                     var EndDate = new Date(items.EndDate)
                     if(filEndDate.getDay() != EndDate.getDay())
                     return false;
                }

                   
                
            return true;        
        });
    }
}