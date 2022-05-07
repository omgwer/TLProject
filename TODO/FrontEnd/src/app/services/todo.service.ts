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

  GetAll() : Observable<TodoDto[]>{    
    return this.http.get<TodoDto[]>('https://localhost:7118/api/Todo/get-all');
  }
}
