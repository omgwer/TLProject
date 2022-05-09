import {HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import {Observable} from "rxjs";
import { TodoDto } from "./item.interface";

@Injectable()
export class TodoService {
  private url: string = 'https://localhost:7118/';

  constructor(private http: HttpClient) {
    this.http = http;
  }

  getAll() : Observable<TodoDto[]>{    
    return this.http.get<TodoDto[]>('https://localhost:7118/api/Todo/get-all');
  }

  getTask(taskId: number) : Observable<TodoDto> {
    return this.http.get<TodoDto>(`https://localhost:7118/api/Todo/${taskId}`);
  }

  createTask(newTask: TodoDto): Observable<TodoDto> {
    return this.http.post<TodoDto>('https://localhost:7118/api/Todo/create', newTask);
  }

  completeTask(taskId: number) : Observable<TodoDto> {
    return this.http.put<TodoDto>(`https://localhost:7118/api/Todo/${taskId}/complete`, null);
  }

  deleteTask(taskId: number) : Observable<any> {
    return this.http.delete(`https://localhost:7118/api/Todo/${taskId}/delete`);
  }
}