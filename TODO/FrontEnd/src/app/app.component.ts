import { Component } from '@angular/core';
import { Book } from './item/item.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  tasks: Array<Book> = [
    { id: 1, name: 'GoToShop' },
    { id: 2, name: 'GoToCinema' },
    { id: 3, name: 'GoToSchool' },
  ];

  closedTasks: Array<Book> = [];

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
