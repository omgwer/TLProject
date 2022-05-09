import { Component, Input, Output, EventEmitter } from '@angular/core';
import { TodoDto } from '../services/item.interface';

export interface Book {
  readonly id: number;
  readonly name: string;
}

@Component({
  selector: 'app-item', // <>  тег с таким именем будет испольозоваться
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css'],
})
export class ItemComponent {
  @Input() todoDto!: TodoDto;
  @Input() isShowOnlyName = false;
  @Output() onDeleteTask: EventEmitter<void> = new EventEmitter<void>();
  @Output() onCloseTask: EventEmitter<void> = new EventEmitter<void>();

  delete(): void {
    this.onDeleteTask.emit();
  }

  close(): void {
    this.onCloseTask.emit();
  }
}
