import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { ITask } from './ITask';

@Pipe({
    name: 'searchFilter'
})
@Injectable()
export class FilterPipe implements PipeTransform {
    transform(items: ITask[], nameSearch: string, parentSearch: string, priorityFromSearch:number, priorityToSearch:number): ITask[] {
        console.log("Inside Transform");
        console.log(nameSearch);
        console.log(parentSearch);
        if (!items) return [];
        return items.filter(items => {
            if(nameSearch && items.taskName.toLocaleLowerCase().indexOf(nameSearch.toLocaleLowerCase()) == -1){
                return false;}
                if(parentSearch && items.parent.toLocaleLowerCase().indexOf(parentSearch.toLocaleLowerCase()) == -1){
                    return false;}
                if(priorityFromSearch && items.priority< priorityFromSearch){
                    return false;}
                if(priorityToSearch && items.priority> priorityToSearch){
                    return false;}
                
            return true;        
        });
    }
}