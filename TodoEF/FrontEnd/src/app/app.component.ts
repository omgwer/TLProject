import { Component, OnInit } from '@angular/core';
import { Book } from './item/item.component';
import { TodoDto } from './services/item.interface'; 
import { TodoService } from './services/todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  tasks: TodoDto[] = [];

  closedTasks: TodoDto[] = []; 

  allTasks: TodoDto[] = [];

  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.syncData();
  }

  syncData(): void
  {
    this.todoService.getAll().subscribe((data: TodoDto[]) => 
    {
      this.allTasks = data;
      this.allTasks.forEach(element => {        
        if(element.isDone)
        {
          this.closedTasks.push(element);          
        } else
        {
          this.tasks.push(element);
        }
      });  
    });      
  }
  
  addTask(myForm: HTMLInputElement): void {    
    const newTask: TodoDto = { id: 0, title: myForm.value.trim(), isDone: false };
    this.todoService.createTask(newTask).subscribe(x => this.tasks.push({
      id: x.id,
      title: x.title,
      isDone: x.isDone
    }
    ));
  }

  onDelete(taskId: number): void {      
    this.todoService.deleteTask(taskId).subscribe(()=>{
      this.tasks = this.tasks.filter((task) => task.id != taskId);
    });       
  }

  onClose(taskId: number): void {  
    this.todoService.completeTask(taskId).subscribe(() => {
      const newClosedTask: TodoDto | undefined = this.tasks.find(
        (task) => task.id == taskId
      );
      this.tasks = this.tasks.filter((task) => task.id != taskId);
      if (newClosedTask !== undefined) {
        this.closedTasks.push(newClosedTask);
      }
    });
  }
}
