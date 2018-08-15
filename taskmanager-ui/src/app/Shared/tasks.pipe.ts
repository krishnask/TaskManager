import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { ITask } from './ITask';

@Pipe({
    name: 'searchFilter'
})
@Injectable()
export class FilterPipe implements PipeTransform {
    transform(items: ITask[], nameSearch: string, parentSearch: string, priorityFromSearch:number, priorityToSearch:number, startDateSearch:string, endDateSearch:string): ITask[] {
        console.log("Inside Transform");
        console.log(nameSearch);
        console.log(parentSearch);
        
        if(startDateSearch)
        {
            console.log("Start date search is not empty");
            console.log(startDateSearch);
        }
        else{
            console.log("Empty start date");
        }

        if (!items) return [];
        return items.filter(items => {
            console.log(items);
            console.log(items.taskName);
            if(nameSearch && items.taskName.toLocaleLowerCase().indexOf(nameSearch.toLocaleLowerCase()) == -1){
                return false;}
                if(parentSearch && items.parent.toLocaleLowerCase().indexOf(parentSearch.toLocaleLowerCase()) == -1){
                    return false;}
                if(priorityFromSearch && items.priority< priorityFromSearch){
                    return false;}
                if(priorityToSearch && items.priority> priorityToSearch){
                    return false;}
           
                if(startDateSearch )
                {
                     var filStartDate = new Date(startDateSearch);
                     var startDate = new Date(items.startDate)
                     if(filStartDate.getDay() != startDate.getDay())
                     return false;
                }

                if(endDateSearch )
                {
                     var filEndDate = new Date(endDateSearch);
                     var endDate = new Date(items.endDate)
                     if(filEndDate.getDay() != endDate.getDay())
                     return false;
                }

                   
                
            return true;        
        });
    }
}