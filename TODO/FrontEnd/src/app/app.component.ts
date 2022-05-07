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
    this.todoService.GetAll().subscribe((data: TodoDto[]) => this.allTasks = data);
      this.allTasks.forEach(element => {
        if(element.isDone)
        {
          this.closedTasks.push(element);
        } else
        {
          this.tasks.push(element);
        }
      });   
  }
  // TODO
  // переписать нормально методы получения и отправки 
  addTask(myForm: HTMLInputElement) {
    let id = this.tasks.length + 1;
    this.tasks.forEach((task) => {
      id = task.id === id ? ++id : id;
    });
    const newTask: Book = { id, name: myForm.value.trim() };
    this.tasks.push(newTask);
  }

  onDelete(taskId: number): void {
    this.tasks = this.tasks.filter((task) => task.id != taskId);
  }

  onClose(taskId: number): void {
    const newClosedTask: Book | undefined = this.tasks.find(
      (task) => task.id == taskId
    );
    this.tasks = this.tasks.filter((task) => task.id != taskId);
    if (newClosedTask !== undefined) {
      this.closedTasks.push(newClosedTask);
    }
  }
}
